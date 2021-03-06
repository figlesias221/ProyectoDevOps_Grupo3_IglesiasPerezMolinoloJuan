using MinTur.BusinessLogicInterface.ResourceManagers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;
using MinTur.Models.Out;
using MinTur.Models.In;
using System.Linq;
using MinTur.WebApi.Filters;

namespace MinTur.WebApi.Controllers
{
    [EnableCors("AllowEverything")]
    [Route("api/chargingPoints")]
    [ApiController]
    public class ChargingPointController : ControllerBase
    {
        private readonly IChargingPointManager _chargingPointManager;

        public ChargingPointController(IChargingPointManager chargingPointManager)
        {
            _chargingPointManager = chargingPointManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(AdministratorAuthorizationFilter))]
        public IActionResult CreateChargingPoint([FromBody] ChargingPointIntentModel chargingPointIntentModel)
        {
            ChargingPoint registeredChargingPoint = _chargingPointManager.RegisterChargingPoint(chargingPointIntentModel.ToEntity());
            ChargingPointBasicInfoModel chargingPointModel = new ChargingPointBasicInfoModel(registeredChargingPoint);
            return Created("api/chargingPoints/" + chargingPointIntentModel.Name, chargingPointIntentModel);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(AdministratorAuthorizationFilter))]
        public IActionResult DeleteChargingPoint([FromRoute] int id)
        {
            ChargingPoint deletedChargingPoint = _chargingPointManager.DeleteChargingPoint(id);

            return Ok($"Charging point {deletedChargingPoint.FourDigit}: {deletedChargingPoint.Name} has been deleted.");
        }

    }
}