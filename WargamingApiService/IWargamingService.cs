﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.Text;

//namespace WargamingApiService
//{
//  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWargamingService" in both code and config file together.
//  [ServiceContract] public interface IWargamingService
//  {
//    [OperationContract]
//    string GetData(int value);

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
using System.ServiceModel;
using WargamingTypesLibrary.Enums;

namespace WargamingApiService
{
  /// <summary>
  /// Represents your application identified by an application id.
  /// You can get one from WG's developer room: http://wargaming.net/developers/
  /// </summary>
  [ServiceContract]
  public interface IWargamingService
  {
    #region Account

    #region Search Players

    /// <summary>
    /// Method returns partial list of players. The list is filtered by initial characters of user name and sorted alphabetically.
    /// </summary>
    /// <param name="searchTerm">search string</param>
    /// <param name="language">language</param>
    /// <param name="searchType">search type: 'startswith' or 'exact'</param>
    /// <param name="limit">Maximum number of results to be returned. limit max value is 100</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    [OperationContract]
    IResponse SearchPlayers(string searchTerm, SearchType searchType, int limit, Language language, string responseFields);

    #endregion Search Players

    #region Player Info

    /// <summary>
    /// Method returns player details.
    /// </summary>
    /// <param name="accountId">player account id</param>
    /// <returns></returns>
    IResponse GetPlayerInfo(long accountId);

    /// <summary>
    /// Method returns player details.
    /// </summary>
    /// <param name="accountIds">list of player account ids</param>
    /// <returns></returns>
    IResponse GetPlayerInfo(long[] accountIds);

    /// <summary>
    /// Method returns player details.
    /// </summary>
    /// <param name="accountIds">list of player account ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetPlayerInfo(long[] accountIds, Language language, string accessToken, string responseFields);

    #endregion Player Info

    #region Player Ratings

    /// <summary>
    /// Method returns details on player's ratings.
    /// </summary>
    /// <param name="accountId">player account id</param>
    /// <returns></returns>
    [Obsolete("Method is deprecated and will be removed soon.")]
    IResponse GetPlayerRatings(long accountId);

    /// <summary>
    /// Method returns details on player's ratings.
    /// </summary>
    /// <param name="accountIds">list of player account ids</param>
    /// <returns></returns>
    [Obsolete("Method is deprecated and will be removed soon.")]
    IResponse GetPlayerRatings(long[] accountIds);

    /// <summary>
    /// Method returns details on player's ratings.
    /// </summary>
    /// <param name="accountIds">list of player account ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    [Obsolete("Method is deprecated and will be removed soon.")]
    IResponse GetPlayerRatings(long[] accountIds, Language language, string accessToken, string responseFields);

    #endregion Player Ratings

    #region Player Tanks

    /// <summary>
    /// Method returns details on player's vehicles.
    /// </summary>
    /// <param name="accountId">player account id</param>
    /// <returns></returns>
    IResponse GetPlayerVehicles(long accountId);

    /// <summary>
    /// Method returns details on player's vehicles.
    /// </summary>
    /// <param name="accountIds">list of player account ids</param>
    /// <returns></returns>
    IResponse GetPlayerVehicles(long[] accountIds);

    /// <summary>
    /// Method returns details on player's vehicles.
    /// </summary>
    /// <param name="accountIds">list of player account ids</param>
    /// <param name="tankIds">list of player vehicle ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetPlayerVehicles(long[] accountIds, long[] tankIds, Language language, string accessToken, string responseFields);

    #endregion Player Tanks

    #region Player Achievements

    /// <summary>
    /// Returns a list of player achievements.
    /// </summary>
    /// <param name="accountId">player account id</param>
    /// <returns></returns>
    IResponse GetPlayerAchievements(long accountId);

    /// <summary>
    /// Returns a list of player achievements.
    /// </summary>
    /// <param name="accountId">list of player account ids</param>
    /// <returns></returns>
    IResponse GetPlayerAchievements(long[] accountId);

    /// <summary>
    /// Returns a list of player achievements.
    /// </summary>
    /// <param name="accountIds">list of player account ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetPlayerAchievements(long[] accountIds, Language language, string accessToken, string responseFields);

    #endregion Player Achievements

    #endregion Account

    #region Authentication

