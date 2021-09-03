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
            //observado ao fazer teste que quando enviado string vazia no valorUnitario, o mapper ao tentar fazer conversao de string para decimal gerava exceção
            //codigo abaixo é para corrigir esse comportamento.
            //CreateMap<ProdutoDto, Produto>()
            //    .ForMember(dest => dest.ValorUnitario, op => op.MapFrom(orig => string.IsNullOrEmpty(orig.ValorUnitario) ? null : orig.ValorUnitario));
        }
    }
}
