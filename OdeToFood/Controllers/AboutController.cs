using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        
        public string Phone()
        {
            return "0304-20905";
        }
        
        public string Address()
        {
            return "SWEDEN";
        }
    }
}