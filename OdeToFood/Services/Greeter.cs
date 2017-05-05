using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OdeToFood.Services;

namespace OdeToFood.NewFolder
{
    public class Greeter:IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration configuration)
        {
            _greeting = configuration["greeting"];
        }
        public string GetGreeter()
        {
            return _greeting;
        }
    }
}
