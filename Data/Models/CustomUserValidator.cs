//using JobSite.Data.Interfaces;
//using Microsoft.AspNetCore.Identity;

//namespace JobSite.Data.Models
//{
//    public class CustomUserValidator : UserValidator<User>
//    {
//        public override Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
//        {
//            List<IdentityError> errors = new List<IdentityError>();

//            if (user.Email.ToLower().EndsWith("@spam.com"))
//            {
//                errors.Add(new IdentityError
//                {
//                    Description = "Данный домен находится в спам-базе. Выберите другой почтовый сервис"
//                });
//            }
//            if (user.UserName.Contains("admin"))
//            {
//                errors.Add(new IdentityError
//                {
//                    Description = "Ник пользователя не должен содержать слово 'admin'"
//                });
//            }
//            return Task.FromResult(errors.Count == 0 ?
//                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
//        }
//    }
//}
