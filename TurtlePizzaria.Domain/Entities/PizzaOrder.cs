using FluentValidation;
using FluentValidation.Results;
using System;

namespace TurtlePizzaria.Domain.Entities
{
    /// <summary>
    /// PizzaOrder
    /// </summary>
    public class PizzaOrder
    {
        /// <summary>
        /// PizzaId
        /// </summary>
        public Guid PizzaId { get; set; }

        /// <summary>
        /// OrderId
        /// </summary>
        public Guid OrderId { get; set; }

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

        public Order Order { get; set; }


        public ValidationResult Validade()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<PizzaOrder>
        {
            public Validator()
            {
                RuleFor(x => x.PizzaId)
                    .NotEmpty()
                    .WithMessage("Pizza Invalid");

                RuleFor(x => x.OrderId)
                    .NotEmpty()
                    .WithMessage("Order Invalid");
            }
        }
    }
}
