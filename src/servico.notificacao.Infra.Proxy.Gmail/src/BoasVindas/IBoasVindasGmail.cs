using servico.notificacao.Infra.Proxy.Gmail.src.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servico.notificacao.Infra.Proxy.Gmail.src.BoasVindas
{
    public interface IBoasVindasGmail
    {
        Task<bool> Enviar(BoasVindasGmailDto boasVindasGmailDto);
    }
}
