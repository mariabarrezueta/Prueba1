using System.Net.Http;

namespace Prueba1
{
    internal class HttpClientHandlerService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            return handler;
        }
    }
}
