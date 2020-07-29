using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Entities
{
    /// <summary>
    /// Entity 
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Id tabela
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// date registrer
        /// </summary>
        public DateTime DateRegister { get; set; }

        /// <summary>
        /// Dado ativo
        /// </summary>
        [Required]
        public bool Active { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
