using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Maximum of 100 characters")]
        public string Name { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Maximum of 100 characters")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Maximum of 100 characters")]
        public string Password { get; set; }
    }
}
