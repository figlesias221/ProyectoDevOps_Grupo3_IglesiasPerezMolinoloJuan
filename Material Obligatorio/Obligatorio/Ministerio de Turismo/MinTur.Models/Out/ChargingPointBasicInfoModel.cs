using System;
using System.Collections.Generic;
using System.Linq;
using MinTur.Domain.BusinessEntities;

namespace MinTur.Models.Out
{
    public class ChargingPointBasicInfoModel
    {
        public int Id { get; set; }

        public ChargingPointBasicInfoModel(int chargingPointId)
        {
            Id = chargingPointId;
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
