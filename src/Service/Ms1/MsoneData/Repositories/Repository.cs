using Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MsoneData.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MsoneData
{
    public class Repository : IRepository
    {
        private ILoggerManager _logger;
        private readonly DBContext _dataContext;


        public Repository(DBContext dataContext, ILoggerManager logger)
        {
            _logger = logger;
            _dataContext = dataContext;

        }
        public async Task<ResponseMessage> GetCompany(string Code, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                var resDB = new List<tblCompanyDetails>();
                var queryable = _dataContext.TblCompanyDetails.AsQueryable();
                if (Code == null)
                    resDB = await queryable.ToListAsync(cancellationToken);
                else
                {
                    queryable = queryable.Where(x => x.CompanyId == Code);
                    resDB = await queryable.ToListAsync(cancellationToken);
                }
                result = new ResponseMessage(true, ResponseCodes.Status0OK, ResponseString.OK.ToString(), null, resDB);
                _logger.LogInfo("GetPrice=" + result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetPrice=" + ex.ToString());
                result = new ResponseMessage(false, ResponseCodes.Status1UnexpectedError, ResponseString.UnexpectedError.ToString(), ex.ToString(), null);
            }
            return result;
        }

        public async Task<ResponseMessage> UpdateCompany(string code, tblCompanyDetails tblCompanyDetail, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                var resDet = await _dataContext.TblCompanyDetails.FirstOrDefaultAsync(e => e.CompanyId == code, cancellationToken);
                if (resDet != null)
                {
                    //resDet.CompanyId = tblCompanyDetail.CompanyId;
                    resDet.Name = tblCompanyDetail.Name;
                    resDet.Description = tblCompanyDetail.Description;
                    resDet.GstNo = tblCompanyDetail.GstNo;
                    resDet.Email = tblCompanyDetail.Email;
                    resDet.Phone = tblCompanyDetail.Phone;
                    resDet.Address = tblCompanyDetail.Address;
                    resDet.City = tblCompanyDetail.City;
                    resDet.Status = tblCompanyDetail.Status;
                    //resDet.CreatedDate = tblCompanyDetail.CreatedDate;
                    resDet.ModifiedDate = System.DateTime.Now;
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    _logger.LogInfo("UpdatePrice" + result);
                    result = new ResponseMessage(true, ResponseCodes.Status0OK, "Record updated...", null, null);
                }
                else
                    result = new ResponseMessage(false, ResponseCodes.Status4InvalidRequestData, "Data not availabe for this details", null, null);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdatePrice=" + ex.ToString());
                result = new ResponseMessage(false, ResponseCodes.Status1UnexpectedError, ResponseString.UnexpectedError.ToString(), ex.ToString(), null);
            }
            return result;
        }

        public async Task<ResponseMessage> DeleteCompany(string code, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                var resDet = await _dataContext.TblCompanyDetails.FirstOrDefaultAsync(e => e.CompanyId == code, cancellationToken);
                if (resDet != null)
                {

                    _dataContext.TblCompanyDetails.Remove(resDet);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    _logger.LogInfo("DeleteCompany" + result);
                    result = new ResponseMessage(true, ResponseCodes.Status0OK, "Record deleted...", null, null);

                }
                else
                    result = new ResponseMessage(false, ResponseCodes.Status4InvalidRequestData, "Data not availabe for this details", null, null);

            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteCompany=" + ex.ToString());
                result = new ResponseMessage(false, ResponseCodes.Status1UnexpectedError, ResponseString.UnexpectedError.ToString(), ex.ToString(), null);
            }
            return result;
        }
        public async Task<ResponseMessage> InsertCompany(tblCompanyDetails tblCompanyDetail, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                if (tblCompanyDetail != null)
                {
                    using (SqlConnection sql = new SqlConnection(DButilities.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("prcCompany", sql))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;                       
                            cmd.Parameters.Add(new SqlParameter("@Name", string.IsNullOrEmpty(tblCompanyDetail.Name) ? "" : tblCompanyDetail.Name));
                            cmd.Parameters.Add(new SqlParameter("@Description", string.IsNullOrEmpty(tblCompanyDetail.Description) ? "" : tblCompanyDetail.Description));
                            cmd.Parameters.Add(new SqlParameter("@GstNo", string.IsNullOrEmpty(tblCompanyDetail.GstNo) ? "" : tblCompanyDetail.GstNo));
                            cmd.Parameters.Add(new SqlParameter("@Email", string.IsNullOrEmpty(tblCompanyDetail.Email) ? "" : tblCompanyDetail.Email));
                            cmd.Parameters.Add(new SqlParameter("@Phone", string.IsNullOrEmpty(tblCompanyDetail.Phone) ? "" : tblCompanyDetail.Phone));
                            cmd.Parameters.Add(new SqlParameter("@Address", string.IsNullOrEmpty(tblCompanyDetail.Address) ? "" : tblCompanyDetail.Address));
                            cmd.Parameters.Add(new SqlParameter("@City", string.IsNullOrEmpty(tblCompanyDetail.City) ? "" : tblCompanyDetail.City));
                            cmd.Parameters.Add(new SqlParameter("@Status", string.IsNullOrEmpty(tblCompanyDetail.Status) ? "" : tblCompanyDetail.Status));                          
                            await sql.OpenAsync(cancellationToken);
                            await cmd.ExecuteNonQueryAsync(cancellationToken);
                            _logger.LogInfo("InsertPrice" + result);
                        }
                    }
                    result = new ResponseMessage(true, ResponseCodes.Status0OK, "Record Inserted...", null, null);
                }
                else
                    result = new ResponseMessage(false, ResponseCodes.Status4InvalidRequestData, $"Kindly give a insert record..!", null, null);
            }
            catch (Exception ex)
            {
                _logger.LogError("InsertMedia=" + ex.ToString());
                result = new ResponseMessage(false, ResponseCodes.Status1UnexpectedError, ResponseString.UnexpectedError.ToString(), ex.ToString(), null);
            }
            return result;
        }
    }
}
