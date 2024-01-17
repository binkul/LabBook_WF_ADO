using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBook.Commons
{
    public static class ColumnData
    {

        private static readonly IDictionary<string, string> VISCOSITY_COLUMNS = new Dictionary<string, string>()
        {
            // key - kolumn name id DataBase; Value - column Header in DGV|column DisplayIndex in DGV|Column width in DGV|Full column description for other use
            {"date_update", "Data|0|100|Data pomiaru" },
            {"days_distance", "Doba|1|100|Doba od pomiaru" },
            {"temp", "Temp|2|100|Temperatura" },
            {"pH", "pH|4|80|pH" },
            {"vis_type", "Typ|5|100|Typ lepkości" },
            {"vis_1", "Lep 1|5|100|Lepkość 1 rpm" },
            {"vis_5", "Lep 5|7|100|Lepkość 5 rpm" },
            {"vis_10", "Lep 10|8|100|Lepkość 10 rpm" },
            {"vis_20", "Lep 20|10|100|Lepkość 20 rpm" },
            {"vis_30", "Lep 30|12|100|Lepkość 30 rpm" },
            {"vis_40", "Lep 40|14|100|Lepkość 40 rpm" },
            {"vis_50", "Lep 50|16|100|Lepkość 50 rpm" },
            {"vis_60", "Lep 60|18|100|Lepkość 60 rpm" },
            {"vis_70", "Lep 70|20|100|Lepkość 70 rpm" },
            {"vis_80", "Lep 80|22|100|Lepkość 80 rpm" },
            {"vis_90", "Lep 90|24|100|Lepkość 90 rpm" },
            {"vis_100", "Lep 100|26|100|Lepkość 100 rpm" },
            {"brook_disc", "Dysk|27|80|Dysk numer" },
            {"brook_comment", "Lepkość uwagi|28|200|Brookfield uwagi" },
            {"brook_x_vis", "Lep X|29|100|Lepkość x" },
            {"brook_x_rpm", "Dysk X|30|80|Obroty X" },
            {"brook_x_disc", "Lep X uwagi|31|80|Dysk x" },
            {"krebs", "Krebs|32|100|Lepkość Krebs" },
            {"krebs_comment", "Krebs uwagi|33|100|Krebs uwagi" },
            {"ici", "ICI|34|80|Lepkość ICI" },
            {"ici_disc", "ICI dysk|35|80|ICI Dysk" },
            {"ici_comment", "ICI uwagi|36|100|ICI uwagi" }
        };

        public static IDictionary<string, string> GetViscosityColumns => VISCOSITY_COLUMNS;

    }
}
