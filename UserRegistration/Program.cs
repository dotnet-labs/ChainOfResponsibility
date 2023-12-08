using UserRegistration.Models;

var user = new User("First Last", "SE", new DateTime(1987, 01, 29));

var result = user.Register();

Console.WriteLine(result);

//--Console Output--
//[AgeValidationHandler] is handling [User]
//[NameValidationHandler] is handling [User]
//[DepartmentValidationHandler] is handling [User]
//True
