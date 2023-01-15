using ESH_Gerenciador.ApplicationService;
using ESH_Gerenciador.ApplicationService.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Threading.Tasks;

namespace ESH_Gerenciador.FuncApp.Funcoes
{
    public static class Alunos
    {
        private static IFacade _facade = new Facade();

        [FunctionName("Alunos_Salvar")]
        public static async Task<IActionResult> Salvar([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "alunos/salvar")] HttpRequest req)
        {
            try
            {
                var obj = Helper.ConvertToView<AlunoView>(req.Body);
                await _facade.Alunos.SalvarAsync(obj);
                return new OkObjectResult("Sucesso");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { ex.Message });
            }
        }

        [FunctionName("Alunos_ObterPor")]
        public static async Task<IActionResult> ObterPor([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "alunos/obterPor/{id}")] HttpRequest req, int id)
        {
            try
            {
                var obj = await _facade.Alunos.ObterPorIdAsync(id);
                return new OkObjectResult(obj);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { ex.Message });
            }
        }

        [FunctionName("Alunos_Excluir")]
        public static async Task<IActionResult> Excluir([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "alunos/excluir/{id}")] HttpRequest req, int id)
        {
            try
            {
                await _facade.Alunos.ExcluirAsync(id);
                return new OkObjectResult("Sucesso");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { ex.Message });
            }
        }

        [FunctionName("Alunos_ObterTodos")]
        public static async Task<IActionResult> ObterTodos([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "alunos/obterTodos")] HttpRequest req)
        {
            try
            {
                var obj = await _facade.Alunos.ObterTodosAsync();
                return new OkObjectResult(obj);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { ex.Message });
            }
        }

        [FunctionName("Alunos_Paginado")]
        public static async Task<IActionResult> ObterPaginado([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "alunos/obterTodos/{pageIndex}/{pageSize}")] HttpRequest req, int pageIndex, int pageSize)
        {
            try
            {
                var obj = await _facade.Alunos.ObterPaginadoAsync(pageIndex, pageSize);
                return new OkObjectResult(obj);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new { ex.Message });
            }
        }
    }
}
