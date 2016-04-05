//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.Text;

//namespace WargamingApiService
//{
//  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WargamingService" in both code and config file together.
//  public class WargamingService : IWargamingService
//  {
//    public string GetData(int value)
//    {
//      return string.Format("You entered: {0}", value);
//    }

//    public CompositeType GetDataUsingDataContract(CompositeType composite)
//    {
//      if (composite == null)
//      {
//        throw new ArgumentNullException("composite");
//      }
//      if (composite.BoolValue)
//      {
//        composite.StringValue += "Suffix";
//      }
//      return composite;
//    }
//  }
//}


/*
The MIT License (MIT)

Copyright (c) 2014 Iulian Grosu

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WargamingApiService.Enums;
using System.Diagnostics.CodeAnalysis;
using WargamingTypesLibrary.Enums;

namespace WargamingApiService
{
  public class WargamingService : IWargamingService
  {
    private readonly string _defaultApiUri;
    private readonly string _applicationId;
    private readonly Settings _settings;
    private readonly Dictionary<RequestTarget, string> _targets = new Dictionary<RequestTarget, string>();

    #region Constructors

    public WargamingService(){}

    public WargamingService(string applicationId, Settings settings = null, string apiUri = @"api.worldoftanks.ru/wot")
    {
      _applicationId = applicationId;
      _settings = settings ?? new Settings();
      _defaultApiUri = apiUri;
     
      _targets = new Dictionary<RequestTarget, string>
      {
        { RequestTarget.AccountList, "account/list"},
        { RequestTarget.AccountInfo, "account/info"},
        { RequestTarget.AccountRatings, "account/ratings"},
        { RequestTarget.AccountTanks, "account/tanks"},
        { RequestTarget.AccountAchievements,"account/achievements"},
        { RequestTarget.AuthLogin, "auth/login"},
        { RequestTarget.AuthProlongate, "auth/prolongate"},
        { RequestTarget.AuthLogout, "auth/logout"},
        { RequestTarget.ClanList, "clan/list"},
        { RequestTarget.ClanInfo, "clan/info"},
        { RequestTarget.ClanBattles, "clan/battles"},
        { RequestTarget.ClanTop, "clan/top"},
        { RequestTarget.ClanProvinces, "clan/provinces"},
        { RequestTarget.ClanVictorypoints, "clan/victorypoints"},
        { RequestTarget.ClanMembersinfo, "clan/membersinfo"},
        { RequestTarget.EncyclopediaTanks, "encyclopedia/tanks"},
        { RequestTarget.EncyclopediaTankInfo, "encyclopedia/tankinfo"},
        { RequestTarget.EncyclopediaTankEngines, "encyclopedia/tankengines"},
        { RequestTarget.EncyclopediaTankTurrets, "encyclopedia/tankturrets"},
        { RequestTarget.EncyclopediaTankRadios, "encyclopedia/tankradios"},
        { RequestTarget.EncyclopediaTankChassis, "encyclopedia/tankchassis"},
        { RequestTarget.EncyclopediaTankGuns, "encyclopedia/tankguns"},
        { RequestTarget.EncyclopediaAchievements, "encyclopedia/achievements"},
        { RequestTarget.TanksStats,"tanks/stats"},
        { RequestTarget.TanksAchievements, "tanks/achievements"}
      };
    }

    #endregion Constructors

    #region Account

    #region Search Players

    public IResponse SearchPlayers(string searchTerm, SearchType searchType = SearchType.StartsWith, int limit = 100, Language? language = null, string responseFields = "")
    {
      var requestUri = CreatePlayerSearchRequestUri(searchTerm, language, responseFields, searchType, limit);
      return GetRequestResponse(requestUri);
    }

    private string CreatePlayerSearchRequestUri(string searchTerm, Language? language, string responseFields, SearchType searchType, int limit)
    {
      var sb = GetDefaultUri(RequestTarget.AccountList, language, responseFields: responseFields);

      var searchTypeField = ToLowerInvariant(searchType);
      sb.AppendFormat("&type={0}&search={1}&limit={2}", searchTypeField, searchTerm, limit);
      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Search Players

    #region Player Info

    public IResponse GetPlayerInfo(long[] accountIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreatePlayerDataRequestUri(accountIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreatePlayerDataRequestUri(IEnumerable<long> accountIds, Language? language, string accessToken, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.AccountInfo, language, accessToken, responseFields);
      sb.AppendFormat("&account_id={0}", string.Join(",", accountIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Player Info

    #region Player Ratings

    [Obsolete("Method has been removed.")]
    public IResponse GetPlayerRatings(long[] accountIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreatePlayerRatingsRequestUri(accountIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    [ExcludeFromCodeCoverage]
    private string CreatePlayerRatingsRequestUri(IEnumerable<long> accountIds, Language? language, string accessToken, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.AccountRatings, language, accessToken, responseFields);
      sb.AppendFormat("&account_id={0}", string.Join(",", accountIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Player Ratings

    #region Player Vehicles

    public IResponse GetPlayerVehicles(long accountId)
    {
      return GetPlayerVehicles(new[] { accountId }, new long[0], _settings.Language, null, null);
    }

    public IResponse GetPlayerVehicles(long[] accountIds)
    {
      return GetPlayerVehicles(accountIds, new long[0], _settings.Language, null, null);
    }

    public IResponse GetPlayerVehicles(long[] accountIds, long[] tankIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreatePlayerVehiclesRequestUri(accountIds, tankIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreatePlayerVehiclesRequestUri(IEnumerable<long> accountIds, long[] tankIds, Language? language, string accessToken, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.AccountTanks, language, accessToken, responseFields);
      sb.AppendFormat("&account_id={0}", string.Join(",", accountIds));

      if (tankIds.Length > 0)
        sb.AppendFormat("&tank_id={0}", string.Join(",", tankIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Player Vehicles

    #region Player Achievements

    public IResponse GetPlayerAchievements(long accountId)
    {
      return GetPlayerAchievements(new[] { accountId });
    }

    public IResponse GetPlayerAchievements(long[] accountIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreatePlayerAchievementsRequestUri(accountIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreatePlayerAchievementsRequestUri(IEnumerable<long> accountIds, Language? language, string accessToken, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.AccountAchievements, language, accessToken, responseFields);
      sb.AppendFormat("&account_id={0}", string.Join(",", accountIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Player Achievements

    #endregion Account

    #region Authentication

    [ExcludeFromCodeCoverage]
    public string AccessToken(string username, string password)
    {
      //var target = "auth/login";
      throw new NotImplementedException("This feature has not been implemented yet");
    }

    [ExcludeFromCodeCoverage]
    public string ProlongToken(string accessToken)
    {
      //var target = "auth/prolongate";
      throw new NotImplementedException("This feature has not been implemented yet");
    }

    [ExcludeFromCodeCoverage]
    public string Logout(string accessToken)
    {
      //var target = "auth/logout";
      throw new NotImplementedException("This feature has not been implemented yet");
    }

    #endregion Authentication

    #region Clans

    #region Search Clans

    public IResponse SearchClans(string searchTerm, Language? language = null, string responseFields = "", int limit = 100, string orderby = "")
    {
      var requestUri = CreateClanSearchRequestUri(searchTerm, language, responseFields, limit, orderby);
      return GetRequestResponse(requestUri);
    }

    private string CreateClanSearchRequestUri(string searchTerm, Language? language, string responseFields, int limit, string orderby)
    {
      var sb = GetDefaultUri(RequestTarget.ClanList, language, null, responseFields);
      sb.AppendFormat("&search={0}&limit={1}", searchTerm, limit);

      if (!string.IsNullOrWhiteSpace(orderby))
        sb.AppendFormat("&order_by={0}", orderby);

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Search Clans

    #region Clan Details

    public IResponse GetClanDetails(long clanId)
    {
      return GetClanDetails(new[] { clanId });
    }

    public IResponse GetClanDetails(long[] clanIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreateClanInfoRequestUri(clanIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateClanInfoRequestUri(IEnumerable<long> clanIds, Language? language, string accessToken, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.ClanInfo, language, accessToken, responseFields);
      sb.AppendFormat("&clan_id={0}", string.Join(",", clanIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Clan Details

    #region Clan's Battles

    public IResponse GetClansBattles(long clanId)
    {
      return GetClansBattles(new[] { clanId });
    }

    public IResponse GetClansBattles(long[] clanIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreateClanBattlesRequestUri(clanIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateClanBattlesRequestUri(IEnumerable<long> clanIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var sb = GetDefaultUri(RequestTarget.ClanBattles, language, accessToken, responseFields);
      sb.AppendFormat("&clan_id={0}", string.Join(",", clanIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Clan's Battles

    #region Top Clans by Victory Points

    public IResponse GetTopClansByVictoryPoints(TimeDelta time = TimeDelta.Season, Language? language = null, string responseFields = "")
    {
      var requestUri = CreateTopClansByVictoryPointsRequestUri(time, language, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateTopClansByVictoryPointsRequestUri(TimeDelta time, Language? language, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.ClanTop, language, responseFields: responseFields);
      sb.AppendFormat("&time={0}", time == TimeDelta.Step ? "current_step" : "current_season");

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Top Clans by Victory Points

    #region Clan's Provinces

    public IResponse GetClansProvinces(long clanId, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreateClansProvincesRequestUri(clanId, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateClansProvincesRequestUri(long clanId, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var sb = GetDefaultUri(RequestTarget.ClanProvinces, language, accessToken, responseFields);
      sb.AppendFormat("&clan_id={0}", clanId);

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Clan's Provinces

    #region Clan's Victory Points

    [Obsolete("Warning. This method is deprecated and will be removed soon.")]
    public IResponse GetClansVictoryPoints(long[] clanIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreateClansVictoryPointsRequestUri(clanIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateClansVictoryPointsRequestUri(IEnumerable<long> clanIds, Language? language, string accessToken, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.ClanVictorypoints, language, accessToken, responseFields);
      sb.AppendFormat("&clan_id={0}", string.Join(",", clanIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Clan's Victory Points

    #region Clan Member Details

    public IResponse GetClanMemberInfo(long memberIds)
    {
      return GetClanMemberInfo(new[] { memberIds });
    }

    public IResponse GetClanMemberInfo(long[] memberIds, Language? language = null, string accessToken = "", string responseFields = "")
    {
      var requestUri = CreateClanMemberInfoRequestUri(memberIds, language, accessToken, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateClanMemberInfoRequestUri(IEnumerable<long> memberIds, Language? language, string accessToken, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.ClanMembersinfo, language, accessToken, responseFields);
      sb.AppendFormat("&member_id={0}", string.Join(",", memberIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Clan Member Details

    #endregion Clans

    #region Encyclopedia

    #region List Vehicles

    public IResponse GetAllVehicles(Language? language = null, string responseFields = "")
    {
      var requestUri = CreateAllVehiclesRequestUri(language, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateAllVehiclesRequestUri(Language? language, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaTanks, language, responseFields: responseFields);

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion List Vehicles

    #region Vehicle Details

    public IResponse GetVehicleDetails(long tankId)
    {
      return GetVehicleDetails(new[] { tankId }, _settings.Language, null);
    }

    public IResponse GetVehicleDetails(long[] tankIds, Language? language = null, string responseFields = "")
    {
      var requestUri = CreateVehicleDetailssRequestUri(tankIds, language, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateVehicleDetailssRequestUri(IEnumerable<long> tankIds, Language? language, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaTankInfo, language, responseFields: responseFields);
      sb.AppendFormat("&tank_id={0}", string.Join(",", tankIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Vehicle Details

    #region Engines

    public IResponse GetEngines(long moduleId)
    {
      return GetEngines(new[] { moduleId });
    }

    public IResponse GetEngines(long[] moduleIds, Language? language = null, Nation nation = Nation.All, string responseFields = "")
    {
      var requestUri = CreateEnginesRequestUri(moduleIds, language, nation, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateEnginesRequestUri(long[] moduleIds, Language? language, Nation nation, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaTankEngines, language, responseFields: responseFields);

      if (nation != Nation.All)
        sb.AppendFormat("&nation={0}", GetNationName(nation));

      if (moduleIds.Length > 0)
        sb.AppendFormat("&module_id={0}", string.Join(",", moduleIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Engines

    #region Turrets

    public IResponse GetTurrets(long moduleId)
    {
      return GetTurrets(new[] { moduleId });
    }

    public IResponse GetTurrets(long[] moduleIds, Language? language = null, Nation nation = Nation.All, string responseFields = "")
    {
      var requestUri = CreateTurretsRequestUri(moduleIds, language, nation, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateTurretsRequestUri(long[] moduleIds, Language? language, Nation nation, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaTankTurrets, language, responseFields: responseFields);

      if (nation != Nation.All)
        sb.AppendFormat("&nation={0}", GetNationName(nation));

      if (moduleIds.Length > 0)
        sb.AppendFormat("&module_id={0}", string.Join(",", moduleIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Turrets

    #region Radios

    public IResponse GetRadios(long moduleId)
    {
      return GetRadios(new[] { moduleId });
    }

    public IResponse GetRadios(long[] moduleIds, Language? language = null, Nation nation = Nation.All, string responseFields = "")
    {
      var requestUri = CreateRadiosRequestUri(moduleIds, language, nation, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateRadiosRequestUri(long[] moduleIds, Language? language, Nation nation, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaTankRadios, language, responseFields: responseFields);

      if (nation != Nation.All)
        sb.AppendFormat("&nation={0}", GetNationName(nation));

      if (moduleIds.Length > 0)
        sb.AppendFormat("&module_id={0}", string.Join(",", moduleIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Radios

    #region Suspensions

    public IResponse GetChassis(long moduleId)
    {
      return GetChassis(new[] { moduleId });
    }

    public IResponse GetChassis(long[] moduleIds, Language? language = null, Nation nation = Nation.All, string responseFields = "")
    {
      var requestUri = CreateSuspensionsRequestUri(moduleIds, language, nation, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateSuspensionsRequestUri(long[] moduleIds, Language? language, Nation nation, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaTankChassis, language, responseFields: responseFields);

      if (nation != Nation.All)
        sb.AppendFormat("&nation={0}", GetNationName(nation));

      if (moduleIds.Length > 0)
        sb.AppendFormat("&module_id={0}", string.Join(",", moduleIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Suspensions

    #region Guns

    public IResponse GetGuns(long moduleId)
    {
      return GetGuns(new[] { moduleId });
    }

    public IResponse GetGuns(long[] moduleIds, Language? language = null, Nation nation = Nation.All, string responseFields = "")
    {
      var requestUri = CreateGunsRequestUri(moduleIds, language, nation, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateGunsRequestUri(long[] moduleIds, Language? language, Nation nation, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaTankGuns, language, responseFields: responseFields);

      if (nation != Nation.All)
        sb.AppendFormat("&nation={0}", GetNationName(nation));

      if (moduleIds.Length > 0)
        sb.AppendFormat("&module_id={0}", string.Join(",", moduleIds));

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Guns

    #region Achievements

    public IResponse GetAchievements(Language? language = null, string responseFields = "")
    {
      var requestUri = CreateAchievementsRequestUri(language, responseFields);
      return GetRequestResponse(requestUri);
    }

    private string CreateAchievementsRequestUri(Language? language, string responseFields)
    {
      var sb = GetDefaultUri(RequestTarget.EncyclopediaAchievements, language, responseFields);
      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Achievements

    #endregion Encyclopedia

    #region Player's vehicles

    #region Vehicle statistics

    public IResponse GetTankStats(long accountId, long[] tankIds, Language? language = null, string responseFields = "", string accessToken = "", bool? inGarage = null)
    {
      var requestUri = CreateTankStatsRequestUri(accountId, tankIds, language, accessToken, responseFields, inGarage);
      return GetRequestResponse(requestUri);
    }

    private string CreateTankStatsRequestUri(long accountId, long[] tankIds, Language? language, string accessToken, string responseFields, bool? inGarage)
    {
      var sb = GetDefaultUri(RequestTarget.TanksStats, language, accessToken, responseFields);
      sb.AppendFormat("&account_id={0}", accountId);

      if (tankIds.Length > 0)
        sb.AppendFormat("&tank_id={0}", string.Join(",", tankIds));

      if (inGarage.HasValue)
        sb.AppendFormat("&in_garage={0}", inGarage.Value ? 1 : 0);

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Vehicle statistics

    #region Vehicle achievements

    public IResponse GetTankAchievements(long accountId, long[] tankIds, Language? language = null, string responseFields = "", string accessToken = "", bool? inGarage = null)
    {
      var requestUri = CreateTankAchievementsRequestUri(accountId, tankIds, language, accessToken, responseFields, inGarage);
      return GetRequestResponse(requestUri);
    }

    private string CreateTankAchievementsRequestUri(long accountId, long[] tankIds, Language? language, string accessToken, string responseFields, bool? inGarage)
    {
      var sb = GetDefaultUri(RequestTarget.TanksAchievements, language, accessToken, responseFields);
      sb.AppendFormat("&account_id={0}", accountId);

      if (tankIds.Length > 0)
        sb.AppendFormat("&tank_id={0}", string.Join(",", tankIds));

      if (inGarage.HasValue)
        sb.AppendFormat("&in_garage={0}", inGarage.Value ? 1 : 0);

      var requestUri = sb.ToString();

      return requestUri;
    }

    #endregion Vehicle achievements

    #endregion Player's vehicles

    #region General methods

    private StringBuilder GetDefaultUri(RequestTarget target, Language? language, string accessToken = null, string responseFields = null)
    {
      if (language == null)
        language = _settings.Language;

      var languageField = GetLanguageName(language.Value);

      var sb = new StringBuilder(_settings.RequestProtocol == RequestProtocol.Http ? "http://" : "https://");

      sb.Append(_defaultApiUri);
      if (!_defaultApiUri.EndsWith("/"))
        sb.Append('/');

      sb.AppendFormat("{0}/?application_id={1}&language={2}", _targets[target], _applicationId, languageField);

      if (!string.IsNullOrWhiteSpace(responseFields))
        sb.AppendFormat("&fields={0}", responseFields);

      if (!string.IsNullOrWhiteSpace(accessToken))
        sb.AppendFormat("&access_token={0}", accessToken);

      return sb;
    }

    private Response GetRequestResponse(string requestUri)
    {
      var request = new Request(requestUri);
      var output = request.GetResponse();
      var result = JsonConvert.DeserializeObject<Response>(output);

      return result;
    }

    private static string GetNationName(Nation nation)
    {
      var name = Enum.GetName(typeof(Nation), nation);
      return name != null ? name.ToLowerInvariant() : string.Empty;
    }

    private static string GetLanguageName(Language language)
    {
      var name = Enum.GetName(typeof(Language), language);
      return name != null ? name.ToLowerInvariant() : string.Empty;
    }

    private static string ToLowerInvariant(SearchType searchType)
    {
      var name = Enum.GetName(typeof(SearchType), searchType);
      return name != null ? name.ToLowerInvariant() : string.Empty;
    }

    #endregion
  }
}