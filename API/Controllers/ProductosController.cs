﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static List<Productos> productosv = new List<Productos> { };
 /*           {
                new Productos {
                    Id = 1,
                    Prod_Nom = "PC",
                    Prod_Desc = "Compu",
                    Cat_Fk = 1
                },
                new Productos {
                    Id = 2,
                    Prod_Nom = "iPhone",
                    Prod_Desc = "Celular",
                    Cat_Fk = 2
                }
            };*/
        //Conexion
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }

        //Leer
        [HttpGet]
        public async Task<ActionResult<List<Productos>>> Get()
        {

            //return Ok(productosv);
            return Ok(await _context.Productos.ToListAsync());
        }
        //Leer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> Get(int id)
        {
            //Id de Productos.cs
            //var producto = productosv.Find(p => p.Id == id);
            var producto =  await _context.Productos.FindAsync(id);
            if (producto == null)
                return BadRequest("Producto no encontrado");
            return Ok(producto);
        }
        //Crear
        [HttpPost]
        public async Task<ActionResult<List<Productos>>> Post([FromBody]Productos producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }
        //Actualizar
        [HttpPut]
        public async Task<ActionResult<List<Productos>>> Update([FromBody] Productos update)
        {

            var dbProducto = await _context.Productos.FindAsync(update.Id);
            if (dbProducto == null)
                return BadRequest("Producto no encontrado");

            dbProducto.Prod_Nom = update.Prod_Nom;
            dbProducto.Prod_Desc = update.Prod_Desc;
            dbProducto.Cat_Fk = update.Cat_Fk;

            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }


        //Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Productos>>> Delete(int id)
        {

            var dbProducto = await _context.Productos.FindAsync(id);
            if (dbProducto == null)
                return BadRequest("Producto no encontrado");

            _context.Productos.Remove(dbProducto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }
    }
}
