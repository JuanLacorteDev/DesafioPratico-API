using PracticalChallenge.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalChallenge.Business.Interfaces.Notificacoes
{
    public interface INotificador
    {
        bool ExisteNotificao();
        List<Notificacao> ObterNotificacoes();
        void Tratar(Notificacao notificao);
    }
}
