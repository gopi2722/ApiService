using System.Threading;
using System.Threading.Tasks;

namespace MsoneData
{
    public interface IRepository
    {
        Task<ResponseMessage> GetCompany(string Code, CancellationToken cancellationToken);
        Task<ResponseMessage> UpdateCompany(string code, tblCompanyDetails tblCompanyDetail, CancellationToken cancellationToken);
        Task<ResponseMessage> DeleteCompany(string code, CancellationToken cancellationToken);
        Task<ResponseMessage> InsertCompany(tblCompanyDetails tblCompanyDetail, CancellationToken cancellationToken);
       
    }
}