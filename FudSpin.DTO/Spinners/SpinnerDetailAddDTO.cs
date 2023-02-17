using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Dto.Spinners
{
    public class SpinnerDetailAddDTO
    {
        public required string Color { get; set; }
        public required string? Name { get; set; }
        public required string? Description { get; set; }
    }
}
