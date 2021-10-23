using System;
using MediatR;

namespace Emaritna.Bll.UserApartment.Delete
{
    public class Command : IRequest<bool>
    {
        public long  ID { get;  }

        public Command( long id)
        {
            ID = id;
        }
    }
}