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
                .ForMember(c => c.VenueName, o => o.MapFrom(m => m.Location.VenueName)).ReverseMap();
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Address1, o => o.MapFrom(m => m.Location.Address1)).ReverseMap();
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Address2, o => o.MapFrom(m => m.Location.Address2)).ReverseMap();
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Address3, o => o.MapFrom(m => m.Location.Address3)).ReverseMap();
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.CityTown, o => o.MapFrom(m => m.Location.CityTown)).ReverseMap();
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.StateProvince, o => o.MapFrom(m => m.Location.StateProvince)).ReverseMap();
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.PostalCode, o => o.MapFrom(m => m.Location.PostalCode)).ReverseMap();
            this.CreateMap<Camp, CampModel>()
               .ForMember(c => c.Country, o => o.MapFrom(m => m.Location.Country)).ReverseMap();
            this.CreateMap<Talk, TalkModel>()
              .ForMember(c => c.Title, o => o.MapFrom(m => m.Title)).ReverseMap();
            this.CreateMap<Talk, TalkModel>()
              .ForMember(c => c.Abstract, o => o.MapFrom(m => m.Abstract)).ReverseMap();
            this.CreateMap<Talk, TalkModel>()
              .ForMember(c => c.Level, o => o.MapFrom(m => m.Level)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.SpeakerId, o => o.MapFrom(m => m.SpeakerId)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.FirstName, o => o.MapFrom(m => m.FirstName)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.LastName, o => o.MapFrom(m => m.LastName)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.MiddleName, o => o.MapFrom(m => m.MiddleName)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.Company, o => o.MapFrom(m => m.Company)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.CompanyUrl, o => o.MapFrom(m => m.CompanyUrl)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.BlogUrl, o => o.MapFrom(m => m.BlogUrl)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.Twitter, o => o.MapFrom(m => m.Twitter)).ReverseMap();
            this.CreateMap<Speaker, SpeakerModel>().ForMember(c => c.GitHub, o => o.MapFrom(m => m.GitHub)).ReverseMap();
        }
    }
}
