﻿using System;
using System.Windows.Forms;
using CommonLib;
using DAL;
using ReportsModule.ViewModels;

namespace ReportsModule.ViewModelBuilders
{
    public class CreditCommitteeViewModelBuilder
    {
        CreditCommitteeViewModel _ViewModel;
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

        public CreditCommitteeViewModelBuilder(string Conn)
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
        }
        public CreditCommitteeViewModel GetModelBuilder()
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
                _ViewModel = new CreditCommitteeViewModel();
                _ViewModel.PrintedOn = DateTime.Now;
                _ViewModel.CompanyLogo = companyLogo;
                _ViewModel.CompanySlogan = companyslogan;
                _ViewModel.CompanyName = companyname;
                _ViewModel.CompanyEmail = companyemail;
                _ViewModel.CompanyAddress = companyaddress;
                _ViewModel.CompanyTelephone = companytelephone;
                _ViewModel.CompanyWebsite = companywebsite;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



    }
}