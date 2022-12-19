using RentalHouseManagement.Core.Repositories;
using RentalHouseManagement.Entities.Entities;
using RentalHouseManagement.Entities.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Services.LanguageServices
{
    public interface ILanguageService
    {
        Task<Language> GetLanguage(Language language);
    }
}
