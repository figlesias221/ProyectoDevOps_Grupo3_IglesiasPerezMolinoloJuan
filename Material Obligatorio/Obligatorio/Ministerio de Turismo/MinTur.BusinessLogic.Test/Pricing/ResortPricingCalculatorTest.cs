using MinTur.Domain.BusinessEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinTur.BusinessLogic.Pricing;
using System;
using System.Collections.Generic;
using MinTur.Domain.DiscountPolicies.GuestGroups;
using Moq;

namespace MinTur.BusinessLogic.Test.Pricing
{
    [TestClass]
    public class ResortPricingCalculatorTest
    {
        private ResortPricingCalculator _resortPricingCalculator;
        private List<IGuestGroupDiscountPolicy> _guestGroupDiscounts;
        private Mock<GuestGroup> _mockGuestGroup;
        private Resort _resort;
        private int ResortPricePerNight = 126;
        private int ResortId = 1;
        private String ResortName = "Hotel Italiano";
        private readonly DateTime _accommodationCheckInSameTime = new DateTime(2020, 9, 27);
        private readonly DateTime _accommodationCheckOutSameTime = new DateTime(2020, 9, 30);
        private readonly DateTime _accommodationCheckInDifferentTime = new DateTime(2020, 9, 27, 12, 0, 0);
        private readonly DateTime _accommodationCheckOutDifferentTime = new DateTime(2020, 9, 30, 16, 0, 0);
        private int GuestGroupAmount = 2;

        [TestInitialize]
        public void SetUp() 
        {
            _mockGuestGroup = new Mock<GuestGroup>(MockBehavior.Strict);
            _guestGroupDiscounts = new List<IGuestGroupDiscountPolicy>();
            
            _resort = new Resort()
            {
                Id = ResortId,
                Name = ResortName,
                PricePerNight = ResortPricePerNight
            };

            _resortPricingCalculator = new ResortPricingCalculator();
        }

        [TestMethod]
        public void TotalPriceForAccommodationCalculatedCorrectlyWithMajorDiscount()
        {
            _guestGroupDiscounts.Add(new BabiesDiscountPolicy());
            _guestGroupDiscounts.Add(new KidsDiscountPolicy());
            _mockGuestGroup.Setup(x => x.GetApplicableDiscountPolicies()).Returns(_guestGroupDiscounts);
            _mockGuestGroup.Setup(x => x.Amount).Returns(GuestGroupAmount);
            
            Accommodation accommodation = new Accommodation()
            {
                CheckIn = _accommodationCheckInSameTime,
                CheckOut = _accommodationCheckOutSameTime
            };
            accommodation.Guests.Add((_mockGuestGroup.Object));

            double majorPolicyDiscount = new KidsDiscountPolicy().GetAssociatedDiscount();
            int amountOfNightsInAccommodation = 3;
            double expectedPrice = amountOfNightsInAccommodation * ResortPricePerNight * GuestGroupAmount * majorPolicyDiscount;
            int totalPrice = _resortPricingCalculator.CalculateTotalPriceForAccommodation(_resort, accommodation);
            Assert.AreEqual(expectedPrice, totalPrice);
        }

        [TestMethod]
        public void TotalPriceForAccommodationWithLaterCheckOutTimeThanCheckInTime()
        {
            Accommodation accommodation = new Accommodation()
            {
                CheckIn = _accommodationCheckInDifferentTime,
                CheckOut = _accommodationCheckOutDifferentTime
            };
            accommodation.Guests.Add(new GuestGroup() { GuestGroupType = GuestType.Adult.ToString(), Amount = GuestGroupAmount});

            int amountOfNightsInAccommodation = 3;
            double expectedPrice =   amountOfNightsInAccommodation * ResortPricePerNight * GuestGroupAmount;
            int totalPrice = _resortPricingCalculator.CalculateTotalPriceForAccommodation(_resort, accommodation);
            Assert.AreEqual(expectedPrice, totalPrice);
        }
    }
}
