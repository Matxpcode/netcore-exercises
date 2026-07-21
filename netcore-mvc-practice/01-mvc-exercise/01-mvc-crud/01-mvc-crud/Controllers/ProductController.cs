using _01_mvc_crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace _01_mvc_crud.Controllers
{
    public class ProductController : Controller
    {
        //1.Creamos el atributo de conexion (unico)
        private readonly string _conexion;

        //2.Constructor para injection dependency el cual implementa a Iconfiguration 
        //que detecta el appsetting.json con su clave "conexion"
        public ProductController(IConfiguration configuration)
        {
            _conexion=configuration.GetConnectionString("conexion");
        }

        //3.Metodo para "listar-products-porNombre"
        private List<Product> getProducts(string nombre)
        {
            List<Product> productos = new List<Product>();

            using (SqlConnection con = new SqlConnection(_conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_list_products_by_name",con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Opcional, si tienes parametros
                    cmd.Parameters.AddWithValue("@ProductName", nombre);
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Product p = new Product
                            {
                                ProductID = dr.GetInt32(0),
                                ProductName = dr.GetString(1),
                                UnitPrice = dr.GetDecimal(2),
                                UnitsInStock = dr.GetInt16(3),
                                CompanyName = dr.GetString(4),
                                CategoryName = dr.GetString(5)
                            };
                            productos.Add(p);
                        }
                    }
                }
            }
            return productos;
        }

        //4.Metodo para "listar-categorias"

        public IActionResult ListProductName(string nombre="")
        { 
            return View(getProducts(nombre));
        }
    }
}
