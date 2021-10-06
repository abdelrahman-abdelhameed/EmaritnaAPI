using System;
using System.Threading.Tasks;
using Emaritna.Bll.IServices;
using Emaritna.Bll.ViewModels.Announcement;
using Emaritna.DAL.IUnitOfWork;
using System.Linq;
using System.Collections.Generic;
using Emaritna.DAL.Entity.Announcement;

namespace Emaritna.Bll.Services
{
    public class AnnouncementServices //: IAnnouncementServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }



        // public async Task AddNewAnnouncement(AnnouncementViewModel dataObj)
        // {
        //     var announcementData = new Announcements
        //     {
        //         Announcement = dataObj.Announcement,
        //         AnnouncmentType = dataObj.AnnouncmentType,
        //         ExpirationDate = dataObj.ShowDays.HasValue ? DateTime.Now.AddDays((double)dataObj.ShowDays) : dataObj.ExpirationDate,
        //         IsPoster = dataObj.IsPoster,
        //         ShowDays = dataObj.ShowDays,
        //         Title = dataObj.Title,
        //     };
        //
        //     await _unitOfWork.AnnouncementsRepository.Add(announcementData);
        //     _unitOfWork.Save();
        //
        // }




        public async Task DeleteAnnouncement(long id)
        {
            var selectedObject =await _unitOfWork.AnnouncementsRepository.GetById(id);
            if (selectedObject != null)
            {
                selectedObject.IsActive = false;

                await _unitOfWork.AnnouncementsRepository.Update(selectedObject);
                _unitOfWork.Save();
            }
        }



        public async Task EditAnnouncement(AnnouncementViewModel dataObj)
        {
            var selectedObject = await _unitOfWork.AnnouncementsRepository.GetById(dataObj.ID);

            if (selectedObject != null)
            {
                selectedObject.Announcement = dataObj.Announcement;
                selectedObject.AnnouncmentType = dataObj.AnnouncmentType;
                selectedObject.ExpirationDate = dataObj.ShowDays.HasValue ? DateTime.Now.AddDays((double)dataObj.ShowDays) : dataObj.ExpirationDate;
                selectedObject.IsPoster = dataObj.IsPoster;
                selectedObject.ShowDays = dataObj.ShowDays;
                selectedObject.Title = dataObj.Title;

                await _unitOfWork.AnnouncementsRepository.Update(selectedObject);
                _unitOfWork.Save();
            }
        }


        // get list of announcements by type listed as paging

        public async Task<List<AnnouncementViewModel>> GetAnnouncementListPagingByType(byte type, int currentPage, int pageSize)
        {
            var data = (await _unitOfWork.AnnouncementsRepository.GetWith(a => a.IsActive == true && a.AnnouncmentType == type
              && (!a.ExpirationDate.HasValue || a.ExpirationDate >= DateTime.Now)))
                 .OrderByDescending(a => a.ID).Skip((currentPage - 1) * pageSize).Take(pageSize).Select(a => new
                  AnnouncementViewModel
                 {
                     Announcement = a.Announcement,
                     AnnouncmentType = a.AnnouncmentType,
                     CreateAt = a.CreateAt,
                     ExpirationDate = a.ExpirationDate,
                     ID = a.ID,
                     IsActive = a.IsActive,
                     IsPoster = a.IsPoster,
                     ShowDays = a.ShowDays,
                     Title = a.Title

                 }).ToList();

            return data;
        }



    }
}