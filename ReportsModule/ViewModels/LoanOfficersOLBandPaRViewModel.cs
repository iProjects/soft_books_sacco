using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportsModule.ViewModels
{
   public class LoanOfficersOLBandPaRViewModel
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
               return "Loan Officers OLB and PaR";
           }
       }
   }
}
