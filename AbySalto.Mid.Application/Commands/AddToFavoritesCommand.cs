using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Application.Commands
{
    public class AddToFavoritesCommand : IRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
