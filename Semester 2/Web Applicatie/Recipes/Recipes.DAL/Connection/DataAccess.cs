using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.DAL.Connection
{
    public class DataAccess
    {
        private readonly string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi538222;Integrated Security=False;User Id=dbi538222;Password=KCR3ank4eba_her-exb;MultipleActiveResultSets=true";
        public SqlConnection Connection { get; private set; }

        public DataAccess()
        {
            Connection = new SqlConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            Connection.Open();
        }

        public void CloseConnection()
        {
            Connection.Dispose();
        }
    }
}
