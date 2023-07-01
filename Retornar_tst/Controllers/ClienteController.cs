using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Retornar_tst.Models;
using Retornar_tst.Services;

namespace Retornar_tst.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        [Route("cliente/{email}")]
        public async Task<IActionResult> GetCliente([FromServices] Context context, [FromRoute] string email)
        {
            var cliente = await context
                .Clientes
                .FirstOrDefaultAsync(c => c.Email.Trim() == email.Trim());

            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        [Route("cliente/cadastro")]
        public async Task<IActionResult> PostCliente([FromServices] Context context, [FromBody] Cliente cliente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await context.Clientes.AddAsync(cliente);
                await context.SaveChangesAsync();
                return Created($"cliente/clientes{cliente.Email}", cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("cliente/{email}/sorteio")]
        public async Task<IActionResult> GerarNumeroSorteio([FromServices] Context context, [FromRoute] string email, [FromServices] NumeroSorteioServices numeroSorteioServices)
        {
            // Verifica o email
            var cliente = await context.Clientes.FirstOrDefaultAsync(c => c.Email.Trim() == email.Trim());
            if (cliente == null)
            {
                return NotFound();
            }

            int numero = numeroSorteioServices.GerarNumero();

            var numeroDuplicado = await context.NumerosSorteio.AnyAsync(ns => ns.Numero == numero);

            if (numeroDuplicado)
            {
                do
                {
                    numero = numeroSorteioServices.GerarNumero();
                    numeroDuplicado = await context.NumerosSorteio.AnyAsync(ns => ns.Numero == numero);
                }
                while (numeroDuplicado);
            }

            var numeroSorteio = new NumeroSorteio
            {
                Numero = numero,
                ClienteId = cliente.Id
            };

            await context.NumerosSorteio.AddAsync(numeroSorteio);
            await context.SaveChangesAsync();

            numeroSorteioServices.SalvarNumeroEmArquivo(numero);

            return Ok(numero); 
        }
    }
}
