using AutoMapper;
using Commom;
using Commom.Dtos;
using DataAccess.Models;

namespace Descarte.Mapping
{
    public class MappingProfile: Profile 
    {
        public MappingProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Reciclador, RecicladorDto>().ReverseMap();

            //CreateMap<Permissao, PermissaoDto>().ReverseMap();
            //CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
