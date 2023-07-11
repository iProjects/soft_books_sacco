using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Models
{
    public class ClientModel
    {
        #region "Tiers"
        public int tierid
        {
            get;
            set;
        }
        public string client_type_code
        {
            get;
            set;
        }
        public float scoring
        {
            get;
            set;
        }
        public int loan_cycle
        {
            get;
            set;
        }
        public bool active
        {
            get;
            set;
        }
        public string other_org_name
        {
            get;
            set;
        }
        public double other_org_amount
        {
            get;
            set;
        }
        public double other_org_debts
        {
            get;
            set;
        }
        public int district_id
        {
            get;
            set;
        }
        public string city
        {
            get;
            set;

        }
        public string address
        {
            get;
            set;
        }
        public int secondary_district_id
        {
            get;
            set;
        }
        public string secondary_city
        {
            get;
            set;
        }
        public string secondary_address
        {
            get;
            set;
        }
        public int cash_input_voucher_number
        {
            get;
            set;
        }
        public int cash_output_voucher_number
        {
            get;
            set;
        }
        public DateTime creation_date
        {
            get;
            set;
        }
        public string home_phone
        {
            get;
            set;
        }
        public string personal_phone
        {
            get;
            set;
        }
        public string secondary_home_phone
        {
            get;
            set;
        }
        public string secondary_personal_phone
        {
            get;
            set;

        }
        public string e_mail
        {
            get;
            set;
        }
        public string secondary_e_mail
        {
            get;
            set;
        }
        public int status
        {
            get;
            set;
        }
        public string other_org_comment
        {
            get;
            set;
        }
        public string sponsor1
        {
            get;
            set;
        }
        public string sponsor1_comment
        {
            get;
            set;
        }
        public string sponsor2
        {
            get;
            set;
        }
        public string sponsor2_comment
        {
            get;
            set;
        }
        public string follow_up_comment
        {
            get;
            set;
        }
        public string home_type
        {
            get;
            set;
        }
        public string secondary_homeType
        {
            get;
            set;

        }
        public string zipCode
        {
            get;
            set;
        }
        public string secondary_zipCode
        {
            get;
            set;
        }
        public int branch_id
        {
            get;
            set;
        }        
        #endregion "Tiers"

        #region "Persons" 
        public int personid
        {
            get;
            set;
        }
        public string first_name
        {
            get;
            set;
        }
        public string sex
        {
            get;
            set;
        }
        public string personidentification_data
        {
            get;
            set;
        }
        public string last_name
        {
            get;
            set;
        }
        public DateTime birth_date
        {
            get;
            set;
        }
        public bool household_head
        {
            get;
            set;
        }
        public int nb_of_dependents
        {
            get;
            set;
        }
        public int nb_of_children
        {
            get;
            set;
        }
        public int children_basic_education
        {
            get;
            set;

        }
        public int livestock_number
        {
            get;
            set;
        }
        public string livestock_type
        {
            get;
            set;
        }
        public float landplot_size
        {
            get;
            set;
        }
        public float home_size
        {
            get;
            set;
        }
        public int home_time_living_in
        {
            get;
            set;
        }
        public string capital_other_equipments
        {
            get;
            set;
        }
        public int activity_id
        {
            get;
            set;
        }
        public int experience
        {
            get;
            set;
        }
        public int nb_of_people
        {
            get;
            set;
        }
        public double monthly_income
        {
            get;
            set;
        }
        public double monthly_expenditure
        {
            get;
            set;

        }
        public string comments
        {
            get;
            set;
        }
        public string image_path
        {
            get;
            set;
        }
        public int father_name
        {
            get;
            set;
        }
        public string birth_place
        {
            get;
            set;
        }
        public string nationality
        {
            get;
            set;
        }
        public string study_level
        {
            get;
            set;
        }
        public string SS
        {
            get;
            set;
        }
        public string CAF
        {
            get;
            set;
        }
        public string housing_situation
        {
            get;
            set;
        }
        public string bank_situation
        {
            get;
            set;
        }
        public bool handicapped
        {
            get;
            set;

        }
        public string professional_experience
        {
            get;
            set;
        }
        public string professional_situation
        {
            get;
            set;
        }
        public DateTime first_contact
        {
            get;
            set;
        }
        public string family_situation
        {
            get;
            set;
        }
        public string mother_name
        {
            get;
            set;
        }
        public int povertylevel_childreneducation
        {
            get;
            set;
        }
        public int povertylevel_economiceducation
        {
            get;
            set;
        }
        public int povertylevel_socialparticipation
        {
            get;
            set;
        }
        public int povertylevel_healthsituation
        {
            get;
            set;
        }
        public int unemployment_months
        {
            get;
            set;
        }
        public DateTime first_appointment
        {
            get;
            set;

        }
        public int loan_officer_id
        {
            get;
            set;
        }
        #endregion "Persons"

    }
}
