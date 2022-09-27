using System.ComponentModel.DataAnnotations;

namespace ApiPrueba.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(300, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Descripcion { get; set; }
        
    }
}
