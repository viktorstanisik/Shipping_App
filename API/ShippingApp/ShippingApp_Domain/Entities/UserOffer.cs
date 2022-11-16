using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingApp_Domain.Entities
{
    public class UserOffers
    {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public string PackageWidth { get; set; }
        public string PackageHeight { get; set; }
        public string PackageDepth { get; set; }
        public string PackageWeight { get; set; }
        public string PackageOfferPrice { get; set; }

    }
}
