using MinTur.Domain.BusinessEntities;
using MinTur.BusinessLogicInterface.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using MinTur.Domain.DiscountPolicies.GuestGroups;

namespace MinTur.BusinessLogic.Pricing
{
    public class ResortPricingCalculator : IResortPricingCalculator
    {
        public int CalculateTotalPriceForAccommodation(Resort resort, Accommodation accommodation)
        {
            int totalPrice = 0;
            int pricePerNight = resort.PricePerNight;
            int amountOfNights = GetAmountOfNightsFromAccommodation(accommodation);
            List<GuestGroup> guestGroups = accommodation.Guests;

            foreach (GuestGroup guestGroup in guestGroups)
            {
                List<IGuestGroupDiscountPolicy> applicableDiscounts = guestGroup.GetApplicableDiscountPolicies();
                if (applicableDiscounts.Count > 0)
                {
                    IGuestGroupDiscountPolicy policyWithMajorDiscount = GetPolicyWithMajorDiscount(applicableDiscounts, guestGroup);
                    int guestsWithDiscount = policyWithMajorDiscount.AmountOfGuestsThatApplyForDiscount(guestGroup);
                    int guestsWithoutDiscount = guestGroup.Amount - guestsWithDiscount;
                    double discount = policyWithMajorDiscount.GetAssociatedDiscount();

                    totalPrice += (int)(amountOfNights * guestsWithDiscount * pricePerNight * (1 - discount));
                    totalPrice += amountOfNights * guestsWithoutDiscount * pricePerNight;
                }
                else
                    totalPrice += amountOfNights * guestGroup.Amount * pricePerNight;
            }

            return totalPrice;
        }

        private int GetAmountOfNightsFromAccommodation(Accommodation accommodation)
        {
            TimeSpan timespan = accommodation.CheckOut.Subtract(accommodation.CheckIn);
            
            int amountOfNights;
            if (accommodation.CheckOut < accommodation.CheckIn)
            {
                amountOfNights = (int)Math.Ceiling(timespan.TotalDays);
            }
            else
            {
                amountOfNights = (int)Math.Floor(timespan.TotalDays);
            }

            return amountOfNights;
        }

        private IGuestGroupDiscountPolicy GetPolicyWithMajorDiscount(List<IGuestGroupDiscountPolicy> discounts,
            GuestGroup guestGroup)
        {
            return discounts.OrderByDescending
                (policy => policy.AmountOfGuestsThatApplyForDiscount(guestGroup) * policy.GetAssociatedDiscount()).First();
        }
    }
}
