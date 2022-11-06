using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static List<Productos> productosv = new List<Productos>
            {
                new Productos {
                    Prod_Id = 1,
                    Prod_Nom = "PC",
                    Prod_Desc = "Compu",
                    Cat_Fk = 1
                },
                new Productos {
                    Prod_Id = 2,
                    Prod_Nom = "iPhone",
                    Prod_Desc = "Celular",
                    Cat_Fk = 2
                }
            };
        //Leer
        [HttpGet]
        public async Task<ActionResult<List<Productos>>> Get()
        {

            return Ok(productosv);
        }
        //Leer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> Get(int id)
        {
            var producto = productosv.Find(p => p.Prod_Id == id);
            if (producto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            return Ok(producto);
        }
        //Crear
        [HttpPost]
        public async Task<ActionResult<List<Productos>>> Post([FromBody]Productos producto)
        {
            productosv.Add(producto);
            return Ok(productosv);
        }
        //Actualizar
        [HttpPut]
        public async Task<ActionResult<List<Productos>>> Update([FromBody] Productos update)
        {
            var producto = productosv.Find(p => p.Prod_Id == update.Prod_Id);
            if (producto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            
            producto.Prod_Nom = update.Prod_Nom;
            producto.Prod_Desc = update.Prod_Desc;
            producto.Cat_Fk = update.Cat_Fk;

            return Ok(productosv);
        }
        //Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Productos>>> Delete(int id)
        {
            var producto = productosv.Find(p => p.Prod_Id == id);
            if (producto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            productosv.Remove(producto);
            return Ok(productosv);
        }
    }
}
