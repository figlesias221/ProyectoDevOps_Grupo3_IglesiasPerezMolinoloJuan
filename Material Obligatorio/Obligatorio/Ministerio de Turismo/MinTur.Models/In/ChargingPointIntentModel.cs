using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;

namespace MinTur.Models.In
{
    public class ChargingPointIntentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int RegionId { get; set; }
        public List<int> CategoriesId { get; set; }

        public ChargingPointIntentModel()
        {
            CategoriesId = new List<int>();
        }

        public ChargingPoint ToEntity()
        {
            ChargingPoint chargingPoint = new ChargingPoint()
            {
                Name = Name,
                Description = Description,
                RegionId = RegionId,
            };

            return chargingPoint;
        }

    }
}
