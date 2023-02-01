using ASPNETMVCCRUD.Controllers;
using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Repository;
using AutoMapper;
using System.Runtime;

namespace ASPNETMVCCRUD.Automapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Add lines to map your objects
            CreateMap<Profile, VehiclesController>();
            CreateMap<VehiclesController, Profile>();
        }
        //public static void ()
        //{
        //    AutoMapper.Mapper.Initialize(config =>
        //    {
        //        config.CreateMap<Profile, UserRepository>();
        //    });


        //}
    }
}
