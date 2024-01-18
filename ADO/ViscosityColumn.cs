namespace LabBook.ADO
{
    public class ViscosityColumn
    {
        public long Id { get; set;  }
        public long LabBookId { get; set; }
        public string Type { get; set; }
        public string Fields { get; set; }

        public ViscosityColumn(long id, long labBookId, string type, string fields)
        {
            Id = id;
            LabBookId = labBookId;
            Type = type;
            Fields = fields;
        }

        public ViscosityColumn()
        {
            Id = -1;
            LabBookId = -1;
            Type = "NOT_SET";
        }

        public ViscosityColumn(string type)
        {
            Id = -1;
            LabBookId = -1;
            Type = type;
        }
    }
}
