// -----------------------------------------------------------------------
// <copyright file="Scripts.cs" company="John">
// Acupuncture Clinic Record Management System 2015
// </copyright>
// -----------------------------------------------------------------------

namespace AcupunctureClinic.Data.Sql
{
    /// <summary>
    /// DBConstants static class contains sql string constants
    /// </summary>
    public static class Scripts
    {
        /// <summary>
        /// Sql to get a  customer details by Id
        /// </summary>
        public static readonly string sqlGetCustomerById = "Select * From Customer Where CustomerID = @CustomerID";
        //    " Id, Name, DateOfBirth, Occupation, MaritalStatus, Sex, Salary, NumberOfChildren" +
        //    " From Customer Where Id = @Id";

        /// <summary>
        /// Sql to get all  customers
        /// </summary>
        public static readonly string SqlGetAllCustomers = "Select * From Customer";
        //public static readonly string SqlGetAllCustomers = "Select" +
        //    " CustomerID, Fname, Lname, Sex, DoB, MaritalStatus, Occupation, Employer, SSI, ID" +
        //    " From Customer";

        /// <summary>
        /// sql to insert a  customer details
        /// </summary>
        public static readonly string SqlInsertCustomer = "Insert Into" +
            " Customer(Fname, Lname, Sex, DoB, MaritalStatus, Occupation, Employer, SSN, DLN)" +
            " Values(@Fname, @Lname, @Sex, @DoB, @MaritalStatus, @Occupation, @Employer, @SSI, @DLN)";



        /// <summary>
        /// sql to search for  customers
        /// </summary>
        public static readonly string SqlSearchCustomers = "Select " +
            " CustomerID, Fname, Lname, Sex, DoB, MaritalStatus, Occupation, Employer, SSN, DLN" +
            " From Customer Where (@CustomerID Is NULL OR @CustomerID = CustomerID) {0}" +
            " (@Lname Is NULL OR @Lname = Lname)";

        /// <summary>
        /// sql to update  customer details
        /// </summary>
        public static readonly string sqlUpdateCustomer = "Update Customer " +
            " Set [Fname] = @Fname, [Lname] = @Lname,[Sex] = @Sex, [DoB] = @DoB, [MaritalStatus] = @MaritalStatus," +
            " [Occupation] = @Occupation, [Employer] = @Employer, " +
            "   [SSN] = @SSN,  [DLN] = @DLN Where ([CustomerID] = @CustomerID)";

        /// <summary>
        /// sql to delete a  customer record
        /// </summary>
        public static readonly string sqlDeleteCustomer = "Delete From Customer Where (CustomerID = @CustomerID)";

        /// <summary>
        /// Sql to get a customer contact details by Id
        /// </summary>
        public static readonly string sqlGetContactById = "Select * From Customer_Contact Where CustomerID = @CustomerID";


        /// <summary>
        /// sql to update customer contact details
        /// </summary>
        public static readonly string sqlUpdateContact = "Update Customer_Contact " +
            " Set [StreetOrApt] = @StreetOrApt,[City] = @City, [State] = @State, [Zip] = @Zip," +
            " [Phone] = @Phone, [CellPhone] = @CellPhone, [Guardian] = @Guardian, [GuardianPhone] = @GuardianPhone Where ([CustomerID] = @CustomerID)";


        /// <summary>
        /// sql to delete customer contact details
        /// </summary>
        public static readonly string sqlDeleteContact = "Delete From Customer_Contact Where (CustomerID = @CustomerID)";

        /// <summary>
        /// sql to update customer contact details
        /// </summary>
        public static readonly string sqlInsertContact = "Insert Into Customer_Contact " +
            " (CustomerID, StreetOrApt,City, State, Zip, Phone, CellPhone, Guardian, GuardianPhone)" +
            " Values(@CustomerID, @StreetOrApt,@City, @State, @Zip, @Phone, @CellPhone, @Guardian, @GuardianPhone)";

        /// <summary>
        /// Sql to get a customer account by Id
        /// </summary>
        public static readonly string sqlGetAccountById = "Select * From Customer_Account Where CustomerID = @CustomerID";


        /// <summary>
        /// Sql to get invoice records by Id
        /// </summary>
        public static readonly string sqlGetInvoicesById = "Select * From Invoice Where CustomerID = @CustomerID";

        /// <summary>
        /// Sql to add invoice record 
        /// </summary>
        public static readonly string sqlAddInvoice = "Insert Into" +
            " Invoice (CustomerID, InvDate, ProcedureCode, HMCode, DiscountRate, PaymentMethod, CardType, CardNo, ExpDate, " +
                " SubTotal, AmountPaid, Balance, Total)  Values(@CustomerID, @InvDate, @ProcedureCode, @HMCode, @DiscountRate, " +
                " @PaymentMethod, @CardType, @CardNo, @ExpDate, @SubTotal, @AmountPaid, @Balance, @Total)";

