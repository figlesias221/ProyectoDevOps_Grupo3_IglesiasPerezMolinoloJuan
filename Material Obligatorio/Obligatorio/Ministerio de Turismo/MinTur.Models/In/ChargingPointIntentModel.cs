using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;

namespace MinTur.Models.In
{
    public class ChargingPointIntentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public int RegionId { get; set; }

        public ChargingPoint ToEntity()
        {
            ChargingPoint chargingPoint = new ChargingPoint()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Direction = Direction,
                RegionId = RegionId,
            };

            return chargingPoint;
        }

    }
}
