using DorsaviTestApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DorsaviTestApp.Services.Interfaces
{
    public interface IPersonService: IService
    {
        /// <summary>
        /// Get people  from remote
        /// </summary>
        /// <returns>IEnumerable<Person></returns>
        Task<IEnumerable<Person>> GetPeople();
    }
}
