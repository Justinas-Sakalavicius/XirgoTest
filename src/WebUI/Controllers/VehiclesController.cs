using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XirgoTest.Application.VehicleDetails.Commands.DeleteVehicleDetails;
using XirgoTest.Application.Vehicles.Commands.CreateVehicle;
using XirgoTest.Application.Vehicles.Commands.DeleteVehicle;
using XirgoTest.Application.Vehicles.Commands.UpdateVehicle;
using XirgoTest.Application.Vehicles.Queries;

namespace XirgoTest.WebUI.Controllers
{
    public class VehiclesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<VehiclesVm>> Get()
        {
            return await Mediator.Send(new GetAllVehiclesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleVm>> GetById(int id)
        {
            return await Mediator.Send(new GetVehicleByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateVehicleCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateVehicleCommand command)
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
            await Mediator.Send(new DeleteVehicleCommand { Id = id });
            await Mediator.Send(new DeleteVehicleDetailsCommand { VehicleId = id });
            return NoContent();
        }
    }
}
