using System.Collections.Generic;
using AutoMapper;

namespace _5_InterfazComun.Extensiones
{
    public static class IMapperDTOExtension
    {
        /// <summary>
        ///     Extensión para mapear a una lista de objetos
        /// </summary>
        /// <typeparam name="TOrigen"></typeparam>
        /// <typeparam name="TDestino"></typeparam>
        /// <param name="origen"></param>
        /// <returns>Objeto</returns>
        public static List<TDestino> MapperPruebas<TOrigen, TDestino>(this List<TOrigen> origen)
            where TDestino : TOrigen, new()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TOrigen, TDestino>(); });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<List<TOrigen>, List<TDestino>>(origen);
        }


        /// <summary>
        ///     Extensión para mapear a una lista de objetos
        /// </summary>
        /// <typeparam name="TOrigen"></typeparam>
        /// <typeparam name="TDestino"></typeparam>
        /// <param name="origen"></param>
        /// <returns>Objeto</returns>
        public static TDestino MapperPruebas<TOrigen, TDestino>(this TOrigen origen)
            where TDestino : TOrigen, new()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TOrigen, TDestino>(); });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<TOrigen, TDestino>(origen);
        }


        /// <summary>
        ///     Extensión para mapear a una lista de objetos quitando todas las referencias que tenga en un contexto
        /// </summary>
        /// <typeparam name="TDestino">Destino</typeparam>
        /// <typeparam name="TOrigen">Origen</typeparam>
        /// <param name="origen"></param>
        /// <returns>Objeto</returns>
        public static List<TDestino> MapperPruebasDetached<TDestino, TOrigen>(this List<TOrigen> origen,
            List<TDestino> nuevaInstancia)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TOrigen, TDestino>(); });
            IMapper mapper = config.CreateMapper();
            return mapper.Map(origen, nuevaInstancia);
        }


        /// <summary>
        ///     Extensión para mapear a una lista de objetos
        /// </summary>
        /// <typeparam name="TDestino">Destino</typeparam>
        /// <typeparam name="TOrigen">Origen</typeparam>
        /// <param name="origen"></param>
        /// <returns>Objeto</returns>
        public static TDestino MapperPruebasDetached<TDestino, TOrigen>(this TOrigen origen, TDestino nuevaInstancia)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<TOrigen, TDestino>(); });
            IMapper mapper = config.CreateMapper();
            return mapper.Map(origen, nuevaInstancia);
        }
                
    }
}