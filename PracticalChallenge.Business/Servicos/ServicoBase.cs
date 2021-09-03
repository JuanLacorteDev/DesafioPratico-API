using FluentValidation;
using FluentValidation.Results;
using PracticalChallenge.Business.Entidades;
using PracticalChallenge.Business.Interfaces.Notificacoes;
using PracticalChallenge.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalChallenge.Business.Servicos
{
    public abstract class ServicoBase
    {
        private readonly INotificador _notificador;
        public ServicoBase(INotificador notificador)
        {
            _notificador = notificador;
        }

        private void NotificarValidacao(ValidationResult result)
        {
            foreach(var erro in result.Errors){
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Tratar(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validator, TE entidade) where TV : AbstractValidator<TE> where TE: EntidadeBase
        {
            var retorno = validator.Validate(entidade);
            if (retorno.IsValid) return true;

            NotificarValidacao(retorno);

            return false;
        }
    }
}
