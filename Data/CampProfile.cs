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
            this.CreateMap<Camp, CampModel>();
        }
    }
}
