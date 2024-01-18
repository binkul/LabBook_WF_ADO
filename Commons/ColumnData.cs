using System.Collections.Generic;

namespace LabBook.Commons
{
    public static class ColumnData
    {
        public const string START_FIELDS = "pH|brook_1|brook_5|brook_20|brook_disc|brook_comment";
        public const string STD_FIELDS = "pH|brook_1|brook_5|brook_20|brook_disc|brook_comment";
        public const string STD_X_FIELDS = "pH|brook_1|brook_5|brook_20|brook_disc|brook_comment|brook_x_vis|brook_x_rpm|brook_x_disc";
        public const string PRB_FIELDS = "pH|brook_1|brook_5|brook_10|brook_20|brook_50|brook_100|brook_disc|brook_comment";
        public const string SLV_FIELDS = "brook_1|brook_5|brook_20|brook_disc|brook_comment";
        public const string SLV_X_FIELDS = "brook_1|brook_5|brook_20|brook_disc|brook_comment|brook_x_vis|brook_x_rpm|brook_x_disc";
        public const string KREBS_FIELDS = "pH|brook_1|brook_5|brook_20|brook_disc|brook_comment|krebs|krebs_comment";
        public const string ICI_FIELDS = "pH|brook_1|brook_5|brook_20|brook_disc|brook_comment|ici|ici_disc|ici_comment";
        public const string KREBS_ICI_FIELDS = "pH|brook_1|brook_5|brook_20|brook_disc|brook_comment|krebs|krebs_comment|ici|ici_disc|ici_comment";
        public const string FULL_FIELDS = "pH|brook_1|brook_5|brook_10|brook_20|brook_30|brook_40|brook_50|brook_60|brook_70|brook_80|brook_90|brook_100|brook_100|brook_disc|brook_comment|brook_x_vis|brook_x_rpm|brook_x_disc|krebs|krebs_comment|krebs|krebs_comment|ici|ici_disc|ici_comment";

        private static readonly IDictionary<string, string> VISCOSITY_COLUMNS = new Dictionary<string, string>()
        {
            // key - kolumn name id DataBase; Value - column Header in DGV|column DisplayIndex in DGV|Column width in DGV|Full column description for other use
            {"date_created", "Utworzony|0|100|Data utworzenia" },
            {"date_update", "Pomiar|1|100|Data pomiaru" },
            {"days_distance", "Doba|2|100|Doba od pomiaru" },
            {"temp", "Temp|3|100|Temperatura" },
            {"pH", "pH|4|80|pH" },
            {"brook_1", "Lep 1|5|100|Lepkość 1 rpm" },
            {"brook_5", "Lep 5|6|100|Lepkość 5 rpm" },
            {"brook_10", "Lep 10|7|100|Lepkość 10 rpm" },
            {"brook_20", "Lep 20|8|100|Lepkość 20 rpm" },
            {"brook_30", "Lep 30|9|100|Lepkość 30 rpm" },
            {"brook_40", "Lep 40|10|100|Lepkość 40 rpm" },
            {"brook_50", "Lep 50|11|100|Lepkość 50 rpm" },
            {"brook_60", "Lep 60|12|100|Lepkość 60 rpm" },
            {"brook_70", "Lep 70|13|100|Lepkość 70 rpm" },
            {"brook_80", "Lep 80|14|100|Lepkość 80 rpm" },
            {"brook_90", "Lep 90|15|100|Lepkość 90 rpm" },
            {"brook_100", "Lep 100|16|100|Lepkość 100 rpm" },
            {"brook_disc", "Dysk|17|80|Dysk numer" },
            {"brook_comment", "Lepkość uwagi|18|200|Brookfield uwagi" },
            {"brook_x_vis", "Lep X|19|100|Lepkość x" },
            {"brook_x_rpm", "Obr. X|20|100|Obroty X" },
            {"brook_x_disc", "Dysk X|21|80|Dysk x" },
            {"krebs", "Krebs|22|100|Lepkość Krebs" },
            {"krebs_comment", "Krebs uwagi|23|200|Krebs uwagi" },
            {"ici", "ICI|24|80|Lepkość ICI" },
            {"ici_disc", "ICI dysk|25|80|ICI Dysk" },
            {"ici_comment", "ICI uwagi|26|150|ICI uwagi" }
        };

        public static IDictionary<string, string> GetViscosityColumns => VISCOSITY_COLUMNS;

    }
}
