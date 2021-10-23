using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Emaritna.Bll.Announcements.List;
using Emaritna.Bll.Logger;
using Emaritna.Bll.ViewModels.Announcement;
using create = Emaritna.Bll.Announcement.Create;
using edit = Emaritna.Bll.Announcement.Edit;
using delete = Emaritna.Bll.Announcement.Delete;
using getById = Emaritna.Bll.Announcement.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Emaritna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnnouncementController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoggerService<UserApartmentController> _logger;


        public AnnouncementController(IMediator mediator, ILoggerService<UserApartmentController> _logger)
        {
            _mediator = mediator;
            this._logger = _logger;
        }


        #region get all Announcement

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllAnnouncementPaging(byte type, int currentPage = 1, int pageSize = 10)
        {
            try
            {
                var query = new Query(type, currentPage, pageSize);

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogErrorData(e?.Message);
                return BadRequest(e);
            }
        }

        #endregion

        #region get all Announcement

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetById(long Id)
        {
            try
            {
                var query = new getById.Query(Id);

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogErrorData(e?.Message);
                return BadRequest(e);
            }
        }

        #endregion


        #region Add New Announcement

        [HttpPost]
        [Route("creat")]
        public async Task<IActionResult> Create(AnnouncementViewModel dataObj)
        {
            try
            {
                var command = new create.Command(dataObj.Announcement, dataObj.Title,
                    dataObj.AnnouncmentType, dataObj.IsPoster, dataObj.ShowDays, dataObj.ExpirationDate);
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogErrorData(e?.Message);
                return BadRequest(e);
            }
        }

        #endregion


        #region Update Announcement

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Edit(AnnouncementViewModel dataObj)
        {
            try
            {
                var command = new edit.Command(dataObj.ID, dataObj.Announcement, dataObj.Title, dataObj.AnnouncmentType,
                    dataObj.IsPoster,
                    dataObj.ShowDays, dataObj.ExpirationDate);

                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogErrorData(e?.Message);
                return BadRequest(e);
            }
        }

        #endregion


        #region Update Announcement

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(long ID)
        {
            try
            {
                var command = new delete.Command(ID);

                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogErrorData(e?.Message);
                return BadRequest(e);
            }
        }

        #endregion
    }
}