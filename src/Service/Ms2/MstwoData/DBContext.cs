using Microsoft.EntityFrameworkCore;
using MstwoData.Models;

namespace MstwoData
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }        
        
        public virtual DbSet<tblEmployeeDetails> TblEmployeeDetails { get; set; }       
    }
}
