using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.IO;

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

            errorProvider.Clear();
            if (IsCorporateValid())
            {
                try
                {
                    Corporate corporate = new Corporate();

                    if (!string.IsNullOrEmpty(txtCorporateName.Text))
                    {
                        corporate.name = Utils.ConvertFirstLetterToUpper(txtCorporateName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtShortName.Text))
                    {
                        corporate.small_name = Utils.ConvertFirstLetterToUpper(txtShortName.Text.Trim());
                    }
                    corporate.establishment_date = dTPCreationDate.Value.ToString("dd-MM-yyyy");
                    int cycle;
                    if (!string.IsNullOrEmpty(txtLoanCycle.Text) && int.TryParse(txtLoanCycle.Text, out cycle))
                    {
                        corporate.loan_officer_id = int.Parse(txtLoanCycle.Text);
                    }
                    if (cboBranch.SelectedIndex != -1)
                    {
                        corporate.activity_id = int.Parse(cboBranch.SelectedValue.ToString());
                    }
                    if (pbPhoto.ImageLocation != null)
                    {
                        corporate.photo = pbPhoto.ImageLocation.ToString();
                    }
                    corporate.status = "active";
                    corporate.created_date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                    if (!db.Corporates.Any(i => i.name == corporate.name))
                    {
                        db.Corporates.AddObject(corporate);
                        db.SaveChanges();
                    }

                    CorporatesListForm f = (CorporatesListForm)this.Owner;
                    f.RefreshGrid(1);
                    this.Close();

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
                errorProvider.SetError(txtCorporateName, "Name cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtShortName.Text))
            {
                errorProvider.SetError(txtShortName, "Short Name cannot be null!");
                noerror = false;
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

        private void AddNewCorporateForm_Load(object sender, EventArgs e)
        {
            try
            {
                pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;

                var _branchesquery = from af in db.Branches
                                     where af.deleted == false
                                     select af;
                List<Branch> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "id";
                cboBranch.DisplayMember = "name";
                //cboBranch.SelectedIndex = -1;

                txtLoanCycle.Text = "0";

                string default_image = "defaultphoto.jpg";

                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string image_path = Path.Combine(base_directory, "Resources");
                string image_file_path = Path.Combine(image_path, default_image);

                FileInfo image_file = new FileInfo(image_file_path);

                if (image_file.Exists)
                {
                    string imagepath = image_file.FullName;
                    pbPhoto.ImageLocation = imagepath;
                    pbPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
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
