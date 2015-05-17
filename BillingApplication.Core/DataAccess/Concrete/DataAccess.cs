using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace BillingApplication.Core.DataAccess.Concrete
{
    public class DataAccess : IDataAccess, IDisposable
    {
        private readonly string _connectionString;
        private SqlTransaction _transaction;
        private readonly SqlConnection _connection;

        public DataAccess()
        {
            _connectionString = ConfigSettings.GetConnectionString();
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }

        public DataAccess(SqlConnection connection)
        {
            _connectionString = ConfigSettings.GetConnectionString();
            _connection = connection;
        }

        public SqlConnection Connection
        {
            get { return _connection; }
        }

        public SqlTransaction Transaction
        {
            get { return _transaction; }
        }

        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public DataTable GetData(string query, IDictionary<string, object> parameters)
        {
            using (var command = new SqlCommand(query, _connection, _transaction))
                {
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        AddParameters(command, parameters);

                        var data = new DataTable();
                        adapter.Fill(data);

                        return data;
                    }
                }
        }

        public DataTable GetDataFromStoredProcedure(string spName, IDictionary<string, object> parameters)
        {
            using (var command = new SqlCommand(spName, _connection, _transaction))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        AddParameters(command, parameters);

                        var data = new DataTable();
                        adapter.Fill(data);

                        return data;
                    }
                }
        }

        private void AddParameters(SqlCommand command, IDictionary<string, object> parameters)
        {
            if(parameters == null) return;

            foreach (var parameter in parameters)
            {
                if (parameter.Value == null) continue;

                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
        }

        public void SaveData(DataSet data)
        {
                foreach (DataTable table in data.Tables)
                {
                    using (var adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = new SqlCommand(string.Format("SELECT * FROM {0}", table.TableName), _connection, _transaction);

                        var commandBuilder = new SqlCommandBuilder(adapter);

                        commandBuilder.GetInsertCommand();
                        commandBuilder.GetUpdateCommand();
                        commandBuilder.GetDeleteCommand();

                        adapter.Update(data, table.TableName);
                    }
                }
        }

        public void SaveData(DataTable data, string tableName)
        {
            using (var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = new SqlCommand(string.Format("SELECT * FROM {0}", tableName), _connection, _transaction);

                    var commandBuilder = new SqlCommandBuilder(adapter);

                    commandBuilder.GetInsertCommand();                   
                    commandBuilder.GetUpdateCommand();
                    commandBuilder.GetDeleteCommand();

                    adapter.Update(data);
                }
        }

        public void ExecuteQuery(string query, IDictionary<string, object> parameters)
        {
            using (var command = new SqlCommand(query, _connection, _transaction))
            {
                AddParameters(command, parameters);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }

            if (_transaction != null)
                _transaction.Dispose();
        }

        #endregion
    }
}
