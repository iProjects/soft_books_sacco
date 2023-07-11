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


namespace CustomerModule.Views
{
    public partial class AddDocumentForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int _ObjectId;
        string _ObjectContainer;
        int user;
        string uploadfilename;
        string uploadfilepath;
        string uploadfileextension;
        long uploadfilesize; 
        #endregion "Private Fields"

        #region "Constructor"
        public AddDocumentForm(int ObjectId,string ObjectContainer, int _user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (ObjectId == null)
                throw new ArgumentNullException("ObjectId");
            _ObjectId = ObjectId;

            if (ObjectContainer == null)
                throw new ArgumentNullException("ObjectContainer");
            _ObjectContainer = ObjectContainer;

            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Create OpenFileDialog 
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Title = "Please select a Document!.";
                // Set filter for file extension 
                ofd.Filter = "All Files(*.*)|*.*|Word Documents(*.docx)|*.docx|Text Documents(*.txt)|*.txt|Pdf Documents(*.pdf)|*.pdf";
                // Default file extension
                //ofd.DefaultExt = ".txt";
                txtDocFilePath.Text = string.Empty;
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
                        uploadfilepath = fileinfo.FullName;
                        uploadfilename = fileinfo.Name;
                        uploadfileextension = fileinfo.Extension;
                        uploadfilesize = fileinfo.Length;
                        txtDocFilePath.Text = uploadfilepath;
                        txtDocFilePath.Enabled = false;
                         
                        string uploadFileNameWithNoExtension = uploadfilename;
                        txtDocName.Text += uploadFileNameWithNoExtension;

                        string Comment = "File: " + uploadfilepath + " Uploaded By: " + user + " at: " + DateTime.Now.ToString("dd/MM/yyyy");
                        txtDocComment.Text = Comment;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsDocumentValid())
            {

                try
                {

                    //gl_Documents document = new gl_Documents();
                    //document.DocName = txtDocName.Text.Trim();
                    //document.DocFileName = uploadfilename.Trim();
                    //document.dUser = _user;
                    //document.UploadDate = DateTime.Now.ToString("dd/MM/yyyy");
                    //document.Comment = txtDocComment.Text;
                    //document.DocFileSize = uploadfilesize;
                    //document.DocFileType = uploadfileextension;
                    //document.DocFilePath = uploadfilepath;
                    //document.ObjectId = _ObjectId;
                    //document.ObjectContainer = _ObjectContainer;

                    //if (!db.gl_Documents.Any(i => i.DocName == document.DocName && i.ObjectId == document.ObjectId && i.ObjectContainer == document.ObjectContainer && i.DocFilePath == document.DocFilePath))
                    //{
                    //    db.gl_Documents.AddObject(document);
                    //    db.SaveChanges();
                    //}

                    if (this.Owner is EditPersonForm)
                    {
                        EditPersonForm f = (EditPersonForm)this.Owner;  
                        this.Close();
                    }
                    else if (this.Owner is EditNonSolidarityGroupForm)
                    {
                        EditNonSolidarityGroupForm f = (EditNonSolidarityGroupForm)this.Owner;
                        //f.RefreshNonSolidarityGroupDocumentsListView();
                        this.Close();
                    }
                    else if (this.Owner is EditSolidarityGroupForm)
                    {
                        EditSolidarityGroupForm f = (EditSolidarityGroupForm)this.Owner;
                        f.RefreshSolidarityGroupDocumentsListView();
                        this.Close();
                    }
                    else if (this.Owner is EditCorporateForm)
                    {
                        EditCorporateForm f = (EditCorporateForm)this.Owner;
                        f.RefreshCorporateDocumentsListView();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsDocumentValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtDocFilePath.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDocFilePath, "Please Upload a Document!");
                return false;
            }
            if(string.IsNullOrEmpty(txtDocName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDocName, "Document Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDocComment.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDocComment, "Comment cannot be null!");
                return false;
            }  
            return noerror;
        }
        private void AddDocumentForm_Load(object sender, EventArgs e)
        {
            txtDocFilePath.Enabled = false;
        }

        #endregion "Private Methods"

        
        


    }
}
