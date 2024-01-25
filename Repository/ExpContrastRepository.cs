using System.Data.SqlClient;

namespace LabBook.Repository
{
    public class ExpContrastRepository
    {
        private const string GET_CONTRASTBY_LABBOOK_ID = "Select c.id, c.labbook_id, DATEDIFF(day, c.date_created, c.date_updated) " +
                    "as days_distance, c.applicator_id, c.position, c.substrate, c.contrast, c.tw, c.sp, c.comments, c.date_created, " +
                    "c.date_updated, a.id, a.name, a.number from LabBook.dbo.ExpContrast c left join LabBook.dbo.CmbApplicator a on " +
                    "c.applicator_id=a.id Where c.labbook_id=XXXX Order by c.date_created, a.number, c.date_updated";

        private readonly SqlConnection _connection;

        public ExpContrastRepository(SqlConnection connection)
        {
            _connection = connection;
        }

    }
}
