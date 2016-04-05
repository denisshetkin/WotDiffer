using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using WargamingApiManager.Entities.PlayerDetails;
using WargamingTypesLibrary.Enums;
using WotApi;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    private const string AppId = "3ea00a80eeb1cdda0e1053d6b0b6c2b7";
    private readonly WargamingManager _manager;

    public Form1()
    {
      InitializeComponent();

      _manager = new WargamingManager(AppId);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      List<Tank> returnValue = _manager.GetAllVehicles();

      dataGridView1.DataSource = returnValue;
      dataGridView1.Update();

      //var sb = new StringBuilder();

      //sb.AppendLine(string.Format("Tanks total: {0}", returnValue.Count));

      //foreach (var source in returnValue.GroupBy(x=>x.Nation))
      //  sb.AppendLine(string.Format("{0} tanks: {1}", source.Key, source.Count()));  
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var ids = textBox1.Text.Split(',').Select(x => Convert.ToInt64(x)).ToArray();

      var details = _manager.GetVehicleDetails(ids);

      _manager.GetAllVehicleDetails(details);

      propertyGrid1.SelectedObject = details[0];
      propertyGrid1.Update();
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

  }
}
