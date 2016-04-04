using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
      var returnValue = _manager.GetAllVehicles();
      var sb = new StringBuilder();

      sb.AppendLine(string.Format("Tanks total: {0}", returnValue.Count));

      foreach (var source in returnValue.GroupBy(x=>x.Nation))
        sb.AppendLine(string.Format("{0} tanks: {1}", source.Key, source.Count()));  

      richTextBox1.Text = sb.ToString();
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
