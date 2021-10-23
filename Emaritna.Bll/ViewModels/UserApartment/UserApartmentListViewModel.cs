using System.Collections.Generic;
using Emaritna.Bll.ViewModels.Base;

namespace Emaritna.Bll.ViewModels.UserApartment
{
    public class UserApartmentListViewModel : PagingDataViewModel
    {
        
        public List<UserApartmentViewModel> Apartments { get; set; }
    }
}