using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using SearchModule.Views;

namespace CustomerModule.Views
{
    public partial class EditCorporateForm : Form
    {



        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        string user;
        Corporate corporate;
        #endregion "Private Fields"

        #region "Constructor"
        public EditCorporateForm(string _user, string Conn, Corporate _corporate)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            user = _user;
           corporate = _corporate;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnAddCorporateDetailsDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //const string ObjectContainer = "listViewCorporateDocuments";

                //AddDocumentForm adf = new AddDocumentForm(corporate.Id, ObjectContainer, _user, connection) { Owner = this };
                //adf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
         
        public void RefreshCorporateDocumentsListView()
        {
            try
            {
                listViewCorporateDocuments.Items.Clear();

                //const string ObjectContainer = "listViewCorporateDocuments";

                //int ObjectId = corporate.Id;

                //var documentsquery = from dc in db.gl_Documents
                //                     where dc.ObjectId == ObjectId
                //                     where dc.ObjectContainer == ObjectContainer
                //                     select dc;

                //List<gl_Documents> CorporateDocuments = documentsquery.ToList();

                //foreach (gl_Documents d in CorporateDocuments)
                //{
                //    listViewCorporateDocuments.Items.Add(new ListViewItem(new string[]
                //{
                //     d.DocFileName,d.DocName ,d.dUser,d.Comment,
                //    d.UploadDate.ToString(),d.DocFileSize.ToString() + "  bytes" 
                //}));
                //}
                //foreach (ListViewItem item in listViewCorporateDocuments.Items)
                //{
                //    item.ImageIndex = 0;
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewCorporateDetailsDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnDeleteCorporateDetailsDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listViewCorporateDocuments.SelectedItems != null)
            {
                try
                {
                    //const string ObjectContainer = "listViewCorporateDocuments";

                    //int ObjectId = corporate.Id;


                    //foreach (ListViewItem lvi in listViewCorporateDocuments.SelectedItems)
                    //{
                    //    ListViewItem.ListViewSubItem SubItem = lvi.SubItems[1];

                    //    gl_Documents doc = this.GetDocument(SubItem.Text, ObjectId, ObjectContainer);

                    //    gl_Documents d = db.gl_Documents.Where(r => r.Id == doc.Id).Single();

                    //    db.gl_Documents.DeleteObject(d);

                    //    db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);

                    //    RefreshCorporateDocumentsListView();
                    //}

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        //private gl_Documents GetDocument(string docname, int ObjectId, string ObjectContainer)
        //{
        //    try
        //    {
        //        var doc = (from dc in db.gl_Documents
        //                   where dc.DocName == docname
        //                   where dc.ObjectId == ObjectId
        //                   where dc.ObjectContainer == ObjectContainer
        //                   select dc).FirstOrDefault();
        //        return doc;

        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //        return null;
        //    }
        //}
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsCorporateValid())
            {
                try
                {
                    //if (!string.IsNullOrEmpty(txtCorporateName.Text))
                    //{
                    //    corporate.Description = Utils.ConvertFirstLetterToUpper(txtCorporateName.Text.Trim());
                    //}
                    //if (!string.IsNullOrEmpty(txtShortName.Text))
                    //{
                    //    corporate.ShortCode = Utils.ConvertFirstLetterToUpper(txtShortName.Text.Trim());
                    //}
                    //corporate.CreationDate = dTPCreationDate.Value;
                    //int cycle;
                    //if (!string.IsNullOrEmpty(txtCorporateLoanCycle.Text) && int.TryParse(txtCorporateLoanCycle.Text, out cycle))
                    //{
                    //    corporate.CorporateCycle = int.Parse(txtCorporateLoanCycle.Text);
                    //}
                    //if (cboBranch.SelectedIndex != -1)
                    //{
                    //    corporate.BranchId = int.Parse(cboBranch.SelectedValue.ToString());
                    //}
                    //if (pbPhoto.ImageLocation != null)
                    //{
                    //    corporate.CorporatePhoto = pbPhoto.ImageLocation.ToString();
                    //}
                    //if (cboEconomicActivity.SelectedIndex != -1)
                    //{
                    //    corporate.EconomicActivityId = int.Parse(cboEconomicActivity.SelectedValue.ToString());
                    //}
                    //if (!string.IsNullOrEmpty(cboLegalForm.Text))
                    //{
                    //    corporate.CompanyIDNo = cboLegalForm.Text.Trim();
                    //}
                    //if (cboLegalForm.SelectedIndex != -1)
                    //{
                    //    corporate.LegalForm = cboLegalForm.SelectedValue.ToString();
                    //}
                    //if (cboInsertionType.SelectedIndex != -1)
                    //{
                    //    corporate.InsertionType = cboInsertionType.SelectedValue.ToString();
                    //}
                    //if (!string.IsNullOrEmpty(txtNumberofEmployees.Text))
                    //{
                    //    corporate.NumberofEmployees = txtNumberofEmployees.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtNumberofVolunteers.Text))
                    //{
                    //    corporate.NumberofVolunteers = txtNumberofVolunteers.Text;
                    //}
                    //if (cboFiscalStatus.SelectedIndex != -1)
                    //{
                    //    corporate.FiscalStatus = cboFiscalStatus.SelectedValue.ToString();
                    //}
                    //if (cboAffiliation.SelectedIndex != -1)
                    //{
                    //    corporate.Affiliation = cboAffiliation.SelectedValue.ToString();
                    //}
                    //corporate.AgreementDate = dateTimePickerAgreementDate.Value;
                    //corporate.CorporateFirstContactDate = dtpFirstContact.Value;
                    //if (cboHowdidthepersonhearabouttheprogram.SelectedIndex != -1)
                    //{
                    //    corporate.CorporateSourceofKnowHow = cboHowdidthepersonhearabouttheprogram.SelectedValue.ToString();
                    //}
                    //if (cboSponsoredby.SelectedIndex != -1)
                    //{
                    //    corporate.CorporateSponsor = cboSponsoredby.SelectedValue.ToString();
                    //}
                    //if (!string.IsNullOrEmpty(txtComments.Text))
                    //{
                    //    corporate.Comment = txtComments.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtand1.Text))
                    //{
                    //    corporate.ProjectCode = txtand1.Text;
                    //} 
                    //if (cboHAProvince.SelectedIndex != -1)
                    //{
                    //    corporate.cProvince = cboHAProvince.SelectedValue.ToString();
                    //}
                    //if (cboHADistrict.SelectedIndex != -1)
                    //{
                    //    corporate.cDistrict = cboHADistrict.SelectedValue.ToString();
                    //}
                    //if (!string.IsNullOrEmpty(txtHACity.Text))
                    //{
                    //    corporate.cCity = txtHACity.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHAdress.Text))
                    //{
                    //    corporate.cAddress = txtHAdress.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHAZipCode.Text))
                    //{
                    //    corporate.cZipCode = txtHAZipCode.Text;
                    //}
                    //if (cboHAHomeType.SelectedIndex != -1)
                    //{
                    //    corporate.cHomeType = cboHAHomeType.SelectedValue.ToString();
                    //}
                    //if (!string.IsNullOrEmpty(txtHAHomePhone.Text))
                    //{
                    //    corporate.ContactPhone = txtHAHomePhone.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHACellPhone.Text))
                    //{
                    //    corporate.ContactPhone = txtHACellPhone.Text;
                    //}
                    //if (!string.IsNullOrEmpty(txtHAEmail.Text))
                    //{
                    //    corporate.cEmail = txtHAEmail.Text;
                    //}

                    //rep.UpdateCorporate(corporate);

                    //CorporatesListForm f = (CorporatesListForm)this.Owner;
                    //f.RefreshGrid();
                    //this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }


        #region "Validation"
        private bool IsCorporateValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtCorporateName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCorporateName, "Corporate Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtShortName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtShortName, "Short Name cannot be null!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"

        private void btnUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Create OpenFileDialog 
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Title = "Please select an image file.";
                // Set filter for file extension 
                //ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

                for (int i = 0; i < codecs.Count(); i++)
                {
                    var temp1 = codecs[0];
                    var temp2 = codecs[1];
                    var temp3 = codecs[2];
                    var temp4 = codecs[3];
                    var temp5 = codecs[4];

                    codecs[0] = temp5;
                    codecs[1] = temp2;
                    codecs[2] = temp1;
                    codecs[3] = temp3;
                    codecs[4] = temp4;
                }

                //codecs = codecs.OrderByDescending(r => r.CodecName).ToArray();
                string sep = string.Empty;
                foreach (var c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, codecName, c.FilenameExtension);
                    sep = "|";
                }
                ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, "All Files", "*.*");
                // Default file extension
                ofd.DefaultExt = ".jpg";
                // Display OpenFileDialog by calling ShowDialog method
                Nullable<bool> result = ofd.ShowDialog();
                // Process open file dialog box results
                if (result == true)
                {
                    // Get the selected file name and display in a TextBox 
                    string filename = ofd.FileName.Trim().ToString();
                    System.IO.FileInfo fileinfo = new System.IO.FileInfo(ofd.FileName);
                    if (!string.IsNullOrEmpty(filename) && !string.IsNullOrWhiteSpace(filename))
                    {
                        string imagepath = fileinfo.FullName;
                        pbPhoto.ImageLocation = imagepath;
                        pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void EditCorporateForm_Load(object sender, EventArgs e)
        {
            try
            {
                listViewCorporateDocuments.View = View.Details;
                listViewCorporateDocuments.GridLines = true;
                listViewCorporateDocuments.FullRowSelect = true;
                listViewCorporateDocuments.MultiSelect = false;
                listViewCorporateDocuments.Columns.Add("", "File", 100);
                listViewCorporateDocuments.Columns.Add("", "Doc Name", 200);
                listViewCorporateDocuments.Columns.Add("", "User", 100);
                listViewCorporateDocuments.Columns.Add("", "Comment", 100);
                listViewCorporateDocuments.Columns.Add("", "Date", 100);
                listViewCorporateDocuments.Columns.Add("", "Size", -2);

                ImageList photoListCorporateDocuments = new ImageList();
                photoListCorporateDocuments.TransparentColor = Color.Blue;
                photoListCorporateDocuments.ColorDepth = ColorDepth.Depth32Bit;
                photoListCorporateDocuments.ImageSize = new Size(10, 10);
                photoListCorporateDocuments.Images.Add(Image.FromFile("Resources/greenmage.jpg"));
                listViewCorporateDocuments.SmallImageList = photoListCorporateDocuments;

                RefreshCorporateDocumentsListView();

                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                //var _economicactivitiesquery = from eco in db.DomainOfApplications
                //                               select eco;
                //List<DomainOfApplication> _EconomicActivities = _economicactivitiesquery.ToList();
                //cboEconomicActivity.DataSource = _EconomicActivities;
                //cboEconomicActivity.ValueMember = "Id";
                //cboEconomicActivity.DisplayMember = "Description";
                //cboEconomicActivity.SelectedIndex = -1;

                //InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        //private void InitializeControls()
        //{

        //    try
        //    {
        //        if (corporate.Description != null)
        //        {
        //            txtCorporateName.Text = corporate.Description;
        //        }
        //        if (corporate.CreationDate != null)
        //        {
        //            dTPCreationDate.Value = corporate.CreationDate.Value;
        //        }
        //        if (corporate.ShortCode != null)
        //        {
        //            txtShortName.Text = corporate.ShortCode;
        //        }
        //        if (corporate.CorporateCycle != null)
        //        {
        //            txtCorporateLoanCycle.Text = corporate.CorporateCycle.ToString();
        //        }
        //        if (corporate.BranchId != null)
        //        {
        //            cboBranch.SelectedValue = corporate.BranchId;
        //        }
        //        if (corporate.CorporatePhoto != null)
        //        {
        //            pbPhoto.ImageLocation = corporate.CorporatePhoto;
        //        }
        //        if (corporate.EconomicActivityId != null)
        //        {
        //            cboEconomicActivity.SelectedValue = corporate.EconomicActivityId;
        //        } 
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.ShowError(ex);
        //    }

        //}
        public void DisableControls()
        {

            try
            {
                txtCorporateName.Enabled = false;
                dTPCreationDate.Enabled = false;
                txtShortName.Enabled = false;
                txtCorporateLoanCycle.Enabled = false;
                cboBranch.Enabled = false;
                cboBranch.Enabled = false;
                pbPhoto.Enabled = false;
                btnUpload.Enabled = false;
                btnUpdate.Enabled = false;
                btnUpdate.Visible = false;
                btnClose.Location = btnUpdate.Location;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        #endregion "Private Methods"

       






    }
}
