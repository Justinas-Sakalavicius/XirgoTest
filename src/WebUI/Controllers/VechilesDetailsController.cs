using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XirgoTest.Application.VechileDetails.Commands.CreateVechileDetails;
using XirgoTest.Application.VechileDetails.Commands.DeleteVechileDetails;
using XirgoTest.Application.VechileDetails.Commands.UpdateVechileDetails;
using XirgoTest.Application.VechileDetails.Queries.GetVechileDetails;

namespace XirgoTest.WebUI.Controllers
{
    public class VechilesDetailsController : ApiController
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<VechileDetailsVm>> GetByVechileId(int id)
        {
            return await Mediator.Send(new GetVechileDetailsQuery { VechileId = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateVechileDetailsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateVechileDetailsCommand command)
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
            await Mediator.Send(new DeleteVechileDetailsCommand { VechileId = id });

            return NoContent();
        }

    }
}
