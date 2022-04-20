using System;
using System.Collections.Generic;
using System.Text;

using Csla;
using Csla.Security;
using System.Data.SqlClient;
using System.Data;
using Csla.Data;

namespace tx_r5.BusinessObect.Accountability
{
    [Serializable()]
    public class Assistance : BusinessBase<Assistance>
    {
        #region Properties

        protected static PropertyInfo<int> ObjIdProperty = RegisterProperty<int>(new PropertyInfo<int>("obj_id"));
        public int ObjId
        {
            get { return GetProperty(ObjIdProperty); }
            set { SetProperty(ObjIdProperty,value); }
        }

        protected static PropertyInfo<Guid> SidProperty = RegisterProperty<Guid>(new PropertyInfo<Guid>("sid"));
        public Guid Sid
        {
            get { return GetProperty(SidProperty); }
            set { SetProperty(SidProperty, value); }
        }

        protected static PropertyInfo<int> User_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("user_id"));
        public int User_Id
        {
            get { return GetProperty(User_IdProperty); }
            set { SetProperty(User_IdProperty, value); }
        }

        protected static PropertyInfo<int> Room_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("room_id"));
        public int Room_Id
        {
            get { return GetProperty(Room_IdProperty); }
            set { SetProperty(Room_IdProperty, value); }
        }

        protected static PropertyInfo<string> Room_NameProperty = RegisterProperty<string>(new PropertyInfo<string>("specific_site"));
        public string Room_Name
        {
            get { return GetProperty(Room_NameProperty); }
        }

        protected static PropertyInfo<int> Site_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("site_id"));
        public int Site_Id
        {
            get { return GetProperty(Site_IdProperty); }
            set { SetProperty(Site_IdProperty, value); }
        }

        protected static PropertyInfo<string> Site_NameProperty = RegisterProperty<string>(new PropertyInfo<string>("client"));
        public string Site_Name
        {
            get { return GetProperty(Site_NameProperty); }
        }

        protected static PropertyInfo<int> SiteType_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("site_type_id"));
        public int SiteType_Id
        {
            get { return GetProperty(SiteType_IdProperty); }
            set { SetProperty(SiteType_IdProperty, value); }
        }

        protected static PropertyInfo<int> Org_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("org_id"));
        public int Org_Id
        {
            get { return GetProperty(Org_IdProperty); }
            set { SetProperty(Org_IdProperty, value); }
        }

       
        protected static PropertyInfo<int> Service_Hour_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("service_hour_id"));
        public int Service_Hour_Id
        {
            get { return GetProperty(Service_Hour_IdProperty); }
            set { SetProperty(Service_Hour_IdProperty, value); }
        }

        protected static PropertyInfo<double> Service_LengthProperty = RegisterProperty<double>(new PropertyInfo<double>("totHours"));
        public double Service_Length
        {
            get { return GetProperty(Service_LengthProperty); }
        }

        protected static PropertyInfo<int> Contact_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("contact_id"));
        public int Contact_Id
        {
            get { return GetProperty(Contact_IdProperty); }
            set { SetProperty(Contact_IdProperty, value); }
        }

        protected static PropertyInfo<int> COVID19_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("COVID19_Id"));
        public int COVID19_Id
        {
            get { return GetProperty(COVID19_IdProperty); }
            set { SetProperty(COVID19_IdProperty, value); }
        }

        //protected static PropertyInfo<int> ProgramIdProperty = RegisterProperty<int>(new PropertyInfo<int>("programs_id"));
        //public int ProgramId
        //{
        //    get { return GetProperty(ProgramIdProperty); }
        //    set { SetProperty(ProgramIdProperty, value); }
        //}

        protected static PropertyInfo<DateTime> Service_DateProperty = RegisterProperty<DateTime>(new PropertyInfo<DateTime>("date"));
        public DateTime Service_Date
        {
            get { return GetProperty(Service_DateProperty); }
            set { SetProperty(Service_DateProperty, value); 
            
            }
        }

        protected static PropertyInfo<int> Budget_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("budget_id"));
        public int Budget_Id
        {
            get { return GetProperty(Budget_IdProperty); }
            set { SetProperty(Budget_IdProperty, value); }
        }

       
        protected static PropertyInfo<string> CommentsProperty = RegisterProperty<string>(new PropertyInfo<string>("comments"));
        public string Comments
        {
            get { return GetProperty(CommentsProperty); }
            set { SetProperty(CommentsProperty, value); }
        }

        protected static PropertyInfo<double> Service_Hour_AmountProperty = RegisterProperty<double>(new PropertyInfo<double>("service_hour_amount"));
        public double Service_Hour_Amount
        {
            get { return GetProperty(Service_Hour_AmountProperty); }
            set {  SetProperty(Service_Hour_AmountProperty, value); }
        }



        private static PropertyInfo<bool> IsSchoolFinanceRelatedProperty = RegisterProperty<bool>(new PropertyInfo<bool>("isSchoolFinanceRelated"));
        public bool IsSchoolFinanceRelated
        {
            get { return GetProperty(IsSchoolFinanceRelatedProperty); }
            set { SetProperty(IsSchoolFinanceRelatedProperty, value); }
        }

        private static PropertyInfo<bool> IsExtendedLearningOpportunitiesProperty = RegisterProperty<bool>(new PropertyInfo<bool>("ExtendedLearningOpportunities"));
        public bool IsExtendedLearningOpportunities
        {
            get { return GetProperty(IsExtendedLearningOpportunitiesProperty); }
            set { SetProperty(IsExtendedLearningOpportunitiesProperty, value); }
        }

        private static PropertyInfo<bool> IsCoreServiceProperty = RegisterProperty<bool>(new PropertyInfo<bool>("CoreService"));
        public bool IsCoreService
        {
            get { return GetProperty(IsCoreServiceProperty); }
            set { SetProperty(IsCoreServiceProperty, value); }
        }

        protected static PropertyInfo<int> FundingIdProperty = RegisterProperty<int>(new PropertyInfo<int>("funding_id"));
        public int FundingId
        {
            get { return GetProperty(FundingIdProperty); }
            set { SetProperty(FundingIdProperty, value); }
        }

        protected static PropertyInfo<int> Activity_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("activity_id"));
        public int Activity_Id
        {
            get { return GetProperty(Activity_IdProperty); }
            set { SetProperty(Activity_IdProperty, value); }
        }

        protected static PropertyInfo<string> Activity_NameProperty = RegisterProperty<string>(new PropertyInfo<string>("activity"));
        public string Activity_Name
        {
            get { return GetProperty(Activity_NameProperty); }
            set { SetProperty(Activity_NameProperty, value); }
        }

        //public static PropertyInfo<int> TEC_Purpose_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("tec_purpose_id"));
        //public int TEC_Purpose_Id
        //{
        //    get { return GetProperty(TEC_Purpose_IdProperty); }
        //    set { SetProperty(TEC_Purpose_IdProperty, value); }
        //}

        protected static PropertyInfo<int> ESC_Strand_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("esc_strand_id"));
        public int ESC_Strand_Id
        {
            get { return GetProperty(ESC_Strand_IdProperty); }
            set { SetProperty(ESC_Strand_IdProperty, value); }
        }

        protected static PropertyInfo<int> StrategyIdProperty = RegisterProperty<int>(new PropertyInfo<int>("strategy_id"));
        public int StrategyId
        {
            get { return GetProperty(StrategyIdProperty); }
            set { SetProperty(StrategyIdProperty, value); }
        }

        private static PropertyInfo<int> LeaveTypeIdProperty = RegisterProperty<int>(new PropertyInfo<int>("leave_type_id"));
        public int LeaveTypeId
        {
            get { return GetProperty(LeaveTypeIdProperty); }
            set { SetProperty(LeaveTypeIdProperty, value); }
        }

        //Added by VM 10-2-2018
        private static PropertyInfo<bool> Is22bMassCommunicationProperty = RegisterProperty<bool>(new PropertyInfo<bool>("is22bMassCommunication"));
        public bool Is22bMassCommunication
        {
            get { return GetProperty(Is22bMassCommunicationProperty); }
            set { SetProperty(Is22bMassCommunicationProperty, value); }
        }
        //Child Objects Properties
        //private static PropertyInfo<Audiences> AudiencesProperty =
        //    RegisterProperty<Audiences>(new PropertyInfo<Audiences>("Audiences"));
        //public Audiences Audiences
        //{
        //    get { return GetProperty(AudiencesProperty); }
        //    set { SetProperty(AudiencesProperty, value); }
        //}

        //Added by VM 9-26-2012
        //protected static PropertyInfo<Organizations> OrganizationsProperty =
        //   RegisterProperty<Organizations>(new PropertyInfo<Organizations>("Organizations"));
        //public Organizations Organizations
        //{
        //    get { return GetProperty(OrganizationsProperty); }
        //    set { SetProperty(OrganizationsProperty, value); }
        //}


        //protected static PropertyInfo<Sites> SitesProperty =
        //   RegisterProperty<Sites>(new PropertyInfo<Sites>("Sites"));
        //public Sites Sites
        //{
        //    get { return GetProperty(SitesProperty); }
        //    set { SetProperty(SitesProperty, value); }
        //}

        //protected static PropertyInfo<Rooms> RoomsProperty =
        //   RegisterProperty<Rooms>(new PropertyInfo<Rooms>("Rooms"));
        //public Rooms Rooms
        //{
        //    get { return GetProperty(RoomsProperty); }
        //    set { SetProperty(RoomsProperty, value); }
        //}


        private static PropertyInfo<FinancialIntegritys> FinancialIntegritysProperty =
       RegisterProperty<FinancialIntegritys>(new PropertyInfo<FinancialIntegritys>("FinancialIntegritys"));
        public FinancialIntegritys FinancialIntegritys
        {
            get { return GetProperty(FinancialIntegritysProperty); }
            set { SetProperty(FinancialIntegritysProperty, value); }
        }

        private static PropertyInfo<IncreaseStudentPerformances> IncreaseStudentPerformancesProperty =
        RegisterProperty<IncreaseStudentPerformances>(new PropertyInfo<IncreaseStudentPerformances>("IncreaseStudentPerformances"));
        public IncreaseStudentPerformances IncreaseStudentPerformances
        {
            get { return GetProperty(IncreaseStudentPerformancesProperty); }
            set { SetProperty(IncreaseStudentPerformancesProperty, value); }
        }

        private static PropertyInfo<PostSecondaryCredits> PostSecondaryCreditsProperty =
        RegisterProperty<PostSecondaryCredits>(new PropertyInfo<PostSecondaryCredits>("PostSecondaryCredits"));
        public PostSecondaryCredits PostSecondaryCredits
        {
            get { return GetProperty(PostSecondaryCreditsProperty); }
            set { SetProperty(PostSecondaryCreditsProperty, value); }
        }

        private static PropertyInfo<NonFirstStandardFinancialAssistances> NonFirstStandardFinancialAssistancesProperty =
        RegisterProperty<NonFirstStandardFinancialAssistances>(new PropertyInfo<NonFirstStandardFinancialAssistances>("NonFirstStandardFinancialAssistances"));
        public NonFirstStandardFinancialAssistances NonFirstStandardFinancialAssistances
        {
            get { return GetProperty(NonFirstStandardFinancialAssistancesProperty); }
            set { SetProperty(NonFirstStandardFinancialAssistancesProperty, value); }
        }

        //private static PropertyInfo<Topics> TopicsProperty =
        //RegisterProperty<Topics>(new PropertyInfo<Topics>("Topics"));
        //public Topics Topics
        //{
        //    get { return GetProperty(TopicsProperty); }
        //    set { SetProperty(TopicsProperty, value); }
        //}
        protected static PropertyInfo<LocationAudiences> LocationAudiencesProperty =
        RegisterProperty<LocationAudiences>(new PropertyInfo<LocationAudiences>("LocationAudiences"));
        public LocationAudiences LocationAudiences
        {
            get { return GetProperty(LocationAudiencesProperty); }
            set { SetProperty(LocationAudiencesProperty, value); }
        }

        protected static PropertyInfo<int> Travel_Hour_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("travel_hour_id"));
        public int Travel_Hour_Id
        {
            get { return GetProperty(Travel_Hour_IdProperty); }
            set { SetProperty(Travel_Hour_IdProperty, value); }
        }

        protected static PropertyInfo<double> Travel_Hour_AmountProperty = RegisterProperty<double>(new PropertyInfo<double>("travel_hour_amount"));
        public double Travel_Hour_Amount
        {
            get { return GetProperty(Travel_Hour_AmountProperty); }
            set { SetProperty(Travel_Hour_AmountProperty, value); }
        }

        //Added by VM 6-12-2018
        protected static PropertyInfo<StrategicPrioritys> StrategicPrioritysProperty =
        RegisterProperty<StrategicPrioritys>(new PropertyInfo<StrategicPrioritys>("StrategicPrioritys"));
        public StrategicPrioritys StrategicPrioritys
        {
            get { return GetProperty(StrategicPrioritysProperty); }
            set { SetProperty(StrategicPrioritysProperty, value); }
        }


        #endregion
        #region Business Rules

        protected override void AddBusinessRules()
        {
            
            ValidationRules.AddRule(ServiceDateRule, Service_DateProperty);
            ValidationRules.AddRule(ServiceLength, Service_Hour_IdProperty);
            ValidationRules.AddRule(BudgetCodeRule, Budget_IdProperty);
            ValidationRules.AddRule(FundingRule, FundingIdProperty);
            ValidationRules.AddRule(ContactMethodRule, Contact_IdProperty);
            ValidationRules.AddRule(ActivityRule, Activity_IdProperty);
            ValidationRules.AddRule(StrategyRule, StrategyIdProperty);
            ValidationRules.AddRule(ESCGoalsRule, ESC_Strand_IdProperty);
            ValidationRules.AddRule(OrganizationsRule, LocationAudiencesProperty);
            ValidationRules.AddRule(LeaveTypeRule, LeaveTypeIdProperty);

        }

        private static bool ServiceDateRule(object target, Csla.Validation.RuleArgs e)
        {
            if (((Assistance)target).Service_Date == DateTime.MinValue)
            {
                e.Description = "The service date field is required.";
                return false;
            }
            else
                return true;
        }

        private static bool ServiceLength(object target, Csla.Validation.RuleArgs e)
        {
            if (((Assistance)target).Service_Hour_Id == 0)
            {
                e.Description = "The service length field is required.";
                return false;
            }
            else
                return true;
        }

        private static bool ContactMethodRule(object target, Csla.Validation.RuleArgs e)
        {
            if (((Assistance)target).Contact_Id == 0 && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
            {
                e.Description = "The contact method field is required.";
                return false;
            }
            else
                return true;
        }

       
        private static bool BudgetCodeRule(object target, Csla.Validation.RuleArgs e)
        {
            //BudgetInfo bi = BudgetInfo.GetBudgetInfoByObjId(((Assistance)target).Budget_Id);
            //if (!bi.Active && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
            //{
            //    e.Description = "The budget code  is invalid.";
            //    return false;
            //}
            //else
            //    return true;

            

            if (((Assistance)target).Budget_Id == 0)
            {
                    e.Description = "The Budget Code field is required.";
                    return false;
            }
            else
                return true;
        }

        //private static bool AudiencesRule(object target, Csla.Validation.RuleArgs e)
        //{
        //    if (((Assistance)target).Audiences.Count == 0 && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
        //    {
        //        e.Description = "The audience served field is required.";
        //        return false;
        //    }
        //    else
        //        return true;
        //}

        private static bool ActivityRule(object target, Csla.Validation.RuleArgs e)
        {
            
            if (((Assistance)target).Activity_Id == 0)
            {
                    e.Description = "The activity field is required.";
                    return false;
            }
            else
                return true;
        }

        private static bool OrganizationsRule(object target, Csla.Validation.RuleArgs e)
        {
            //if (((Assistance)target).LocationAudiences.Count == 0 && !((Assistance)target).Activity_Name.ToLower().Contains("leave") && ((Assistance)target).Activity_Name.ToLower() != "jury duty")
            if (((Assistance)target).LocationAudiences.Count == 0 && ((Assistance)target).Activity_Name.ToLower().Contains("technical") )
            {
                e.Description = "The Location/Audience/#Served field is required.";
                return false;
            }
            else
                return true;
        }

        private static bool FundingRule(object target, Csla.Validation.RuleArgs e)
        {
            
            if ( ((Assistance)target).FundingId==0)
            {
                e.Description = "The Funding field is required.";
                return false;
            }
            else
                return true;
        }

        private static bool StrategyRule(object target, Csla.Validation.RuleArgs e)
        {

            if (((Assistance)target).StrategyId == 0 && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
            {
                e.Description = "The Strategies field is required.";
                return false;
            }
            else
                return true;
        }

        private static bool ESCGoalsRule(object target, Csla.Validation.RuleArgs e)
        {

            if (((Assistance)target).ESC_Strand_Id == 0 && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
            {
                e.Description = "The ESC Goals field is required.";
                return false;
            }
            else
                return true;
        }


        //private static bool OrganizationsRule(object target, Csla.Validation.RuleArgs e)
        //{
        //    if (((Assistance)target).Organizations.Count == 0 && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
        //    {
        //         e.Description = "The location field is required.";
        //         return false;
        //    }
        //    else
        //        return true;
        //}

        //private static bool ProgramRule(object target, Csla.Validation.RuleArgs e)
        //{
        //    if (((Assistance)target).ProgramId == 0 && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
        //    {
        //         e.Description = "The programs field is required.";
        //        return false;
        //    }
        //    else
        //        return true;
        //}

        private static bool CustomerRule(object target, Csla.Validation.RuleArgs e)
        {
            if (((Assistance)target).Site_Id == 0 && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
            {
                e.Description = "The client field is required.";
                return false;
            }
            else
                return true;
        }

        private static bool SpecificSiteRule(object target, Csla.Validation.RuleArgs e)
        {
            if ((((Assistance)target).SiteType_Id == 521 || ((Assistance)target).SiteType_Id == 522) && ((Assistance)target).Activity_Name.ToLower() == "technical assistance")
            {
                if (((Assistance)target).Room_Id == 0)
                {
                    e.Description = "The specific site field is required.";
                    return false;
                }
                else
                    return true;
            }
            else
            {
                return true;
            }
        }

        private static bool LeaveTypeRule(object target, Csla.Validation.RuleArgs e)
        {
            //if (((Assistance)target).LocationAudiences.Count == 0 && !((Assistance)target).Activity_Name.ToLower().Contains("leave") && ((Assistance)target).Activity_Name.ToLower() != "jury duty")
            if (((Assistance)target).Activity_Name.ToLower() == "leave" && ((Assistance)target).LeaveTypeId == 0)
            {
                e.Description = "The Leave Type is required.";
                return false;
            }
            else
                return true;
        }

        #endregion

        #region Business Methods

        public Assistance CallCheckRules(Assistance a)
        {
            ValidationRules.CheckRules();
            return a;
        }

        public bool isEditable()
        {
            ConfigurationInfoList list = ConfigurationInfoList.GetConfigurationInfoList(Service_Date.Year.ToString());
            ConfigurationInfo ci = list.GetConfigurationInfo(Service_Date.Month.ToString(), Service_Date.Year.ToString());
            if (ci == null) //Do not set a close date
                return false;
            else
            {
                if (DateTime.Today > ci.ClosingDate) // Closing date is over/no closing date is set
                    return false;
                else
                    return true;
            }
        }

        #endregion


        #region Factory Methods
        protected Assistance()
        { /* require use of factory methods */ }

        internal static Assistance NewAssistance()
        {     
            
            return DataPortal.CreateChild<Assistance>();
        }
     
        
        public static Assistance GetAssistence(SafeDataReader dr)
        {
            return DataPortal.FetchChild<Assistance>(dr);
        }

        public static Assistance CreateNew()
        {
            
            return NewAssistance();
        }

        #endregion

        #region Data Access

        protected override void Child_Create()
        {
            
            using (BypassPropertyChecks)
            {
                this.ObjId = -1;
                this.LocationAudiences = LocationAudiences.NewLocationAudiences();
                this.IncreaseStudentPerformances = IncreaseStudentPerformances.NewIncreaseStudentPerformances();
                this.PostSecondaryCredits = PostSecondaryCredits.NewPostSecondaryCredits();
                this.FinancialIntegritys = FinancialIntegritys.NewFinancialIntegritys();
                this.NonFirstStandardFinancialAssistances = NonFirstStandardFinancialAssistances.NewNonFirstStandardFinancialAssistances();
                this.StrategicPrioritys = StrategicPrioritys.NewStrategicPrioritys(); // Added by VM 6-12-2018

            }
        }

        protected void MapFieldsFromData(SafeDataReader dr)
        {
            using (BypassPropertyChecks)
            {
                LoadProperty(ObjIdProperty, dr.GetInt32("obj_id"));
                LoadProperty(User_IdProperty, dr.GetInt32("user_id"));
                LoadProperty(SidProperty, dr.GetGuid("sid"));
                LoadProperty(Room_IdProperty, dr.GetInt32("room_id"));
                LoadProperty(Room_NameProperty, dr.GetString("specific_site"));
                LoadProperty(Site_IdProperty, dr.GetInt32("site_id"));
                LoadProperty(SiteType_IdProperty, dr.GetInt32("site_type_id"));
                LoadProperty(Site_NameProperty, dr.GetString("client"));
                LoadProperty(Org_IdProperty, dr.GetInt32("org_id"));
                LoadProperty(Service_Hour_IdProperty, dr.GetInt32("service_hour_id"));
                LoadProperty(Service_LengthProperty, dr.GetDouble("totHours"));
                LoadProperty(Service_Hour_AmountProperty, dr.GetDouble("service_hour_amount"));
                LoadProperty(Contact_IdProperty, dr.GetInt32("contact_id"));
                LoadProperty(Service_DateProperty, dr.GetSmartDate("date", true));
                LoadProperty(Budget_IdProperty, dr.GetInt32("budget_id"));
                LoadProperty(CommentsProperty, dr.GetString("comments"));
                LoadProperty(IsSchoolFinanceRelatedProperty, dr.GetBoolean("isSchoolFinanceRelated"));
                LoadProperty(IsExtendedLearningOpportunitiesProperty, dr.GetBoolean("ExtendedLearningOpportunities"));
                LoadProperty(IsCoreServiceProperty, dr.GetBoolean("CoreService"));
                LoadProperty(FundingIdProperty, dr.GetInt32("funding_id"));
                LoadProperty(Activity_IdProperty, dr.GetInt32("activity_id"));
                LoadProperty(Activity_NameProperty, dr.GetString("activity"));
                LoadProperty(Travel_Hour_AmountProperty, dr.GetDouble("travel_hour_amount"));
                LoadProperty(Travel_Hour_IdProperty, dr.GetInt32("travel_hour_id"));
                LoadProperty(ESC_Strand_IdProperty, dr.GetInt32("esc_strand_id"));
                LoadProperty(StrategyIdProperty, dr.GetInt32("strategy_id"));
                LoadProperty(LeaveTypeIdProperty, dr.GetInt32("leave_type_id"));
                LoadProperty(Is22bMassCommunicationProperty, dr.GetBoolean("is22bMassCommunication")); //Added by VM 10-2-2018
                LoadProperty(COVID19_IdProperty, dr.GetInt32("COVID19_Id"));
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected void Child_Update(Assistances a)
        {
            
            if (this.IsSelfDirty)
            {
                using (SqlConnection cn = region4.Common.DataConnection.DbConnection)
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        // Update activity info
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "ItsAssistancesUpdate";
                        cm.Parameters.AddWithValue("@obj_id", this.ObjId);
                        this.MapFieldsToParams(cm);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            this.DataPortal_Update();

        }

        protected void Child_Insert(Assistances a)
        {
            if (this.IsNew)
            {

                using (SqlConnection cn = region4.Common.DataConnection.DbConnection)
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ItsAssistancesInsert";
                        cmd.Parameters.AddWithValue("@obj_id", this.ObjId).Direction = ParameterDirection.Output;
                        this.MapFieldsToParams(cmd);
                        cmd.ExecuteNonQuery();
                        this.ObjId = Convert.ToInt32(cmd.Parameters["@obj_id"].Value);
                    }
                    this.DataPortal_Update();
                }
            }
        }

        protected void Child_DeleteSelf(Assistances a)
        {
            
            if (this.IsDeleted)
            {
                using (SqlConnection cn = region4.Common.DataConnection.DbConnection)
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ItsAssistancesDelete";
                        cmd.Parameters.AddWithValue("@obj_id", this.ObjId);
                        cmd.ExecuteNonQuery();
                    }
                    this.DataPortal_Update();
                }
            }
        }

        private void Child_Fetch(SafeDataReader dr)
        {
            MapFieldsFromData(dr);

            LoadProperty(IncreaseStudentPerformancesProperty, IncreaseStudentPerformances.GetIncreaseStudentPerformances(dr.GetInt32("obj_id")));
            LoadProperty(PostSecondaryCreditsProperty, PostSecondaryCredits.GetPostSecondaryCredits(dr.GetInt32("obj_id")));
            LoadProperty(FinancialIntegritysProperty, FinancialIntegritys.GetFinancialIntegritys(dr.GetInt32("obj_id")));
            LoadProperty(NonFirstStandardFinancialAssistancesProperty, NonFirstStandardFinancialAssistances.GetNonFirstStandardFinancialAssistances(dr.GetInt32("obj_id")));
            LoadProperty(LocationAudiencesProperty, LocationAudiences.GeLocationAudiences(dr.GetInt32("obj_id")));
            LoadProperty(StrategicPrioritysProperty, StrategicPrioritys.GetStrategicPrioritys(dr.GetInt32("obj_id"))); // Added by VM 6-12-2018


            Child_Fetch_Customize(dr);
            //_service_hour_amount = GetHours(dr.GetInt32("service_hour_id"));
            //_travel_hour_amount = GetHours(dr.GetInt32("travel_hour_id"));
        }

        protected virtual void Child_Fetch_Customize(SafeDataReader dr)
        {
        }

        protected void MapFieldsToParams(SqlCommand cmd)
        {
            //cmd.Parameters.AddWithValue("@obj_id", ObjId);
            cmd.Parameters.AddWithValue("user_id", User_Id);
            cmd.Parameters.AddWithValue("room_id", Room_Id);
            cmd.Parameters.AddWithValue("site_id", Site_Id);
            cmd.Parameters.AddWithValue("org_id", Org_Id);
            cmd.Parameters.AddWithValue("service_hour_id", Service_Hour_Id);
            cmd.Parameters.AddWithValue("contact_id", Contact_Id);
            cmd.Parameters.AddWithValue("date", Service_Date);
            cmd.Parameters.AddWithValue("budget_id", Budget_Id);
            cmd.Parameters.AddWithValue("comments", Comments);
            cmd.Parameters.AddWithValue("isSchoolFinanceRelated", IsSchoolFinanceRelated);
            cmd.Parameters.AddWithValue("ExtendedLearningOpportunities", IsExtendedLearningOpportunities);
            cmd.Parameters.AddWithValue("CoreService", IsCoreService);
            cmd.Parameters.AddWithValue("funding_id", FundingId);
            cmd.Parameters.AddWithValue("activity_id", Activity_Id);
            cmd.Parameters.AddWithValue("travel_hour_id", Travel_Hour_Id);
            cmd.Parameters.AddWithValue("esc_strand_id", ESC_Strand_Id);
            cmd.Parameters.AddWithValue("strategy_id", StrategyId);
            cmd.Parameters.AddWithValue("leave_type_id", LeaveTypeId);
            cmd.Parameters.AddWithValue("is22bMassCommunication", Is22bMassCommunication); //Added by VM 10-2-2018
            cmd.Parameters.AddWithValue("COVID19_Id", COVID19_Id);
        }


       
        public  double GetHours(int id)
        {
            double amount=0.0;

            using (SqlConnection cn = region4.Common.DataConnection.DbConnection)
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ItsHoursAmountGet";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@amount", amount).Direction = ParameterDirection.Output;      
                    cmd.ExecuteNonQuery();
                    amount = cmd.Parameters["@amount"].Value == DBNull.Value ? 0 : Convert.ToDouble(cmd.Parameters["@amount"].Value);
                }
            
            }

            return amount;
        }


        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (SqlConnection dbConn = region4.Common.DataConnection.DbConnection)
            {
                dbConn.Open();

                //need to add to this later
                if (
                    //(FieldManager.FieldExists(AudiencesProperty) && this.Audiences.IsDirty) 
                    //|| 
                    (FieldManager.FieldExists(FinancialIntegritysProperty) && this.FinancialIntegritys.IsDirty)
                    || (FieldManager.FieldExists(IncreaseStudentPerformancesProperty) && this.IncreaseStudentPerformances.IsDirty)
                    || (FieldManager.FieldExists(PostSecondaryCreditsProperty) && this.PostSecondaryCredits.IsDirty)
                    || (FieldManager.FieldExists(NonFirstStandardFinancialAssistancesProperty) && this.NonFirstStandardFinancialAssistances.IsDirty)
                    || (FieldManager.FieldExists(LocationAudiencesProperty) && this.LocationAudiences.IsDirty)
                    || (FieldManager.FieldExists(StrategicPrioritysProperty) && this.StrategicPrioritys.IsDirty)) // Added by VM 6-12-2018
                {
                    FieldManager.UpdateChildren(this, dbConn);
                }
            }
        }

        #endregion
    }
}
