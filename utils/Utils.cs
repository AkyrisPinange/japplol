using static Org.BouncyCastle.Math.EC.ECCurve;

namespace JAppInfos.utils
{
    public class Utils
    {
        private readonly IConfiguration _config;
        public Utils(IConfiguration config)
        {
            _config = config;
        }
        public string getConfig(string config)
        {
            if (config != null)
            {
                return _config[config]; 
            }
            else 
            {
                throw new Exception("Empty JWT key in configuration");
            }
        }
    }
}
