using MstwoData.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MstwoData
{
    public interface IRepository
    {
        Task<ResponseMessage> GetEmployee(string Code, CancellationToken cancellationToken);
        Task<ResponseMessage> UpdateEmployee(string code, tblEmployeeDetails tblEmployeeDetail, CancellationToken cancellationToken);
        Task<ResponseMessage> DeleteEmployee(string code, CancellationToken cancellationToken);
        Task<ResponseMessage> InsertEmployee(tblEmployeeDetails tblEmployeeDetail, CancellationToken cancellationToken);
       
    }
}