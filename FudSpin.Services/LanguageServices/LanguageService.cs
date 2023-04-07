using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly IGenericRepository<Language> languageService;
        public LanguageService(IGenericRepository<Language> languageService)
        {
            this.languageService = languageService;
        }
        public async Task<Language> GetLanguage(string key)
        {
            Language language = await languageService.Get(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase) && x.IsActive);
            return await Task.FromResult(language);
        }
    }
}
