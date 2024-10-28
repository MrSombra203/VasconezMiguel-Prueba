using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace VasconezMiguel_Prueba.Models
{
    public class Celular
    {
        [Key]
        [Required(ErrorMessage = "Es obligatorio ingresar la ID")]
        public int Id { get; set; }
        [MaxLength(100)]
        [DisplayName("Marca")]
        public string Modelo { get; set; }
        public int Año { get; set; }
        [AllowNull]
        public float precio { get; set; }
    }
}
