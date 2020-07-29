using FluentValidation;
using FluentValidation.Results;

namespace Demo.Domain.Entities
{
    /// <summary>
    /// User
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
        
        public ValidationResult UserValidade()
        {
            return new UserValidator().Validate(this);
        }

        public class UserValidator : AbstractValidator<User>
        {
            public UserValidator()
            {
                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("Name is required");

                RuleFor(c => c.Email)
                    .NotEmpty()
                    .WithMessage("Email is required")
                    .EmailAddress()
                    .WithMessage("Email invalid");

                RuleFor(c => c.Password)
                    .NotEmpty()
                    .WithMessage("Password is required");
            }
        }
    }
}
