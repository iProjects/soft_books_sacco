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
    public partial class EditProvinceDistrictCityForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection; 
        int _ParentId;
        CityModel _cm;
        DistrictModel _dm;
        ProvinceModel _pm;
        #endregion "Private Fields"

        #region "Constructor"
        public EditProvinceDistrictCityForm(int _parentId, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (_parentId == null)
                throw new ArgumentNullException("ParentId");
            _ParentId = _parentId; 
        }
        public EditProvinceDistrictCityForm(ProvinceModel pm, string Conn)
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
        public EditProvinceDistrictCityForm(DistrictModel dm, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (dm == null)
                throw new ArgumentNullException("DistrictModel");
            _dm = dm;
        }
        public EditProvinceDistrictCityForm(CityModel cm, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (cm == null)
                throw new ArgumentNullException("CityModel");
            _cm = cm;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        } 
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (_cm != null)
                {
                    _cm.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                     rep.UpdateCity(_cm);
                }
                if (_dm != null)
                {
                    _dm.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                    rep.UpdateDistrict(_dm);
                }
                if (_pm != null)
                {
                    _pm.name = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                    rep.UpdateProvince(_pm);
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
        private void EditProvinceDistrictCityForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls( )
        {
            try
            {
                if (_cm != null)
                {
                    txtDescription.Text = _cm.name;
                }
                if ( _pm != null)
                {
                    txtDescription.Text = _pm.name;
                }
                if (_dm != null)
                {
                    txtDescription.Text = _dm.name;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"





    }
}
