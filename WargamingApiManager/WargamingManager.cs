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
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using WargamingApiManager.Entities.ClanDetails;
using WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Achievements;
using WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Modules;
using WargamingApiManager.Entities.PlayerDetails;
using WargamingApiManager.Interfaces;
using WargamingApiService;
using WargamingTypesLibrary.Enums;
using Newtonsoft.Json;


namespace WotApi
{
  /// <summary>
  /// Represents your application identified by an application id.
  /// You can get one from 's developer room: http://wargaming.net/developers/
  /// </summary>
  public class WargamingManager : IWargamingApiManager
  {
    private readonly string _applicationId;
    private readonly Settings _settings;
    private readonly WargamingService _service;

    #region Constructors

    public WargamingManager(string applicationId)
    {
      _applicationId = applicationId;
      _settings = new Settings();

      _service = new WargamingService(_applicationId, _settings);
    }

    public WargamingManager(string applicationId, Settings settings)
      : this(applicationId)
    {
      _settings = settings;
    }

    #endregion Constructors

    #region Account

    #region Search Players

    public List<Player> SearchPlayers(string searchTerm)
    {
      return SearchPlayers(searchTerm, SearchType.StartsWith, 100, _settings.Language, null);
    }

    public List<Player> SearchPlayers(string searchTerm, SearchType searchType)
    {
      return SearchPlayers(searchTerm, searchType, 100, _settings.Language, null);
    }

    public List<Player> SearchPlayers(string searchTerm, SearchType searchType, int limit)
    {
      return SearchPlayers(searchTerm, searchType, limit, _settings.Language, null);
    }

