using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Dto.Tokens
{
    public class TokenDTO
    {
        public required string Language { get; set; }
        public required Guid ID { get; set; }
        public required string NameSurname { get; set; }
        public required bool IsValid { get; set; }
    }
}
