using Escola.Domain.Commands.UsuarioCommands;
using Escola.Domain.Entities;
using Escola.Domain.Handlers.UsuarioHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Domain.Resources;
using Escola.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Escola.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GenericCommandResult>> Create(
            [FromBody] UsuarioCreateCommand command,
            [FromServices] UsuarioCreateHandler handler)
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
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll(
            [FromServices] IUsuarioRepository<Usuario> repository)
        {
            try
            {
                var Usuarios = await repository.GetAll();
                
                if (Usuarios == null)
                    return Ok(EscolaResource.NaoExistemUsuariosCadastrados);
                
                return Ok(Usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(EscolaResource.FalhaServidor, ex.Message));
            }
        }

        [HttpGet("{UsuarioId}")]
        public async Task<ActionResult<Usuario>> Get(
            int UsuarioId,
            [FromServices] IUsuarioRepository<Usuario> repository)
        {
            try
            {
                var usuario = await repository.Get(UsuarioId);
                
                if (usuario == null)
                    return Ok(EscolaResource.UsuarioNaoExiste);
                
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(EscolaResource.FalhaServidor, ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult<GenericCommandResult>> Update(
            [FromBody] UsuarioUpdateCommand command,
            [FromServices] UsuarioUpdateHandler handler)
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

        [HttpDelete("{UsuarioId}")]
        public async Task<ActionResult<GenericCommandResult>> Delete(
            int UsuarioId,
            [FromServices] UsuarioDeleteHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(UsuarioId);
                
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
