using CoreCodeCamp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Models
{
    public class CampModel
    {
        public string Name { get; set; }
        public string Moniker { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; } = 1;
        public string VenueName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string CityTown { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        //When you want to pull in properties from different classes (that are different from the model class origin) into the model class you must prefix the property name with the name of the external class so automapper can map to it and get the necessary data.

        //eg public string LocationPostalCode { get; set; } is getting PostalCode property from Location entity class.
        //Automapper will know this because of the Location prefix.

        //Note that if you do not like the way the property names look when the API is fetched there are other ways to go about it.
        //Adjust it in the Profile class of the model, the profile class is where you map the entity class to the model class.
    }
}
