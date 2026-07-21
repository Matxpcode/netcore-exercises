using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _01_mvc_crud.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(80, ErrorMessage = "Maximo 80 caracteres")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Debe seleccionar un proveedor")]
        [Range(1,int.MaxValue, ErrorMessage ="Proveedor no valido")]
        public int SupplierID { get; set; }

        [Required(ErrorMessage ="Debe seleccionar una categoria")]
        [Range(1,int.MaxValue,ErrorMessage ="Categoria no valida")]
        public int CategoryID { get; set; }

        //Range protege contra precios negativos o cero
        [Required(ErrorMessage ="El precio es obligatorio")]
        [Range(0.01,10000,ErrorMessage ="El precio debe estar entre 0.01 y 10 000")]
        public decimal UnitPrice { get; set; }

        //Range protege contra stock negativo
        [Required(ErrorMessage ="El stock es obligatorio")]
        [Range(0,32767,ErrorMessage ="El stock no puede ser negativo")]
        public int UnitsInStock { get; set; }

        //Propiedades extra
        public string? CompanyName { get; set; }
        public string? CategoryName { get; set; }
    }
}
