using System;
using System.Windows.Forms;
using ReportsModule.ViewModels;
using CommonLib;
using DAL;

namespace ReportsModule.ViewModels
{
   public class WrittenoffPenaltiesViewModel
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
               return "Written off Penalties";
           }
       }
   }
}
