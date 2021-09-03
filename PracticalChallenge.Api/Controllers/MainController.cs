using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PracticalChallenge.Business.Interfaces.Notificacoes;
using PracticalChallenge.Business.Notificacoes;
using System.Linq;

namespace PracticalChallenge.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected ActionResult CustomResponse(string statusCode)
        {
            var _erros = _notificador.ObterNotificacoes().Select(n => n.Mensagem);
            switch (statusCode) 
            {
                case "404":
                    return NotFound(new { success = false, erros = _erros });
                //case "404":
                //    return NotFound(new { success = false, erros = _erros });
                //case "404":
                //    return NotFound(new { success = false, erros = _erros });
            }
            return BadRequest();

        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                erros = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarModelStateInvelida(modelState);
            return CustomResponse();
        }

        protected bool OperacaoValida()
        {
            return !_notificador.ExisteNotificao();
        }

        protected void NotificarModelStateInvelida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach(var erro in erros)
            {
                var mensagemErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(mensagemErro);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Tratar(new Notificacao(mensagem));
        }

    }
}
