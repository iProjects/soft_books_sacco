using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;


namespace AdminstratorModule.Views
{
    public partial class AddEconomicActivityForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int _ParentId=-1; 
        #endregion "Private Fields"

        public AddEconomicActivityForm(int _parentId, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
             
            _ParentId = _parentId;
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_ParentId != -1 && _ParentId == 0)
                {
                    ActivityModel am = new ActivityModel();
                    am.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    am.deleted = false;
                    am.parent_id = null;

                    if (rep.GetNonDeletedEconomicActivitiesList().Any(i => i.name == am.name))
                    {
                        MessageBox.Show("Economic Activity with Name " + am.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!rep.GetNonDeletedEconomicActivitiesList().Any(i => i.name == am.name))
                    {
                        rep.AddNewEconomicActivity(am);

                        EconomicActivityForm f = (EconomicActivityForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    }
                }
                if (_ParentId != -1 && _ParentId !=0)
                {
                    ActivityModel am = new ActivityModel();
                    am.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    am.deleted = false;
                    am.parent_id = _ParentId;

                    if (rep.GetNonDeletedEconomicActivitiesList().Any(i => i.name == am.name))
                    {
                        MessageBox.Show("Economic Activity with Name " + am.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!rep.GetNonDeletedEconomicActivitiesList().Any(i => i.name == am.name))
                    {
                        rep.AddNewEconomicActivity(am);

                        EconomicActivityForm f = (EconomicActivityForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        } 
        private void AddEconomicActivityForm_Load(object sender, EventArgs e)
        {
            try
            { 

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



    }
}
