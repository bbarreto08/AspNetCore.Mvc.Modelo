using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Business.Interfaces
{
    public interface INotificador
    {
        10:48
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
