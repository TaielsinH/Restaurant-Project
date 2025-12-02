using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.Models
{
    
    public class DishQueryParameters
    {
        /// <summary>Buscar platos por nombre (búsqueda parcial)</summary>
        /// <example>pizza</example>
        public string? Name { get; set; }

        /// <summary>Filtrar por categoría (id)</summary>
        /// <example>1</example>
        public int? Category { get; set; }

        /// <summary>Ordenar por precio: asc o desc</summary>
        public SortDirection SortByPrice { get; set; } = SortDirection.none;

        /// <summary>Si true devuelve solo platos disponibles</summary>
        /// <example>true</example>
        public bool OnlyActive { get; set; } = true;

    }

}