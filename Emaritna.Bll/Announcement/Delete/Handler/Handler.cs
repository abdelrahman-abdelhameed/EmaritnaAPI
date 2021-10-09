using  System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.DAL.IUnitOfWork;
using MediatR;


namespace Emaritna.Bll.Announcement.Delete
{
    public class Handler : IRequestHandler<Command , bool>
    {
        
        
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        
        
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var selectedObject =await _unitOfWork.AnnouncementsRepository.GetById(request.ID);
            if (selectedObject != null)
            {
                selectedObject.IsActive = false;

                await _unitOfWork.AnnouncementsRepository.Update(selectedObject);
                _unitOfWork.Save();

                return true;
            }

            return false;
        }
    }
}