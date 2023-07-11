using System;
using System.Windows.Forms;
using ReportsModule.ViewModels;
using CommonLib;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace ReportsModule.ViewModelBuilders
{
    public class ClientInformationViewModelBuilders
    {
        ClientInformationViewModel _ViewModel;
        bool error = false;
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        string companyLogo;
        string companyslogan;
        string companyname;
        string companytelephone;
        string companyaddress;
        string companyemail;
        string companywebsite;
        int _personid;
        int _branchid;

        public ClientInformationViewModelBuilders(int personid, int branchid, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            companyLogo = rep.SettingLookup("COMPANYLOGO");
            companyslogan = rep.SettingLookup("COMPANYSLOGAN");
            companyname = rep.SettingLookup("COMPANYNAME");
            companytelephone = rep.SettingLookup("COMPANYTELEPHONE");
            companyaddress = rep.SettingLookup("COMPANYADDRESS");
            companyemail = rep.SettingLookup("COMPANYEMAIL");
            companywebsite = rep.SettingLookup("COMPANYWEBSITE");

            _personid = personid;
            _branchid = branchid;
        }
        public ClientInformationViewModel GetModelBuilder()
        {
            try
            {
                Build();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void Build()
        {
            try
            {
                _ViewModel = new ClientInformationViewModel();
                _ViewModel.PrintedOn = DateTime.Now;
                _ViewModel.CompanyLogo = companyLogo;
                _ViewModel.CompanySlogan = companyslogan;
                _ViewModel.CompanyName = companyname;
                _ViewModel.CompanyEmail = companyemail;
                _ViewModel.CompanyAddress = companyaddress;
                _ViewModel.CompanyTelephone = companytelephone;
                _ViewModel.CompanyWebsite = companywebsite;

                _ViewModel._PersonalInformation = this.GetClientPersonalInformation();
                _ViewModel._PersonalInformationCredit = this.GetClientPersonalInformationCredit();
                _ViewModel._PersonalInformationSavings = this.GetClientPersonalInformationSavings();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<ClientPersonalInformationModel> GetClientPersonalInformation()
        {
            try
            {
                var _clientinfoquery = from ci in rep.GetClientPersonalInformation(_personid, _branchid)
                                       select ci;
                return _clientinfoquery.ToList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private List<ClientPersonalInformationCreditModel> GetClientPersonalInformationCredit()
        {
            try
            {
                var _clientinfoquery = from ci in rep.GetClientPersonalInformationCredit(_personid, _branchid)
                                       select ci;
                return _clientinfoquery.ToList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private List<ClientPersonalInformationSavingsModel> GetClientPersonalInformationSavings()
        {
            try
            {
                var _clientinfoquery = from ci in rep.GetClientPersonalInformationSavings(_personid, _branchid)
                                       select ci;
                return _clientinfoquery.ToList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }















    }
}