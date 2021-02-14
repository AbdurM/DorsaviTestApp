using DorsaviTestApp.Gateway.Interfaces;
using DorsaviTestApp.Models;
using DorsaviTestApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DorsaviTestApp.Services.Implementations
{
    public class PersonService: IPersonService
    {
        #region fields
        private readonly IPersonGateway _personGateway;
        #endregion

        #region constructors
        public PersonService(IPersonGateway personGateway)
        {
            _personGateway = personGateway;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Person>> GetPeople()
        {
            IEnumerable<Person> result = new List<Person>();

            try
            {
                result = await _personGateway.GetPeople();
            }
            catch(Exception ex)
            {
                //Would use logging to relevant platform(ex raygun) in prod
                Debug.WriteLine(ex.Message);
            }

            return result;

        }
        #endregion
    }
}
