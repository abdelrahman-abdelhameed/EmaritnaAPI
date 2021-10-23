using MediatR;
using System;
using Emaritna.Bll.ViewModels.UserApartment;

namespace Emaritna.Bll.UserApartment.List
{
    public class Query : IRequest<UserApartmentListViewModel>
    {
        public int CurrentPage { get;  }

        public int PageSize { get;  }

        public string  UserId { get; set; }
        
        
        public Query(string userId , int currentPage , int pageSize)
        {
            UserId = userId;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
        }
    }
}