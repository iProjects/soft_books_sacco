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
    public partial class SearchPersonClientsForm : Form
    {

        #region "Private Fields"
        Repository rep;
        static int index;
        List<Field> ClientFields = new List<Field>();
        CriteriaBuilder criteriaBuilder = new CriteriaBuilder();
        List<gl_Person> personclients;
        //delegate
        public delegate void PersonClientSelectHandler(object sender, PersonClientSelectEventArgs e);
        //event
        public event PersonClientSelectHandler OnPersonClientListSelected;
        #endregion "Private Fields"

        #region "Constructor"
        public SearchPersonClientsForm()
        {
            InitializeComponent();
            rep = new Repository();
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void SearchClientsForm_Load(object sender, EventArgs e)
        {
            try
            {

                ClientFields.Add(new Field("firstname", "string"));
                ClientFields.Add(new Field("lastname", "string"));
                ClientFields.Add(new Field("gender", "string"));
                ClientFields.Add(new Field("idno", "string"));


                cbField.DataSource = ClientFields;
                cbField.DisplayMember = "Name";
                cbField.ValueMember = "Name";

                cbOperator.DataSource = Op.GetList();
                cbOperator.DisplayMember = "Description";
                cbOperator.ValueMember = "Symbol";
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtValue.Text))
                {
                    CriterionItem cr = GetValidCriterionItem();
                    if (cr != null)
                    {
                        criteriaBuilder.AddCriterionItem(cr);
                        index++;
                    }
                    //refresh
                    ListBoxRefresh();
                }

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void ListBoxRefresh()
        {
            lstCriteria.DataSource = null;
            lstCriteria.DataSource = criteriaBuilder.CriterionItemList();
        }
        private CriterionItem GetValidCriterionItem()
        {
            Field field = (Field)cbField.SelectedItem;
            Op Op = (Op)cbOperator.SelectedItem;
            string FValue = txtValue.Text;
            conjuction cj;
            string FieldType = field.Type;
            if (criteriaBuilder.IsFirstItem())
            {
                cj = conjuction.nil;
            }
            else
            {
                if (rbAnd.Checked)
                {
                    cj = conjuction.and;
                }
                else cj = conjuction.or;
            }
            switch (FieldType.ToLower())
            {
                case "string":
                    FValue = string.Format("{0}", FValue);
                    break;
                case "decimal":
                    decimal d;
                    if (!decimal.TryParse(FValue, out d))
                    {
                        lblMessage.Text = "Please enter a number in the field value";
                        return null;
                    }
                    break;
                case "date":
                    DateTime dd;
                    if (!DateTime.TryParse(FValue, out dd))
                    {
                        lblMessage.Text = "Please enter a date in the field value";
                        return null;
                    }
                    FValue = string.Format("{0}", FValue); //do a date format
                    break;
                case "like":
                    FValue = string.Format("{0}", FValue);
                    break;
            }
            //clean. no error
            Criterion cr = new Criterion(cj, field.Name, Op, FValue);
            return new CriterionItem("index" + index, cr);

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCriteria.SelectedItem != null)
                {
                    CriterionItem selCriterionItem = (CriterionItem)lstCriteria.SelectedValue;
                    criteriaBuilder.Remove(selCriterionItem);

                    //refresh
                    ListBoxRefresh();
                }

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
            personclients = rep.GetPersonClientsFromCriteria(criteriaBuilder.CriterionItemList());
            bindingSourceClients.DataSource = personclients;
            dataGridViewClients.AutoGenerateColumns = false;
            this.dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.DataSource = bindingSourceClients;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> personclientsids = rep.GetPersonClientIdsFromCriteria(criteriaBuilder.CriterionItemList());
                personclients = rep.GetPersonClientsFromCriteria(criteriaBuilder.CriterionItemList());
                OnPersonClientListSelected(this, new PersonClientSelectEventArgs(personclientsids, personclients));

                //if (this.Owner is SBSacco.SACCOCORE)
                //    {
                //        SACCOCORE f = (SACCOCORE)this.Owner;
                //        this.Close();
                //    }
                //    else if (this.Owner is SACCOCORE)
                //    {
                //        SACCOCORE f = (SACCOCORE)this.Owner;
                //        this.Close();
                //    }

                }
                catch (Exception ex)
                {
                    Log.WriteToErrorLogFile(ex);
                }

        }
        #endregion "Private Methods"
         

    }


    public class PersonClientSelectEventArgs : System.EventArgs
    {

        #region "Private Field"
        // add local member variables to hold text
        private List<string> ClientIds;
        private List<gl_Person> clients;
        #endregion "Private Field"

        #region "Constructor"
        public PersonClientSelectEventArgs(List<string> clientids, List<gl_Person> clients)
        {
            this.ClientIds = clientids;
            this.clients = clients;
        }
        #endregion "Constructor"

        #region "public Properties"
        // Properties - Viewable by each listener
        public List<string> ClientIdsList
        {
            get
            {
                return ClientIds;
            }
        }
        public List<gl_Person> ClientsList
        {
            get
            {
                return clients;
            }
        }
        #endregion "public Properties"

    }
    


}