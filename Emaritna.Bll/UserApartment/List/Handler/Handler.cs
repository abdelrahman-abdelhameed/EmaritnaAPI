using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Emaritna.Bll.ViewModels.UserApartment;
using Emaritna.DAL.IUnitOfWork;
using MediatR;

namespace Emaritna.Bll.UserApartment.List
{
    public class Handler : IRequestHandler<Query ,UserApartmentListViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;


        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        
        
        public async Task<UserApartmentListViewModel> Handle(Query request, CancellationToken cancellationToken)
        {
            var _result = new UserApartmentListViewModel();

            _result.Apartments =
                (await _unitOfWork.UserApartmentsRepository.GetWith(a => a.IsActive && a.UserId == request.UserId))
                .OrderByDescending(keySelector: a => a.ID).
                Skip(count: (request.CurrentPage - 1) * request.PageSize).Take(count: request.PageSize).Select(a => new UserApartmentViewModel
                {
                   UserId = a.UserId,
                   ID = a.ID,
                   FloorNumber = a.FloorNumber,
                   TowerSection = a.TowerSection,
                   ApartmentNumber = a.ApartmentNumber
                }).ToList();

            _result.PageSize = request.PageSize;
            _result.CurrentPage = request.CurrentPage;
            _result.Count = (await _unitOfWork.UserApartmentsRepository.GetWith(a => a.IsActive && a.UserId == request.UserId))
                .OrderByDescending(keySelector: a => a.ID).Count();


            return _result;
        }
    }
}