    /// <summary>
    /// Method authenticates user based on Wargaming.net ID (OpenID). To log in, player must enter email and password used for creating account.
    /// The way I want to implement this might not be accepted. This will, most probably, be dropped in the future.
    /// </summary>
    /// <param name="username">username</param>
    /// <param name="password">password</param>
    /// <returns></returns>
    string AccessToken(string username, string password);

    /// <summary>
    /// Method generates new access_token based on the current token.
    /// This method is used when the player is still using the application but the current access_token is about to expire.
    /// </summary>
    /// <param name="accessToken">access token</param>
    /// <returns></returns>
    string ProlongToken(string accessToken);

    /// <summary>
    /// Method deletes user's access_token.
    /// After this method is called, access_token becomes invalid.
    /// </summary>
    /// <param name="accessToken">access token</param>
    /// <returns></returns>
    string Logout(string accessToken);

    #endregion Authentication

    #region Clans

    #region Search Clans

    /// <summary>
    /// Method returns partial list of clans filtered by initial characters of clan name or tag. The list is sorted by clan nameby default.
    /// </summary>
    /// <param name="searchTerm">search string</param>
    /// <returns></returns>
    IResponse SearchClans(string searchTerm);

    /// <summary>
    /// Method returns partial list of clans filtered by initial characters of clan name or tag. The list is sorted by clan nameby default.
    /// </summary>
    /// <param name="searchTerm">search string</param>
    /// <param name="limit">Maximum number of results to be returned. limit max value is 100</param>
    /// <returns></returns>
    IResponse SearchClans(string searchTerm, int limit);

    /// <summary>
    /// Method returns partial list of clans filtered by initial characters of clan name or tag. 
    /// </summary>
    /// <param name="searchTerm">search string</param>
    /// <param name="language">language</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <param name="limit">Maximum number of results to be returned. limit max value is 100</param>
    /// <param name="orderby">The list is sorted by clan name (default), creation date, tag, or size.</param>
    /// <returns></returns>
    IResponse SearchClans(string searchTerm, Language language, string responseFields, int limit, string orderby);

    #endregion Search Clans

    #region Clan Details

    /// <summary>
    /// Method returns clan details.
    /// </summary>
    /// <param name="clanId">clan id</param>
    /// <returns></returns>
    IResponse GetClanDetails(long clanId);

    /// <summary>
    /// Method returns clan details.
    /// </summary>
    /// <param name="clanIds">list of clan ids</param>
    /// <returns></returns>
    IResponse GetClanDetails(long[] clanIds);

    /// <summary>
    /// Method returns clan details.
    /// </summary>
    /// <param name="clanIds">list of clan ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetClanDetails(long[] clanIds, Language language, string accessToken, string responseFields);

    #endregion Clan Details

    #region Clan's Battles

    /// <summary>
    /// Method returns list of clan's battles.
    /// </summary>
    /// <param name="clanId">clan id</param>
    /// <returns></returns>
    IResponse GetClansBattles(long clanId);

    /// <summary>
    /// Method returns list of clan's battles.
    /// </summary>
    /// <param name="clanIds">list of clan ids</param>
    /// <returns></returns>
    IResponse GetClansBattles(long[] clanIds);

    /// <summary>
    /// Method returns list of clan's battles.
    /// </summary>
    /// <param name="clanIds">list of clan ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetClansBattles(long[] clanIds, Language language, string accessToken, string responseFields);

    #endregion Clan's Battles

    #region Top Clans by Victory Points

    /// <summary>
    /// Method returns top 100 clans sorted by rating.
    /// </summary>
    /// <returns></returns>
    IResponse GetTopClansByVictoryPoints();

    /// <summary>
    /// Method returns top 100 clans sorted by rating.
    /// </summary>
    /// <param name="time">Time delta. Valid values: current_season (default), current_step</param>
    /// <returns></returns>
    IResponse GetTopClansByVictoryPoints(TimeDelta time);

    /// <summary>
    /// Method returns top 100 clans sorted by rating.
    /// </summary>
    /// <param name="time">Time delta. Valid values: current_season (default), current_step</param>
    /// <param name="language">language</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetTopClansByVictoryPoints(TimeDelta time, Language language, string responseFields);

    #endregion Top Clans by Victory Points

    #region Clan's Provinces

    /// <summary>
    /// Method returns list of clan's provinces.
    /// </summary>
    /// <param name="clanId">clan id</param>
    /// <returns></returns>
    IResponse GetClansProvinces(long clanId);

    /// <summary>
    /// Method returns list of clan's provinces.
    /// </summary>
    /// <param name="clanId">clan id</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetClansProvinces(long clanId, Language language, string accessToken, string responseFields);

