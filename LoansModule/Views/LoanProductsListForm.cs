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

namespace LoansModule.Views
{
    public partial class LoanProductsListForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        IQueryable<LoanPackageModel> _loanPackages;
        #endregion "Private Fields"

        #region "Constructor"
        public LoanProductsListForm(string Conn)
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
            try
            {
                AddLoanProductForm anpf = new AddLoanProductForm(connection) { Owner = this };
                anpf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void LoanProductsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewLoanProducts.AutoGenerateColumns = false;
                this.dataGridViewLoanProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //bindingSourceLoanProducts.DataSource = rep.GetLoanPackagesList();
                //dataGridViewLoanProducts.DataSource = bindingSourceLoanProducts;
                //groupBox1.Text = bindingSourceLoanProducts.Count.ToString();

                this.RefreshGrid(1);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceLoanProducts.DataSource = null;
                //set the datasource to a method
                bindingSourceLoanProducts.DataSource = rep.GetLoanPackagesList();
                groupBox1.Text = bindingSourceLoanProducts.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewLoanProducts.Rows)
                {
                    dataGridViewLoanProducts.Rows[dataGridViewLoanProducts.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewLoanProducts.Rows.Count - 1;
                    bindingSourceLoanProducts.Position = nRowIndex;
                }
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
                if (dataGridViewLoanProducts.SelectedRows.Count != 0)
                {
                    DAL.LoanPackageModel loan = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    EditLoanProductForm epf = new EditLoanProductForm(loan, connection) { Owner = this };
                    epf.Text = loan.name.ToUpper().Trim();
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
                if (dataGridViewLoanProducts.SelectedRows.Count != 0)
                {
                    DAL.LoanPackageModel loan = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    EditLoanProductForm epf = new EditLoanProductForm(loan, connection) { Owner = this };
                    epf.Text = loan.name.ToUpper().Trim();
                    epf.DisableControls();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLoanProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewLoanProducts.SelectedRows.Count != 0)
                {
                    DAL.LoanPackageModel loan = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    EditLoanProductForm epf = new EditLoanProductForm(loan, connection) { Owner = this };
                    epf.Text = loan.name.ToUpper().Trim();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewLoanProducts.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.LoanPackageModel c = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Loan\n" + c.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeletePackage(c);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }


        int NO_OF_RECORDS_PER_PAGE = 5;
        int NO_OF_PAGES_TO_DISPLAY = 5;

        public void RefreshGrid(int pageIndex)
        {
            try
            {
                NO_OF_RECORDS_PER_PAGE = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NO_OF_RECORDS_PER_PAGE"]);
                int no_of_records_per_page_from_db = rep.get_no_of_records_per_page();
                NO_OF_RECORDS_PER_PAGE = no_of_records_per_page_from_db;
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
                    using (SqlCommand cmd = new SqlCommand("GetLoanPackagesPageWise", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                        cmd.Parameters.AddWithValue("@PageSize", NO_OF_RECORDS_PER_PAGE);
                        cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                        cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        convert_datatable_into_list(dt);
                        BindGrid();
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
            panelPager.Controls.Clear();

            //Loop and add Buttons for Pager.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(38 * count, 5);
                btnPage.Size = new System.Drawing.Size(40, 20);
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.BackColor = Color.LimeGreen;
                btnPage.ForeColor = Color.Black;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                panelPager.Controls.Add(btnPage);
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

        private void convert_datatable_into_list(DataTable dt)
        {
            try
            {
                List<LoanPackageModel> lst_model = new List<LoanPackageModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    LoanPackageModel model = new LoanPackageModel();

                    if (dr["id"] != null)
                        model.packageid = Convert.ToInt32(dr["id"]);
                    //if (dr["contract_id"] != null)
                    //    model.contract_id = Convert.ToInt32(dr["contract_id"]);
                    model.code = dr["code"].ToString();
                    if (dr["compulsory_amount"] != null)
                        model.compulsory_amount = int.Parse(dr["compulsory_amount"].ToString());
                    if (dr["compulsory_amount_max"] != null)
                        model.compulsory_amount_max = int.Parse(dr["compulsory_amount_max"].ToString());
                    if (dr["compulsory_amount_min"] != null)
                        model.compulsory_amount_min = int.Parse(dr["compulsory_amount_min"].ToString());
                    if (dr["currency_id"] != null)
                        model.currency_id = int.Parse(dr["currency_id"].ToString());
                    if (dr["cycle_id"] != null)
                        model.cycle_id = int.Parse(dr["cycle_id"].ToString());
                    model.deleted = bool.Parse(dr["deleted"].ToString());
                    if (dr["fundingLine_id"] != null)
                        model.fundingLine_id = int.Parse(dr["fundingLine_id"].ToString());
                    if (dr["grace_period"] != null)
                        model.grace_period = int.Parse(dr["grace_period"].ToString());
                    if (dr["grace_period_max"] != null)
                        model.grace_period_max = int.Parse(dr["grace_period_max"].ToString());
                    if (dr["grace_period_min"] != null)
                        model.grace_period_min = int.Parse(dr["grace_period_min"].ToString());
                    if (dr["grace_period_of_latefees"] != null)
                        model.grace_period_of_latefees = int.Parse(dr["grace_period_of_latefees"].ToString());
                    if (dr["installment_type"] != null)
                        model.installment_type = int.Parse(dr["installment_type"].ToString());
                    if (dr["insurance_max"] != null)
                        model.insurance_max = decimal.Parse(dr["insurance_max"].ToString());
                    if (dr["insurance_min"] != null)
                        model.insurance_min = decimal.Parse(dr["insurance_min"].ToString());
                    if (dr["interest_rate"] != null)
                        model.interest_rate = decimal.Parse(dr["interest_rate"].ToString());
                    if (dr["interest_rate_max"] != null)
                        model.interest_rate_max = decimal.Parse(dr["interest_rate_max"].ToString());
                    if (dr["interest_rate_min"] != null)
                        model.interest_rate_min = decimal.Parse(dr["interest_rate_min"].ToString());
                    model.is_balloon = bool.Parse(dr["is_balloon"].ToString());
                    model.keep_expected_installment = bool.Parse(dr["keep_expected_installment"].ToString());
                    if (dr["loan_type"] != null)
                        model.loan_type = short.Parse(dr["loan_type"].ToString());
                    if (dr["maturity_loc_min"] != null)
                        model.maturity_loc_min = int.Parse(dr["maturity_loc_min"].ToString());
                    if (dr["maturity_loc_max"] != null)
                        model.maturity_loc_max = int.Parse(dr["maturity_loc_max"].ToString());
                    model.name = dr["name"].ToString();
                    if (dr["non_repayment_penalties_based_on_initial_amount"] != null)
                        model.non_repayment_penalties_based_on_initial_amount = int.Parse(dr["non_repayment_penalties_based_on_initial_amount"].ToString());
                    if (dr["non_repayment_penalties_based_on_initial_amount_max"] != null)
                        model.non_repayment_penalties_based_on_initial_amount_max = int.Parse(dr["non_repayment_penalties_based_on_initial_amount_max"].ToString());
                    if (dr["non_repayment_penalties_based_on_initial_amount_min"] != null)
                        model.non_repayment_penalties_based_on_initial_amount_min = int.Parse(dr["non_repayment_penalties_based_on_initial_amount_min"].ToString());
                    if (dr["non_repayment_penalties_based_on_olb"] != null)
                        model.non_repayment_penalties_based_on_olb = int.Parse(dr["non_repayment_penalties_based_on_olb"].ToString());
                    if (dr["non_repayment_penalties_based_on_olb_max"] != null)
                        model.non_repayment_penalties_based_on_olb_max = int.Parse(dr["non_repayment_penalties_based_on_olb_max"].ToString());
                    if (dr["non_repayment_penalties_based_on_olb_min"] != null)
                        model.non_repayment_penalties_based_on_olb_min = int.Parse(dr["non_repayment_penalties_based_on_olb_min"].ToString());
                    if (dr["non_repayment_penalties_based_on_overdue_interest"] != null)
                        model.non_repayment_penalties_based_on_overdue_interest = int.Parse(dr["non_repayment_penalties_based_on_overdue_interest"].ToString());
                    if (dr["non_repayment_penalties_based_on_overdue_interest_max"] != null)
                        model.non_repayment_penalties_based_on_overdue_interest_max = int.Parse(dr["non_repayment_penalties_based_on_overdue_interest_max"].ToString());
                    if (dr["non_repayment_penalties_based_on_overdue_interest_min"] != null)
                        model.non_repayment_penalties_based_on_overdue_interest_min = int.Parse(dr["non_repayment_penalties_based_on_overdue_interest_min"].ToString());
                    if (dr["non_repayment_penalties_based_on_overdue_principal"] != null)
                        model.non_repayment_penalties_based_on_overdue_principal = int.Parse(dr["non_repayment_penalties_based_on_overdue_principal"].ToString());
                    if (dr["non_repayment_penalties_based_on_overdue_principal_max"] != null)
                        model.non_repayment_penalties_based_on_overdue_principal_max = int.Parse(dr["non_repayment_penalties_based_on_overdue_principal_max"].ToString());
                    if (dr["non_repayment_penalties_based_on_overdue_principal_min"] != null)
                        model.non_repayment_penalties_based_on_overdue_principal_min = int.Parse(dr["non_repayment_penalties_based_on_overdue_principal_min"].ToString());
                    if (dr["number_of_drawings_loc"] != null)
                        model.number_of_drawings_loc = int.Parse(dr["number_of_drawings_loc"].ToString());
                    if (dr["number_of_installments"] != null)
                        model.number_of_installments = int.Parse(dr["number_of_installments"].ToString());
                    if (dr["number_of_installments_max"] != null)
                        model.number_of_installments_max = int.Parse(dr["number_of_installments_max"].ToString());
                    if (dr["number_of_installments_min"] != null)
                        model.number_of_installments_min = int.Parse(dr["number_of_installments_min"].ToString());
                    if (dr["percentage_separate_collateral"] != null)
                        model.percentage_separate_collateral = int.Parse(dr["percentage_separate_collateral"].ToString());
                    if (dr["percentage_separate_guarantor"] != null)
                        model.percentage_separate_guarantor = int.Parse(dr["percentage_separate_guarantor"].ToString());
                    if (dr["percentage_total_guarantor_collateral"] != null)
                        model.percentage_total_guarantor_collateral = int.Parse(dr["percentage_total_guarantor_collateral"].ToString());
                    if (dr["rounding_type"] != null)
                        model.rounding_type = short.Parse(dr["rounding_type"].ToString());
                    model.set_separate_guarantor_collateral = bool.Parse(dr["set_separate_guarantor_collateral"].ToString());
                    model.use_compulsory_savings = bool.Parse(dr["use_compulsory_savings"].ToString());
                    model.use_entry_fees_cycles = bool.Parse(dr["use_entry_fees_cycles"].ToString());
                    model.use_guarantor_collateral = bool.Parse(dr["use_guarantor_collateral"].ToString());

                    lst_model.Add(model);

                }

                _loanPackages = lst_model.AsQueryable();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile_and_EventViewer(ex);
                Utils.ShowError(ex);
            }
        }

        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                this.bindingSourceLoanProducts.DataSource = null;
                var filter = CreateFilter(_loanPackages);
                // set the filter
                this.bindingSourceLoanProducts.DataSource = filter;
                groupBox1.Text = bindingSourceLoanProducts.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<LoanPackageModel> CreateFilter(IQueryable<LoanPackageModel> model)
        {
            //none
            //if (string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtLastName.Text))
            //{
            //    return model;
            //}
            ////all
            //if (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text))
            //{
            //    model = null;
            //    string _FirstName = txtFirstName.Text.Trim();
            //    string _LastName = txtLastName.Text.Trim();
            //    model = (from st in _loanPackages
            //                 where st.first_name.StartsWith(_FirstName)
            //                 where st.last_name.StartsWith(_LastName)
            //                 select st).AsQueryable();
            //    return model;
            //}
            ////firstname
            //if (!string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtLastName.Text))
            //{
            //    model = null;
            //    string _FirstName = txtFirstName.Text.Trim();
            //    model = (from st in _loanPackages
            //                 where st.first_name.Trim().StartsWith(_FirstName)
            //                 select st).AsQueryable();
            //    return model;
            //}
            ////lastname  
            //if (string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text))
            //{
            //    model = null;
            //    string _LastName = txtLastName.Text.Trim();
            //    model = (from st in _loanPackages
            //                 where st.last_name.StartsWith(_LastName)
            //                 select st).AsQueryable();
            //    return model;
            //}
            return model;
        }

        private void BindGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceLoanProducts.DataSource = null;
                //set the datasource to a method
                bindingSourceLoanProducts.DataSource = _loanPackages;
                dataGridViewLoanProducts.DataSource = bindingSourceLoanProducts;
                groupBox1.Text = bindingSourceLoanProducts.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewLoanProducts.Rows)
                {
                    dataGridViewLoanProducts.Rows[dataGridViewLoanProducts.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewLoanProducts.Rows.Count - 1;
                    bindingSourceLoanProducts.Position = nRowIndex;
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