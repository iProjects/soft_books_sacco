using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace CustomerModule.Views
{
    public partial class AddCorporateForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddCorporateForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (IsCorporateValid())
            {
                try
                {
                    //gl_Corporate corporate = new gl_Corporate();

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

                    //if (!db.gl_Corporate.Any(i => i.Description == corporate.Description && i.ShortCode == corporate.ShortCode))
                    //{
                    //    db.gl_Corporate.AddObject(corporate);
                    //    db.SaveChanges();
                    //}

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
                errorProvider1.SetError(txtCorporateName, "Name cannot be null!");
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

        private void AddNewCorporateForm_Load(object sender, EventArgs e)
        {
            try
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                //var _branchesquery = from af in db.gl_Branches
                //                     where af.Isdeleted == false
                //                     select af;
                //List<gl_Branches> _Branches = _branchesquery.ToList();
                //cboBranch.DataSource = _Branches;
                //cboBranch.ValueMember = "Id";
                //cboBranch.DisplayMember = "BranchName";
                //cboBranch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"



    }
}
