using  System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.Bll.ViewModels.Announcement;
using Emaritna.DAL.IUnitOfWork;
using MediatR;


namespace Emaritna.Bll.Announcement.GetById
{
    public class Handler : IRequestHandler<Query ,AnnouncementViewModel>
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        public async Task<AnnouncementViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var _data = await _unitOfWork.AnnouncementsRepository.GetById(request.Id);

            return new AnnouncementViewModel
            {
              ID = _data.ID,
              Announcement = _data.Announcement,
              Title = _data.Title,
              CreateAt = _data.CreateAt,
              IsPoster = _data.IsPoster,
              AnnouncmentType = _data.AnnouncmentType,
              ShowDays = _data.ShowDays,
              ExpirationDate = _data.ExpirationDate,
            };
        }
    }
}