using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace TurtlePizzaria.Domain.Entities
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order : Entity
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Order price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Order comment
        /// </summary>
        public string Comment { get; set; }


        //EF
        public IEnumerable<PizzaOrder> PizzaOrders { get; set; }
        public User User { get; set; }


        public ValidationResult Validade()
        {
            return new Validator().Validate(this);
        }

        public class Validator : AbstractValidator<Order>
        {
            public Validator()
            {
                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .WithMessage("User invalid");

                RuleFor(x => x.Price)
                    .GreaterThan(0)
                    .WithMessage("Price must be higher than 0");

                RuleFor(x => x.Comment)
                    .MaximumLength(255)
                    .WithMessage("Comment maximum of 100 characters");
            }
        }
    }
}
