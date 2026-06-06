using ApiDePruebas.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiDePruebas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //Segmento Productos
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Productos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product producto)
        {
            var existing = await _context.Productos.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Nombre = producto.Nombre;
            existing.Precio = producto.Precio;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
    //Segmento Clientes
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }
    }
    //Segmento ventas
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta(VentaDTO dto)
        {
            var producto = await _context.Productos.FindAsync(dto.ProductoId);

            if (producto == null)
                return NotFound("Producto no encontrado");

            if (producto.Stock < dto.Cantidad)
                return BadRequest("No hay suficiente stock");

            producto.Stock -= dto.Cantidad;

            var venta = new Venta
            {
                ProductoId = dto.ProductoId,
                ClienteId = dto.ClienteId,
                Cantidad = dto.Cantidad,
                Fecha = DateTime.UtcNow
            };

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return Ok(venta);
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var ventas = await _context.Ventas.ToListAsync();
            return Ok(ventas);
        }
    }
}