    #endregion Clan's Provinces

    #region Clan's Victory Points

    /// <summary>
    /// Method returns number of clan victory points.
    /// </summary>
    /// <param name="clanId">clan id</param>
    /// <returns></returns>
    IResponse GetClansVictoryPoints(long clanId);

    /// <summary>
    /// Method returns number of clan victory points.
    /// </summary>
    /// <param name="clanIds">list of clan ids</param>
    /// <returns></returns>
    IResponse GetClansVictoryPoints(long[] clanIds);

    /// <summary>
    /// Method returns number of clan victory points.
    /// </summary>
    /// <param name="clanIds">list of clan ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetClansVictoryPoints(long[] clanIds, Language language, string accessToken, string responseFields);

    #endregion Clan's Victory Points

    #region Clan Member Details

    /// <summary>
    /// Method returns clan member info.
    /// </summary>
    /// <param name="memberId">member id</param>
    /// <returns></returns>
    IResponse GetClanMemberInfo(long memberId);

    /// <summary>
    /// Method returns clan member info.
    /// </summary>
    /// <param name="memberIds">list of clan member ids</param>
    /// <returns></returns>
    IResponse GetClanMemberInfo(long[] memberIds);

    /// <summary>
    /// Method returns clan member info.
    /// </summary>
    /// <param name="memberIds">list of clan member ids</param>
    /// <param name="language">language</param>
    /// <param name="accessToken">access token</param>
    /// <param name="responseFields">fields to be returned. Null or string.Empty for all</param>
    /// <returns></returns>
    IResponse GetClanMemberInfo(long[] memberIds, Language language, string accessToken, string responseFields);

    #endregion Clan Member Details

    #endregion Clans

    #region Encyclopedia

    #region List Vehicles

    /// <summary>
    /// Method returns list of all vehicles from Tankopedia.
    /// </summary>
    /// <returns></returns>
    IResponse GetAllVehicles();

    /// <summary>
    /// Method returns list of all vehicles from Tankopedia.
    /// </summary>
    /// <param name="language">language</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetAllVehicles(Language language, string responseFields);

    #endregion List Vehicles

    #region Vehicle Details

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tankId"></param>
    /// <returns></returns>
    IResponse GetVehicleDetails(long tankId);

    /// <summary>
    /// Method returns list of all vehicles from Tankopedia.
    /// </summary>
    /// <returns></returns>
    IResponse GetVehicleDetails(long[] tankIds);

    /// <summary>
    /// Method returns list of all vehicles from Tankopedia.
    /// </summary>
    /// <param name="tankIds">list of player vehicle ids</param>
    /// <param name="language">language</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetVehicleDetails(long[] tankIds, Language language, string responseFields);

    #endregion Vehicle Details

    #region Engines

    /// <summary>
    /// Method returns list of engines.
    /// </summary>
    /// <returns></returns>
    IResponse GetEngines();

    /// <summary>
    /// Method returns list of engines.
    /// </summary>
    /// <param name="moduleId">module id - not mandatory</param>
    /// <returns></returns>
    IResponse GetEngines(long moduleId);

    /// <summary>
    /// Method returns list of engines.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <returns></returns>
    IResponse GetEngines(long[] moduleIds);

    /// <summary>
    /// Method returns list of engines.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <param name="language">language</param>
    /// <param name="nation">nation</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetEngines(long[] moduleIds, Language language, Nation nation, string responseFields);

    #endregion Engines

    #region Turrets

    /// <summary>
    /// Method returns list of turrets.
    /// </summary>
    /// <returns></returns>
    IResponse GetTurrets();

    /// <summary>
    /// Method returns list of turrets.
    /// </summary>
    /// <param name="moduleId">module id - not mandatory</param>
    /// <returns></returns>
    IResponse GetTurrets(long moduleId);

    /// <summary>
    /// Method returns list of turrets.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <returns></returns>
    IResponse GetTurrets(long[] moduleIds);

    /// <summary>
    /// Method returns list of turrets.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <param name="language">language</param>
    /// <param name="nation">nation</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetTurrets(long[] moduleIds, Language language, Nation nation, string responseFields);

    #endregion Turrets

