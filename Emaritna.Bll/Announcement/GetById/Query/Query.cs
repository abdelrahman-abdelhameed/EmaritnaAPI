using System;
using Emaritna.Bll.ViewModels.Announcement;
using MediatR;


namespace Emaritna.Bll.Announcement.GetById
{
    public class Query : IRequest<AnnouncementViewModel>
    {
        public long Id { get; }

        public Query(long id)
        {
            this.Id = id;
        }
    }
}