using Emaritna.Bll.ViewModels.Base;
using System;
using System.Collections.Generic;

namespace  Emaritna.Bll.ViewModels.Announcement
{
    public class AnnouncementListViewModel : PagingDataViewModel
    {
         public List<AnnouncementViewModel> AnnouncementsList { get; set; }         
         
    }
}