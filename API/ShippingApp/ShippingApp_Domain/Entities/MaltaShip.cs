using ShippingApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_Domain.Models
{
    public class MaltaShip : CargoForYou
    {
        public override double CalculatePrices(double packageWidth, double packageHeight, double packageDepth, double packageWeight)
        {
            double finalPriceWeight = 0;
            double finalPriceDimensions = 0;

            double dimension = packageHeight * packageWidth * packageDepth;
            double weight = packageWidth;

            //Weight
            if (weight > 10 && weight <= 20)
                finalPriceWeight = 16.99;

            if (weight > 20 && weight <= 30)
                finalPriceWeight = 33.99;

            if (weight >= 30)
            {
                double plusKilos = 0.41;
                var howMany = (int)weight - 25;

                double extraWeight = 0;

                for (double i = 0; i < howMany; i++)
                {
                    extraWeight = extraWeight + plusKilos;
                }

                finalPriceWeight = 43.99 + extraWeight;
            }

            //Dimension
            if (dimension <= 1000) 
                finalPriceDimensions = 9.50;
            
            if(dimension > 1000 && dimension <= 2000)
                finalPriceDimensions = 19.50;

            if (dimension > 2000 && dimension <= 5000)
                finalPriceDimensions = 48.50;

            if (dimension > 5000)
                finalPriceDimensions = 147.50;

            //Biggest Offer
            return Math.Max(finalPriceWeight, finalPriceDimensions);
        }
    }
}

