using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Dto.Spinners
{
    public class SpinnerAdd
    {
        public required SpinnerMasterAddDTO SpinnerMaster { get; set; }
        public required List<SpinnerDetailAddDTO> SpinnerDetails { get; set; }  
    }
}
