namespace TransactionApproval.Models;

public abstract class BankEmployee(string name)
{
    public string Name { get; } = name;
    public BankEmployee? NextUpLevel { get; private set; }

    public void SetNextUpLevel(BankEmployee nextUpLevel)
    {
        NextUpLevel = nextUpLevel;
    }

    public void HandleWithdrawRequest(BankAccount account, decimal amount)
    {
        if (CanHandleRequest(account, amount))
        {
            Withdraw(account, amount);
        }
        else
        {
            if (NextUpLevel == null)
            {
                Console.WriteLine($"Not able to handle this withdraw, because {Name}'s next upper level is not set.");
                return;
            }
            NextUpLevel.HandleWithdrawRequest(account, amount);
        }
    }

    protected abstract bool CanHandleRequest(BankAccount account, decimal amount);

    protected abstract void Withdraw(BankAccount account, decimal amount);
}

public class Teller(string name) : BankEmployee(name)
{
    protected override bool CanHandleRequest(BankAccount account, decimal amount)
    {
        return amount <= 10000;
    }

    protected override void Withdraw(BankAccount account, decimal amount)
    {
        Console.WriteLine("Amount withdrawn by Teller");
    }
}

public class Supervisor(string name) : BankEmployee(name)
{
    protected override bool CanHandleRequest(BankAccount account, decimal amount)
    {
        return amount <= 100000;
    }

    protected override void Withdraw(BankAccount account, decimal amount)
    {
        if (!account.IdOnRecord)
        {
            Console.WriteLine("Account holder does not have ID on record. Not able to proceed.");
            return;
        }

        Console.WriteLine("Amount withdrawn by Supervisor");
    }
}

public class BankManager(string name) : BankEmployee(name)
{
    protected override bool CanHandleRequest(BankAccount account, decimal amount)
    {
        return true;
    }

    protected override void Withdraw(BankAccount account, decimal amount)
    {
        Console.WriteLine("Amount withdrawn by Bank Manager");
    }
}