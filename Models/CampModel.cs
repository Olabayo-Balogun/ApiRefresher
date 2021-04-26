using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCodeCamp.Models
{
    public class CampModel
    {
        //Data annotation attributes help validate data to ensure that we get the kind of data we want from the client
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Moniker { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;

        [Range(1,100)]
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

        public ICollection<TalkModel> Talks { get; set; }

        //The code above enables us to fetch data from the properties in the TalkModel
    }
}