using System;
using System.ComponentModel.DataAnnotations;

namespace TurtlePizzaria.Domain.Entities
{
    /// <summary>
    /// Entity 
    /// </summary>
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Table id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// date registrer
        /// </summary>
        public DateTime DateRegister { get; set; }

        /// <summary>
        /// Active
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}
