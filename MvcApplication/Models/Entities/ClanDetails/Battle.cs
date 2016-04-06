using System.Collections.Generic;
using MvcApplication.Models.Enums;

namespace MvcApplication.Models.Entities.ClanDetails
{
  public class Battle
  {
    public Clan Clan { get; set; }

    private IList<Province> _provinces = new List<Province>();
    public IList<Province> Provinces { get { return _provinces; } set { _provinces = value; } }

    public bool Started { get; set; }

    public long StartTime { get; set; }

    private IList<Province> _arenas = new List<Province>();
    public IList<Province> Arenas { get { return _arenas; } set { _arenas = value; } }

    public BattleType Type { get; set; }
  }
}