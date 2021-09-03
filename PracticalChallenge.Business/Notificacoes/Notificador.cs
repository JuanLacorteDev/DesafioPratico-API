using PracticalChallenge.Business.Interfaces.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalChallenge.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }
        public bool ExisteNotificao()
        {
            return _notificacoes.Any();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public void Tratar(Notificacao notificao)
        {
            _notificacoes.Add(notificao);
        }
    }
}
