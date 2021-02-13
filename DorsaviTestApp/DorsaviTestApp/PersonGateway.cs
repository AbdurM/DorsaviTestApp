using DorsaviTestApp.Gateway.Implementations;
using DorsaviTestApp.Gateway.Interfaces;
using DorsaviTestApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System;

namespace DorsaviTestApp
{
    public class PersonGateway : GatewayBase<Person>, IPersonGateway
    {
        #region fields
        private readonly string _personUrl = "https://dorsavicodechallenge.azurewebsites.net/Melbourne";
        #endregion 
        #region Constructor
        public PersonGateway()
        {
                
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Person>> GetPeople()
        {
            IEnumerable<Person> result = null;
            try
            {
                var json = await GetJsonStream(_personUrl);
                result = JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
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