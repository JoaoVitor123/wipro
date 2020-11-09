using AutoMapper;

namespace ConsoleApp.Mappers
{
    public class AutoMapperConfig
    {
        [System.Obsolete]
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ObjectToDomainMappingProfile>();
            });
        }

    }
}
