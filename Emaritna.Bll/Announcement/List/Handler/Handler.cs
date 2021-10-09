using MediatR;
using Emaritna.Bll.Announcements.List;
using Emaritna.Bll.ViewModels.Announcement;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.DAL.IUnitOfWork;

namespace Emaritna.Bll.Announcement.List
{
    public class Handler : IRequestHandler<Query , AnnouncementListViewModel >
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<AnnouncementListViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var data = (await _unitOfWork.AnnouncementsRepository.GetWith(filter: a => a.IsActive == true &&
                    a.AnnouncmentType == request.Type && (!a.ExpirationDate.HasValue || a.ExpirationDate >= DateTime.Now)))
                .OrderByDescending(keySelector: a => a.ID).Skip(count: (request.CurrentPage - 1) * request.PageSize).Take(count: request.PageSize).Select(selector: a => new
                    AnnouncementViewModel
                    {
                        Announcement = a.Announcement,
                        AnnouncmentType = a.AnnouncmentType,
                        CreateAt = a.CreateAt,
                        ExpirationDate = a.ExpirationDate,
                        ID = a.ID,
                        IsActive = a.IsActive,
                        IsPoster = a.IsPoster,
                        ShowDays = a.ShowDays,
                        Title = a.Title,
                        AddedDate = a.CreateAt.ToShortDateString()

                    }).ToList();

            var _result = new AnnouncementListViewModel
            { 
                AnnouncementsList = data,
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage,
                Count = (await _unitOfWork.AnnouncementsRepository.GetWith(filter: a => a.IsActive == true &&
                        a.AnnouncmentType == request.Type && (!a.ExpirationDate.HasValue || a.ExpirationDate >= DateTime.Now))).Count(),
                
                
            };
            
            return _result;
        }
    }
}