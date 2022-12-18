using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CreativeTim.Argon.DotNetCore.Free.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CreativeTim.Argon.DotNetCore.Free.Models
{
    public class db
    {       
        ApplicationDbContext applicationDbContext ;
        DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder;
        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        public db(IConfiguration configuration )
        {
            optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MsSqlConnection"));
            
          
            applicationDbContext = new ApplicationDbContext(optionsBuilder.Options);
        }
        public async Task<int> InsertOpCl(AddOpClViewModel addOpClViewModel)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocInsertOpCl]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    if (addOpClViewModel.id != null)
                    {
                        id.Value = addOpClViewModel.id;
                    }
                    else
                    {
                        id.Value = 0;
                    }
                    SqlParameter publish_status = new SqlParameter("@publish_status", SqlDbType.Bit);
                    SqlParameter isSpecial = new SqlParameter("@isSpecial", SqlDbType.Bit);
                    publish_status.Value = 0;
                    isSpecial.Value = addOpClViewModel.isSpecial;
                    command.Parameters.Add(id);
                    // command.Parameters.Add(new SqlParameter("@id", 0));
                    command.Parameters.Add(new SqlParameter("@op", addOpClViewModel.o));
                    command.Parameters.Add(new SqlParameter("@cl", addOpClViewModel.c));
                    command.Parameters.Add(new SqlParameter("@jd", addOpClViewModel.jd));
                    command.Parameters.Add(publish_status);
                    command.Parameters.Add(new SqlParameter("@publish_date",indianTime));
                    command.Parameters.Add(new SqlParameter("@timeslot", addOpClViewModel.oCID));
                    command.Parameters.Add(isSpecial);
                    if (addOpClViewModel.id != null)
                    {
                        command.Parameters.Add(new SqlParameter("@StatementType", "Update"));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@StatementType", "Insert"));
                    }
                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                   await  applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }catch(Exception ex)
            {                
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }
        public async Task<int> OpClDelete(string opclid)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocInsertOpCl]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    id.Value = Convert.ToInt32(opclid);
                    SqlParameter publish_status = new SqlParameter("@publish_status", SqlDbType.Bit);
                    publish_status.Value = 0;
                    SqlParameter isSpecial = new SqlParameter("@isSpecial", SqlDbType.Bit);
                    isSpecial.Value = 0;
                    command.Parameters.Add(id);
                    // command.Parameters.Add(new SqlParameter("@id", 0));
                    command.Parameters.Add(new SqlParameter("@op",""));
                    command.Parameters.Add(new SqlParameter("@cl", ""));
                    command.Parameters.Add(new SqlParameter("@jd", ""));
                    command.Parameters.Add(publish_status);
                    command.Parameters.Add(new SqlParameter("@publish_date",indianTime));
                    command.Parameters.Add(new SqlParameter("@timeslot", ""));
                    command.Parameters.Add(isSpecial);
                    command.Parameters.Add(new SqlParameter("@StatementType", "Delete"));
                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }
        public async Task<int> OpClApprove(string opclid)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocInsertOpCl]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    id.Value = Convert.ToInt32(opclid);
                    SqlParameter publish_status = new SqlParameter("@publish_status", SqlDbType.Bit);
                    publish_status.Value = 0;
                    SqlParameter isSpecial = new SqlParameter("@isSpecial", SqlDbType.Bit);
                    isSpecial.Value = 0;
                    command.Parameters.Add(id);
                    // command.Parameters.Add(new SqlParameter("@id", 0));
                    command.Parameters.Add(new SqlParameter("@op", ""));
                    command.Parameters.Add(new SqlParameter("@cl", ""));
                    command.Parameters.Add(new SqlParameter("@jd", ""));
                    command.Parameters.Add(publish_status);
                    command.Parameters.Add(new SqlParameter("@publish_date",indianTime));
                    command.Parameters.Add(new SqlParameter("@timeslot", ""));
                    command.Parameters.Add(isSpecial);
                    command.Parameters.Add(new SqlParameter("@StatementType", "Approve"));

                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }

        public async Task<int> UpdateSequence(string recid,string seqtype)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocInsertOpCl]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    id.Value = Convert.ToInt32(recid);
                    SqlParameter publish_status = new SqlParameter("@publish_status", SqlDbType.Bit);
                    publish_status.Value = 0;
                    SqlParameter isSpecial = new SqlParameter("@isSpecial", SqlDbType.Bit);
                    isSpecial.Value = 0;
                    command.Parameters.Add(id);
                    // command.Parameters.Add(new SqlParameter("@id", 0));
                    command.Parameters.Add(new SqlParameter("@op", ""));
                    command.Parameters.Add(new SqlParameter("@cl", ""));
                    command.Parameters.Add(new SqlParameter("@jd", ""));
                    command.Parameters.Add(publish_status);
                    command.Parameters.Add(new SqlParameter("@publish_date", indianTime));
                    command.Parameters.Add(new SqlParameter("@timeslot", ""));
                    command.Parameters.Add(isSpecial);
                    command.Parameters.Add(new SqlParameter("@StatementType", "Approve"));

                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }
        public async Task<List<tblOpCl>> GetOpCl(int id=0)
        {
            List<tblOpCl> tblOpClList = new List<tblOpCl>();
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocGetOpCl]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter _id = new SqlParameter("@id", SqlDbType.Int);
                    _id.Value = id;
                    command.Parameters.Add(_id);
                    await applicationDbContext.Database.OpenConnectionAsync();
                   DbDataReader reader=await command.ExecuteReaderAsync();
                    {

                        while (reader.Read())
                        {
                            tblOpCl tbl = new tblOpCl();
                            tbl.id =Convert.ToInt32(reader[0]);
                            tbl.op = Convert.ToInt32(reader[1]);
                            tbl.cl = Convert.ToInt32(reader[2]);
                            tbl.jd = Convert.ToInt32(reader[3]);
                            tbl.publish_status = Convert.ToBoolean(reader[4]);
                            tbl.publish_date = Convert.ToDateTime(reader[5]);
                            tbl.timeslot = reader[6].ToString();
                            tbl.dayseq = Convert.ToInt32(reader[7]);
                            tblOpClList.Add(tbl);
                        }
                        return tblOpClList;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return tblOpClList;
        }

        public async Task<List<CaontactNumbers>> GetCN(int id = 0)
        {
            List<CaontactNumbers> caontactNumberList = new List<CaontactNumbers>();
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocGetCN]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter _id = new SqlParameter("@id", SqlDbType.Int);
                    _id.Value = id;
                    command.Parameters.Add(_id);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    {

                        while (reader.Read())
                        {
                            CaontactNumbers tbl = new CaontactNumbers();
                            tbl.id = Convert.ToInt32(reader[0]);
                            tbl.number1 = (reader[1].ToString());
                            tbl.number2 = (reader[2].ToString());
                            tbl.status = Convert.ToBoolean(reader[3]);
                            caontactNumberList.Add(tbl);
                        }
                        return caontactNumberList;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return caontactNumberList;
        }

        public async Task<List<tblLuckyNumber>> GetLN(int id = 0,string searchValue="")
        {
            List<tblLuckyNumber> tblLuckyNumbers = new List<tblLuckyNumber>();
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocGetLN]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter _id = new SqlParameter("@id", SqlDbType.Int);
                    _id.Value = id;
                    SqlParameter _searchValue = new SqlParameter("@searchValue", SqlDbType.NVarChar);
                    _searchValue.Value = searchValue;
                    command.Parameters.Add(_id);
                    command.Parameters.Add(_searchValue);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    {

                        while (reader.Read())
                        {
                            tblLuckyNumber tbl = new tblLuckyNumber();
                            tbl.id = Convert.ToInt32(reader[0]);
                            tbl.LuckyNumberType = (reader[1].ToString());
                            tbl.LuckyNumber = (reader[2].ToString());
                            tbl.date = Convert.ToDateTime (reader[3].ToString());
                            tbl.status = Convert.ToBoolean(reader[4]);
                            tblLuckyNumbers.Add(tbl);
                        }
                        return tblLuckyNumbers;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return tblLuckyNumbers;
        }

        public async Task<int> InsertCN(AddPhoneNumberViewModel addPhoneNumberViewModel)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocInsertContactNumbers]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    id.Value = 0;
                    SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);
                    status.Value = 1;
                    command.Parameters.Add(id);
                     
                    command.Parameters.Add(new SqlParameter("@number1", addPhoneNumberViewModel.number1));
                    command.Parameters.Add(new SqlParameter("@number2", addPhoneNumberViewModel.number2));
                    command.Parameters.Add(status);
                    command.Parameters.Add(new SqlParameter("@StatementType", "Insert"));
                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }

        public async Task<int> InsertLuckyNumbers(AddDailyLuckyViewModel addDailyLuckyViewModel)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocInsertLuckyNumbers]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    id.Value = 0;
                    SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);
                    status.Value = 0;
                    command.Parameters.Add(id);
                    // command.Parameters.Add(new SqlParameter("@id", 0));
                    command.Parameters.Add(new SqlParameter("@LuckyNumberType", addDailyLuckyViewModel.oCID));
                    command.Parameters.Add(new SqlParameter("@LuckyNumber", addDailyLuckyViewModel.o));
                    command.Parameters.Add(new SqlParameter("@date", addDailyLuckyViewModel.dateTime));
                    command.Parameters.Add(status);
                    command.Parameters.Add(new SqlParameter("@StatementType", addDailyLuckyViewModel.crud));
                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }
        public async Task<int> LNDelete(string lnid)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[tblLuckyNumber]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    id.Value = Convert.ToInt32(lnid);
                    SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);
                    status.Value = 0;
                    command.Parameters.Add(id);
                    // command.Parameters.Add(new SqlParameter("@id", 0));
                    command.Parameters.Add(new SqlParameter("@LuckyNumberType", ""));
                    command.Parameters.Add(new SqlParameter("@LuckyNumber", ""));
                    command.Parameters.Add(new SqlParameter("@date", ""));
                    command.Parameters.Add(status);
                    command.Parameters.Add(new SqlParameter("@StatementType", "Delete"));
                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }
        public async Task<int> LNApprove(string lnid)
        {
            var result = 0;
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocInsertLuckyNumbers]";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@id", SqlDbType.Int);
                    id.Value = Convert.ToInt32(lnid);
                    SqlParameter status = new SqlParameter("@status", SqlDbType.Bit);
                    status.Value = 1;
                    command.Parameters.Add(id);
                    // command.Parameters.Add(new SqlParameter("@id", 0));
                    command.Parameters.Add(new SqlParameter("@LuckyNumberType", ""));
                    command.Parameters.Add(new SqlParameter("@LuckyNumber",""));
                    command.Parameters.Add(new SqlParameter("@date", ""));
                    command.Parameters.Add(status);
                    command.Parameters.Add(new SqlParameter("@StatementType", "Approve"));
                    SqlParameter sqlParameter = new SqlParameter("@return_value", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(sqlParameter);
                    await applicationDbContext.Database.OpenConnectionAsync();
                    await command.ExecuteNonQueryAsync();
                    {
                        result = Convert.ToInt32(sqlParameter.Value);
                        //if (r.HasRows)
                        //{
                        //    r.Read();
                        //    var x = r.GetInt32(0); // x = your sp count value
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return result;
        }
        public async Task<List<tblLuckyNumber>> GetLNToday()
        {
            List<tblLuckyNumber> tblLuckyNumbers = new List<tblLuckyNumber>();
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocGetLNToday]";
                    command.CommandType = CommandType.StoredProcedure;
                    await applicationDbContext.Database.OpenConnectionAsync();
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    {

                        while (reader.Read())
                        {
                            tblLuckyNumber tbl = new tblLuckyNumber();
                            tbl.id = Convert.ToInt32(reader[0]);
                            tbl.LuckyNumberType = (reader[1].ToString());
                            tbl.LuckyNumber =(reader[2].ToString());
                            tbl.date = Convert.ToDateTime(reader[3].ToString());
                            tbl.status = Convert.ToBoolean(reader[4]);
                            tblLuckyNumbers.Add(tbl);
                        }
                        return tblLuckyNumbers;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return tblLuckyNumbers;
        }

        public async Task<List<tblOpCl>> GetOPCLToday()
        {
            List<tblOpCl> tblOpClList = new List<tblOpCl>();
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {   
                    command.CommandText = "[dbo].[strprocGetOPCLToday]";
                    command.CommandType = CommandType.StoredProcedure;
                    await applicationDbContext.Database.OpenConnectionAsync();
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    {
                        while (reader.Read())
                        {
                            tblOpCl tbl = new tblOpCl();
                            tbl.id = Convert.ToInt32(reader[0]);
                            tbl.op = Convert.ToInt32(reader[1]);
                            tbl.cl = Convert.ToInt32(reader[2]);
                            tbl.jd = Convert.ToInt32(reader[3]);
                            tbl.publish_status = Convert.ToBoolean(reader[4]);
                            tbl.publish_date = Convert.ToDateTime(reader[5]);
                            tbl.timeslot = reader[6].ToString();
                            tbl.dayseq = Convert.ToInt32(reader[7]);
                            tbl.isSpecial = Convert.ToBoolean(reader[8]);
                            tblOpClList.Add(tbl);
                        }
                        return tblOpClList;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return tblOpClList;
        }

        public async Task<List<tblOpCl>> GetOPCLHistory()
        {
            List<tblOpCl> tblOpClList = new List<tblOpCl>();
            try
            {
                using (var command = applicationDbContext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "[dbo].[strprocGetOPCLHistory]";
                    command.CommandType = CommandType.StoredProcedure;
                    await applicationDbContext.Database.OpenConnectionAsync();
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    {

                        while (reader.Read())
                        {
                            tblOpCl tbl = new tblOpCl();
                            tbl.id = Convert.ToInt32(reader[0]);
                            tbl.op = Convert.ToInt32(reader[1]);
                            tbl.cl = Convert.ToInt32(reader[2]);
                            tbl.jd = Convert.ToInt32(reader[3]);
                            tbl.publish_status = Convert.ToBoolean(reader[4]);
                            tbl.publish_date = Convert.ToDateTime(reader[5]);
                            tbl.timeslot = reader[6].ToString();
                            tbl.dayseq = Convert.ToInt32(reader[7]);
                            tbl.isSpecial = Convert.ToBoolean(reader[8]);
                            tblOpClList.Add(tbl);
                        }
                        return tblOpClList;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await applicationDbContext.Database.CloseConnectionAsync();
            }
            return tblOpClList;
        }


       

    }
}
