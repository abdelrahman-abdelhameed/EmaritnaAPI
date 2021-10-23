using System.Collections.Generic;
using System.Threading.Tasks;
using Emaritna.Bll.ViewModels.UserApartment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using list = Emaritna.Bll.UserApartment.List;
using create = Emaritna.Bll.UserApartment.Create;
using edit = Emaritna.Bll.UserApartment.Edit;
using delete = Emaritna.Bll.UserApartment.Delete;
using getById = Emaritna.Bll.UserApartment.GetById;


namespace Emaritna.API.Controllers
{
    [Authorize]
    public class UserApartmentController : Controller
    {
        private readonly IMediator _mediator;

        public UserApartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region get all

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetListPaging(string UserId, int currentPage = 1, int pageSize = 10)
        {
            var query = new list.Query(UserId, currentPage, pageSize);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        #endregion

        #region get by id

        [HttpGet]
        [Route("get-by-id/{Id}")]
        public async Task<IActionResult> GetByID(int Id)
        {
            var query = new getById.Query(Id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        #endregion

        #region create

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] UserApartmentViewModel dataObj)
        {
            var command = new create.Command(dataObj.ApartmentNumber, dataObj.TowerSection, dataObj.FloorNumber,
                dataObj.UserId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        #endregion

        #region edit

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] UserApartmentViewModel dataObj)
        {
            var command = new edit.Command(dataObj.ID,dataObj.ApartmentNumber, dataObj.TowerSection, dataObj.FloorNumber);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        #endregion


        #region delete 
        [HttpDelete]
        [Route("delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new delete.Command(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        #endregion
        
    }
}