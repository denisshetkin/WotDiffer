﻿using MvcApplication.Models.Enums;

namespace MvcApplication.Models.Entities
{
  public abstract class BaseStatistics
  {
    public long BattleAvgXp { get; set; }
    public long Battles { get; set; }
    public long CapturePoints { get; set; }
    public long DamageDealt { get; set; }
    public long DamageReceived { get; set; }
    public long Draws { get; set; }
    public long DroppedCapturePoints { get; set; }
    public long Frags { get; set; }
    public long Hits { get; set; }
    public long HitsPercent { get; set; }
    public long Losses { get; set; }
    public long Shots { get; set; }
    public long Spotted { get; set; }
    public long SurvivedBattles { get; set; }
    public long Wins { get; set; }
    public long Xp { get; set; }
    public abstract StatisticsType StatisticsType { get; }
  }
}
