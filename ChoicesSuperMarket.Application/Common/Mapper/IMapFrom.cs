using AutoMapper;

namespace ChoicesSuperMarket.Application.Common.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}