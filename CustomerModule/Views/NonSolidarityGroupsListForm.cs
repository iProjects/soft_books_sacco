using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;
using System.Data.SqlClient;

namespace CustomerModule.Views
{
    public partial class NonSolidarityGroupsListForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        string user;
        #endregion "Private Fields"

        #region "Constructor"
        public NonSolidarityGroupsListForm(string _user, string Conn)
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
        private void btnAddNewNonSolidarityGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddNonSolidarityGroupForm annsgf = new AddNonSolidarityGroupForm(connection) { Owner = this };
                annsgf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void NonSolidarityGroupsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewNonSolidarityGroup.AutoGenerateColumns = false;
                this.dataGridViewNonSolidarityGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //bindingSourceNonSolidarityGroup.DataSource = rep.GetNonSolidarityGroupsList();
                //dataGridViewNonSolidarityGroup.DataSource = bindingSourceNonSolidarityGroup;
                //groupBox1.Text = bindingSourceNonSolidarityGroup.Count.ToString();

                this.RefreshGrid(1);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                if (dataGridViewNonSolidarityGroup.SelectedRows.Count != 0)
                {
                    DAL.tbl_non_solidarity_groups nonsolidaritygroup = (DAL.tbl_non_solidarity_groups)bindingSourceNonSolidarityGroup.Current;
                    EditNonSolidarityGroupForm epf = new EditNonSolidarityGroupForm(nonsolidaritygroup, user, connection) { Owner = this };
                    epf.Text = nonsolidaritygroup.name.ToUpper().Trim();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewNonSolidarityGroup.SelectedRows.Count != 0)
                {
                    DAL.tbl_non_solidarity_groups nonsolidaritygroup = (DAL.tbl_non_solidarity_groups)bindingSourceNonSolidarityGroup.Current;
                    EditNonSolidarityGroupForm epf = new EditNonSolidarityGroupForm(nonsolidaritygroup, user, connection) { Owner = this };
                    epf.Text = nonsolidaritygroup.name.ToUpper().Trim();
                    epf.DisableControls();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewNonSolidarityGroup_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewNonSolidarityGroup.SelectedRows.Count != 0)
                {
                    DAL.tbl_non_solidarity_groups nonsolidaritygroup = (DAL.tbl_non_solidarity_groups)bindingSourceNonSolidarityGroup.Current;
                    EditNonSolidarityGroupForm epf = new EditNonSolidarityGroupForm(nonsolidaritygroup, user, connection) { Owner = this };
                    epf.Text = nonsolidaritygroup.name.ToUpper().Trim();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"

        private void BindGrid(DataTable dt)
        {
            try
            {
                //set the datasource to null
                bindingSourceNonSolidarityGroup.DataSource = null;
                //set the datasource to a method
                bindingSourceNonSolidarityGroup.DataSource = dt;
                dataGridViewNonSolidarityGroup.DataSource = bindingSourceNonSolidarityGroup;
                groupBox1.Text = bindingSourceNonSolidarityGroup.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewNonSolidarityGroup.Rows)
                {
                    dataGridViewNonSolidarityGroup.Rows[dataGridViewNonSolidarityGroup.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewNonSolidarityGroup.Rows.Count - 1;
                    bindingSourceNonSolidarityGroup.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        int NO_OF_RECORDS_PER_PAGE = 5;
        int NO_OF_PAGES_TO_DISPLAY = 5;

        public void RefreshGrid(int pageIndex)
        {
            try
            {
                NO_OF_RECORDS_PER_PAGE = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NO_OF_RECORDS_PER_PAGE"]);
                NO_OF_PAGES_TO_DISPLAY = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NO_OF_PAGES_TO_DISPLAY"]);
                string[] conn_str_arr = connection.Split(';');
                string data_source = string.Empty;
                string data_base = string.Empty;
                string integrated_security = string.Empty;

                for (int i = 0; i < conn_str_arr.Length; i++)
                {
                    if (i == 2)
                    {
                        string[] data_source_arr = conn_str_arr[2].Split('=');
                        data_source = data_source_arr[2];
                    }
                    if (i == 3)
                    {
                        string[] data_base_arr = conn_str_arr[3].Split('=');
                        data_base = data_base_arr[1];
                    }
                    if (i == 4)
                    {
                        string[] integrated_security_arr = conn_str_arr[4].Split('=');
                        integrated_security = integrated_security_arr[1];
                    }
                }

                string constring = @"Data Source=" + data_source + @";Initial Catalog=" + data_base + @";Integrated Security=" + integrated_security;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("GetNonSolidarityGroupPageWise", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                        cmd.Parameters.AddWithValue("@PageSize", NO_OF_RECORDS_PER_PAGE);
                        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        BindGrid(dt);
                        //dataGridViewCorporates.DataSource = dt;
                        con.Close();
                        int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                        this.PopulatePager(recordCount, pageIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


        private void PopulatePager(int recordCount, int currentPage)
        {
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(NO_OF_RECORDS_PER_PAGE));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + NO_OF_PAGES_TO_DISPLAY - 1 < NO_OF_PAGES_TO_DISPLAY ? currentPage : 1;
            endIndex = pageCount > NO_OF_PAGES_TO_DISPLAY ? NO_OF_PAGES_TO_DISPLAY : pageCount;
            if (currentPage > NO_OF_PAGES_TO_DISPLAY % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (NO_OF_PAGES_TO_DISPLAY - currentPage) + 1;
            }

            if (endIndex - (NO_OF_PAGES_TO_DISPLAY - 1) > startIndex)
            {
                startIndex = endIndex - (NO_OF_PAGES_TO_DISPLAY - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - NO_OF_PAGES_TO_DISPLAY) + 1) > 0 ? (endIndex - NO_OF_PAGES_TO_DISPLAY) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "First", Value = "1" });
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = "Last", Value = pageCount.ToString() });
            }

            //Clear existing Pager Buttons.
            pnlPager.Controls.Clear();

            //Loop and add Buttons for Pager.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(38 * count, 5);
                btnPage.Size = new System.Drawing.Size(50, 20);
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.BackColor = Color.LimeGreen;
                btnPage.ForeColor = Color.Black;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                pnlPager.Controls.Add(btnPage);
                count++;

                if (page.Selected)
                {
                    btnPage.BackColor = Color.Magenta;
                    btnPage.ForeColor = Color.Black;
                }
            }
        }

        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.RefreshGrid(int.Parse(btnPager.Name));
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridViewNonSolidarityGroup_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }

    }


}
