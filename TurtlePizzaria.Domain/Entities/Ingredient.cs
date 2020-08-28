using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace TurtlePizzaria.Domain.Entities
{
    /// <summary>
    /// Ingredient
    /// </summary>
    public class Ingredient : Entity
    {
        /// <summary>
        /// Ingredient Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ingredient Price
        /// </summary>
        public decimal Price { get; set; }


        //EF
        public IEnumerable<PizzaIngredient> PizzaIngredients { get; set; }


        public ValidationResult Validade()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<Ingredient>
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
