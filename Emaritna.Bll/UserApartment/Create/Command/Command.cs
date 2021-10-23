using  System;
using MediatR;

namespace Emaritna.Bll.UserApartment.Create
{
    public class Command : IRequest
    {
        public string ApartmentNumber { get;  }

        public byte? TowerSection { get;  }

        public int? FloorNumber { get;  }

        public string UserId { get;  }

        public Command(string apartmentNumber , byte? towerSection , int? floorNumber , string userId)
        {
            this.ApartmentNumber = apartmentNumber;
            this.TowerSection = towerSection;
            this.FloorNumber = floorNumber;
            this.UserId = userId;
        }

    }
}