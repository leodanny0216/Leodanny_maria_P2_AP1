using System.ComponentModel.DataAnnotations;

namespace Leodanny_maria_P2_AP1.Models
{
    public class Ciudades
    {
        [Key]
        public int CiudadId { get; set; }

        public string NombreCiudad { get; set; }
        public double Monto { get; set; }

    }

}
