using System;
using System.Collections.Generic;

namespace LabBook.ADO
{
    public class CmbApplicator : IComparable<CmbApplicator>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public CmbApplicator(long id, string name, int number)
        {
            Id = id;
            Name = name;
            Number = number;
        }

        public override bool Equals(object obj)
        {
            return obj is CmbApplicator applicator &&
                   Id == applicator.Id &&
                   Name == applicator.Name &&
                   Number == applicator.Number;
        }

        public override int GetHashCode()
        {
            int hashCode = 1746673078;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            return hashCode;
        }

        public int CompareTo(CmbApplicator other)
        {
            if (other == null)
                return 1;
            else
                return Number.CompareTo(other.Number);
        }
    }
}
