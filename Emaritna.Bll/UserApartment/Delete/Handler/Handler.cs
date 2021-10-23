using  System;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.DAL.IUnitOfWork;
using MediatR;

namespace Emaritna.Bll.UserApartment.Delete
{
    public class Handler : IRequestHandler<Command , bool>
    {
        
        
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        
        
        public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
        {
            var selectedObject =await _unitOfWork.UserApartmentsRepository.GetById(request.ID);
            if (selectedObject != null)
            {
                selectedObject.IsActive = false;

                await _unitOfWork.UserApartmentsRepository.Update(selectedObject);
                _unitOfWork.Save();

                return true;
            }

            return false;
        }
    }
}