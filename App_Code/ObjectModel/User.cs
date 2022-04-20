using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace escWeb.tx_r5.ObjectModel
{
    [Serializable]
    public class User : region4.ObjectModel.User
    {
        private int _division_id;
        public int Division_Id
        {
            get { return _division_id; }
            set { _division_id = value; }
        }

        private string _division_name;
        public string Division_Name
        {
            get { return _division_name; }
            set { _division_name = value; }
        }

        private int _department_id;
        public int Department_Id
        {
            get { return _department_id; }
            set { _department_id = value; }
        }

        private string _department_name;
        public string Department_Name
        {
            get { return _department_name; }
            set { _department_name = value; }
        }

        private int _team_id;
        public int Team_Id
        {
            get { return _team_id; }
            set { _team_id = value; }
        }

        private string _team_name;
        public string Team_Name
        {
            get { return _team_name; }
            set { _team_name = value; }
        }

        private int _focus_id;
        public int Focus_Id
        {
            get { return _focus_id; }
            set { _focus_id = value; }
        }

        private string _focus_name;
        public string Focus_Name
        {
            get { return _focus_name; }
            set { _focus_name = value; }
        }

        private Guid _manager_sid;
        public Guid Manager_Sid
        {
            get { return _manager_sid; }
            set { _manager_sid = value; }
        }

        private string _manager_first_name;
        public string Manager_FirstName
        {
            get { return _manager_first_name; }
            set { _manager_first_name = value; }
        }

        private string _manager_last_name;
        public string Manager_LastName
        {
            get { return _manager_last_name; }
            set { _manager_last_name = value; }
        }

        private string _specialNeeds;
        public string SpecialNeeds
        {
            get { return _specialNeeds; }
            set { _specialNeeds = value; }
        }
        private string _employeeID;
        public string EmployeeID
        {
            get { return _employeeID; }
        }

        public User(int user_pk)
            : base(user_pk)
        {
        }

        public User(Guid sid)
            : base(sid)
        {
        }

        protected override void LoadCustomerInfo(System.Data.SqlClient.SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.User.CustomerSpec.Load]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", this.Sid);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    _division_id = Convert.ToInt32(reader["division_id"].ToString());
                    _division_name = reader["division_name"].ToString();
                    _department_id = Convert.ToInt32(reader["department_id"].ToString());
                    _department_name = reader["department_name"].ToString();
                    _team_id = Convert.ToInt32(reader["team_id"].ToString());
                    _team_name = reader["team_name"].ToString();
                    _focus_id = Convert.ToInt32(reader["focus_id"].ToString());
                    _focus_name = reader["focus_name"].ToString();
                    _manager_sid = new Guid(reader["manager_sid"].ToString());
                    _manager_first_name = reader["manager_firstname"].ToString();
                    _manager_last_name = reader["manager_lastname"].ToString();
                    _specialNeeds = reader["SpecialNeeds"].ToString();
                    _employeeID = reader["employeeID"].ToString();

                }
                reader.Close();
            }
            cmd.CommandText = "";
            cmd.Parameters.Clear();
        }

        protected override void SaveCustomerInfo(System.Data.SqlClient.SqlCommand cmd)
        {
            string query = string.Empty;

            cmd.Parameters.Clear();
            cmd.CommandText = "[p.objectModel.User.CustomerSpec.Save]";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", this.Sid);
            cmd.Parameters.AddWithValue("@special_needs", SpecialNeeds);

            cmd.ExecuteNonQuery();

            cmd.CommandText = "";
            cmd.Parameters.Clear();
       
        }


    }
}