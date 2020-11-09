using AutoMapper;
using ConsoleApp.Data.Model;

namespace ConsoleApp.Mappers
{
    public class ObjectToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ObjectToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Retorno, Item>();
        }
    }
}
