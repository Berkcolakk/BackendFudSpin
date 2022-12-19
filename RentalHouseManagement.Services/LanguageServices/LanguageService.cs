using RentalHouseManagement.Core.Repositories;
using RentalHouseManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Services.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly IGenericRepository<Language> languageService;
        public LanguageService(IGenericRepository<Language> languageService)
        {
            this.languageService = languageService;
        }
        public async Task<Language> GetLanguage(Language language)
        {
            return await languageService.Get(x => string.Equals(x.Key, language.Key, StringComparison.OrdinalIgnoreCase) && x.IsActive);
        }
    }
}
