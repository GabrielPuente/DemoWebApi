using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace TurtlePizzaria.Domain.Entities
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
        /// User Cpf
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }


        //EF
        public IEnumerable<Order> Orders { get; set; }


        public ValidationResult Validade()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<User>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name is required")
                    .MaximumLength(100)
                    .WithMessage("Name maximum of 100 characters");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email is required")
                    .EmailAddress()
                    .WithMessage("Email invalid")
                    .MaximumLength(100)
                    .WithMessage("Email maximum of 100 characters");

                RuleFor(x => x.Cpf)
                    .NotEmpty()
                    .WithMessage("Cpf is required")
                    .Custom((campo, context) =>
                    {
                        if (Core.Util.Validate.Cpf(campo))
                            context.AddFailure("Cpf Invalid");
                    });

                RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password is required");
            }
        }
    }
}
