using System.ComponentModel.DataAnnotations;

namespace _01_mvc_crud.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="El nombre de la categoria es obligatorio")]
        [StringLength(80,ErrorMessage ="El nombre no puede exceder los 80 caracteres")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
