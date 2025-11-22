using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    //Record special type was introduced c#9.0
    //based On value not ref & immutable
    public record ProductResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = null;
        public string PictureUrl { get; set; } = null;
        public decimal Price { get; set; }

        public string BrandName { get; set; } = null!;
        public string TypeName { get; set; } = null!;

    }
}
