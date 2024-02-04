using Escola.Data;
using Escola.Extensions;
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

                return Ok(new ResultViewModel<List<Aluno>>(alunos));
            }

            catch
            {
                return StatusCode(500,value: new ResultViewModel<List<Aluno>>(errors: "AC0102 - Falha interna no servidor."));
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
                    return NotFound( new ResultViewModel<Aluno>(errors:"Aluno não encontrado"));

                return Ok(new ResultViewModel<Aluno>(aluno));
            }
            catch
            {
                return StatusCode(500, value: new ResultViewModel<List<Aluno>>(errors: "AC0102 - Falha interna no servidor."));
            }
        }

        [HttpPost("v1/alunos")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorAlunoViewModel model,
            [FromServices] EscolaDataContext context)
        {
            //Grava um Aluno
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);

            try
            {
                if(model is null)
                    return NotFound();

                var pessoa = new Pessoa
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    DataNascimento = model.DataNascimento,
                    Cpf = model.Cpf,
                    Telefone = model.Telefone,
                    UsuInclusaoId = model.UsuarioId,
                    DataInclusao = DateTime.Now,
                    UsuUltAtuId = model.UsuarioId,
                    DataUltAtu = DateTime.Now,
                };
                context.Pessoas.Add(pessoa);
                context.SaveChanges();

                var aluno = new Aluno
                {
                    Ra = model.Ra,
                    DataMatricula = model.DataMatricula,
                    PessoaId = pessoa.Id,
                    UsuInclusaoId = model.UsuarioId,
                    DataInclusao = DateTime.Now,
                    UsuUltAtuId = model.UsuarioId,
                    DataUltAtu = DateTime.Now,

                };
                context.Alunos.Add(aluno);
                context.SaveChanges();

                return Created($"v1/alunos/{aluno.Id}", new ResultViewModel<Aluno>(aluno));


            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("AC0301 - Não possível retornar consulta de alunos."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("AC0302 - Falha interna no servidor."));
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
                if (model == null) return NotFound(new ResultViewModel<Aluno>("Conteúdo não encontrado"));

                var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.Id == id);

                if (aluno == null)
                    return NotFound(new ResultViewModel<Aluno>("Aluno não localizado"));

                var pessoa = await context.Pessoas.FirstOrDefaultAsync(x => x.Id == aluno.PessoaId);

                if (pessoa == null)
                    return NotFound(new ResultViewModel<Aluno>("Aluno não localizado"));

                pessoa.Nome = model.Nome;
                pessoa.Email = model.Email;
                pessoa.DataNascimento = model.DataNascimento;
                pessoa.Cpf = model.Cpf;
                pessoa.Telefone = model.Telefone;
                pessoa.UsuUltAtuId = model.UsuarioId;
                pessoa.DataUltAtu = DateTime.Now;
                
                context.Pessoas.Update(pessoa);
                context.SaveChanges();

                aluno.Ra = model.Ra;
                aluno.DataMatricula = model.DataMatricula;
                aluno.UsuUltAtuId = model.UsuarioId;
                aluno.DataUltAtu = DateTime.Now;
                
                context.Alunos.Update(aluno);
                context.SaveChanges();

                return Ok(new ResultViewModel<Aluno>(aluno));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("AC0401 - Não possível retornar consulta de alunos."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("AC0402 - Falha interna no servidor."));
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
                    return NotFound(new ResultViewModel<Aluno>("Aluno não localizado"));

                context.Alunos.Remove(aluno);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Aluno>(aluno));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("AC0501 - Não possível retornar consulta de alunos."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultViewModel<Aluno>("AC0502 - Falha interna no servidor."));
            }
        }
    }
}
