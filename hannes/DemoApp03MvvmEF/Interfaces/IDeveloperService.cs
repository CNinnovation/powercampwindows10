using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetDevelopersAsync();
        Task<Developer> AddDeveloperAsync(Developer dev);
    }
}
