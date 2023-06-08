using AutoMapper;

namespace App.Mappers
{
    public interface IMapFrom<T>
    {
        void MappingFrom(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }
    }
}
