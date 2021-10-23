using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.Bll.ViewModels.UserApartment;
using Emaritna.DAL.IUnitOfWork;
using MediatR;


namespace Emaritna.Bll.UserApartment.GetById
{
    public class Handler : IRequestHandler<Query, UserApartmentViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<UserApartmentViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.UserApartmentsRepository.GetById(request.Id);

            return new UserApartmentViewModel
            {
                ID = data.ID,
                TowerSection = data.TowerSection,
                FloorNumber = data.FloorNumber,
                ApartmentNumber = data.ApartmentNumber,
                UserId = data.UserId
            };
        }
    }
}