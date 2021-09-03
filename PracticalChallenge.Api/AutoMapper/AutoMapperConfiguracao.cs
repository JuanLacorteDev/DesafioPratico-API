using AutoMapper;
using PracticalChallenge.Api.EntidadesDto;
using PracticalChallenge.Business.Entidades;
using PracticalChallenge.Business.Entidades.Validacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalChallenge.Api.AutoMapper
{
    public class AutoMapperConfiguracao : Profile
    {
        public AutoMapperConfiguracao()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
