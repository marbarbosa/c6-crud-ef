using Escola.Data;
using Escola.Models;
using Escola.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Escola.Controllers
{
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpGet("v1/alunos")]
        public async Task<IActionResult> GetAsync([FromServices] EscolaDataContext context)
        {
            // retorna uma lista de alunos
            try
            {
                var alunos = await context.Alunos.ToListAsync();

                if (alunos == null)
                    return NotFound();

                return Ok(alunos);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "AC0101 - Não possível retornar consulta de alunos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "AC0102 - Falha interna no servidor.");
            }
        }

        [HttpGet("v1/alunos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] EscolaDataContext context)
        {
            // retorna um aluno

            try
            {
                var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

                if (aluno == null)
                    return NotFound();

                return Ok(aluno);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "AC0201 - Não possível retornar consulta de alunos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "AC0202 - Falha interna no servidor.");
            }
        }

        [HttpPost("v1/alunos")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorAlunoViewModel model,
            [FromServices] EscolaDataContext context)
        {
            //Grava um Aluno
            try
            {
                //if (model.RequiresValidationContext == false)
                //    return BadRequest(model);

                var aluno = new Aluno
                {
                    Ra = model.Ra,
                    //DataMatricula = model.DataMatricula;
                    //DataRecisao = model.DataRecisao;
                    //UsuInclusaoId = model.UsuarioId;
                    //DataInclusao = DateTime.Now;
                    //UsuUltAtuId = model.UsuarioId;
                    //DataUltAtu = DateTime.Now;
                };

                if (model == null)
                        return NotFound();

                await context.Alunos.AddAsync(aluno);
                await context.SaveChangesAsync();

                return Created($"v1/alunos/{aluno.Id}", aluno);

            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "AC0301 - Não possível retornar consulta de alunos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "AC0302 - Falha interna no servidor.");
            }
        }

        [HttpPut("v1/alunos/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorAlunoViewModel model,
            [FromServices] EscolaDataContext context)
        {
            // retorna alteração de um aluno
            try
            {
                var aluno = new Aluno
                { 
                    Ra = model.Ra,
                };

                if (model == null) return NotFound();

                //var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

                //if (aluno == null)
                //    return NotFound();

                //aluno.Ra = model.Ra;
                //aluno.DataMatricula = model.DataMatricula;
                //aluno.DataRecisao = model.DataRecisao;
                //aluno.UsuUltAtuId = model.UsuarioId;
                //aluno.DataUltAtu = DateTime.Now;
                //context.Alunos.Update(aluno);
                //await context.SaveChangesAsync();

                //return Ok(aluno);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "AC0401 - Não possível retornar consulta de alunos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "AC0402 - Falha interna no servidor.");
            }
        }

        [HttpDelete("v1/alunos/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] EscolaDataContext context)
        {
            // retorna a exclusão de um aluno
            try
            {
                var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

                if (aluno == null)
                    return NotFound();

                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();

                return Ok(aluno);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "AC0501 - Não possível retornar consulta de alunos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "AC0502 - Falha interna no servidor.");
            }
        }
    }
}
