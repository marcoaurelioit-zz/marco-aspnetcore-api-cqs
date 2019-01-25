using AutoMapper;
using Marco.AspNetCore.Cqs.Domain.Models;
using v1 = Marco.AspNetCore.Cqs.WebApi.Models.v1;

namespace Marco.AspNetCore.Cqs.WebApi
{
    public class WebApiAutoMapperProfile : Profile
    {
        public WebApiAutoMapperProfile()
        {
            #region [Mapping for WebApi Version 1.0]

            CreateMap<PessoaFisica, v1.PessoaFisicaGetResult>(); 

            #endregion
        }
    }
}