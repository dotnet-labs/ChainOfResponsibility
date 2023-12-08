using TransactionApproval.Models;

var bankManager = new BankManager("Bob");
var bankSupervisor = new Supervisor("Smith");
bankSupervisor.SetNextUpLevel(bankManager);
var frontLineStaff = new Teller("Taylor");
frontLineStaff.SetNextUpLevel(bankSupervisor);

var account = new BankAccount();
account.WithdrawMoney(frontLineStaff, 5000);
account.WithdrawMoney(frontLineStaff, 50000);
account.WithdrawMoney(frontLineStaff, 500000);

var teller2 = new Teller("Tim");
account.WithdrawMoney(teller2, 50000);

//--Console Output--
//Amount withdrawn by Teller
//Account holder does not have ID on record. Not able to proceed.
//Amount withdrawn by Bank Manager
//Not able to handle this withdraw, because Tim's next upper level is not set.