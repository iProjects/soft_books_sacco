using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;


namespace AdminstratorModule.Views
{
    public partial class ContractCodeForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        List<string> _ContractCode;
        #endregion "Private Fields"

        #region "Constructor"
        public ContractCodeForm(int _user, string Conn)
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
        private void ContractCodeForm_Load(object sender, EventArgs e)
        {
            try
            {
                _ContractCode = new List<string>(10);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkContractId_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkContractId.Checked)
                {
                    _ContractCode.Insert(chkContractId.TabIndex, "CT");
                    txtCodeTemplate.Text = displayList(_ContractCode);                   
                }
                else
                {
                    _ContractCode.RemoveAt(chkContractId.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkBranchCode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBranchCode.Checked)
                {
                    _ContractCode.Insert(chkBranchCode.TabIndex, "BC");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkBranchCode.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }   
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkDistrict_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDistrict.Checked)
                {
                    _ContractCode.Insert(chkDistrict.TabIndex, "DT");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkDistrict.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }   
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkYear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkYear.Checked)
                {
                    _ContractCode.Insert(chkYear.TabIndex, "YY");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkYear.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }   
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkLoanOfficer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkLoanOfficer.Checked)
                {
                    _ContractCode.Insert(chkLoanOfficer.TabIndex, "LO");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkLoanOfficer.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }   
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkProductCode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkProductCode.Checked)
                {
                    _ContractCode.Insert(chkProductCode.TabIndex, "PC");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkProductCode.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }   
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkLoanCycle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkLoanCycle.Checked)
                {
                    _ContractCode.Insert(chkLoanCycle.TabIndex, "LC");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkLoanCycle.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }   
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkProjectCycle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkProjectCycle.Checked)
                {
                    _ContractCode.Insert(chkProjectCycle.TabIndex, "PJ");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkProjectCycle.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }   
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void chkClientId_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkClientId.Checked)
                {
                    _ContractCode.Insert(chkClientId.TabIndex, "CI");
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
                else
                {
                    _ContractCode.RemoveAt(chkClientId.TabIndex);
                    txtCodeTemplate.Text = displayList(_ContractCode);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public string displayList(List<String> ilist)
        {
            try
            {
                return string.Join("/", ilist.ToArray());
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
           
        }
        #endregion "Private Methods"







    }
}
