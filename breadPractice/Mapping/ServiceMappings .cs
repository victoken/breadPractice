using AutoMapper;
using breadPractice.Models;
using breadPractice.Parameter;

namespace breadPractice.Mapping
{
    public class ServiceMappings: Profile
    {
        public ServiceMappings()
        {
            CreateMap<CategoriesParameter, Categories>();
        }
    }
}
