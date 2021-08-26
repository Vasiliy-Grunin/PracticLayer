using AutoMapper;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DAL.Entitys.Model.Inheritance;

namespace DAL.Service.MappingService
{
    internal class AutoMapping : Profile
    {
        internal AutoMapping()
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
                .ForMember(dst => dst.Author, opt => opt.MapFrom(cfg => cfg.Author))
                .ReverseMap();


            CreateMap<AuthorInheritance, AuthorInheritanceDto>(MemberList.Destination)
                .IncludeBase<AuthorModel, AuthorDto>()
                .ReverseMap();

            CreateMap<GenryInheritance, GenryInheritanceDto>(MemberList.Destination)
                .IncludeBase<GenryModel, GenryDto>()
                .ReverseMap();

            CreateMap<PeopleInheritance, ReaderInheritanceDto>(MemberList.Destination)
                .IncludeBase<PeopleModel, ReaderDto>()
                .ReverseMap();

            CreateMap<BookInheritance, BookInheritanceDto>(MemberList.Destination)
                .IncludeBase<BookModel, BookDto>() 
                .ReverseMap();
        }
    }
}