        /// <summary>
        /// Sql to update invoice record 
        /// </summary>
        public static readonly string sqlUpdateInvoice = "Update Invoice " +
            " Set [CustomerID] = @CustomerID,[InvDate] = @InvDate, [ProcedureCode] = @ProcedureCode, [HMCode] = @HMCode," +
            " [DiscountRate] = @DiscountRate, [PaymentMethod] = @PaymentMethod, [CardType] = @CardType, [CardNo] = @CardNo, " +
            " [ExpDate] = @ExpDate, [SubTotal] = @SubTotal, [AmountPaid] = @AmountPaid, [Balance] = @Balance, [Total] = @Total " +
            " where ([InvNo] = @InvNo) ";

        /// <summary>
        /// sql to delete invoice details
        /// </summary>
        public static readonly string sqlDeleteInvoice = "Delete From Invoice Where (InvNo = @InvNo)";

        /// <summary>
        /// Sql to get a HealthInfor by Id
        /// </summary>
        public static readonly string sqlSelectHealthInforById = "Select * From Health_Infor Where CustomerID = @CustomerID";

        /// <summary>
        /// Sql add a record to Health_Infor 
        /// </summary>
        public static readonly string sqlAddHealthInfor = "Insert Into" +
            " Health_Infor (CustomerID, Family_History, Allergies, Musculoskeletal, Motor ) " +
            "  Values(@CustomerID, @Family_History, @Allergies, @Musculoskeletal, @Motor) ";

        public static readonly string sqlUpdateHealthInfor = "Update Health_Infor " +
            " Set [Family_History] = @Family_History, [Allergies] = @Allergies, [Musculoskeletal] = @Musculoskeletal," +
            " [Motor] = @Motor  where ([CustomerID] = @CustomerID) ";

        
        /// <summary>
        /// Sql to get invoice records by Id
        /// </summary>             
        public static readonly string sqlSelectInitVisitById = "Select * From Initial_Visit Where CustomerID = @CustomerID ORDER BY InitialDate ASC "; //ASCENDING

        /// <summary>
        /// Sql to get initial visiting infor records by InitNo
        /// </summary>      
        public static readonly string sqlSelectInitVisitByInitNo = "Select * From Initial_Visit Where CustomerID = @CustomerID and InitialNo = @InitialNo ORDER BY InitialDate ASC "; //ASCENDING
        
        /// <summary>
        /// Sql to get invoice records by Id
        /// </summary>        
        public static readonly string sqlSelectFollowupVisitById = "Select * From Follow_Up_Visit Where CustomerID = @CustomerID ORDER BY InitialNo ASC, FollowUpNo ASC "; //ASCENDING

        /// <summary>
        /// Sql to get invoice records by Id
        /// </summary>        
        public static readonly string sqlSelectFollowupVisitByInitNo = "Select * From Follow_Up_Visit Where (CustomerID = @CustomerID and InitialNo = @InitialNo and FollowUpNo = @FollowUpNo) ORDER BY InitialNo , FollowUpNo ASC "; //ASCENDING

        /// <summary>
        /// Sql to get invoice records by Id
        /// </summary>        
        public static readonly string sqlSelectInitVisitByInitNoOnly = "Select * From Follow_Up_Visit Where (CustomerID = @CustomerID and InitialNo = @InitialNo) ORDER BY InitialNo , FollowUpNo ASC "; //ASCENDING


        /// <summary>
        /// Sql to get invoice records by Id
        /// </summary>        
        public static readonly string sqlSelectInitVisitByFollowUpNoOnly = "Select * From Follow_Up_Visit Where (CustomerID = @CustomerID and FollowUpNo = @FollowUpNo) ORDER BY InitialNo , FollowUpNo ASC "; //ASCENDING

        /// <summary>
        /// Sql add a record to Health_Infor 
        /// </summary>
        public static readonly string sqlAddInitVisit = "Insert Into" +
            " Initial_Visit (CustomerID, InitialNo, InitialDate, Medications, ChiefComplaint, HistoryOfPresentIllness, " +
            " BP, Pulse, Cranial, Cerbellar, DeepTendonRef, Sensory, Impression ) " +
            "  Values(@CustomerID,@InitialNo, @InitialDate, @Medications, @ChiefComplaint, @HistoryOfPresentIllness, " +
            " @BP, @Pulse, @Cranial, @Cerbellar, @DeepTendonRef, @Sensory, @Impression )";
        
        /// <summary>
        /// Sql update a record to Initial_Visit 
        /// </summary>
        public static readonly string sqlUpdateInitVisit = "Update Initial_Visit " +
            " Set [InitialDate] = @InitialDate, [Medications] = @Medications, [ChiefComplaint] = @ChiefComplaint," +
            " [HistoryOfPresentIllness] = @HistoryOfPresentIllness, [BP] = @BP, [Pulse] = @Pulse, [Cranial] = @Cranial," +
            " [Cerbellar] = @Cerbellar, [DeepTendonRef] = @DeepTendonRef, [Sensory] = @Sensory, [Impression] = @Impression  where ([CustomerID] = @CustomerID and [InitialNo] = @InitialNo)";
        
