using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capita.PruApp.BusinessTests.Phase2.Constants
{
    class ConstantsList
    {
        //List of browsers. Don't worry about case, the Driver Manager coverts to lowercase before using them.
        public const string fireFox = "FireFox";
        public const string chrome = "chrome";
        public const string ie10 = "ie10";
        public const string ie11 = "ie11";

        //List of page titles
        public const string loginTitle = "Welcome to the Prudential ISA application site";
        public const string dashBoardTitle = "Home Page";
        public const string ExistingCustomerTitle = "Existing Customer";
        public const string InvestorDetailsTitle = "Investor details";
        public const string InvestorAddressTitle = "Investor address";
        public const string InvestorNationalityTitle = "Investor nationality";
        public const string InvestorNINOTitle = "Investor national insurance number";
        public const string InvestmentFundsTitle = "Investment funds";
        public const string SingleSetupChargeTitle = "Single Investment Set-up Adviser Charge";
        public const string OngoingChargeTitle = "Ongoing Advisor Charges";
        public const string RegularWithdrawalTitle = "Regular Withdrawal Facility";
        public const string SingleInvesmentPaymentTitle = "Payment Details";
        public const string CVIInvestorTitle  = "Confirmation of verification of identity";
        public const string CVIInvestor2Title = "Confirmation of verification of identity evidence";
        public const string CVIDonorTitle     = "Confirmation of verification of identity";
        public const string CVIDonor2Title    = "Confirmation of verification of identity evidence";


        //Modal headers
        public const string registerHeader = "Need to register?";
        public const string forgottenHeader = "Forgotten your details?";


        //List of URLS - see selenium course for how to use URL type rather than str
       // public const string pruAppLogin =   "https://prptrnonlineisa.casfs.co.uk/src/#/login/";
        public const string pruAppLogin = "https://prptrnonlineisa.casfs.co.uk/src/#/login/"; //training int
        public const string d2cWelcome = "https://prpintd2c.casfs.co.uk/src/#/welcome";

        //List of currently working IFA codes
        public const string ifaOne = "35235";
        public const string ifaTwo = "35158";
        public const string ifaThree = "32354";

        //Investment types
        public const string SinglePayment = "Single";
        public const string RegularPayment = "Regular";
        public const string TransferInPayment = "Transfer";

        //Payment Methods
        public const string Direct = "DirectPayment";
        public const string Cheque = "Cheque";

        //Dropdown constants
        //Charge Frequencies
        public const string Monthly = "Monthly";
        public const string Quarterly = "Quarterly";
        public const string Half_Yearly = "HalfYearly";
        public const string Yearly = "Yearly";

        //Miscellaneous constants
        public const string password = "Password.1";
        public const int ISALimit = 15240;
       

        ////////CONSTANTS FOR EDEN//////////////
        //public const string OLDEden_pruAppLogin = "https://ednintisa.casfs.co.uk/app/#/login/";
        public const string Eden_pruAppLogin    = "https://prpintonlineisa.casfs.co.uk/src/#/login/";
        public const string Screenshot_folder = "C:\\repos\\capita.businesstests\\src\\Capita.PruApp.BusinessTests.Phase2\\Screenshots\\";
                                                
        
        public const string Eden_Alt_pruAppLogin = "https://ednintisa.casfs.co.uk/app/";
        public const string Eden_LoginTitle = "Prudential ISA applications";
        public const string Eden_DashboardTitle = "Prudential ISA applications";

        //Application statuses
        public const string Status_Complete     = "Completed";
        public const string Status_InProgress   = "In progress";
        public const string Status_Submitted    = "Submitted";

        //Screen Headers
        public const string Eden_DashboardHeader                = "Start a new application";
        public const string Eden_NewOrExistingHeaderText        = "New or existing investor?";
        public const string Eden_NewInvestorDetailsHeaderText   = "New investor details";
        public const string Eden_InvestorNationalityHeaderText  = "Nationality";
        public const string Eden_InvestmentFundsHeaderText      = "Investment Funds";
        public const string Eden_SingleSetupChargeHeaderText    = "Single investment set-up adviser charge";
        public const string Eden_TransferSetupChargeHeaderText  = "Transfer in set-up adviser charge"; 
        public const string Eden_OngoingChargeHeaderText        = "Ongoing adviser charges";
        public const string Eden_RegularWithdrawalHeaderText    = "Regular withdrawal facility";
        public const string Eden_SinglePaymentHeaderText        = "Single investment payment details";
        public const string Eden_TransferInHeaderText           = "Transfer in";
        public const string Eden_CVIInvestorHeaderText          = "Confirmation of verification of identity – private individual";
        public const string Eden_CVIInvestor2ndHeaderText       = "Confirmation of verification of identity – private individual";
        public const string Eden_AdviserDeclarationHeaderText   = "Adviser declaration";
        public const string Eden_InvestorDeclarationChoiceText  = "Investor declaration choice";
        public const string Eden_ApplicationSummaryHeaderText   = "Application summary";
        public const string Eden_NextStepsHeaderText            = "Your next steps";
    }

}