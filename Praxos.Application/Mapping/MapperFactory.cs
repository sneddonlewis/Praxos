using AutoMapper;

namespace Praxos.Application.Mapping;

public class MapperFactory<TProfile> where TProfile : Profile, new()
{
    private Lazy<IMapper>? LazyMapper { get; set; }

    public IMapper Mapper
    {
        get     
        {
            if (LazyMapper is not null)
            {
                return LazyMapper.Value;
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TProfile>();
            });
            LazyMapper = new Lazy<IMapper>(config.CreateMapper());
            return LazyMapper.Value;
        }
    }
}