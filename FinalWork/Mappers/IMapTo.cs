using AutoMapper;

namespace App.Mappers
{
    public interface IMapTo<T>
    {
        void MappingTo (Profile profile)
        {
            profile.CreateMap(GetType(), typeof(T));
        }
    }
}
