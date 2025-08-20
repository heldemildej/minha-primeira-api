using System.ComponentModel.DataAnnotations;

namespace MinhaPrimeiraAPI.Controllers.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}
