using System.Configuration;
using System.Data;

namespace LibraryDAL
{
    public class DapperBase
    {

        public DapperBase() : this(ConfigurationManager.ConnectionStrings["LibraryConn"].ConnectionString)
        {
        }

        public DapperBase(string conn)
        {
            this.connectionString = conn;
        }

        private string connectionString { get; }

        protected DapperContext GetDapperContext(
            string commandText,
            bool isTransaction,
            string connectionDb,
            int commandTimeOut = 30,
            CommandType commandType = CommandType.Text)
        {
            return new DapperContext()
            {
                ConnectionString = connectionDb,
                CommandText = commandText,
                IsTransaction = isTransaction,
                CommandType = commandType,
                CommandTimeOut = commandTimeOut
            };
        }

        protected DapperContext GetDapperContext(
            string commandText,
            bool isTransaction)
        {
            return this.GetDapperContext(commandText, isTransaction, this.connectionString);
        }
    }
}