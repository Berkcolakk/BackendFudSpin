using FudSpin.Core.Repositories;
using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.LanguageServices
{
    public interface ILanguageService
    {
        Task<Language> GetLanguage(string key);
    }
}
