using System;
using System.Linq;
using System.Collections.Generic;
using MediatR;
using Emaritna.Bll.ViewModels.Announcement;

namespace Emaritna.Bll.Announcements.List
{
    public class Query : IRequest<AnnouncementListViewModel>
    {
        public byte Type { get;  }

        public int CurrentPage { get;  }

        public int PageSize { get;  }

        public Query(byte type , int currentPage , int pageSize)
        {
            this.Type = type;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
        }
    }
}
