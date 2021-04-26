using AutoMapper;
using CoreCodeCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            //This is how you map between two classes, it works great especially when their names are similiar
            //By using mapping, you can create a class and populate it with the methods you'd like to expose to the client and then run operations using that Model and send it to the client.
            //The profile class is where these linkages are declared

            //Code
            //this.CreateMap<Camp, CampModel>();

            //The line of code above is different from the line of code below because it makes it easier to map to different properties in entity classes that are different from the mapped entity and model class

            this.CreateMap<Camp, CampModel>()
                .ForMember(c => c.VenueName, o => o.MapFrom(m => m.Location.VenueName));
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Address1, o => o.MapFrom(m => m.Location.Address1));
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Address2, o => o.MapFrom(m => m.Location.Address2));
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Address3, o => o.MapFrom(m => m.Location.Address3));
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.CityTown, o => o.MapFrom(m => m.Location.CityTown));
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.StateProvince, o => o.MapFrom(m => m.Location.StateProvince));
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.PostalCode, o => o.MapFrom(m => m.Location.PostalCode));
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Country, o => o.MapFrom(m => m.Location.Country));
        }
    }
}
