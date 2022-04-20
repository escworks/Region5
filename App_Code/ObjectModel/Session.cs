using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace escWeb.tx_r5.ObjectModel
{
    [Serializable]
    public class Session : region4.ObjectModel.Session
    {
        private string _dimensions = string.Empty;
        public string Dimensions { get { return this._dimensions; } }

        private string _standards = string.Empty;
        public string Standards { get { return this._standards; } }

        public Session(int session_id) : base(session_id)
        {
                    
        }

        protected override void LoadCustomerData(SqlDataReader reader)
        {
            this._dimensions = reader["dimensions"].ToString();
            this._standards = reader["standards"].ToString();

            //Added by VM 4-26-2017
            this._PrevSessionID = (int)(reader["PrerequisiteSessionID"] == DBNull.Value ? -1 : reader["PrerequisiteSessionID"]);
            this._NextSessionID = (int)(reader["NextSessionID"] == DBNull.Value ? -1 : reader["NextSessionID"]);
            this._allowPO = Convert.ToBoolean(reader["allowPO"]);
        }

        //Added by VM 4-26-2017
        public override int Limit
        {
            get
            {
                if (IsSelfPacedOnline || (IsOnDemandOnline && _limit == 0))//If it is 0, we treat it as unlimited
                    return 999999;
                else
                    return _limit;
            }
        }

    }
}