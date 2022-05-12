using MinTur.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MinTur.Domain.BusinessEntities
{
    public class ChargingPoint
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Direction { get; set; }
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        [Required]
        public int RegionId { get; set; }
        [Required]
        public Region Region { get; set; }
        
        public ChargingPoint()
        {
        }

        public virtual void ValidOrFail() 
        {
            ValidateName();
            ValidateDescription();
        }

        private void ValidateName()
        {
            Regex nameRegex = new Regex(@"^[a-zA-ZñÑáéíóúü0-9 ]+$");

            if (Name == null || !nameRegex.IsMatch(Name) ||  Name.Length > 20)
                throw new InvalidRequestDataException("Invalid tourist point name - only alphanumeric and up to 20 characters");
        }

        private void ValidateDescription() 
        {
            if (Description == null || Description.Length > 60)
                throw new InvalidRequestDataException("Invalid description - only up to 60 characters");
        }

        private void ValidateDirection() 
        {
            if (Direction == null || Direction.Length > 30)
                throw new InvalidRequestDataException("Invalid direction - only up to 30 characters");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var touristPoint = obj as TouristPoint;
            return Id == touristPoint.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

    }
}
