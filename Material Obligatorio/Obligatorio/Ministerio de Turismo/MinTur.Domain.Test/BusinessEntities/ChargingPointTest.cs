using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MinTur.Domain.Test.BusinessEntities
{
    [TestClass]
    public class ChargingPointTest
    {
        [TestMethod]
        public void ChargingPointInitialized()
        {
            ChargingPoint chargingPoint = new ChargingPoint()
            {
                Id = 1
            };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingPointWithInvalidNameFailsValidation() 
        {
            ChargingPoint chargingPoint = new ChargingPoint()
            {
                Name = "Inva_lid! Name**",
                Description = "Valid description",
                RegionId = 2
            };
            chargingPoint.ValidOrFail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRequestDataException))]
        public void ChargingPointWithLongerThanMaxDescriptionFailsValidation()
        {
            ChargingPoint chargingPoint = new ChargingPoint()
            {
                Name = "Punta del Este",
                Description = new string('a',61),
                RegionId = 2
            };
            chargingPoint.ValidOrFail();
        }

        [TestMethod]
        public void ValidChargingPointPassesValidation()
        {
            ChargingPoint chargingPoint = new ChargingPoint()
            {
                Name = "Tacuarembó",
                Description = "Valid description",
                RegionId = 2,
                Direction = "Rambla de mvd",
                FourDigit = 1111
            };
            chargingPoint.ValidOrFail();
        }
    }
}
