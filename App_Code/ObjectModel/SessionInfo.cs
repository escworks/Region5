using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace escWeb.tx_r5.ObjectModel
{
    /// <summary>
    /// Summary description for AttendeeInfo
    /// </summary>
    [Serializable]
    public class SessionInfo : region4.ObjectModel.SessionInfo
    {
        public bool IsTETN { get { return EventType.ItemId == 6473; } } // 6473 event type TETN

        public bool IsVideoConference { get { return EventType.ItemId == 34; } } //34 is event type VideoConference

        public SessionInfo(DataRow reader) : base(reader)
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}