using System;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.DAL.IUnitOfWork;
using MediatR;


namespace Emaritna.Bll.UserApartment.Edit
{
    
    public class Handler : IRequestHandler<Command>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var data =await _unitOfWork.UserApartmentsRepository.GetById(request.ID);

            data.ApartmentNumber = request.ApartmentNumber;
            data.FloorNumber = request.FloorNumber;
            data.TowerSection = request.TowerSection;

            await _unitOfWork.UserApartmentsRepository.Update(data);
            _unitOfWork.Save();
            
            return  MediatR.Unit.Value;

        }
    }
}