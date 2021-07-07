using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClientNet.Data;
using ApiClientNet.Http;
using ApiClientNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClientNet.Controllers
{
    [ApiController]
    [Route("")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("clientes")]
        public async Task<BaseResponse<List<Cliente>>> GetClientes([FromServices] DataContext context)
        {
            var clientes = await context.Clientes.ToListAsync();
            return new BaseResponse<List<Cliente>>(clientes);
        }

        [HttpGet]
        [Route("cliente/{id:int}")]
        public async Task<BaseResponse<Cliente>> GetClienteById([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.Include(c => c.Enderecos).FirstOrDefaultAsync(c => c.Id == id);
            return new BaseResponse<Cliente>(cliente);
        }

        [HttpPost]
        [Route("cliente")]
        public async Task<BaseResponse<string>> PostCliente([FromServices] DataContext context, [FromBody] Cliente model)
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
            }
            return new BaseResponse<string>("");
        }

        [HttpPut]
        [Route("cliente/{id:int}")]
        public async Task<BaseResponse<bool>> PutCliente([FromServices] DataContext context, [FromBody] Cliente model, int id)
        {
            if (!ModelState.IsValid)
            {
                return new BaseResponse<bool>(false, false, "Falta coisa aí");
            }
            var cliente = context.Clientes.First(c => c.Id == id);

            if (cliente != null)
            {
                cliente.DataNascimento = model.DataNascimento;
                cliente.Nome = model.Nome;
                cliente.Sexo = model.Sexo;
                await context.SaveChangesAsync();
                return new BaseResponse<bool>(true, true, "Cliente atualizado");
            }

            return new BaseResponse<bool>(false, false, "Cliente não encontrado");
        }

        [HttpDelete]
        [Route("cliente/{id:int}")]
        public async Task<BaseResponse<bool>> DeleteClienteById([FromServices] DataContext context, int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
            }
            return new BaseResponse<bool>(true);
        }

        [HttpPost]
        [Route("endereco/{clienteId:int}")]
        public async Task<BaseResponse<object>> PostEndereco([FromServices] DataContext context, [FromBody] Endereco model, int clienteId)
        {
            if (!ModelState.IsValid)
            {
                return new BaseResponse<object>(new { id = model.Id });
            }
            var cliente = context.Clientes.First(c => c.Id == clienteId);
            if (cliente != null)
            {
                cliente.Enderecos.Add(model);
                await context.SaveChangesAsync();
                return new BaseResponse<object>(new { id = model.Id });
            }
            return new BaseResponse<object>(null, false, "Cliente não encontrado");
        }

        [HttpPut]
        [Route("endereco/{clienteId:int}/{enderecoId:int}")]
        public async Task<BaseResponse<object>> PutEndereco([FromServices] DataContext context, [FromBody] Endereco model, int clienteId, int enderecoId)
        {
            if (!ModelState.IsValid)
            {
                return new BaseResponse<object>(new { id = model.Id });
            }
            var cliente = context.Clientes.First(c => c.Id == clienteId);
            if (cliente != null)
            {
                var endereco = cliente.Enderecos.First(e => e.Id == enderecoId);
                if (endereco != null)
                {
                    endereco.Bairro = model.Bairro;
                    endereco.Cep = model.Cep;
                    endereco.Complemento = model.Complemento;
                    endereco.Logradouro = model.Logradouro;
                    endereco.Numero = model.Numero;
                    endereco.tipo = model.tipo;
                    endereco.UF = model.UF;
                    await context.SaveChangesAsync();
                    return new BaseResponse<object>(new { id = model.Id });
                }
            }
            return new BaseResponse<object>(null, false, "Cliente não encontrado");
        }

        [HttpDelete]
        [Route("endereco/{clienteId:int}/{enderecoId:int}")]
        public async Task<BaseResponse<object>> DeleteEnderecoById([FromServices] DataContext context, int clienteId, int enderecoId)
        {
            var cliente = await context.Clientes.FindAsync(clienteId);
            if (cliente != null)
            {
                var endereco = cliente.Enderecos.First(e => e.Id == enderecoId);
                if (endereco != null)
                {
                    cliente.Enderecos.Remove(endereco);
                    await context.SaveChangesAsync();
                    return new BaseResponse<object>(null);
                }
            }
            return new BaseResponse<object>(null, false, "Cliente não encontrado");
        }
    }

}

