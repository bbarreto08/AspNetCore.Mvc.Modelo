﻿using Modelo.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Modelo.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> notificacoes;

        public Notificador()
        {
            notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return notificacoes;
        }

        public bool TemNotificacao()
        {
            return notificacoes.Any();
        }
    }
}
