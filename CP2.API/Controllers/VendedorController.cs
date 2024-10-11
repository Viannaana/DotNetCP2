using CP2.Application.Dtos; // Importa os Data Transfer Objects (DTOs) utilizados
using CP2.Domain.Entities; // Importa as entidades do domínio
using CP2.Domain.Interfaces; // Importa as interfaces do domínio
using CP2.Domain.Interfaces.Dtos; // Importa as interfaces dos DTOs
using Microsoft.AspNetCore.Mvc; // Importa o namespace do ASP.NET Core para controllers
using System.Net; // Importa o namespace para trabalhar com códigos de status HTTP

namespace CP2.API.Controllers
{
    // Define a rota base para as requisições a este controlador
    [Route("api/[controller]")]
    [ApiController] // Indica que esta classe é um controlador de API
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService; // Injeção de dependência do serviço de aplicação

        // Construtor que recebe a instância do serviço de aplicação
        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService; // Inicializa o serviço de aplicação
        }

        // Endpoint para obter todos os vendedores
        [HttpGet]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores(); // Chama o serviço para obter todos os vendedores
            return Ok(objModel); // Retorna os vendedores encontrados
        }

        // Endpoint para obter um vendedor por ID
        [HttpGet("{id}")] // Rota que aceita um ID como parâmetro
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id); // Chama o serviço para obter o vendedor pelo ID
            if (objModel is not null)
                return Ok(objModel); // Retorna o vendedor encontrado
            return NotFound("Vendedor não encontrado"); // Retorna erro 404 se não encontrado
        }

        // Endpoint para criar um novo vendedor
        [HttpPost]
        public IActionResult Post([FromBody] IVendedorDto entity) // Recebe um DTO do corpo da requisição
        {
            try
            {
                _applicationService.SalvarDadosVendedor(entity); // Chama o serviço para salvar o novo vendedor
                return CreatedAtAction(nameof(GetPorId), new { id = entity.Id }, entity); // Retorna o vendedor criado com status 201
            }
            catch (Exception ex) // Captura exceções
            {
                return BadRequest(new { Error = ex.Message }); // Retorna mensagem de erro
            }
        }

        // Endpoint para atualizar um vendedor existente
        [HttpPut("{id}")] // Rota que aceita um ID como parâmetro
        public IActionResult Put(int id, [FromBody] IVendedorDto entity) // Recebe o ID e um DTO do corpo da requisição
        {
            try
            {
                _applicationService.EditarDadosVendedor(id, entity); // Chama o serviço para editar o vendedor
                return NoContent(); // Retorna status 204 se a atualização for bem-sucedida
            }
            catch (Exception ex) // Captura exceções
            {
                return BadRequest(new { Error = ex.Message }); // Retorna mensagem de erro
            }
        }

        // Endpoint para deletar um vendedor pelo ID
        [HttpDelete("{id}")] // Rota que aceita um ID como parâmetro
        public IActionResult Delete(int id)
        {
            try
            {
                _applicationService.DeletarDadosVendedor(id); // Chama o serviço para deletar o vendedor
                return NoContent(); // Retorna status 204 se a deleção for bem-sucedida
            }
            catch (Exception ex) // Captura exceções
            {
                return BadRequest(new { Error = ex.Message }); // Retorna mensagem de erro
            }
        }
    }
}
