using System.ComponentModel.DataAnnotations;

namespace _01_mvc_crud.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage ="El nombre de la compañia es obligatorio")]
        [StringLength(80,ErrorMessage ="El nombre no puede exceder los 80 caracteres")]
        public string CompanyName { get; set; } = string.Empty;
    }
}
