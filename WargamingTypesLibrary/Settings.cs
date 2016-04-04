using WargamingApiService.Enums;
using WargamingTypesLibrary.Enums;

namespace WargamingApiService
{
  public class Settings
  {
    public RequestMethod RequestMethod;
    public RequestProtocol RequestProtocol;
    public int MaxRequestsPerSecond;
    public Language Language;

    public Settings()
    {
      RequestMethod = RequestMethod.GET;
      RequestProtocol = RequestProtocol.Http;
      MaxRequestsPerSecond = 10;
      Language = Language.RU;
    }

    public Settings(RequestMethod requestMethod, RequestProtocol requestProtocol, int maxRequestsPerSecond, Language language)
    {
      RequestMethod = requestMethod;
      RequestProtocol = requestProtocol;
      MaxRequestsPerSecond = maxRequestsPerSecond;
      Language = language;
    }
  }
}
