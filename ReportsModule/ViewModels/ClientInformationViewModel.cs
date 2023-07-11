using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  DAL;
namespace ReportsModule.ViewModels
{
    public class ClientInformationViewModel
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTelephone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanySlogan { get; set; }
        public DateTime PrintedOn { get; set; }
        public string ReportName
        {
            get
            {
                return "Client Personal Information\n";
            }
        }
        public string PersonalInfoReportName
        {
            get
            {
                return "Personal Information\n";
            }
        }
        public string CreditInfoReportName
        {
            get
            {
                return "Credit Information\n";
            }
        }
        public string SavingsInfoReportName
        {
            get
            {
                return "Savings Information\n";
            }
        }
        public List<ClientPersonalInformationModel> _PersonalInformation { get; set; }
        public List<ClientPersonalInformationCreditModel> _PersonalInformationCredit { get; set; }
        public List<ClientPersonalInformationSavingsModel> _PersonalInformationSavings { get; set; }














    }
}