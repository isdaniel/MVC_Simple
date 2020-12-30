using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;

namespace LibraryDAL
{
    public class DapperContext
    {

        internal string ConnectionString { get; set; }

        internal CommandType CommandType { get; set; }

        internal string CommandText { get; set; }

        internal int CommandTimeOut { get; set; }

        public DynamicParameters Parameters { get; } = new DynamicParameters();

        internal bool IsTransaction { get; set; }

        public int ExecuteNonQuery()
        {
            return this.DapperQueryHock<int>((dbConnection, transaction) => dbConnection.Execute(this.CommandText, (object) this.Parameters, transaction, new int?(this.CommandTimeOut), this.CommandType));
        }

        public IEnumerable<T> Query<T>()
        {
            return this.DapperQueryHock((dbConnection, transaction) => dbConnection.Query<T>(this.CommandText, this.Parameters, transaction, true, new int?(this.CommandTimeOut), this.CommandType));
        }

        private T DapperQueryHock<T>(Func<IDbConnection, IDbTransaction, T> func)
        {
            try
            {
                T obj;
                using (IDbConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (IDbTransaction transaction = this.CreateTransaction(conn))
                    {
                        obj = func(conn, transaction);
                        transaction?.Commit();
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T QueryFirstOrDefault<T>()
        {
            return this.DapperQueryHock((dbConnection, transaction) => dbConnection.QueryFirstOrDefault<T>(this.CommandText, this.Parameters, transaction, this.CommandTimeOut, this.CommandType));
        }

        public T QuerySingleOrDefault<T>()
        {
            return this.DapperQueryHock((dbConnection, transaction) => dbConnection.QuerySingleOrDefault<T>(this.CommandText, this.Parameters, transaction, this.CommandTimeOut, this.CommandType));
        }


        public T Query<T>(Func<SqlMapper.GridReader, T> func) where T : class
        {
            try
            {
                T obj;
                using (IDbConnection dbConnection =new SqlConnection(this.ConnectionString))
                {
                    dbConnection.Open();
                    using (IDbTransaction transaction = this.CreateTransaction(dbConnection))
                    {
                        using (SqlMapper.GridReader gridReader = dbConnection.QueryMultiple(this.CommandText, (object) this.Parameters, transaction, new int?(this.CommandTimeOut), this.CommandType))
                        {
                            obj = func(gridReader);
                            transaction?.Commit();
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteReader(Action<DbDataReader> func)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this.ConnectionString))
                {
                    dbConnection.Open();
                    using (IDbTransaction transaction = this.CreateTransaction(dbConnection))
                    {
                        using (DbDataReader dbDataReader = (DbDataReader) dbConnection.ExecuteReader(this.CommandText, this.Parameters, transaction, this.CommandTimeOut, this.CommandType))
                        {
                            func(dbDataReader);
                            transaction?.Commit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IDbTransaction CreateTransaction(IDbConnection conn)
        {
            return this.IsTransaction ? conn.BeginTransaction() : null;
        }
    }
}