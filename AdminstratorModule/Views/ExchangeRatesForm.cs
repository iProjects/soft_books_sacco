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
    public partial class ExchangeRatesForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        FundingLineModel fundingline;
        BindingList<DAL.ExchangeRate> observablemonthexchangeRates;
        #endregion "Private Fields"

        #region "Constructor"
        public ExchangeRatesForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
             
            observablemonthexchangeRates = new BindingList<DAL.ExchangeRate>();
        }
        public ExchangeRatesForm(DAL.FundingLineModel _fundingline, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            fundingline = _fundingline;
            observablemonthexchangeRates = new BindingList<DAL.ExchangeRate>();
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsExchangeRateValid())
            {
                try
                {


                    if (this.Owner is AddFundingLineEventForm)
                    {
                        AddFundingLineEventForm f = (AddFundingLineEventForm)this.Owner;
                        this.Close();
                    }
                    else if (this.Owner is AddFundingLineEventForm)
                    {
                        AddFundingLineEventForm f = (AddFundingLineEventForm)this.Owner;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsExchangeRateValid()
        {
            bool noerror = true;


            return noerror;
        }
        #endregion "Validation"
        private void ExchangeRatesForm_Load(object sender, EventArgs e)
        {
            try
            {
                //var currenciesquery = from cr in db.gl_Currencies
                //                      select cr;
                //List<gl_Currencies> currencies = currenciesquery.ToList();
                //cboCurrency.DataSource = currencies;
                //cboCurrency.ValueMember = "Id";
                //cboCurrency.DisplayMember = "Description";
                //cboCurrency.SelectedIndex = -1;

                int year = monthCalendar.SelectionStart.Year;
                int month = monthCalendar.SelectionStart.Month;
                this.GetMonthDates(year, month);
                this.monthCalendar.TodayDate = DateTime.Today;

                //bindingSourceExchangeRates.DataSource = observablemonthexchangeRates;
                dataGridViewExchangeRates.AutoGenerateColumns = false;
                this.dataGridViewExchangeRates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExchangeRates.DataSource = bindingSourceExchangeRates;

                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {

            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void GetMonthDates(int year, int month)
        {
            try
            {
                //observablemonthexchangeRates.Clear();
                //// Loop from the first day of the month until we hit the next month, moving forward a day at a time
                //for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
                //{
                //    gl_ExchangeRates er = new gl_ExchangeRates();
                //    er.ExchangeDate = date;

                //    observablemonthexchangeRates.Add(er);
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                int year = monthCalendar.SelectionStart.Year;
                int month = monthCalendar.SelectionStart.Month;
                this.GetMonthDates(year, month);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"

    }
}
