using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VasconezMiguel_Prueba.Models
{
    public class MVasconez
    {
        [Key]
        [Required(ErrorMessage = "La ID es obligatorio")]
        [AllowNull]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        [AllowNull]
        public DateTime Fecha { get; set; }
        public float peso { get; set; }
        public bool Compra {  get; set; }
        public Celular Celular { get; set; }
        [ForeignKey("Celular")]
        public int IdCelular { get; set; }

    }
}
