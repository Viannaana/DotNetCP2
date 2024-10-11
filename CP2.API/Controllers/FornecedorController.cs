using CP2.Application.Dtos; // Importa os Data Transfer Objects (DTOs) utilizados
using CP2.Domain.Entities; // Importa as entidades do domínio
using CP2.Domain.Interfaces; // Importa as interfaces do domínio
using Microsoft.AspNetCore.Mvc; // Importa o namespace do ASP.NET Core para controllers
using System.Net; // Importa o namespace para trabalhar com códigos de status HTTP

namespace CP2.API.Controllers
{
    // Define a rota base para as requisições a este controlador
    [Route("api/[controller]")]
    [ApiController] // Indica que esta classe é um controlador de API
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService; // Injeção de dependência do serviço de aplicação

        // Construtor que recebe a instância do serviço de aplicação
        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService; // Inicializa o serviço de aplicação
        }

        // Endpoint para obter todos os fornecedores
        [HttpGet]
        [Produces<IEnumerable<FornecedorEntity>>] // Especifica o tipo de retorno
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores(); // Chama o serviço para obter todos os fornecedores
            return objModel is not null ? Ok(objModel) : BadRequest("Não foi possível obter os dados"); // Retorna o resultado
        }

        // Endpoint para obter um fornecedor por ID
        [HttpGet("{id}")] // Rota que aceita um ID como parâmetro
        [Produces<FornecedorEntity>] // Especifica o tipo de retorno
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorPorId(id); // Chama o serviço para obter o fornecedor pelo ID
            return objModel is not null ? Ok(objModel) : BadRequest("Não foi possível obter os dados"); // Retorna o resultado
        }

        // Endpoint para criar um novo fornecedor
        [HttpPost]
        [Produces<FornecedorEntity>] // Especifica o tipo de retorno
        public IActionResult Post([FromBody] FornecedorDto entity) // Recebe um DTO do corpo da requisição
        {
            try
            {
                var objModel = _applicationService.SalvarDadosFornecedor(entity); // Chama o serviço para salvar o novo fornecedor
                return objModel is not null ? Ok(objModel) : BadRequest("Não foi possível salvar os dados"); // Retorna o resultado
            }
            catch (Exception ex) // Captura exceções
            {
                return BadRequest(new { Error = ex.Message, status = HttpStatusCode.BadRequest }); // Retorna mensagem de erro
            }
        }

        // Endpoint para atualizar um fornecedor existente
        [HttpPut("{id}")] // Rota que aceita um ID como parâmetro
        [Produces<FornecedorEntity>] // Especifica o tipo de retorno
        public IActionResult Put(int id, [FromBody] FornecedorDto entity) // Recebe o ID e um DTO do corpo da requisição
        {
            try
            {
                var objModel = _applicationService.EditarDadosFornecedor(id, entity); // Chama o serviço para editar o fornecedor
                return objModel is not null ? Ok(objModel) : BadRequest("Não foi possível salvar os dados"); // Retorna o resultado
            }
            catch (Exception ex) // Captura exceções
            {
                return BadRequest(new { Error = ex.Message, status = HttpStatusCode.BadRequest }); // Retorna mensagem de erro
            }
        }

        // Endpoint para deletar um fornecedor pelo ID
        [HttpDelete("{id}")] // Rota que aceita um ID como parâmetro
        [Produces<FornecedorEntity>] // Especifica o tipo de retorno
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id); // Chama o serviço para deletar o fornecedor
            return objModel is not null ? Ok(objModel) : BadRequest("Não foi possível deletar os dados"); // Retorna o resultado
        }
    }
}
