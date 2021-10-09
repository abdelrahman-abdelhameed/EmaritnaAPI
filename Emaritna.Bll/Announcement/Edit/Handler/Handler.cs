using  System;
using  System.Linq;
using  System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.DAL.IUnitOfWork;
using MediatR;

namespace Emaritna.Bll.Announcement.Edit
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
            var selectedObject = await _unitOfWork.AnnouncementsRepository.GetById(request.ID);

            if (selectedObject != null)
            {
                selectedObject.Announcement = request.Announcement;
                selectedObject.AnnouncmentType = request.AnnouncmentType;
                selectedObject.ExpirationDate = request.ShowDays.HasValue ? DateTime.Now.AddDays((double)request.ShowDays) : request.ExpirationDate;
                selectedObject.IsPoster = request.IsPoster;
                selectedObject.ShowDays = request.ShowDays;
                selectedObject.Title = request.Title;

                await _unitOfWork.AnnouncementsRepository.Update(selectedObject);
                _unitOfWork.Save();
            }
            
            return MediatR.Unit.Value;  
        }
    }
}