using Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MstwoData.Logger;
using MstwoData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MstwoData
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
        public async Task<ResponseMessage> GetEmployee(string Code, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                var resDB = new List<tblEmployeeDetails>();
                var queryable = _dataContext.TblEmployeeDetails.AsQueryable();
                if (Code == null)
                    resDB = await queryable.ToListAsync(cancellationToken);
                else
                {
                    queryable = queryable.Where(x => x.EmpId == Code);
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

        public async Task<ResponseMessage> UpdateEmployee(string code, tblEmployeeDetails tblEmployeeDetails, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                var resDet = await _dataContext.TblEmployeeDetails.FirstOrDefaultAsync(e => e.EmpId == code, cancellationToken);
                if (resDet != null)
                {
                    //resDet.CompanyId = tblCompanyDetail.CompanyId;
                    resDet.Name = tblEmployeeDetails.Name;
                    resDet.Description = tblEmployeeDetails.Description;                   
                    resDet.Email = tblEmployeeDetails.Email;
                    resDet.Phone = tblEmployeeDetails.Phone;
                    resDet.Address = tblEmployeeDetails.Address;
                    resDet.City = tblEmployeeDetails.City;
                    resDet.Status = tblEmployeeDetails.Status;
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

        public async Task<ResponseMessage> DeleteEmployee(string code, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                var resDet = await _dataContext.TblEmployeeDetails.FirstOrDefaultAsync(e => e.EmpId == code, cancellationToken);
                if (resDet != null)
                {

                    _dataContext.TblEmployeeDetails.Remove(resDet);
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
        public async Task<ResponseMessage> InsertEmployee(tblEmployeeDetails tblEmployeeDetails, CancellationToken cancellationToken)
        {
            var result = new ResponseMessage();
            try
            {
                if (tblEmployeeDetails != null)
                {
                    using (SqlConnection sql = new SqlConnection(DButilities.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("prcEmployee", sql))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;                           
                            cmd.Parameters.Add(new SqlParameter("@Name", string.IsNullOrEmpty(tblEmployeeDetails.Name) ? "" : tblEmployeeDetails.Name));
                            cmd.Parameters.Add(new SqlParameter("@Description", string.IsNullOrEmpty(tblEmployeeDetails.Description) ? "" : tblEmployeeDetails.Description));                          
                            cmd.Parameters.Add(new SqlParameter("@Email", string.IsNullOrEmpty(tblEmployeeDetails.Email) ? "" : tblEmployeeDetails.Email));
                            cmd.Parameters.Add(new SqlParameter("@Phone", string.IsNullOrEmpty(tblEmployeeDetails.Phone) ? "" : tblEmployeeDetails.Phone));
                            cmd.Parameters.Add(new SqlParameter("@Address", string.IsNullOrEmpty(tblEmployeeDetails.Address) ? "" : tblEmployeeDetails.Address));
                            cmd.Parameters.Add(new SqlParameter("@City", string.IsNullOrEmpty(tblEmployeeDetails.City) ? "" : tblEmployeeDetails.City));
                            cmd.Parameters.Add(new SqlParameter("@Status", string.IsNullOrEmpty(tblEmployeeDetails.Status) ? "" : tblEmployeeDetails.Status));                          
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
