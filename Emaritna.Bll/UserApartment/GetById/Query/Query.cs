using Emaritna.Bll.ViewModels.UserApartment;
using MediatR;

namespace Emaritna.Bll.UserApartment.GetById
{
     
        public class Query : IRequest<UserApartmentViewModel>
        {
            public int  Id { get; }

            public Query(int id)
            {
                this.Id = id;
            }
        }
    
}