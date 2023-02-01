using ASPNETMVCCRUD.Automapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;

namespace ASPNETMVCCRUD
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();

        }
    }
       
}
