using  System;
using  System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Emaritna.Bll.Announcement.Create;
using Emaritna.DAL.IUnitOfWork;

namespace Emaritna.Bll.Announcement.Create
{
    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var announcementData = new DAL.Entity.Announcement.Announcements
            {
                Announcement = request.Announcement,
                AnnouncmentType = request.AnnouncmentType,
                ExpirationDate = request.ShowDays.HasValue
                    ? DateTime.Now.AddDays((double) request.ShowDays)
                    : (DateTime?) null,
                IsPoster = request.IsPoster,
                ShowDays = request.ShowDays,
                Title = request.Title,
                IsActive = true,
            };

            await _unitOfWork.AnnouncementsRepository.Add(announcementData);
            _unitOfWork.Save();

            return MediatR.Unit.Value;
        }
    }
}