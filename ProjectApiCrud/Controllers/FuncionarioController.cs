using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectApiCrud.Models;
using ProjectApiCrud.Service.FuncionarioService;

namespace ProjectApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            // This is where you would typically retrieve data from a database
            // For now, we will return a simple message
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
            {

            }
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editandoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editandoFuncionario);

            return Ok(serviceResponse);

        }

        [HttpPut("InactiveFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InactiveFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InactiveFuncionario(id);

            return Ok(serviceResponse);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(serviceResponse);
        }
    }
}
