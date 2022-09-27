using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiPrueba.Models
{
    public class ProductoProovedor
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        [Required(ErrorMessage ="{0} es requerido")]
        public int ProovedorId { get; set; }
        [JsonIgnore]
        public Producto Producto { get; set; }
        [JsonIgnore]
        public Proovedor Proovedor { get; set; }
    }
}
