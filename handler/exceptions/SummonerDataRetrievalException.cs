using JAppInfos.Models;
using JAppInfos.Models.handler;

namespace JAppInfos.handler.exceptions
{
    public class SummonerDataRetrievalException : Exception
    {
       
        public  ErrorResponse _errorResponse { get; set; }
       
        public SummonerDataRetrievalException(ErrorResponse errorResponse)
            
        {
            _errorResponse = errorResponse;
        }

     
    }
}
