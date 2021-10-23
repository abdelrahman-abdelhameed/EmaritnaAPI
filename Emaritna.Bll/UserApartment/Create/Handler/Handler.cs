using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using  Emaritna.Bll.UserApartment.Create;
using Emaritna.DAL.Entity.Users;
using Emaritna.DAL.IUnitOfWork;

namespace Emaritna.Bll.UserApartment.Create
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
            var userApartment = new UserApartments
            {
                ApartmentNumber = request.ApartmentNumber,
                FloorNumber = request.FloorNumber,
                IsActive = true,
                TowerSection = request.TowerSection,
                UserId = request.UserId,
            };
           await _unitOfWork.UserApartmentsRepository.Add(userApartment);
            _unitOfWork.Save();
            
            return MediatR.Unit.Value;
        }
    }
}