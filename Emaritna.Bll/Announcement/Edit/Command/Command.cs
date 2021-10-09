using System;
using  System.Linq;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using MediatR;

namespace Emaritna.Bll.Announcement.Edit
{
    public class Command : IRequest
    {

        public long  ID { get; set; }
        
        public string Announcement { get;  }

        public string Title { get; }

        public byte AnnouncmentType { get; }

        public bool IsPoster { get;  }

        public Nullable<int> ShowDays { get;  }

        public Nullable<DateTime> ExpirationDate { get; }


        public Command(long id , string announcement , string title , byte announcmentType , 
             bool isPoster , int? showDays , DateTime? expirationDate)
        {
            ID = id;
            Announcement = announcement;
            Title = title;
            AnnouncmentType = announcmentType;
            IsPoster = isPoster;
            ShowDays = showDays;
            ExpirationDate = expirationDate;
        }
    }
}