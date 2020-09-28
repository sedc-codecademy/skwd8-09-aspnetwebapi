using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.WebApi.Class03.Api.Models.DtoModels
{
    public class GetPagingRouteParams
    {
        [Required]
        public int Page { get; set; }
        [Required]
        public int PageSize { get; set; }
        public bool IncludeTags { get; set; }

        // 50 more props or optional quesry params
    }
}