    #region Radios

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <returns></returns>
    IResponse GetRadios();

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <param name="moduleId">module id - not mandatory</param>
    /// <returns></returns>
    IResponse GetRadios(long moduleId);

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <returns></returns>
    IResponse GetRadios(long[] moduleIds);

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <param name="language">language</param>
    /// <param name="nation">nation</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetRadios(long[] moduleIds, Language language, Nation nation, string responseFields);

    #endregion Radios

    #region Suspensions

    /// <summary>
    /// Method returns list of suspensions.
    /// </summary>
    /// <returns></returns>
    IResponse GetSuspensions();

    /// <summary>
    /// Method returns list of suspensions.
    /// </summary>
    /// <param name="moduleId">module id - not mandatory</param>
    /// <returns></returns>
    IResponse GetSuspensions(long moduleId);

    /// <summary>
    /// Method returns list of suspensions.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <returns></returns>
    IResponse GetSuspensions(long[] moduleIds);

    /// <summary>
    /// Method returns list of suspensions.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <param name="language">language</param>
    /// <param name="nation">nation</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetSuspensions(long[] moduleIds, Language language, Nation nation, string responseFields);

    #endregion Suspensions

    #region Guns

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <returns></returns>
    IResponse GetGuns();

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <param name="moduleId">module id - not mandatory</param>
    /// <returns></returns>
    IResponse GetGuns(long moduleId);

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <returns></returns>
    IResponse GetGuns(long[] moduleIds);

    /// <summary>
    /// Method returns list of radios.
    /// </summary>
    /// <param name="moduleIds">list of modules - not mandatory</param>
    /// <param name="language">language</param>
    /// <param name="nation">nation</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetGuns(long[] moduleIds, Language language, Nation nation, string responseFields);

    #endregion Guns

    #region Achievements

    /// <summary>
    /// Warning. This method runs in test mode.
    /// </summary>
    /// <returns></returns>
    IResponse GetAchievements();

    /// <summary>
    /// Warning. This method runs in test mode.
    /// </summary>
    /// <param name="language">language</param>
    /// <param name="responseFields">fields to be returned.</param>
    /// <returns></returns>
    IResponse GetAchievements(Language language, string responseFields);

    #endregion Achievements

    #endregion Encyclopedia

    #region Player's vehicles

    #region Vehicle statistics

    /// <summary>
    /// Method returns overall statistics, Tank Company statistics, and clan statistics per each vehicle for a user.
    /// Warning. This method runs in test mode.
    /// </summary>
    /// <param name="accountId">account id</param>
    /// <returns></returns>
    IResponse GetTankStats(long accountId);

    /// <summary>
    /// Method returns overall statistics, Tank Company statistics, and clan statistics per each vehicle for each user.
    /// Warning. This method runs in test mode.
    /// </summary>
    /// <param name="accountId">account id</param>
    /// <param name="tankIds">list of player vehicle ids</param>
    /// <param name="language">language</param>
    /// <param name="responseFields">fields to be returned</param>
    /// <param name="accessToken">access token</param>
    /// <param name="inGarage">Filter by vehicle availability in the Garage. If the parameter is not specified, all vehicles are returned. Valid values: "1" — Return vehicles available in the Garage. "0" — Return vehicles that are no longer in the Garage.</param>
    /// <returns></returns>
    IResponse GetTankStats(long accountId, long[] tankIds, Language language, string responseFields, string accessToken, bool? inGarage);

    #endregion Vehicle statistics

    #region Vehicle achievements

    /// <summary>
    /// Method returns list of vehicles and achievements per vehicle for a user.
    /// Warning. This method runs in test mode.
    /// </summary>
    /// <param name="accountId">account id</param>
    /// <returns></returns>
    IResponse GetTankAchievements(long accountId);

    /// <summary>
    /// Method returns list of vehicles and achievements per vehicle a user.
    /// Warning. This method runs in test mode.
    /// </summary>
    /// <param name="accountId">account id</param>
    /// <param name="tankIds">list of player vehicle ids</param>
    /// <param name="language">language</param>
    /// <param name="responseFields">fields to be returned</param>
    /// <param name="accessToken">access token</param>
    /// <param name="inGarage">Filter by vehicle availability in the Garage. If the parameter is not specified, all vehicles are returned. Valid values: "1" — Return vehicles available in the Garage. "0" — Return vehicles that are no longer in the Garage.</param>
    /// <returns></returns>
    IResponse GetTankAchievements(long accountId, long[] tankIds, Language language, string responseFields, string accessToken, bool? inGarage);

    #endregion Vehicle achievements

    #endregion Player's vehicles
  }
}
