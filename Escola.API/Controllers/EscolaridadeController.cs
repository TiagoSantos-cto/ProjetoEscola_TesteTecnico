using Escola.Domain.Commands.EscolaridadeCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.EscolaridadeHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody] EscolaridadeCreateCommand command,
            [FromServices] EscolaridadeCreateHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(command);
               
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(EscolaResource.FalhaServidor, ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escolaridade>>> GetAll(
            [FromServices] IEscolaridadeRepository<Escolaridade> repository)
        {
            try
            {
                var escolaridades = await repository.GetAll();
                
                if (escolaridades == null)
                    return Ok(EscolaResource.NaoExistemEscolaridadesCadastradas);
                
                return Ok(escolaridades);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(EscolaResource.FalhaServidor, ex.Message));
            }
        }

        [HttpGet("{EscolaridadeId}")]
        public async Task<ActionResult<Escolaridade>> Get( 
            int EscolaridadeId,
            [FromServices] IEscolaridadeRepository<Escolaridade> repository)
        {
            try
            {
                var escolaridade = await repository.Get(EscolaridadeId);
                
                if (escolaridade == null)
                    return Ok(EscolaResource.EscolaridadeNaoEncontrada);
                
                return Ok(escolaridade);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(EscolaResource.FalhaServidor, ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody] EscolaridadeUpdateCommand command,
            [FromServices] EscolaridadeUpdateHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(command);
                
                if (!result.Success)
                    return BadRequest(result);              
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(EscolaResource.FalhaServidor, ex.Message));
            }
        }

        [HttpDelete("{EscolaridadeId}")]
        public async Task<ActionResult<GenericCommandResult>> Delete(
            int EscolaridadeId,
            [FromServices] EscolaridadeDeleteHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(EscolaridadeId);
                
                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(EscolaResource.FalhaServidor, ex.Message));
            }
        }
    }
}
