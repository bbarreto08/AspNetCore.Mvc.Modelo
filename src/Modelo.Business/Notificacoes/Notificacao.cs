﻿using System;
using System.Linq;
using System.Text;

namespace Modelo.Business.Notificacoes
{
    public class Notificacao
    {
        public string Mensagem { get; }
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }        
    }
}
