using  System;
using  System.Linq;
using  System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Emaritna.Bll.ViewModels.Announcement;
using MediatR;

namespace Emaritna.Bll.Announcement.Create
{
    public class Command : IRequest
    {
         
        public string Announcement { get;  }

        
        public string Title { get;  }

        
        public byte AnnouncmentType { get;  }

        
        public bool IsPoster { get;  }

        public Nullable<int> ShowDays { get;  }

        public Nullable<DateTime> ExpirationDate { get;  }
        

        public Command(string announcement , string title ,byte announcmentType , bool isPoster , int? showDays , DateTime? expirationDate)
        {
            Announcement = announcement;
            Title = title;
            AnnouncmentType = announcmentType;
            IsPoster = isPoster;
            ShowDays = showDays;
            ExpirationDate = expirationDate;
        }
    }
}