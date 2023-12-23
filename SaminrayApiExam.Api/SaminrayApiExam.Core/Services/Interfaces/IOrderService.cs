using SaminrayApiExam.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaminrayApiExam.Core.Services.Interfaces
{
    public interface IOrderService
    {
        OrderResponseDTO AddOrder(OrderDTO order);
    }
}
