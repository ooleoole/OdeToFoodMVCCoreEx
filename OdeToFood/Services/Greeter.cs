using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    public class Greeter:IGreeter
    {
        private readonly string _greeting;

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
