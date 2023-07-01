using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Retornar_tst.Models
{
    public class Cliente
    {
        
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "O email fornecido não é válido.")]
        [Required]
        public string Email { get; set; }
        public string Cpf { get; set; }

        public Cliente(string nome, string telefone, string email, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Cpf = cpf;
        }

    }
}