    public List<Player> SearchPlayers(string searchTerm, SearchType searchType, int limit, Language language, string responseFields)
    {
      var response = _service.SearchPlayers(searchTerm, searchType, limit, language, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Player>>(response.Data.ToString());

      return obj;
    }

    #endregion Search Players

	//asd
	
    #region Player Info

    public List<Player> GetPlayerInfo(long accountId)
    {
      return GetPlayerInfo(new[] { accountId }, _settings.Language, null, null);
    }

    public List<Player> GetPlayerInfo(long[] accountIds)
    {
      return GetPlayerInfo(accountIds, _settings.Language, null, null);
    }

    public List<Player> GetPlayerInfo(long[] accountIds, Language language, string accessToken, string responseFields)
    {
      var response = _service.GetPlayerInfo(accountIds, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Player>>(response.Data.ToString());

      return obj;
    }

    #endregion Player Info

    #region Player Ratings

    [Obsolete("Method has been removed.")]
    [ExcludeFromCodeCoverage]
    public object GetPlayerRatings(long accountId)
    {
      return GetPlayerRatings(new[] { accountId });
    }

    [Obsolete("Method has been removed.")]
    [ExcludeFromCodeCoverage]
    public object GetPlayerRatings(long[] accountIds)
    {
      return GetPlayerRatings(accountIds, _settings.Language, null, null);
    }

    [Obsolete("Method has been removed.")]
    public object GetPlayerRatings(long[] accountIds, Language language, string accessToken, string responseFields)
    {
      throw new NotImplementedException();
    }

    #endregion Player Ratings

    #region Player Vehicles

    public List<Player> GetPlayerVehicles(long accountId)
    {
      return GetPlayerVehicles(new[] { accountId }, new long[0], _settings.Language, null, null);
    }

    public List<Player> GetPlayerVehicles(long[] accountIds)
    {
      return GetPlayerVehicles(accountIds, new long[0], _settings.Language, null, null);
    }

    public List<Player> GetPlayerVehicles(long[] accountIds, long[] tankIds, Language language, string accessToken, string responseFields)
    {
      var response = _service.GetPlayerVehicles(accountIds, tankIds, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Player>>(response.Data.ToString());

      //var output = GetRequestResponse(requestUri);
      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);
      //var obj = new Response<List<Player>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Player>(wgRawResponse.Count)
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var accountId in accountIds)
      //{
      //    var accountIdString = accountId.ToString();
      //    var userTanks = jObject[accountIdString].ToObject(typeof(List<Tank>)) as List<Tank>;

      //    var player = new Player { AccountId = accountId, Tanks = userTanks };

      //    foreach (var tank in player.Tanks)
      //    {
      //        tank.Player = player;
      //    }

      //    obj.Data.Add(player);
      //}

      return obj;
    }

    #endregion Player Vehicles

    #region Player Achievements

    public List<Achievement> GetPlayerAchievements(long accountId)
    {
      var response = _service.GetPlayerAchievements(accountId);
      var obj = JsonConvert.DeserializeObject<List<Achievement>>(response.Data.ToString());

      //var response = GetPlayerAchievements(new[] { accountId });

      //var partialResult = new Response<List<Achievement>
      //{
      //    Status = result.Status,
      //    Count = result.Count,
      //    Data = new List<Achievement>(),
      //};

      //// if we get a bad/empty answer
      //if (result.Status != "ok" || result.Count == 0 || result.Data.Count == 0)
      //    return partialResult;

      //// otherwise populate our object
      //partialResult.Count = result.Data[0].Achievements.Count;
      //partialResult.Data = result.Data[0].Achievements;

      return obj;
    }

    public List<Player> GetPlayerAchievements(long[] accountIds)
    {
      return GetPlayerAchievements(accountIds, _settings.Language, null, null);
    }

    public List<Player> GetPlayerAchievements(long[] accountIds, Language language, string accessToken, string responseFields)
    {

      var response = _service.GetPlayerAchievements(accountIds, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Player>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Player>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Player>(wgRawResponse.Count)
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var accountId in accountIds)
      //{
      //    var accountIdString = accountId.ToString();
      //    var player = new Player { AccountId = accountId, Achievements = new List<Achievement>() };

      //    var jObjectAchievements = jObject[accountIdString]["achievements"];

      //    foreach (var jObjAchievement in jObjectAchievements)
      //    {
      //        var jProp = (JProperty)jObjAchievement;
      //        var achievement = new Achievement { Name = jProp.Name, TimesAchieved = jObjAchievement.ToObject<long>() };
      //        player.Achievements.Add(achievement);
      //    }

      //    obj.Data.Add(player);
      //}

      return obj;
    }

    #endregion Player Achievements

    #endregion Account

    #region Authentication

    [ExcludeFromCodeCoverage]
    public string AccessToken(string username, string password)
    {
      //var target = "auth/login";
      var accessToken = string.Empty;

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

    public List<Clan> SearchClans(string searchTerm)
    {
      return SearchClans(searchTerm, _settings.Language, null, 100, null);
    }

    public List<Clan> SearchClans(string searchTerm, int limit)
    {
      return SearchClans(searchTerm, _settings.Language, null, limit, null);
    }

    public List<Clan> SearchClans(string searchTerm, Language language, string responseFields, int limit, string orderby)
    {
      var response = _service.SearchClans(searchTerm, language, responseFields, limit, orderby);
      var obj = JsonConvert.DeserializeObject<List<Clan>>(response.Data.ToString());

      return obj;
    }

    #endregion Search Clans

    #region Clan Details

    public List<Clan> GetClanDetails(long clanId)
    {
      return GetClanDetails(new long[] { clanId }, _settings.Language, null, null);
    }

    public List<Clan> GetClanDetails(long[] clanIds)
    {
      return GetClanDetails(clanIds, _settings.Language, null, null);
    }

    public List<Clan> GetClanDetails(long[] clanIds, Language language, string accessToken, string responseFields)
    {
      var response = _service.GetClanDetails(clanIds, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Clan>>(response.Data.ToString());

      //// this is our raw response which we will parse later on
      //var rawResponse = JsonConvert.DeserializeObject<Response>(output);

      //// JObject accepts Language-INtegrated Queries over it, so it's our friend
      //var jObject = rawResponse.Data as JObject;

      //// copy the response details from the raw response to an actual response
      //var obj = new Response<List<Clan>
      //{
      //    Status = rawResponse.Status,
      //    Count = rawResponse.Count,
      //    Data = new List<Clan>(rawResponse.Count)
      //};

      //// were there any problems?
      //if (obj.Status != "ok")
      //    return obj;

      //// everything went fine
      //// let's begin with some nasty parsing :(
      //foreach (var clanId in clanIds)
      //{
      //    // I don't really like calling methods in the indexer - this should improve readability
      //    var stringClanId = clanId.ToString();

      //    // create our empty clan entity
      //    var clan = new Clan();

      //    // get the json string for the clan id
      //    var clanJsonString = jObject[stringClanId];

      //    // parse the json string and retrieve all the fields that we can
      //    clan = clanJsonString.ToObject<Clan>();

      //    #region parse members in clan

      //    // get the list of members array
      //    var listOfMembers = clanJsonString["members"];

      //    // any members? -> the answer is expected to be true, but we ask anyway
      //    if (listOfMembers.HasValues)
      //    {
      //        // get the children json strings for each member
      //        var listOfActualMembers = listOfMembers.Children();

      //        // go through our list
      //        foreach (var member in listOfActualMembers)
      //        {
      //            // get the json string
      //            var memberJsonString = member.First;

      //            // parse the json string and get a Member entity
      //            var parsedMember = memberJsonString.ToObject<Member>();

      //            // add each parsed member to our clan list
      //            clan.Members.Add(parsedMember);
      //        }
      //    }

      //    #endregion parse members in clan

      //    // add the clan to the our actual response data
      //    obj.Data.Add(clan);
      //}

      return obj;
    }

    #endregion Clan Details

    #region Clan's Battles

    public List<Battle> GetClansBattles(long clanId)
    {
      return GetClansBattles(new long[] { clanId }, _settings.Language, null, null);
    }

    public List<Battle> GetClansBattles(long[] clanIds)
    {
      return GetClansBattles(clanIds, _settings.Language, null, null);
    }

    public List<Battle> GetClansBattles(long[] clanIds, Language language, string accessToken, string responseFields)
    {
      var response = _service.GetClansBattles(clanIds, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Battle>>(response.Data.ToString());


      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);
      //var obj = new Response<List<Battle>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Battle>(wgRawResponse.Count)
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //// nastiest parsing so far
      //foreach (var clanId in clanIds)
      //{
      //    var clanBattle = new Battle { Clan = new Clan { Id = clanId } };
      //    var clanIdString = clanId.ToString();
      //    var clanBattleJObject = jObject[clanIdString].First;

      //    foreach (var provinceJObject in clanBattleJObject["provinces"])
      //    {
      //        var province = new Province { Name = provinceJObject.ToString() };

      //        clanBattle.Provinces.Add(province);
      //    }

      //    clanBattle.Started = clanBattleJObject["started"].ToObject<bool>();

      //    clanBattle.StartTime = clanBattleJObject["time"].ToObject<long>();

      //    foreach (var arenaJObject in clanBattleJObject["arenas"])
      //    {
      //        var arena = new Province { ArenaNameLocalized = arenaJObject["name_i18n"].ToString(), ArenaName = arenaJObject["name"].ToString() };

      //        clanBattle.Arenas.Add(arena);
      //    }

      //    var battleType = clanBattleJObject["type"].ToString();

      //    if (battleType == "for_province")
      //        clanBattle.Type = BattleType.Province;
      //    else if (battleType == "meeting_engagement")
      //        clanBattle.Type = BattleType.Encounter;
      //    else
      //        clanBattle.Type = BattleType.Landing;

      //    obj.Data.Add(clanBattle);
      //}

      return obj;
    }

    #endregion Clan's Battles

    #region Top Clans by Victory Points

    public List<Clan> GetTopClansByVictoryPoints()
    {
      return GetTopClansByVictoryPoints(TimeDelta.Season);
    }

    public List<Clan> GetTopClansByVictoryPoints(TimeDelta time)
    {
      return GetTopClansByVictoryPoints(time, _settings.Language, null);
    }

    public List<Clan> GetTopClansByVictoryPoints(TimeDelta time, Language language, string responseFields)
    {
      var response = _service.GetTopClansByVictoryPoints(time, language, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Clan>>(response.Data.ToString());

      return obj;
    }

    #endregion Top Clans by Victory Points

    #region Clan's Provinces

    public List<Province> GetClansProvinces(long clanId)
    {
      return GetClansProvinces(clanId, _settings.Language, null, null);
    }

    public List<Province> GetClansProvinces(long clanId, Language language, string accessToken, string responseFields)
    {
      var response = _service.GetClansProvinces(clanId, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Province>>(response.Data.ToString());

      // get the raw response
      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //// this is the response we will return
      //var obj = new Response<List<Province>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Province>(wgRawResponse.Count)
      //};

      //// any errors? stop what we're doing and return the object
      //if (wgRawResponse.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //// nasty parsing, again :(
      //if (jObject.HasValues)
      //    foreach (var province in jObject.Children())
      //    {
      //        var provinceJsonString = province.First;

      //        var provinceObj = provinceJsonString.ToObject<Province>();

      //        obj.Data.Add(provinceObj);
      //    }

      return obj;
    }

    #endregion Clan's Provinces

    #region Clan's Victory Points

    [Obsolete("Warning. This method is deprecated and will be removed soon.")]
    public List<long> GetClansVictoryPoints(long clanId)
    {
      return GetClansVictoryPoints(new long[] { clanId }, _settings.Language, null, null);
    }

    [Obsolete("Warning. This method is deprecated and will be removed soon.")]
    public List<long> GetClansVictoryPoints(long[] clanIds)
    {
      return GetClansVictoryPoints(clanIds, _settings.Language, null, null);
    }

    [Obsolete("Warning. This method is deprecated and will be removed soon.")]
    public List<long> GetClansVictoryPoints(long[] clanIds, Language language, string accessToken, string responseFields)
    {
      var response = _service.GetClansVictoryPoints(clanIds, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<long>>(response.Data.ToString());


      //      var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);
      //var obj = new Response<List<long>
      //      {
      //          Count = wgRawResponse.Count,
      //          Status = wgRawResponse.Status,
      //          Data = new List<long>(wgRawResponse.Count)
      //      };

      //      if (obj.Status != "ok")
      //          return obj;

      //      var jObject = wgRawResponse.Data as JObject;

      //      foreach (var clanId in clanIds)
      //      {
      //          var clanIdString = clanId.ToString();

      //          var victoryPoints = jObject[clanIdString]["points"].ToObject<long>();

      //          obj.Data.Add(victoryPoints);
      //      }

      return obj;
    }

    #endregion Clan's Victory Points

    #region Clan Member Details

    public List<Member> GetClanMemberInfo(long memberId)
    {
      return GetClanMemberInfo(new long[] { memberId }, _settings.Language, null, null);
    }

    public List<Member> GetClanMemberInfo(long[] memberIds)
    {
      return GetClanMemberInfo(memberIds, _settings.Language, null, null);
    }

    public List<Member> GetClanMemberInfo(long[] memberIds, Language language, string accessToken, string responseFields)
    {
      var response = _service.GetClanMemberInfo(memberIds, language, accessToken, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Member>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Member>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Member>(wgRawResponse.Count)
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var memberId in memberIds)
      //{
      //    var memberIdString = memberId.ToString();

      //    var member = jObject[memberIdString].First.ToObject<Member>();

      //    obj.Data.Add(member);
      //}

      return obj;
    }

    #endregion Clan Member Details

    #endregion Clans

    #region Encyclopedia

    #region List Vehicles

    public List<Tank> GetAllVehicles()
    {
      return GetAllVehicles(_settings.Language, null);
    }

    public List<Tank> GetAllVehicles(Language language, string responseFields)
    {
      var response = _service.GetAllVehicles(language, responseFields);
      //var obj = JsonConvert.DeserializeObject<List<Tank>>(response.Data.ToString());

      var data = new List<Tank>(response.Meta.Count);
      foreach (var tankJObject in (response.Data as JObject).Children())
        data.Add(tankJObject.First.ToObject<Tank>());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Tank>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Tank>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var tankJObject in jObject.Children())
      //{
      //    var tank = tankJObject.First.ToObject<Tank>();

      //    obj.Data.Add(tank);
      //}

      return data;
    }

    #endregion List Vehicles

    #region Vehicle Details

    public List<Tank> GetVehicleDetails(long tankId)
    {
      return GetVehicleDetails(new[] { tankId }, _settings.Language, null);
    }

    public List<Tank> GetVehicleDetails(long[] tankIds)
    {
      return GetVehicleDetails(tankIds, _settings.Language, null);
    }

    public List<Tank> GetVehicleDetails(long[] tankIds, Language language, string responseFields)
    {
      var response = _service.GetVehicleDetails(tankIds, language, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Tank>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Tank>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Tank>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var tankJObject in jObject.Children())
      //{
      //    var tank = tankJObject.First.ToObject<Tank>();

      //    obj.Data.Add(tank);
      //}

      return obj;
    }

    #endregion Vehicle Details

    #region Engines

    public List<Engine> GetEngines()
    {
      return GetEngines(new long[0], _settings.Language, Nation.All, null);
    }

    public List<Engine> GetEngines(long moduleId)
    {
      return GetEngines(new[] { moduleId });
    }

    public List<Engine> GetEngines(long[] moduleIds)
    {
      return GetEngines(moduleIds, _settings.Language, Nation.All, null);
    }

    public List<Engine> GetEngines(long[] moduleIds, Language language, Nation nation, string responseFields)
    {
      var response = _service.GetTurrets(moduleIds, language, nation, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Engine>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Engine>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Engine>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var engineJsonString in jObject.Children())
      //{
      //    var engine = engineJsonString.First.ToObject<Engine>();

      //    obj.Data.Add(engine);
      //}

      return obj;
    }

    #endregion Engines

    #region Turrets

    public List<Turret> GetTurrets()
    {
      return GetTurrets(new long[0], _settings.Language, Nation.All, null);
    }

    public List<Turret> GetTurrets(long moduleId)
    {
      return GetTurrets(new[] { moduleId });
    }

    public List<Turret> GetTurrets(long[] moduleIds)
    {
      return GetTurrets(moduleIds, _settings.Language, Nation.All, null);
    }

    public List<Turret> GetTurrets(long[] moduleIds, Language language, Nation nation, string responseFields)
    {
      var response = _service.GetTurrets(moduleIds, language, nation, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Turret>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Turret>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Turret>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var turretJsonString in jObject.Children())
      //{
      //    var turret = turretJsonString.First.ToObject<Turret>();
      //    obj.Data.Add(turret);
      //}

      return obj;
    }

    #endregion Turrets

    #region Radios

    public List<Radio> GetRadios()
    {
      return GetRadios(new long[0], _settings.Language, Nation.All, null);
    }

    public List<Radio> GetRadios(long moduleId)
    {
      return GetRadios(new[] { moduleId });
    }

    public List<Radio> GetRadios(long[] moduleIds)
    {
      return GetRadios(moduleIds, _settings.Language, Nation.All, null);
    }

    public List<Radio> GetRadios(long[] moduleIds, Language language, Nation nation, string responseFields)
    {
      var response = _service.GetRadios(moduleIds, language, nation, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Radio>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Radio>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Radio>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var radioJsonString in jObject.Children())
      //{
      //    var radio = radioJsonString.First.ToObject<Radio>();
      //    obj.Data.Add(radio);
      //}

      return obj;
    }

    #endregion Radios

    #region Suspensions

    public List<Chassis> GetSuspensions()
    {
      return GetSuspensions(new long[0], _settings.Language, Nation.All, null);
    }

    public List<Chassis> GetSuspensions(long moduleId)
    {
      return GetSuspensions(new[] { moduleId });
    }

    public List<Chassis> GetSuspensions(long[] moduleIds)
    {
      return GetSuspensions(moduleIds, _settings.Language, Nation.All, null);
    }

    public List<Chassis> GetSuspensions(long[] moduleIds, Language language, Nation nation, string responseFields)
    {
      var response = _service.GetSuspensions(moduleIds, language, nation, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Chassis>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);

      //var obj = new Response<List<Chassis>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Chassis>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var suspensionJsonString in jObject.Children())
      //{
      //    var suspension = suspensionJsonString.First.ToObject<Chassis>();
      //    obj.Data.Add(suspension);
      //}

      return obj;
    }

    #endregion Suspensions

    #region Guns

    public List<Gun> GetGuns()
    {
      return GetGuns(new long[0], _settings.Language, Nation.All, null);
    }

    public List<Gun> GetGuns(long moduleId)
    {
      return GetGuns(new[] { moduleId });
    }

    public List<Gun> GetGuns(long[] moduleIds)
    {
      return GetGuns(moduleIds, _settings.Language, Nation.All, null);
    }

    public List<Gun> GetGuns(long[] moduleIds, Language language, Nation nation, string responseFields)
    {
      var response = _service.GetGuns(moduleIds, language, nation, responseFields);
      var obj = JsonConvert.DeserializeObject<List<Gun>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);
      //var obj = new Response<List<Gun>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<Gun>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var gubJsonString in jObject.Children())
      //{
      //    var gun = gubJsonString.First.ToObject<Gun>();
      //    obj.Data.Add(gun);
      //}

      return obj;
    }

    #endregion Guns

    #region Achievements

    public List<TankAchievement> GetAchievements()
    {
      return GetAchievements(_settings.Language, null);
    }

    public List<TankAchievement> GetAchievements(Language language, string responseFields)
    {
      var response = _service.GetAchievements(language, responseFields);
      var obj = JsonConvert.DeserializeObject<List<TankAchievement>>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);
      //var obj = new Response<List<TankAchievement>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new List<TankAchievement>(wgRawResponse.Count),
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;

      //foreach (var achievementJsonString in jObject.Children())
      //{
      //    var achievement = achievementJsonString.First.ToObject<TankAchievement>();
      //    obj.Data.Add(achievement);
      //}

      return obj;
    }

    #endregion Achievements

    #endregion Encyclopedia

    #region Player's vehicles

    #region Vehicle statistics

    public List<Tank> GetTankStats(long accountId)
    {
      return GetTankStats(accountId, new long[0], _settings.Language, null, null, null);
    }

    public List<Tank> GetTankStats(long accountId, long[] tankIds, Language language, string responseFields, string accessToken, bool? inGarage)
    {
      var response = _service.GetTankStats(accountId, tankIds, language, accessToken, responseFields, inGarage);
      var obj = JsonConvert.DeserializeObject<List<Tank>>(response.Data.ToString());


      //  var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);
      //var obj = new Response<List<Tank>
      //  {
      //      Status = wgRawResponse.Status,
      //      Count = wgRawResponse.Count,
      //      Data = new List<Tank>(wgRawResponse.Count)
      //  };

      //  if (obj.Status != "ok")
      //      return obj;

      //  var jObject = wgRawResponse.Data as JObject;
      //var accountIdString = accountId.ToString();
      //var tankStats = jObject[accountIdString].Children();

      //  foreach (var tankStatJObj in tankStats)
      //  {
      //      var tankStat = tankStatJObj.ToObject<Tank>();
      //    obj.Data.Add(tankStat);
      //  }

      return obj;
    }

    #endregion Vehicle statistics

    #region Vehicle achievements

    public Player GetTankAchievements(long accountId)
    {
      return GetTankAchievements(accountId, new long[0], _settings.Language, null, null, null);
    }

    public Player GetTankAchievements(long accountId, long[] tankIds, Language language, string responseFields, string accessToken, bool? inGarage)
    {
      var response = _service.GetTankAchievements(accountId, tankIds, language, accessToken, responseFields, inGarage);
      var obj = JsonConvert.DeserializeObject<Player>(response.Data.ToString());

      //var wgRawResponse = JsonConvert.DeserializeObject<Response>(output);
      //var obj = new Response<Player>
      //{
      //    Status = wgRawResponse.Status,
      //    Count = wgRawResponse.Count,
      //    Data = new Player { AccountId = accountId }
      //};

      //if (obj.Status != "ok")
      //    return obj;

      //var jObject = wgRawResponse.Data as JObject;
      //var accountIdString = accountId.ToString();
      //var tanks = jObject[accountIdString].Children();

      //foreach (var jObjTank in tanks)
      //{
      //    var tank = jObjTank.ToObject<Tank>();
      //    tank.Player = obj.Data;

      //    foreach (var jObjAchievement in jObjTank["achievements"].Children())
      //    {
      //        var jProp = (JProperty)jObjAchievement;
      //        var achievement = new Achievement { Name = jProp.Name, TimesAchieved = jObjAchievement.ToObject<long>() };

      //        tank.Achievements.Add(achievement);
      //    }

      //    obj.Data.Tanks.Add(tank);
      //}

      return obj;
    }

    #endregion Vehicle achievements

    #endregion Player's vehicles
  }
}