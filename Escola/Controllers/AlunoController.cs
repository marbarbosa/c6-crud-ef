using Escola.Data;
using Escola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Escola.Controllers
{
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
            [FromBody] Aluno model,
            [FromServices] EscolaDataContext context)
        {
            //Grava um Aluno
            try
            {
                await context.Alunos.AddAsync(model);
                await context.SaveChangesAsync();

                return Created($"v1/alunos/{model.Id}", model);
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
            [FromBody] Aluno model,
            [FromServices] EscolaDataContext context)
        {
            // retorna alteração de um aluno
            var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

            if (aluno == null)
                return NotFound();

            aluno.Pessoa.Nome = model.Pessoa.Nome;
            aluno.Pessoa.Email = model.Pessoa.Email;
            aluno.Pessoa.DataNascimento = model.Pessoa.DataNascimento;
            aluno.Pessoa.Cpf = model.Pessoa.Cpf;
            aluno.Pessoa.DataUltAtu = model.Pessoa.DataUltAtu;
            aluno.Pessoa.UsuUltAtu = model.Pessoa.UsuUltAtu;
            aluno.Ra = model.Ra;
            aluno.DataMatricula = model.DataMatricula;
            aluno.DataUltAtu = model.DataUltAtu;
            aluno.UsuUltAtu = model.UsuUltAtu;
            context.Alunos.Update(aluno);
            await context.SaveChangesAsync();

            return Ok(aluno);
        }

        [HttpDelete("v1/alunos/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] EscolaDataContext context)
        {
            // retorna a exclusão de um aluno
            var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

            if (aluno == null)
                return NotFound();

            context.Alunos.Remove(aluno);
            await context.SaveChangesAsync();

            return Ok(aluno);
        }
    }
}
