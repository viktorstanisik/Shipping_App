using ShippingApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_Domain.Models
{
    public class ShipFaster : CargoForYou
    {
        public override double CalculatePrices(double packageWidth, double packageHeight, double packageDepth, double packageWeight)
        {
            double finalPriceWeight = 0;
            double finalPriceDimensions = 0;

            double dimension = packageHeight * packageWidth * packageDepth;
            double weight = packageWidth;

            //Weight Calc
            if (weight > 10 && weight <= 15)
                finalPriceWeight = 16.50;

            if (weight > 15 && weight <= 25)
                finalPriceWeight = 36.50;

            if (weight > 25)
            {
                double plusKilos = 0.417;
                var howMany = (int)weight - 25;

                double extraWeight = 0;

                for (double i = 0; i < howMany; i++)
                {
                    extraWeight = extraWeight + plusKilos;
                }

                finalPriceWeight = 40 + extraWeight;

            }
            //Dimension Calc
            if (dimension <= 1000)
                finalPriceDimensions = 11.99;

            if (dimension > 1000 && dimension <= 1700)
                finalPriceDimensions = 21.99;


            //ReturnBiggestOffer
            return Math.Max(finalPriceWeight, finalPriceDimensions);
        }
    }
}

