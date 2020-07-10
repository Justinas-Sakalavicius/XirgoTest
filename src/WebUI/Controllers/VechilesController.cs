using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XirgoTest.Application.VechileDetails.Commands.DeleteVechileDetails;
using XirgoTest.Application.Vechiles.CreateVechile;
using XirgoTest.Application.Vechiles.DeleteVechile;
using XirgoTest.Application.Vechiles.Queries.GetVechile;
using XirgoTest.Application.Vechiles.Queries.GetVechileList;
using XirgoTest.Application.Vechiles.UpdateVechile;

namespace XirgoTest.WebUI.Controllers
{
    public class VechilesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<VechilesVm>> Get()
        {
            return await Mediator.Send(new GetVechilesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VechileVm>> GetById(int id)
        {
            return await Mediator.Send(new GetVechileByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVechileCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateVechileCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteVechileCommand { Id = id });
            await Mediator.Send(new DeleteVechileDetailsCommand { VechileId = id });
            return NoContent();
        }
    }
}
