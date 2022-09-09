
using AutoMapper;
using {{cookiecutter.project_api_pkg}}.ViewModels;

namespace {{cookiecutter.project_api_pkg}}.Mapper
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperProfile()
        {

            // AppUserViewModel
            CreateMap<AppUserViewModel, AppUser>()
                .ReverseMap();
            CreateMap<AppUser, AppUserViewModel>()
                .ReverseMap();

        }
    }
}
