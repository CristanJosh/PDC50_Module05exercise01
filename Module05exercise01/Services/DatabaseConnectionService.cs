using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module05exercise01.Services
{
    public class DatabaseConnectionService
    {
        private readonly string _connectionString;

        public DatabaseConnectionService()
        {
            _connectionString = "Server=localhost;Database=CompanyDB;User ID=companyuser;Password=companyuser";
        }

        public string GetConnectionString()
        {
            return
                _connectionString;
        }
    }
}
