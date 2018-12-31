
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _5_InterfazComun.Extensiones
{
    /// <summary>
    ///     clase de extensiones Extensiones
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class Extenciones
    {
        /// <summary>
        ///     Método que devuelve el valor del atributo Descripciónn de una enumeración
        /// </summary>
        /// <param name="enumeracion">Enumeración a retornar atributo </param>
        /// <returns></returns>
        public static string LeerDescripcion(this Enum enumeracion)
        {
            DescriptionAttribute attribute = enumeracion.GetType().GetField(enumeracion.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? enumeracion.ToString() : attribute.Description;
        }

        /// <summary>
        ///     Método que devuelve el valor del atributo Category de una enumeración
        /// </summary>
        /// <param name="enumeracion">Enumeracion a devolver atributo</param>
        /// <returns></returns>
        public static string LeerCategoria(this Enum enumeracion)
        {
            CategoryAttribute attribute =
                enumeracion.GetType().GetField(enumeracion.ToString())
                    .GetCustomAttributes(typeof(CategoryAttribute), false).SingleOrDefault() as CategoryAttribute;
            return attribute == null ? enumeracion.ToString() : attribute.Category;
        }


        /// <summary>
        ///     Metodo para validar si un string es numerico o no
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string input)
        {
            int test;
            return int.TryParse(input, out test);
        }


        /// <summary>
        ///     Metodo para obtener un id aleatoreo de una lista enviada
        /// </summary>
        /// <typeparam name="TEntidad">Entidad</typeparam>
        /// <param name="enumerable"></param>
        /// <returns>Entidad Aleatorea</returns>
        public static TEntidad ObtenerEntidadAleatoria<TEntidad>(this IEnumerable<TEntidad> enumerable)
        {
            Random r = new Random();
            IList<TEntidad> list = enumerable as IList<TEntidad> ?? enumerable.ToList();
            return list.ElementAt(r.Next(0, list.Count()));
        }
    }
}