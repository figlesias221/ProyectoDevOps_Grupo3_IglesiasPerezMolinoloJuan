using System;
using System.Collections.Generic;
using System.Linq;
using MinTur.Domain.BusinessEntities;

namespace MinTur.Models.Out
{
    public class ChargingPointBasicInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public RegionBasicInfoModel Region { get; set; }

        public ChargingPointBasicInfoModel(ChargingPoint chargingPoint)
        {
            Id = chargingPoint.Id;
            Name = chargingPoint.Name;
            Description = chargingPoint.Description;
            Direction = chargingPoint.Direction;
            Region = new RegionBasicInfoModel(chargingPoint.Region);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var chargingPointModel = obj as ChargingPointBasicInfoModel;
            return Id == chargingPointModel.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
