using ShippingApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_Domain.Models
{
    public class CargoForYou
    {
        public virtual double CalculatePrices(double packageWidth, double packageHeight, double packageDepth, double packageWeight)
        {
            double finalPriceWeight = 0;
            double finalPriceDimensions = 0;

            double dimension = packageHeight * packageWidth * packageDepth;
            double weight = packageWidth;

            // CargoForYou Weight
            if (weight <= 2)
                finalPriceWeight = 15;

            if (weight > 2 && weight <= 15)
                finalPriceWeight = 18;

            if (weight > 15 && weight <= 20)
                finalPriceWeight = 18;

           //CargoFor you DIMENSIONS
            if (dimension <= 1000)
                finalPriceDimensions = 10;

            if (dimension > 1000 && dimension <= 2000)
                finalPriceDimensions = 20;

            //ReturnBiggerOffer
            return Math.Max(finalPriceWeight, finalPriceDimensions);
        }
    }
}
