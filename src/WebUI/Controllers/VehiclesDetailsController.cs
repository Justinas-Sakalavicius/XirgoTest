using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XirgoTest.Application.VehicleDetails.Commands.CreateVehicleDetails;
using XirgoTest.Application.VehicleDetails.Commands.DeleteVehicleDetails;
using XirgoTest.Application.VehicleDetails.Commands.UpdateVehicleDetails;
using XirgoTest.Application.VehicleDetails.Queries.GetVehicleDetails;

namespace XirgoTest.WebUI.Controllers
{
    public class VehiclesDetailsController : ApiController
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDetailsVm>> GetByVehicleId(int id)
        {
            return await Mediator.Send(new GetVehicleDetailsQuery { VehicleId = id });
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateVehicleDetailsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateVehicleDetailsCommand command)
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
            await Mediator.Send(new DeleteVehicleDetailsCommand { VehicleId = id });

            return NoContent();
        }

    }
}
