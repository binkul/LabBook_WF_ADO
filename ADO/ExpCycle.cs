using System;
using System.Collections.Generic;

namespace LabBook.ADO
{
    public class ExpCycle
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long User_id { get; set; }
        public DateTime Date { get; set; }

        public ExpCycle(long id, string name, long user_id, DateTime date)
        {
            Id = id;
            Name = name;
            User_id = user_id;
            Date = date;
        }

        public override bool Equals(object obj)
        {
            return obj is ExpCycle cycle &&
                   Id == cycle.Id &&
                   Name == cycle.Name &&
                   User_id == cycle.User_id &&
                   Date == cycle.Date;
        }

        public override int GetHashCode()
        {
            int hashCode = 1463498409;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + User_id.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
