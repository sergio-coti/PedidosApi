using PedidosApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApi.Domain.Interfaces.Events
{
    public interface IPedidoCriadoEvent
    {
        Task RealizarPagamento(PedidoCriadoModel model);
    }
}
