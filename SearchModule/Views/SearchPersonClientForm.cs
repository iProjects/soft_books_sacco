using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace SearchModule.Views
{
    public partial class SearchPersonClientForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        static int index;
        List<Field> ClientFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<Person> _Persons;
        //delegate
        public delegate void PersonClientSelectHandler(object sender, PersonClientSelectEventArgs e);
        //event
        public event PersonClientSelectHandler OnPersonClientListSelected;
        #endregion "Private Fields"

        #region "Constructor"
        public SearchPersonClientForm(string Conn)
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
        #endregion "Private Methods"


    }


    public class PersonClientSelectEventArgs : System.EventArgs
    {

        #region "Private Field"
        // add local member variables to hold text
        private Person _client;
        #endregion "Private Field"

        #region "Constructor"
        public PersonClientSelectEventArgs(Person client)
        {
            this._client = client;
        }
        #endregion "Constructor"

        #region "public Properties"
        // Properties - Viewable by each listener
        public Person _Client
        {
            get
            {
                return _client;
            }
        }
        #endregion "public Properties"

    }

}