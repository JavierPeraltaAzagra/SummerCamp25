using System.ComponentModel.DataAnnotations;

namespace Examen22_08_25.Entidades
{
    public class GrupoMusica
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        public string Genero { get; set; }
        [Required]
        [Range(1, 100)]
        public int NumeroIntegrantes { get; set; }
        public DateTime FechaFormacion { get; set; }
        public bool Activo { get; set; }

        public GrupoMusica(string nombre, string genero, int numeroIntegrantes ,DateTime fechaFormacion, bool activo)
        {
            Nombre = nombre;
            Genero = genero;
            NumeroIntegrantes = numeroIntegrantes;
            FechaFormacion = fechaFormacion;
            Activo = activo;
        }
        public GrupoMusica() { }
    }
}
