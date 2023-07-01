using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Retornar_tst.Models
{
    public class NumeroSorteio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public NumeroSorteio()
        {

        }
    }
}
