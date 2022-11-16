using NUnit.Framework;

namespace ShippingApp_Tests
{
    [TestFixture]
    public class CarrierPrices
    {
        [Test]
        public void CargoForYouCalculation()
        {
            //1000
            double height = 10;
            double width = 10;
            double depth = 10;
            //weight
            double weight = 20;
            var res = CalculatePrizeForCargoForYou(height, width, depth, weight);

            Assert.That(res, Is.EqualTo(18));

        }

        [Test]
        public void ShipFasterCalculation()
        {
            //1700
            double height = 10;
            double width = 17;
            double depth = 10;
            //weight
            double weight = 22;
            var res = CalculatePrizeForCargoForYou(height, width, depth, weight);

            Assert.That(res, Is.EqualTo(36.5));

        }


        [Test]
        public void MaltaShipCalculation()
        {
            //8500
            double height = 50;
            double width = 17;
            double depth = 10;
            //weight
            double weight = 35;
            var res = CalculatePrizeForCargoForYou(height, width, depth, weight);

            Assert.That(res, Is.GreaterThan(100).And.LessThan(200).And.Not.Negative);

        }

        private double CalculatePrizeForCargoForYou(double height, double width, double depth, double weight)
        {
            double finalPriceWeight = 0;
            double finalPriceDimensions = 0;

            double dimension = height * width * depth;

            //Cargo4You
            if (weight <= 20 && dimension < 2000)
            {
                //CargoFor you WEIGHT
                if (weight <= 2)
                    finalPriceWeight = 15;

                if (weight > 2 && weight <= 15)
                    finalPriceWeight = 18;

                if (weight > 15 && weight <= 20)
                    finalPriceWeight = 18;


                // //CargoFor you DIMENSIONS
                if (dimension <= 1000)
                    finalPriceDimensions = 10;

                if (dimension > 1000 && dimension <= 2000)
                    finalPriceDimensions = 20;

                return Math.Max(finalPriceWeight, finalPriceDimensions);

            }

            //ShipFaster
            if (weight > 10 && weight <= 30 && dimension <= 1700)
            {
                //ShipFaster

                if (weight > 10 && weight <= 15)
                    finalPriceWeight = 16.50;

                if (weight > 15 && weight <= 25)
                    finalPriceWeight = 36.50;

                if (weight > 25)
                {
                    double plusKilos = 0.417;
                    var howMany = (int)weight - 25;
                    double res = 0;

                    for (double i = 0; i < howMany; i++)
                    {
                        res = howMany + plusKilos;
                    }

                    finalPriceWeight = 40 + res;

                }

                if (dimension <= 1000)
                    finalPriceDimensions = 11.99;

                if (dimension > 1000 && dimension <= 1700)
                    finalPriceDimensions = 21.99;

                return Math.Max(finalPriceWeight, finalPriceDimensions);

            }

            //Malta Ship
            if (weight > 10 && weight <= 20)
                finalPriceWeight = 16.99;

            if (weight > 20 && weight <= 30)
                finalPriceWeight = 33.99;

            if (weight >= 30)
            {
                double plusKilos = 0.41;
                var howMany = (int)weight - 25;

                double res = 0;

                for (double i = 0; i < howMany; i++)
                {
                    res = res + plusKilos;
                }

                finalPriceWeight = 43.99 + res;
            }

            //Dimension
            if (dimension <= 1000)
                finalPriceDimensions = 9.50;

            if (dimension > 1000 && dimension <= 2000)
                finalPriceDimensions = 19.50;

            if (dimension > 2000 && dimension <= 5000)
                finalPriceDimensions = 48.50;

            if (dimension > 5000)
                finalPriceDimensions = 147.50;

            return Math.Max(finalPriceWeight, finalPriceDimensions);

        }

    }

}
