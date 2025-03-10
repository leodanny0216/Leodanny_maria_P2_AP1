using System.ComponentModel.DataAnnotations;

namespace Leodanny_maria_P2_AP1.Models
{
    public class Modelo
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }
    }
}
