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
    public partial class AddProvinceDistrictCityForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection; 
        int _ParentId =-1; 
        ProvinceModel _pm;
        #endregion "Private Fields"

        #region "Constructor"
        public AddProvinceDistrictCityForm(int _parentId, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _ParentId = _parentId; 
        }
        public AddProvinceDistrictCityForm(ProvinceModel pm, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (pm == null)
                throw new ArgumentNullException("ProvinceModel");
            _pm = pm;
        } 
        #endregion "Constructor"

        #region "Private Methods"
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_pm != null)
                {
                    DistrictModel dm = new DistrictModel();
                    dm.province_id = _pm.provinceid;
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        dm.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    }
                    dm.deleted = false;

                    rep.AddNewDistrict(dm);
                }
                if (_ParentId ==0)
                {
                    ProvinceModel pm = new ProvinceModel(); 
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        pm.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    }
                    pm.deleted = false;

                    rep.AddNewProvince(pm);
                }

                ProvinceDistrictCitiesForm f = (ProvinceDistrictCitiesForm)this.Owner;
                f.RefreshGrid();
                this.Close();
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
        private void AddProvinceDistrictCityForm_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"






    }
}