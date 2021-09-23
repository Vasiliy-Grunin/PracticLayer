using AutoMapper;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;

namespace DataServices.MappingService
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<GenryModel, GenryBaseDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PeopleModel, ReaderBaseDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<AuthorModel, AuthorBaseDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<BookModel, BookBaseDto>(MemberList.Destination)
                .ReverseMap();


            CreateMap<GenryModel, GenryDto>(MemberList.Destination)
                .IncludeBase<GenryModel, GenryBaseDto>()
                .ForMember(dst => dst.Books, opt => opt.MapFrom(cfg => cfg.Books))
                .ReverseMap();

            CreateMap<PeopleModel, ReaderDto>(MemberList.Destination)
                .IncludeBase<PeopleModel, ReaderBaseDto>()
                .ForMember(dst => dst.Books, opt => opt.MapFrom(cfg => cfg.Books))
                .ReverseMap();

            CreateMap<AuthorModel, AuthorDto>(MemberList.Destination)
                .IncludeBase<AuthorModel, AuthorBaseDto>()
                .ForMember(dst => dst.Books, opt => opt.MapFrom(cfg => cfg.Books))
                .ReverseMap();

            CreateMap<BookModel, BookDto>(MemberList.Destination)
                .IncludeBase<BookModel, BookBaseDto>()
                .ForMember(dst => dst.Genre, opt => opt.MapFrom(cfg => cfg.Genre))
                .ReverseMap();
        }
    }
}
