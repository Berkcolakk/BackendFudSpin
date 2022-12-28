using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Infrastructure.Cryptography
{
    public interface ICryptographyProcessor
    {
        string CreateSalt(int size);
        string GenerateHash(string input);
        bool AreEqual(string plainTextInput, string hashedInput);
    }
}
