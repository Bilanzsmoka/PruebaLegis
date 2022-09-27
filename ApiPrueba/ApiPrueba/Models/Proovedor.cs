using System.ComponentModel.DataAnnotations;

namespace ApiPrueba.Models
{
    public class Proovedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(17, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        [RegularExpression(@"^(\(\+?\d{2,3}\)[\*|\s|\-|\.]?(([\d][\*|\s|\-|\.]?){6})(([\d][\s|\-|\.]?){2})?|(\+?[\d][\s|\-|\.]?){8}(([\d][\s|\-|\.]?){2}(([\d][\s|\-|\.]?){2})?)?)$",
                            ErrorMessage = "Digite un Numero Telefonico"
                            )]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(70, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string  Direccion { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Contacto { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.DateTime)]
        public DateTime FechaEntrega { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        public string FechaEntrega1 { get; set; } = DateTime.Now.ToString("yyyy/mm/dd");

    }
}
