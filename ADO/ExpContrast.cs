using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBook.ADO
{
    public class ExpContrast
    {
        public long Id { get; set; }
        public long labBookId { get; set; }
        public CmbApplicator CmbApplicator { get; set; }
        public int Posiotion { get; set; }
        public string Substrate { get; set; }
        public double? Contrast { get; set; }
        public double? Tw { get; set; }
        public double? Sp { get; set; }
        public string Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int Day { get; set; }
        public string GetApplicatorName => CmbApplicator.Name;

        public ExpContrast(long id, long labBookId, CmbApplicator cmbApplicator, int posiotion, string substrate, double? contrast, 
            double? tw, double? sp, string comments, DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            this.labBookId = labBookId;
            CmbApplicator = cmbApplicator;
            Posiotion = posiotion;
            Substrate = substrate;
            Contrast = contrast;
            Tw = tw;
            Sp = sp;
            Comments = comments;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            Day = (dateUpdated.Date - dateCreated.Date).Days;
        }

        public ExpContrast(long id, long labBookId, CmbApplicator cmbApplicator, int posiotion, string substrate, 
            DateTime dateCreated, DateTime dateUpdated)
        {
            Id = id;
            this.labBookId = labBookId;
            CmbApplicator = cmbApplicator;
            Posiotion = posiotion;
            Substrate = substrate;
            DateCreated = dateCreated;
            DateUpdated = dateUpdated;
            Day = (dateUpdated.Date - dateCreated.Date).Days;
        }
    }
}
