using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Emaritna.Bll.ViewModels.Announcement;

namespace Emaritna.Bll.IServices
{
    public interface IAnnouncementServices
    {
         Task<List<AnnouncementViewModel>> GetAnnouncementListPagingByType(byte Type , int currentPage, int pageSize = 10);

         
    }
}