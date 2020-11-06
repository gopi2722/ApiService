using Microsoft.EntityFrameworkCore;

namespace MsoneData
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }        
        
        public virtual DbSet<tblCompanyDetails> TblCompanyDetails { get; set; }       
    }
}