        /// <summary>
        /// Sql add a record to Follow_Up_Visit 
        /// </summary>
        public static readonly string sqlAddFollowUpVisit = "Insert Into" +
            " Follow_Up_Visit (CustomerID, InitialNo, FollowUpNo, FollowUpDate, Subjective, Objective, DiagnosticsCode, " +
            " ProcedureCode, HM_Code ) " +
            "  Values(@CustomerID,@InitialNo, @FollowUpNo, @FollowUpDate, @Subjective, @Objective, @DiagnosticsCode, " +
            " @ProcedureCode, @HM_Code )";
        
        /// <summary>
        /// Sql update a record in Follow_Up_Visit 
        /// </summary>
        public static readonly string sqlUpdateFollowUpVisit = "Update Follow_Up_Visit " +
        " Set [FollowUpDate] = @FollowUpDate, [Subjective] = @Subjective, [Objective] = @Objective," +
        " [DiagnosticsCode] = @DiagnosticsCode, [ProcedureCode] = @ProcedureCode, [HM_Code] = @HM_Code " +
        " where ([CustomerID] = @CustomerID and [InitialNo] = @InitialNo) and [FollowUpNo] = @FollowUpNo";
 
        ///SQL Codes accessing Treatment_Procedure table
        /// <summary>
        /// Sql Select all records in Treatment_Procedure 
        /// </summary>
        public static readonly string sqlLoadProcedureCodes = "Select * From Treatment_Procedure ORDER BY Procedure_Code  ASC"; //DESC"; ASC ";
        
        /// <summary>
        /// Sql add a record to Trement_Procedure 
        /// </summary>
        public static readonly string sqlAddProcedureCode = "Insert Into" +
            " Treatment_Procedure (Procedure_Code, Description, Price ) " +
            "  Values(@ProcedureCode,@ProcedureName, @Price ) ";
        
        /// <summary>
        /// sql to delete procedure code record
        /// </summary>
        public static readonly string sqlDeleteProcedureCode = "Delete From Treatment_Procedure Where (Procedure_Code = @ProcedureCode)";


        /// <summary>
        /// Sql update a record in Follow_Up_Visit 
        /// </summary>
        public static readonly string sqlUpdateProcedureCode = "Update Treatment_Procedure " +
        " Set [Description] = @ProcedureName, [Price] = @Price " +
        " where [Procedure_Code] = @ProcedureCode";

        ///SQL Codes accessing Herbs_Medicines table
        /// <summary>
        /// Sql Select all records in Herbs_Medicines 
        /// </summary>
        public static readonly string sqlLoadHMCodes = "Select * From Herbs_Medicines ORDER BY H_M_Code  ASC"; //DESC"; ASC ";

        /// <summary>
        /// Sql add a record to Trement_HM 
        /// </summary>
        public static readonly string sqlAddHMCode = "Insert Into" +
            " Herbs_Medicines (H_M_Code, Description, Price ) " +
            "  Values(@HMCode,@Description, @Price ) ";

        /// <summary>
        /// sql to delete procedure code record
        /// </summary>
        public static readonly string sqlDeleteHMCode = "Delete From Herbs_Medicines Where (H_M_Code = @HMCode)";


        /// <summary>
        /// Sql update a record in Follow_Up_Visit 
        /// </summary>
        public static readonly string sqlUpdateHMCode = "Update Herbs_Medicines " +
        " Set [Description] = @Description, [Price] = @Price " +
        " where [H_M_Code] = @HMCode";
 
        /// <summary>
        /// Sql Get the last initial No for the customer 
        /// </summary>
        public static readonly string sqlCreateInitialNoByID = "Select  MAX(InitialNo) From Initial_Visit Where CustomerID = @CustomerID";

              /// <summary>
        /// Sql Get the last Follow up No for the customer and Initial No
        /// </summary>
        public static readonly string sqlCreateFollowupNoByID = "Select  MAX(FollowUpNo) From Follow_Up_Visit Where CustomerID = @CustomerID AND InitialNo = @InitialNo";

        ///SQL Codes accessing Diagnostics table
        /// <summary>
        /// Sql Select all records in Treatment_Procedure 
        /// </summary>
        public static readonly string sqlLoadDiagCodes = "Select Diagnostics_Code, Description From Diagnostics_Codes ORDER BY Diagnostics_Code  ASC"; //DESC"; ASC ";

        /// <summary>
        /// Sql add a record to Trement_Procedure 
        /// </summary>
        public static readonly string sqlAddDiagCode = "Insert Into" +
            " Diagnostics_Codes (Diagnostics_Code, Description ) " +
            "  Values(@DiagnosticsCode,@Description ) ";
     
       /// <summary>
        /// sql to delete diagnostics code record
        /// </summary>
        public static readonly string sqlDeleteDiagCode = "Delete From Diagnostics_Codes Where (Diagnostics_Code = @DiagnosticsCode)";


        /// <summary>
        /// Sql update a record in Diagnostics_Codes 
        /// </summary>
        public static readonly string sqlUpdateDiagCode = "Update Diagnostics_Codes " +
        " Set [Description] = @Description " +
        " where [Diagnostics_Code] = @DiagnosticsCode";

    }
}