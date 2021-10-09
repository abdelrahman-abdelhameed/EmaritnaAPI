using  System;
using MediatR;


namespace Emaritna.Bll.Announcement.Delete
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