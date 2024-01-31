using LabBook.Commons;
using System;

namespace LabBook.ADO
{
    public class ExpContrast
    {
        private long _id = -1;
        private long _labBookId;
        private string _applicatorName;
        private int _position;
        private string _substarte;
        private double? _contrast;
        private double? _tw;
        private double? _sp;
        private string _comment;
        private DateTime _created;
        private DateTime _updatetd;
        private States _state = States.None;

        public int Day { get => (int)(_updatetd - _created).TotalDays; }

        public long Id 
        {
            get => _id;
            set { _id = value; State = States.Modified; }
        }

        public long LabBookId
        {
            get => _labBookId;
            set { _labBookId = value; State = States.Modified; }
        }

        public string ApplicatorName
        {
            get => _applicatorName;
            set { _applicatorName = value; State = States.Modified; }
        }

        public int Position
        {
            get => _position;
            set { _position = value; State = States.Modified; }
        }

        public string Substrate
        {
            get => _substarte;
            set { _substarte = value; State = States.Modified; }
        }

        public double? Contrast
        {
            get => _contrast;
            set { _contrast = value; State = States.Modified; }
        }

        public double? Tw
        {
            get => _tw;
            set { _tw = value; State = States.Modified; }
        }

        public double? Sp
        {
            get => _sp;
            set { _sp = value; State = States.Modified; }
        }

        public string Comments
        {
            get => _comment;
            set { _comment = value; State = States.Modified; }
        }

        public DateTime DateCreated
        {
            get => _created;
            set { _created = value; State = States.Modified; }
        }

        public DateTime DateUpdated
        {
            get => _updatetd;
            set { _updatetd = value; State = States.Modified; }
        }

        public States State
        {
            get => _state;
            set
            {
                if (_state == States.None)
                    _state = value;
            }
        }

        public ExpContrast() { _state = States.Added; }

        public ExpContrast(long id, long labBookId, string applicatorName, int position, string substrate, 
            double? contrast, double? tw, double? sp, string comments, DateTime dateCreated, DateTime dateUpdated)
        {
            _id = id;
            _labBookId = labBookId;
            _applicatorName = applicatorName;
            _position = position;
            _substarte = substrate;
            _contrast = contrast;
            _tw = tw;
            _sp = sp;
            _comment = comments;
            _created = dateCreated;
            _updatetd = dateUpdated;
        }

        public ExpContrast(long labBookId, string name, int position, string substrate, DateTime created, DateTime updatetd, States state)
        {
            _labBookId = labBookId;
            _applicatorName = name;
            _position = position;
            _substarte = substrate;
            _created = created;
            _updatetd = updatetd;
            _state = state;
        }
    }
}
