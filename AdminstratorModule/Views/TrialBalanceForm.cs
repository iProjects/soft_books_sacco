using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AdminstratorModule.Views
{
    public partial class TrialBalanceForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user; 
        #endregion "Private Fields"

        #region "Constructor"
        public TrialBalanceForm(int _user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"  
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void TrialBalanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _branchesquery = from br in rep.GetNonDeletedBranches()
                                     select br;
                List<BranchModel> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                cboBranch.SelectedIndex = -1;

                var _currenciesquery = from br in rep.GetCurrenciesList()
                                     select br;
                List<CurrencyModel> _Currencies = _currenciesquery.ToList();
                cboCurrency.DataSource = _Currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;

                //ContractCode Combox
                var ContractCode = new BindingList<KeyValuePair<string, string>>();
                ContractCode.Add(new KeyValuePair<string, string>("ALL", "All"));
                ContractCode.Add(new KeyValuePair<string, string>("NEW", "New Contract Code"));
                cboContractCode.DataSource = ContractCode;
                cboContractCode.ValueMember = "Key";
                cboContractCode.DisplayMember = "Value";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"
         
    }
}
