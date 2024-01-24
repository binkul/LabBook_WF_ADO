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

        private static readonly IDictionary<string, IList<string>> VISCOSITY_COLUMNS = new Dictionary<string, IList<string>>()
        {
            // key - kolumn name id DataBase; Value - column Header name in DGV|column DisplayIndex in DGV|Column width in DGV|Full column description for other use|ChbBox name in ViscosityColumnsForms
            {"date_created", new List<string>(){ "Utworzony", "0", "100", "Data utworzenia", "NULL" } },
            {"date_update", new List<string>(){ "Pomiar", "1", "100", "Data pomiaru", "NULL" } },
            {"days_distance", new List<string>(){ "Doba", "2", "100", "Doba od pomiaru", "NULL" } },
            {"temp", new List<string>(){ "Temp", "3", "100", "Temperatura", "NULL" } },
            {"pH", new List<string>(){ "pH", "4", "80", "pH", "ChbPh" } },
            {"brook_1", new List<string>(){ "Lep 1", "5", "100", "Lepkość 1 rpm", "ChbBrook_1" } },
            {"brook_5", new List<string>(){ "Lep 5", "6", "100", "Lepkość 5 rpm", "ChbBrook_5" } },
            {"brook_10", new List<string>(){ "Lep 10", "7", "100", "Lepkość 10 rpm", "ChbBrook_10" } },
            {"brook_20", new List<string>(){ "Lep 20", "8", "100", "Lepkość 20 rpm", "ChbBrook_20" } },
            {"brook_30", new List<string>(){ "Lep 30", "9", "100", "Lepkość 30 rpm", "ChbBrook_30" } },
            {"brook_40", new List<string>(){ "Lep 40", "10", "100", "Lepkość 40 rpm", "ChbBrook_40" } },
            {"brook_50", new List<string>(){ "Lep 50", "11", "100", "Lepkość 50 rpm", "ChbBrook_50" } },
            {"brook_60", new List<string>(){ "Lep 60", "12", "100", "Lepkość 60 rpm", "ChbBrook_60" } },
            {"brook_70", new List<string>(){ "Lep 70", "13", "100", "Lepkość 70 rpm", "ChbBrook_70" } },
            {"brook_80", new List<string>(){ "Lep 80", "14", "100", "Lepkość 80 rpm", "ChbBrook_80" } },
            {"brook_90", new List<string>(){ "Lep 90", "15", "100", "Lepkość 90 rpm", "ChbBrook_90" } },
            {"brook_100", new List<string>(){ "Lep 100", "16", "100", "Lepkość 100 rpm", "ChbBrook_100" } },
            {"brook_disc", new List<string>(){ "Dysk", "17", "80", "Dysk numer", "ChbBrook_disc" } },
            {"brook_comment", new List<string>(){ "Lepkość uwagi", "18", "200", "Brookfield uwagi", "ChbBrook_comment" } },
            {"brook_x_vis", new List<string>(){ "Lep X", "19", "100", "Lepkość x", "ChbBrook_X" } },
            {"brook_x_rpm", new List<string>(){ "Obr. X", "20", "100", "Obroty X", "ChbBrook_X_rpm" } },
            {"brook_x_disc", new List<string>(){ "Dysk X", "21", "80", "Dysk x", "ChbBrook_X_disc" } },
            {"krebs", new List<string>(){ "Krebs", "22", "100", "Lepkość Krebs", "ChbKrebs" } },
            {"krebs_comment", new List<string>(){ "Krebs uwagi", "23", "200", "Krebs uwagi", "ChbKrebs_comment" } },
            {"ici", new List<string>(){ "ICI", "24", "80", "Lepkość ICI", "ChbIci" } },
            {"ici_disc", new List<string>(){ "ICI dysk", "25", "80", "ICI Dysk", "ChbIci_disc" } },
            {"ici_comment", new List<string>(){ "ICI uwagi", "26", "150", "ICI uwagi", "ChbIci_comment" } }
        };

        public static IDictionary<string, IList<string>> GetViscosityColumns => VISCOSITY_COLUMNS;

    }
}
