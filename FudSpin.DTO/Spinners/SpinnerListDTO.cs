using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Dto.Spinners
{
    public class SpinnerMasterDTO
    {
        public Guid ID { get; set; }
        public string MasterName { get; set; }
        public List<SpinnerListDTO>? SpinnerList { get; set; }
    }
    public class SpinnerListDTO
    {
        public Guid ID { get; set; }
        public string? Color { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
