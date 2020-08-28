using FluentValidation;
using FluentValidation.Results;
using System;

namespace TurtlePizzaria.Domain.Entities
{
    /// <summary>
    /// PizzaIngredient
    /// </summary>
    public class PizzaIngredient
    {
        /// <summary>
        /// PizzaId
        /// </summary>
        public Guid PizzaId { get; set; }

        /// <summary>
        /// IngredientId
        /// </summary>
        public Guid IngredientId { get; set; }

        /// <summary>
        /// date registrer
        /// </summary>
        public DateTime DateRegister { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        public bool Active { get; set; }


        //EF
        public Pizza Pizza { get; set; }

        public Ingredient Ingredient { get; set; }


        public ValidationResult Validade()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<PizzaIngredient>
        {
            public Validator()
            {
                RuleFor(x => x.PizzaId)
                    .NotEmpty()
                    .WithMessage("Pizza Invalid");

                RuleFor(x => x.IngredientId)
                    .NotEmpty()
                    .WithMessage("Ingredient Invalid");
            }
        }
    }
}
