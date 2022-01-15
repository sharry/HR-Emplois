using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace HR_Emplois
{
    public class ADO
    {
        private SqlConnection Connection_;
        private SqlCommand Command_;

        public SqlConnection Connection
        {
            get
            {
                return Connection_;
            }

            set
            {
                Connection_ = value;
            }
        }
        public SqlCommand Command
        {
            get
            {
                return Command_;
            }

            set
            {
                Command_ = value;
            }
        }

        public ADO()
        {
            Connection = new SqlConnection(Properties.Settings.Default.ConnectionStrng);
        }

        public void Open()
        {
            if (Connection != null && Connection.State == ConnectionState.Closed)
                Connection.Open();
        }
        public void Close()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }
    }
}