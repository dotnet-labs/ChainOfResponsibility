using UserRegistration.Exceptions;
using UserRegistration.Handlers.UserValidation;

namespace UserRegistration.Models;

public class User(string name, string department, DateTime dateOfBirth)
{
    public string Name { get; } = name;
    public DateTime DateOfBirth { get; } = dateOfBirth;
    public string Department { get; } = department;

    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public bool Register()
    {
        try
        {
            var handler = new AgeValidationHandler();
            handler.SetNext(new NameValidationHandler())
                .SetNext(new DepartmentValidationHandler());
            handler.Handle(this);
        }
        catch (UserValidationException)
        {
            return false;
        }

        return true;
    }
}