using AutoMapper;

namespace Praxos.Application.Models.Mapping;

public class MapperFactory<TProfile> where TProfile : Profile, new()
{
    // static MapperFactory()
    // {
    //     var config = new MapperConfiguration(cfg =>
    //     {
    //         cfg.AddProfile<TProfile>();
    //     });
    //
    // }
    // public IMapper Mapper { get; private set; }
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
    // {
    //     if (LazyMapper is not null)
    //     {
    //         return LazyMapper.Value;
    //     }
    //     var config = new MapperConfiguration(cfg =>
    //     {
    //         cfg.AddProfile<TProfile>();
    //     });
    //     LazyMapper = new Lazy<IMapper>(config.CreateMapper());
    //     return LazyMapper.Value;
    // }
}