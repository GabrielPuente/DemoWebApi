using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace TurtlePizzaria.Domain.Entities
{
    /// <summary>
    /// Pizza
    /// </summary>
    public class Pizza : Entity
    {
        /// <summary>
        /// Pizza name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pizza price
        /// </summary>
        public decimal Price { get; set; }


        //EF
        public IEnumerable<PizzaIngredient> PizzaIngredients { get; set; }
        public IEnumerable<PizzaOrder> PizzaOrders { get; set; }


        public ValidationResult Validade()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<Pizza>
        {
            public Validator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Name is required")
                    .MaximumLength(50)
                    .WithMessage("Name maximum of 50 characters");

                RuleFor(x => x.Price)
                    .GreaterThan(0)
                    .WithMessage("Price must be higher than 0");
            }
        }
    }
}
