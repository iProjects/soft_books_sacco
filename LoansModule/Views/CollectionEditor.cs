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
namespace LoansModule.Views
{
    public partial class CollectionEditor : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        public CollectionEditor(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }

        private void CollectionEditor_Load(object sender, EventArgs e)
        {
            try
            {
                // Create the customer object we want to display
                Customer bill = new Customer();
                // Assign values to the properties
                bill.Age = 50;
                bill.Address = " 114 Maple Drive ";
                bill.DateOfBirth = Convert.ToDateTime(" 9/14/78");
                bill.SSN = "123-345-3566";
                bill.Email = "bill@aol.com";
                bill.Name = "Bill Smith";
                // Sets the the grid with the customer instance to be
                // browsed
                propertyGrid1.SelectedObject = bill;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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












    /// <summary>
    // Customer class to be displayed in the property grid
    /// </summary>
    /// 
    [DefaultPropertyAttribute("Name")]
    public class Customer
    {
        private string _name;
        private int _age;
        private DateTime _dateOfBirth;
        private string _SSN;
        private string _address;
        private string _email;
        private bool _frequentBuyer;
        // Name property with category attribute and 
        // description attribute added 
        [CategoryAttribute("ID Settings"), DescriptionAttribute("Name of the customer")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        [CategoryAttribute("ID Settings"),
        DescriptionAttribute("Social Security Number of the customer")]
        public string SSN
        {
            get
            {
                return _SSN;
            }
            set
            {
                _SSN = value;
            }
        }
        [CategoryAttribute("ID Settings"),
        DescriptionAttribute("Address of the customer")]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        [CategoryAttribute("ID Settings"),
        DescriptionAttribute("Date of Birth of the Customer (optional)")]
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
            }
        }
        [CategoryAttribute("ID Settings"), 
        DescriptionAttribute("Age of the customer")]
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        [CategoryAttribute("Marketting Settings"), 
        DescriptionAttribute("If the customer has bought more than 10 times, this is set to true")]
        public bool FrequentBuyer
        {
            get
            {
                return _frequentBuyer;
            }
            set
            {
                _frequentBuyer = value;
            }
        }
        [CategoryAttribute("Marketting Settings"), 
        DescriptionAttribute("Most current e-mail of the customer")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public Customer()
        {
        }
    }

















}