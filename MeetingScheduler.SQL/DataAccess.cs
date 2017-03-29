﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MeetingScheduler.Persistence.Contract;
using System.Data;

namespace MeetingScheduler.SQL
{
    public class DataAccess : IDataAccess
    {
        public SqlConnection conn;
        public SqlCommand cmd;
        public DataAccess(IConnection con)
        {
            conn = (SqlConnection)con.GetConnection();
        }
        //Connection and transaction
        public void CloseConnection()
        {
            if (conn != null)
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                conn.Dispose();
            }
        }
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }
        public void EndTransaction()
        {
            throw new NotImplementedException();
        }
        private SqlCommand PrepareCommand(string query, IEnumerable<KeyValuePair<string,object>> param)
        {
            conn.Open();

            var cmd = new SqlCommand(query, conn);
            if (param != null)
            {
                foreach (var item in param)
                {
                    cmd.Parameters.Add(new SqlParameter(string.Format("@{0}", item.Key.ToLower()), item.Value ?? DBNull.Value));
                }
            } 
            return cmd;
        }
        public int Execute(string query, IEnumerable<KeyValuePair<string, object>> param)
        {
            int rowsAffected=-1;
            
            using (SqlCommand cmd = PrepareCommand(query, param))
            {
                rowsAffected = cmd.ExecuteNonQuery();
            }
            CloseConnection();
            return rowsAffected;
        }

        public object ExecuteScalar(string query, IList<KeyValuePair<string, object>> param)
        {
            throw new NotImplementedException();
        }

        public IList<object> Select(string query, IList<KeyValuePair<string, object>> param)
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteDataReader(string query, IEnumerable<KeyValuePair<string, object>> param)
        {
            using (SqlCommand cmd = PrepareCommand(query, param))
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);    
            }
        }

        //_________________________________________//

        //_________________________________________//
    }
}
