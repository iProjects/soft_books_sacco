using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using CommonLib;
using System.Text;

namespace DAL
{

    public class Repository
    {

        #region "Private Fields"
        SBSaccoDBEntities db;
        AuditDBEntities audit_db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public Repository()
        {

            //Should be called by login service only
        }
        public Repository(string _connection)
        {
            connection = _connection;
            db = new SBSaccoDBEntities(_connection); 
        }
        public Repository(string _connection, string log_info)
        {
            connection = _connection; 
            audit_db = new AuditDBEntities(_connection);
        }
        #endregion "Constructor"

        #region "public Methods"
        #region "Database and Connection"
        public bool Connect(
         string providerName,
         string serverName,
         string databaseName,
         string attacheddb,
         string userName,
         string password,
     string metaData,
          bool IntegratedSecurity)
        {
            try
            {
                EntityConnection conn = new EntityConnection(GetConnectionString(
                    providerName,
                    serverName,
                    databaseName,
                    attacheddb,
                    userName,
                    password,
                    metaData,
                    IntegratedSecurity));

                //overwrite the default context with this one
                db = new SBSaccoDBEntities(conn);

                return true;
            }
            catch (Exception ex)
            {
                ///TODO Log error
                Log.WriteToErrorLogFile(ex);
                db = null;
                return false;
            }
        }
        public bool Connect(string connectiostr)
        {
            try
            {
                //overwrite the default context with this one
                //string encConnection = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

                db = new SBSaccoDBEntities(connectiostr);

                return true;
            }
            catch (Exception ex)
            {
                ///TODO Log error
                Log.WriteToErrorLogFile(ex);
                db = null;
                return false;
            }
        }
        public string GetConnectionString(
           string providerName,
           string serverName,
           string databaseName,
           string attacheddb,
           string userName,
           string password,
            string metaData,
            bool IntegratedSecurity)
        {
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
                new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            if (!string.IsNullOrEmpty(attacheddb)) sqlBuilder.AttachDBFilename = attacheddb;
            sqlBuilder.IntegratedSecurity = IntegratedSecurity;
            sqlBuilder.UserID = userName;
            sqlBuilder.Password = password;


            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            //entityBuilder.Metadata = string.Format(@"metadata=res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl",
            //    metaData);
            entityBuilder.Metadata = string.Format(@"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl",
                metaData);
            return entityBuilder.ToString();
        }
        #endregion "Database and Connection"
        #region "UserModel"
        public void AddUser(UserModel_dto _user)
        {
            try
            {
                User user = new User();
                user.user_name = _user.user_name;
                user.user_pass = _user.user_pass;
                user.role_code = _user.role_code;
                user.first_name = _user.first_name;
                user.last_name = _user.last_name;
                user.mail = _user.mail;
                user.phone = _user.phone;
                user.sex = _user.sex;
                user.deleted = _user.deleted;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateUser(DAL.UserModel_dto _user)
        {
            try
            {
                User user = db.Users.First(u => u.id == _user.userid);
                user.user_name = _user.user_name;
                user.user_pass = _user.user_pass;
                user.role_code = _user.role_code;
                user.first_name = _user.first_name;
                user.last_name = _user.last_name;
                user.mail = _user.mail;
                user.phone = _user.phone;
                user.sex = _user.sex;
                user.deleted = _user.deleted;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public void DeleteUser(DAL.UserModel_dto _user)
        {
            try
            {
                DAL.User user = db.Users.Where(i => i.id == _user.userid).Single();

                db.Users.DeleteObject(user);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public void GetUsersModel(Action<IList<UserModel_dto>> callback)
        {
            callback(GetUserModelList());
        }
        public IList<UserModel_dto> GetUserModelList()
        {

            var usermodels = from usr in db.Users
                             join ur in db.UserRoles on usr.id equals ur.user_id
                             select new UserModel_dto
                             {
                                 userid = usr.id,
                                 user_name = usr.user_name,
                                 user_pass = usr.user_pass,
                                 role_code = usr.role_code,
                                 first_name = usr.first_name,
                                 last_name = usr.last_name,
                                 phone = usr.phone,
                                 mail = usr.mail,
                                 deleted = usr.deleted,
                                 role_id = ur.role_id,
                                 sex = usr.sex
                             };

            return usermodels.ToList();
        }
        public IList<UserModel_dto> GetCombinedUserModelList()
        {

            List<UserModel_dto> _users = new List<UserModel_dto>();
            var usermodels = from usr in db.Users
                             join rl in db.Roles on usr.role_code equals rl.code
                             join ur in db.UserRoles on usr.id equals ur.user_id
                             where usr.deleted == false
                             select usr;
            foreach (var us in usermodels)
            {
                UserModel_dto _user = new UserModel_dto();
                _user.userid = us.id;
                _user.user_name = us.user_name;
                _user.user_pass = us.user_pass;
                _user.role_code = us.role_code;
                _user.first_name = us.first_name;
                _user.last_name = us.last_name;
                _user.phone = us.phone;
                _user.mail = us.mail;
                _user.deleted = us.deleted;
                _user.sex = us.sex;

                _users.Add(_user);
            }

            return _users;
        }
        public IList<UserModel_dto> GetRoleUsersModel(int roleid)
        {

            var usermodels = from usr in db.Users
                             join ur in db.UserRoles on usr.id equals ur.user_id
                             join rl in db.Roles on ur.role_id equals rl.id
                             where rl.id == roleid
                             select new UserModel_dto
                             {
                                 userid = usr.id,
                                 user_name = usr.user_name,
                                 user_pass = usr.user_pass,
                                 role_code = usr.role_code,
                                 first_name = usr.first_name,
                                 last_name = usr.last_name,
                                 phone = usr.phone,
                                 mail = usr.mail,
                                 deleted = usr.deleted,
                                 role_id = ur.role_id,
                                 sex = usr.sex
                             };

            return usermodels.ToList();
        }
        public IList<UserModel_dto> GetUsersModelwithRolesList()
        {
            List<UserModel_dto> _Users = new List<UserModel_dto>();
            var _usermodelquery = from usr in db.Users
                                  select usr;
            List<User> _usermodels = _usermodelquery.ToList();
            foreach (var usr in _usermodels)
            {
                UserModel_dto _user = new UserModel_dto();
                _user.userid = usr.id;
                _user.user_name = usr.user_name;
                _user.user_pass = usr.user_pass;
                _user.role_code = usr.role_code;
                _user.first_name = usr.first_name;
                _user.last_name = usr.last_name;
                _user.mail = usr.mail;
                _user.phone = usr.phone;
                _user.deleted = usr.deleted;
                _user.role_id = this.GetUserModelRoleId(usr.id);

                _Users.Add(_user);
            }

            return _Users;
        }
        public int GetUserModelRoleId(int userid)
        {
            var userrolequery = (from rl in db.Roles
                                 join us in db.Users on userid equals us.id
                                 where us.role_code.Equals(rl.code)
                                 select rl.id).FirstOrDefault();
            return userrolequery;
        }
        public IList<UserModel_dto> GetUserModelSubOrdinates(int userid)
        {
            List<UserModel_dto> _Users = new List<UserModel_dto>();

            List<int> ChildIds = (from uss in db.UsersSubordinates
                                  join usr in db.Users on uss.user_id equals usr.id
                                  where uss.user_id == userid
                                  select uss.subordinate_id).ToList();

            List<UserModel_dto> _usermodels = new List<UserModel_dto>();
            foreach (var _id in ChildIds)
            {
                var _usermodelquery = (from usr in db.Users
                                       where usr.id == _id
                                       select new UserModel_dto
                                       {
                                           userid = usr.id,
                                           user_name = usr.user_name,
                                           user_pass = usr.user_pass,
                                           role_code = usr.role_code,
                                           first_name = usr.first_name,
                                           last_name = usr.last_name,
                                           phone = usr.phone,
                                           mail = usr.mail,
                                           deleted = usr.deleted
                                       }).FirstOrDefault();

                UserModel_dto _usermodel = _usermodelquery;

                if (_usermodel != null)
                {
                    _usermodels.Add(_usermodelquery);
                }
            }

            foreach (var usr in _usermodels)
            {
                UserModel_dto _user = new UserModel_dto();
                _user.userid = usr.userid;
                _user.user_name = usr.user_name;
                _user.user_pass = usr.user_pass;
                _user.role_code = usr.role_code;
                _user.first_name = usr.first_name;
                _user.last_name = usr.last_name;
                _user.mail = usr.mail;
                _user.phone = usr.phone;
                _user.deleted = usr.deleted;
                _user.role_id = this.GetUserModelRoleId(usr.userid);

                _Users.Add(_user);
            }

            return _Users;
        }
        public List<UsersBranch> GetUserModelBranches(int userid)
        {
            try
            {
                var _userbranchesquery = from ub in db.UsersBranches
                                         join br in db.Branches on ub.branch_id equals br.id
                                         where ub.user_id == userid
                                         select ub;

                return _userbranchesquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "UserModel"
        #region "Login"
        public bool Register(string username, string Pwd, int roleid)
        {
            try
            {
                spUser user = new spUser();

                user.UserName = username;
                user.Password = Pwd;
                user.RoleId = roleid;
                db.AddTospUsers(user);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }

        }
        public bool CheckUserExists(string username, string Pwd)
        {
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         where users.Password == Pwd
                         select users;
                return (us.Count() > 0);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public bool IsUserLocked(string username)
        {
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         where users.Locked == true
                         select users;
                return (us.Count() > 0);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public void LockUser(string username)
        {
            spUser user;
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         select users;
                user = us.Single();
                user.Locked = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public spUser GetUserbyUserName(string username)
        {
            try
            {
                var us = from users in db.spUsers
                         where users.UserName == username
                         select users;
                return us.Single();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public bool ChangePassword(string username, string Pwd)
        {
            try
            {
                var us = (from users in db.spUsers
                          where users.UserName == username
                          select users).Single();
                us.Password = Pwd;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        #endregion "Login"
        #region "Users"
        public void GetUsers(Action<IList<UserModel>> callback)
        {
            callback(GetUserList());
        }
        public IList<UserModel> GetUserList()
        {

            var usermodels = from usr in db.spUsers
                             select new UserModel
                             {
                                 UserName = usr.UserName,
                                 Password = usr.Password,
                                 RoleId = usr.RoleId,
                                 Locked = usr.Locked
                             };

            return usermodels.ToList();
        }
        public UserModel GetUser(string _user)
        {

            var usermodel = (from usr in db.spUsers
                             where usr.UserName == _user
                             select new UserModel
                             {
                                 UserName = usr.UserName,
                                 Password = usr.Password,
                                 RoleId = usr.RoleId,
                                 Locked = usr.Locked
                             }).FirstOrDefault();

            return usermodel;
        }
        public void GetUserRoles()
        {

        }
        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<spUser> GetUsers()
        {
            try
            {

                return db.spUsers.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }

        }
        public void AddUser(string username, string password, int roleid, bool locked)
        {
            try
            {

                spUser user = new spUser();
                user.UserName = username;
                user.Password = password;
                user.RoleId = roleid;
                user.Locked = locked;

                db.AddTospUsers(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public void AddUser(spUser user)
        {
            try
            {
                spUser _user = new spUser();
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _user.RoleId = user.RoleId;
                _user.Surname = user.Surname;
                _user.OtherNames = user.OtherNames;
                _user.NationalID = user.NationalID;
                _user.DateOfBirth = user.DateOfBirth;
                _user.Gender = user.Gender;
                _user.InformBy = user.InformBy;
                _user.Email = user.Email;
                _user.Telephone = user.Telephone;
                _user.Photo = user.Photo;
                _user.Locked = user.Locked;
                _user.IsDeleted = user.IsDeleted;
                _user.SystemId = user.SystemId;
                _user.Status = user.Status;
                _user.DateJoined = user.DateJoined;
                _user.password_hash = user.password_hash;
                _user.password_salt = user.password_salt;

                db.AddTospUsers(_user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateUser(DAL.spUser user)
        {
            try
            {
                spUser _user = db.spUsers.First(u => u.Id == user.Id);
                _user.UserName = user.UserName;
                _user.Password = user.Password;
                _user.RoleId = user.RoleId;
                _user.Surname = user.Surname;
                _user.OtherNames = user.OtherNames;
                _user.NationalID = user.NationalID;
                _user.DateOfBirth = user.DateOfBirth;
                _user.Gender = user.Gender;
                _user.InformBy = user.InformBy;
                _user.Email = user.Email;
                _user.Telephone = user.Telephone;
                _user.Photo = user.Photo;
                _user.Locked = user.Locked;
                _user.IsDeleted = user.IsDeleted;
                _user.SystemId = user.SystemId;
                _user.Status = user.Status;
                _user.DateJoined = user.DateJoined;
                _user.password_hash = user.password_hash;
                _user.password_salt = user.password_salt;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public void UpdateUser(DAL.spUser user, string password, int roleid, bool locked)
        {
            try
            {

                spUser _user = db.spUsers.First(u => u.Id == user.Id);

                _user.Password = password;
                _user.RoleId = roleid;
                _user.Locked = locked;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);

            }
        }
        public bool ChangePassword(UserModel user)
        {
            try
            {
                var _user = (from us in db.spUsers
                             where us.Id == user.UserId
                             select us).Single();

                _user.Password = user.Password;
                _user.password_hash = user.password_hash;
                _user.password_salt = user.password_salt;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                return true;
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        public bool Authenticate(string userId, string pwd, int Maxtries, int tries, ref string message, ref string errCode)
        {
            if (tries > Maxtries)
            {
                message = "Maximum tries exceeded; User locked ";
                errCode = "100";
                LockUser(userId);
                return false;
            }
            if (!CheckUserExists(userId, pwd))
            {
                message = "Username or password not correct";
                errCode = "101";
                return false;
            }
            if (IsUserLocked(userId))
            {
                message = "User locked, please contact the administrator";
                errCode = "102";
                return false;
            }
            ///TODO continue checking all authentication conditions

            return true;
        }
        #endregion "Users"
        #region "Roles"
        public void AddRole(spRole role)
        {
            try
            {
                spRole c = new spRole();
                c = role;

                db.spRoles.AddObject(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateRole(spRole role)
        {
            try
            {
                spRole c = db.spRoles.First(r => r.Id == role.Id);
                c.Description = role.Description;
                c.ShortCode = role.ShortCode;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteRole(spRole role)
        {
            try
            {
                spRole c = db.spRoles.Where(r => r.Id == role.Id).Single();
                db.spRoles.DeleteObject(c);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }

            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<spRole> GetRolesList()
        {
            try
            {
                return db.spRoles.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Roles"
        #region "Rights"
        public void UpdateRight(spAllowedRoleMenu right)
        {
            try
            {
                spAllowedRoleMenu _right = db.spAllowedRoleMenus.First(r => r.Id == right.Id);
                _right.RoleId = right.RoleId;
                _right.MenuItemId = right.MenuItemId;
                _right.Allowed = right.Allowed;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateReportsRight(spAllowedReportsRolesMenu right)
        {
            try
            {
                spAllowedReportsRolesMenu _right = db.spAllowedReportsRolesMenus.First(r => r.Id == right.Id);
                _right.RoleId = right.RoleId;
                _right.MenuItemId = right.MenuItemId;
                _right.Allowed = right.Allowed;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "Rights"
        #region "Person"
        public void AddNewPerson(ClientModel cm)
        {
            try
            {
                Tier _tier = new Tier();
                _tier.client_type_code = cm.client_type_code;
                _tier.scoring = cm.scoring;
                _tier.loan_cycle = cm.loan_cycle;
                _tier.active = cm.active;
                _tier.other_org_name = cm.other_org_name;
                _tier.other_org_amount = cm.other_org_amount;
                _tier.other_org_debts = cm.other_org_debts;
                _tier.district_id = cm.district_id;
                _tier.city = cm.city;
                _tier.address = cm.address;
                _tier.secondary_district_id = cm.secondary_district_id;
                _tier.secondary_city = cm.secondary_city;
                _tier.secondary_address = cm.secondary_address;
                _tier.cash_input_voucher_number = cm.cash_input_voucher_number;
                _tier.cash_output_voucher_number = cm.cash_output_voucher_number;
                _tier.creation_date = cm.creation_date;
                _tier.home_phone = cm.home_phone;
                _tier.personal_phone = cm.personal_phone;
                _tier.secondary_home_phone = cm.secondary_home_phone;
                _tier.secondary_personal_phone = cm.secondary_personal_phone;
                _tier.email = cm.email;
                _tier.secondary_e_mail = cm.secondary_e_mail;
                _tier.status = cm.status;
                _tier.other_org_comment = cm.other_org_comment;
                _tier.sponsor1 = cm.sponsor1;
                _tier.sponsor1_comment = cm.sponsor1_comment;
                _tier.sponsor2 = cm.sponsor2;
                _tier.sponsor2_comment = cm.sponsor2_comment;
                _tier.follow_up_comment = cm.follow_up_comment;
                _tier.home_type = cm.home_type;
                _tier.secondary_homeType = cm.secondary_homeType;
                _tier.zipCode = cm.zipCode;
                _tier.secondary_zipCode = cm.secondary_zipCode;
                _tier.branch_id = cm.branch_id;

                db.Tiers.AddObject(_tier);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                //var tieridquery = (from tr in db.Tiers
                //where tr.client_type_code == cm.client_type_code
                //where tr.creation_date == cm.creation_date
                ////where tr.district_id == cm.district_id
                //where tr.active == cm.active
                //where tr.branch_id == cm.branch_id
                //select tr).FirstOrDefault();

                if (_tier.id != null)
                {
                    Person _person = new Person();
                    _person.id = _tier.id;
                    _person.first_name = cm.first_name;
                    _person.sex = cm.sex;
                    _person.identification_data = cm.identification_data;
                    _person.last_name = cm.last_name;
                    _person.birth_date = cm.birth_date;
                    _person.household_head = cm.household_head;
                    _person.nb_of_dependents = cm.nb_of_dependents;
                    _person.nb_of_children = cm.nb_of_children;
                    _person.children_basic_education = cm.children_basic_education;
                    _person.livestock_number = cm.livestock_number;
                    _person.livestock_type = cm.livestock_type;
                    _person.landplot_size = cm.landplot_size;
                    _person.home_size = cm.home_size;
                    _person.home_time_living_in = cm.home_time_living_in;
                    _person.capital_other_equipments = cm.capital_other_equipments;
                    _person.activity_id = cm.activity_id;
                    _person.experience = cm.experience;
                    _person.nb_of_people = cm.nb_of_people;
                    _person.monthly_income = cm.monthly_income;
                    _person.monthly_expenditure = cm.monthly_expenditure;
                    _person.comments = cm.comments;
                    _person.image_path = cm.image_path;
                    _person.father_name = cm.father_name;
                    _person.birth_place = cm.birth_place;
                    _person.nationality = cm.nationality;
                    _person.study_level = cm.study_level;
                    _person.SS = cm.SS;
                    _person.CAF = cm.CAF;
                    _person.housing_situation = cm.housing_situation;
                    _person.bank_situation = cm.bank_situation;
                    _person.handicapped = cm.handicapped;
                    _person.professional_experience = cm.professional_experience;
                    _person.professional_situation = cm.professional_situation;
                    _person.first_contact = cm.first_contact;
                    _person.family_situation = cm.family_situation;
                    _person.mother_name = cm.mother_name;
                    _person.povertylevel_childreneducation = cm.povertylevel_childreneducation;
                    _person.povertylevel_economiceducation = cm.povertylevel_economiceducation;
                    _person.povertylevel_socialparticipation = cm.povertylevel_socialparticipation;
                    _person.povertylevel_healthsituation = cm.povertylevel_healthsituation;
                    _person.unemployment_months = cm.unemployment_months;
                    _person.first_appointment = cm.first_appointment;
                    _person.loan_officer_id = cm.loan_officer_id;

                    db.Persons.AddObject(_person);
                    db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                    Console.WriteLine(_tier.id);
                    Console.WriteLine(_person.id);
                }

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public short GetDefaultStatus()
        {
            try
            {
                var defaultstatusidquery = (from s in db.Statuses
                                            select s.id).FirstOrDefault();
                short statusid = 1;
                if (short.TryParse(defaultstatusidquery.ToString(), out statusid)) { }
                return statusid;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 1;
            }
        }
        public void UpdatePerson(ClientModel cm)
        {
            try
            {
                Tier _tier = db.Tiers.First(r => r.id == cm.tierid);

                _tier.client_type_code = cm.client_type_code;
                _tier.scoring = cm.scoring;
                _tier.loan_cycle = cm.loan_cycle;
                _tier.active = cm.active;
                _tier.other_org_name = cm.other_org_name;
                _tier.other_org_amount = cm.other_org_amount;
                _tier.other_org_debts = cm.other_org_debts;
                _tier.district_id = cm.district_id;
                _tier.city = cm.city;
                _tier.address = cm.address;
                _tier.secondary_district_id = cm.secondary_district_id;
                _tier.secondary_city = cm.secondary_city;
                _tier.secondary_address = cm.secondary_address;
                _tier.cash_input_voucher_number = cm.cash_input_voucher_number;
                _tier.cash_output_voucher_number = cm.cash_output_voucher_number;
                _tier.creation_date = cm.creation_date;
                _tier.home_phone = cm.home_phone;
                _tier.personal_phone = cm.personal_phone;
                _tier.secondary_home_phone = cm.secondary_home_phone;
                _tier.secondary_personal_phone = cm.secondary_personal_phone;
                _tier.email = cm.email;
                _tier.secondary_e_mail = cm.secondary_e_mail;
                _tier.status = cm.status;
                _tier.other_org_comment = cm.other_org_comment;
                _tier.sponsor1 = cm.sponsor1;
                _tier.sponsor1_comment = cm.sponsor1_comment;
                _tier.sponsor2 = cm.sponsor2;
                _tier.sponsor2_comment = cm.sponsor2_comment;
                _tier.follow_up_comment = cm.follow_up_comment;
                _tier.home_type = cm.home_type;
                _tier.secondary_homeType = cm.secondary_homeType;
                _tier.zipCode = cm.zipCode;
                _tier.secondary_zipCode = cm.secondary_zipCode;
                _tier.branch_id = cm.branch_id;

                Person _person = db.Persons.First(r => r.id == cm.tierid);

                _person.first_name = cm.first_name;
                _person.sex = cm.sex;
                _person.identification_data = cm.identification_data;
                _person.last_name = cm.last_name;
                _person.birth_date = cm.birth_date;
                _person.household_head = cm.household_head;
                _person.nb_of_dependents = cm.nb_of_dependents;
                _person.nb_of_children = cm.nb_of_children;
                _person.children_basic_education = cm.children_basic_education;
                _person.livestock_number = cm.livestock_number;
                _person.livestock_type = cm.livestock_type;
                _person.landplot_size = cm.landplot_size;
                _person.home_size = cm.home_size;
                _person.home_time_living_in = cm.home_time_living_in;
                _person.capital_other_equipments = cm.capital_other_equipments;
                _person.activity_id = cm.activity_id;
                _person.experience = cm.experience;
                _person.nb_of_people = cm.nb_of_people;
                _person.monthly_income = cm.monthly_income;
                _person.monthly_expenditure = cm.monthly_expenditure;
                _person.comments = cm.comments;
                _person.image_path = cm.image_path;
                _person.father_name = cm.father_name;
                _person.birth_place = cm.birth_place;
                _person.nationality = cm.nationality;
                _person.study_level = cm.study_level;
                _person.SS = cm.SS;
                _person.CAF = cm.CAF;
                _person.housing_situation = cm.housing_situation;
                _person.bank_situation = cm.bank_situation;
                _person.handicapped = cm.handicapped;
                _person.professional_experience = cm.professional_experience;
                _person.professional_situation = cm.professional_situation;
                _person.first_contact = cm.first_contact;
                _person.family_situation = cm.family_situation;
                _person.mother_name = cm.mother_name;
                _person.povertylevel_childreneducation = cm.povertylevel_childreneducation;
                _person.povertylevel_economiceducation = cm.povertylevel_economiceducation;
                _person.povertylevel_socialparticipation = cm.povertylevel_socialparticipation;
                _person.povertylevel_healthsituation = cm.povertylevel_healthsituation;
                _person.unemployment_months = cm.unemployment_months;
                _person.first_appointment = cm.first_appointment;
                _person.loan_officer_id = cm.loan_officer_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateClientLoanCycle(ClientModel cm)
        {
            try
            {
                Tier _tier = db.Tiers.First(r => r.id == cm.tierid);

                _tier.loan_cycle = cm.loan_cycle;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeletePerson(Person p)
        {
            try
            {
                Person person = db.Persons.Where(r => r.id == p.id).Single();

                db.Persons.DeleteObject(person);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ClientModel> GetPersonsList()
        {
            try
            {
                var persons = from tr in db.Tiers
                              join ps in db.Persons on tr.id equals ps.id
                              join ds in db.Districts on tr.district_id equals ds.id
                              join pr in db.Provinces on ds.province_id equals pr.id
                              join ds2 in db.Districts on tr.secondary_district_id equals ds2.id
                              join pr2 in db.Provinces on ds2.province_id equals pr2.id
                              select new ClientModel
                              {
                                  active = tr.active,
                                  activity_id = ps.activity_id,
                                  address = tr.address,
                                  bank_situation = ps.bank_situation,
                                  birth_date = ps.birth_date,
                                  birth_place = ps.birth_place,
                                  branch_id = tr.branch_id,
                                  CAF = ps.CAF,
                                  capital_other_equipments = ps.capital_other_equipments,
                                  cash_input_voucher_number = tr.cash_input_voucher_number,
                                  cash_output_voucher_number = tr.cash_output_voucher_number,
                                  children_basic_education = ps.children_basic_education,
                                  city = tr.city,
                                  client_type_code = tr.client_type_code,
                                  comments = ps.comments,
                                  creation_date = tr.creation_date,
                                  district_id = tr.district_id??0,
                                  district_name = ds.name,
                                  province_id = pr.id,
                                  secondary_province_id = pr2.id,
                                  email = tr.email,
                                  experience = ps.experience,
                                  family_situation = ps.family_situation,
                                  father_name = ps.father_name,
                                  first_appointment = ps.first_appointment,
                                  first_contact = ps.first_contact,
                                  first_name = ps.first_name,
                                  follow_up_comment = tr.follow_up_comment,
                                  handicapped = ps.handicapped,
                                  home_phone = tr.home_phone,
                                  home_size = ps.home_size,
                                  home_time_living_in = ps.home_time_living_in,
                                  home_type = tr.home_type,
                                  household_head = ps.household_head,
                                  housing_situation = ps.housing_situation,
                                  image_path = ps.image_path,
                                  landplot_size = ps.landplot_size,
                                  last_name = ps.last_name,
                                  livestock_number = ps.livestock_number,
                                  livestock_type = ps.livestock_type,
                                  loan_cycle = tr.loan_cycle,
                                  loan_officer_id = ps.loan_officer_id,
                                  monthly_expenditure = ps.monthly_expenditure,
                                  monthly_income = ps.monthly_income,
                                  mother_name = ps.mother_name,
                                  nationality = ps.nationality,
                                  nb_of_children = ps.nb_of_children,
                                  nb_of_dependents = ps.nb_of_dependents,
                                  nb_of_people = ps.nb_of_people,
                                  other_org_amount = tr.other_org_amount,
                                  other_org_comment = tr.other_org_comment,
                                  other_org_debts = tr.other_org_debts,
                                  other_org_name = tr.other_org_name,
                                  personal_phone = tr.personal_phone,
                                  personid = ps.id,
                                  identification_data = ps.identification_data,
                                  povertylevel_childreneducation = ps.povertylevel_childreneducation ?? 0,
                                  povertylevel_economiceducation = ps.povertylevel_economiceducation ?? 0,
                                  povertylevel_healthsituation = ps.povertylevel_healthsituation ?? 0,
                                  povertylevel_socialparticipation = ps.povertylevel_socialparticipation ?? 0,
                                  professional_experience = ps.professional_experience,
                                  professional_situation = ps.professional_situation,
                                  scoring = tr.scoring,
                                  secondary_address = tr.secondary_address,
                                  secondary_city = tr.secondary_city,
                                  secondary_district_id = tr.secondary_district_id,
                                  secondary_e_mail = tr.secondary_e_mail,
                                  secondary_home_phone = tr.secondary_home_phone,
                                  secondary_homeType = tr.secondary_homeType,
                                  secondary_personal_phone = tr.secondary_personal_phone,
                                  secondary_zipCode = tr.zipCode,
                                  sex = ps.sex,
                                  sponsor1 = tr.sponsor1,
                                  sponsor1_comment = tr.sponsor1_comment,
                                  sponsor2 = tr.sponsor2,
                                  sponsor2_comment = tr.sponsor2_comment,
                                  SS = ps.SS,
                                  status = tr.status,
                                  study_level = ps.study_level,
                                  tierid = tr.id,
                                  unemployment_months = ps.unemployment_months,
                                  zipCode = tr.zipCode
                              };

                return persons.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public string GetClientName(int tierid, string client_code)
        {
            try
            {
                string client_name = string.Empty;
                switch (client_code)
                {
                    case "I": client_name = (from tr in db.Tiers
                                             join ps in db.Persons on tr.id equals ps.id
                                             where ps.id == tr.id
                                             select ps.father_name + ps.first_name + ps.last_name).FirstOrDefault();
                        break;
                    case "C": client_name = (from tr in db.Tiers
                                             join cp in db.Corporates on tr.id equals cp.id
                                             where cp.id == tr.id
                                             select cp.name).FirstOrDefault();
                        break;
                    case "G": client_name = (from tr in db.Tiers
                                             join gp in db.Groups on tr.id equals gp.id
                                             where gp.id == tr.id
                                             select gp.name).FirstOrDefault();
                        break;
                    case "V": client_name = (from tr in db.Tiers
                                             join vl in db.Villages on tr.id equals vl.id
                                             where vl.id == tr.id
                                             select vl.name).FirstOrDefault();
                        break;
                }
                return client_name;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Person"
        #region "Login & User"
        public int GetUserId(int userId)
        {
            try
            {
                var us = (from users in db.Users
                          where users.id == userId
                          select users).Single();
                return us.id;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 1;
            }
        }
        #endregion "Login & User"
        #region "Branches"
        public void AddNewBranch(BranchModel branch)
        {
            try
            {
                Branch _branch = new Branch();
                _branch.name = branch.name;
                _branch.deleted = branch.deleted;
                _branch.code = branch.code;
                _branch.address = branch.address;
                _branch.description = branch.description;

                db.Branches.AddObject(_branch);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateBranch(BranchModel branch)
        {
            try
            {
                Branch _branch = db.Branches.First(b => b.id == branch.branchid);
                _branch.name = branch.name;
                _branch.deleted = branch.deleted;
                _branch.code = branch.code;
                _branch.address = branch.address;
                _branch.description = branch.description;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteBranch(BranchModel branch)
        {
            try
            {
                Branch _branch = db.Branches.First(b => b.id == branch.branchid);
                _branch.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<BranchModel> GetNonDeletedBranches()
        {
            try
            {
                List<BranchModel> _branches = new List<BranchModel>();
                var _branchesquery = from br in db.Branches
                                     where br.deleted == false
                                     select br;
                foreach (var branch in _branchesquery)
                {
                    BranchModel _branch = new BranchModel();
                    _branch.branchid = branch.id;
                    _branch.name = branch.name;
                    _branch.deleted = branch.deleted;
                    _branch.code = branch.code;
                    _branch.address = branch.address;
                    _branch.description = branch.description;

                    _branches.Add(_branch);
                }

                return _branches;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<BranchModel> GetAllBranches()
        {
            try
            {
                List<BranchModel> _branches = new List<BranchModel>();
                var _branchesquery = from br in db.Branches
                                     select br;
                foreach (var branch in _branchesquery)
                {
                    BranchModel _branch = new BranchModel();
                    _branch.branchid = branch.id;
                    _branch.name = branch.name;
                    _branch.deleted = branch.deleted;
                    _branch.code = branch.code;
                    _branch.address = branch.address;
                    _branch.description = branch.description;

                    _branches.Add(_branch);
                }

                return _branches;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public BranchModel GetDefaultBranch()
        {
            try
            {
                var currency = (from cr in db.Branches
                                where cr.deleted == false
                                select new BranchModel
                                {
                                    address = cr.address,
                                    name = cr.name,
                                    branchid = cr.id,
                                    code = cr.code,
                                    deleted = cr.deleted,
                                    description = cr.description
                                }).FirstOrDefault();

                return currency;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Branches"
        #region "Package"
        public void AddNewLoanPackage(LoanPackageModel ln)
        {
            try
            {
                Package pk = new Package();


                db.Packages.AddObject(pk);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdatePackage(LoanPackageModel package)
        {
            try
            {
                Package l = db.Packages.First(r => r.id == package.packageid);


                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeletePackage(LoanPackageModel package)
        {
            try
            {
                Package l = db.Packages.Where(i => i.id == package.packageid).Single();

                db.Packages.DeleteObject(l);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<LoanPackageModel> GetLoanPackagesList()
        {
            try
            {
                var loans = from p in db.Packages
                            select new LoanPackageModel
                            {
                                activated_loc = p.activated_loc,
                                allow_flexible_schedule = p.allow_flexible_schedule,
                                amount = p.amount,
                                amount_max = p.amount_max,
                                amount_min = p.amount_min,
                                amount_under_loc = p.amount_under_loc,
                                amount_under_loc_max = p.amount_under_loc_max,
                                amount_under_loc_min = p.amount_under_loc_min,
                                anticipated_partial_repayment_base = p.anticipated_partial_repayment_base,
                                anticipated_partial_repayment_penalties = p.anticipated_partial_repayment_penalties,
                                anticipated_partial_repayment_penalties_max = p.anticipated_partial_repayment_penalties_max,
                                anticipated_partial_repayment_penalties_min = p.anticipated_partial_repayment_penalties_min,
                                anticipated_total_repayment_base = p.anticipated_total_repayment_base,
                                anticipated_total_repayment_penalties = p.anticipated_total_repayment_penalties,
                                anticipated_total_repayment_penalties_max = p.anticipated_total_repayment_penalties_max,
                                anticipated_total_repayment_penalties_min = p.anticipated_total_repayment_penalties_min,
                                charge_interest_within_grace_period = p.charge_interest_within_grace_period,
                                client_type = p.client_type,
                                code = p.code,
                                compulsory_amount = p.compulsory_amount,
                                compulsory_amount_max = p.compulsory_amount_max,
                                compulsory_amount_min = p.compulsory_amount_min,
                                currency_id = p.currency_id,
                                cycle_id = p.cycle_id,
                                deleted = p.deleted,
                                fundingLine_id = p.fundingLine_id,
                                grace_period = p.grace_period,
                                grace_period_max = p.grace_period_max,
                                grace_period_min = p.grace_period_min,
                                grace_period_of_latefees = p.grace_period_of_latefees,
                                installment_type = p.installment_type,
                                insurance_max = p.insurance_max,
                                insurance_min = p.insurance_min,
                                interest_rate = p.interest_rate,
                                interest_rate_max = p.interest_rate_max,
                                interest_rate_min = p.interest_rate_min,
                                is_balloon = p.is_balloon,
                                keep_expected_installment = p.keep_expected_installment,
                                loan_type = p.loan_type,
                                maturity_loc = p.maturity_loc,
                                maturity_loc_max = p.maturity_loc_max,
                                maturity_loc_min = p.maturity_loc_min,
                                name = p.name,
                                non_repayment_penalties_based_on_initial_amount = p.non_repayment_penalties_based_on_initial_amount,
                                non_repayment_penalties_based_on_initial_amount_max = p.non_repayment_penalties_based_on_initial_amount_max,
                                non_repayment_penalties_based_on_initial_amount_min = p.non_repayment_penalties_based_on_initial_amount_min,
                                non_repayment_penalties_based_on_olb = p.non_repayment_penalties_based_on_olb,
                                non_repayment_penalties_based_on_olb_max = p.non_repayment_penalties_based_on_olb_max,
                                non_repayment_penalties_based_on_olb_min = p.non_repayment_penalties_based_on_olb_min,
                                non_repayment_penalties_based_on_overdue_interest = p.non_repayment_penalties_based_on_overdue_interest,
                                non_repayment_penalties_based_on_overdue_interest_max = p.non_repayment_penalties_based_on_overdue_interest_max,
                                non_repayment_penalties_based_on_overdue_interest_min = p.non_repayment_penalties_based_on_overdue_interest_min,
                                non_repayment_penalties_based_on_overdue_principal = p.non_repayment_penalties_based_on_overdue_principal,
                                non_repayment_penalties_based_on_overdue_principal_max = p.non_repayment_penalties_based_on_overdue_principal_max,
                                non_repayment_penalties_based_on_overdue_principal_min = p.non_repayment_penalties_based_on_overdue_principal_min,
                                number_of_drawings_loc = p.number_of_drawings_loc,
                                number_of_installments = p.number_of_installments,
                                number_of_installments_max = p.number_of_installments_max,
                                number_of_installments_min = p.number_of_installments_min,
                                packageid = p.id,
                                percentage_separate_collateral = p.percentage_separate_collateral,
                                percentage_separate_guarantor = p.percentage_separate_guarantor,
                                percentage_total_guarantor_collateral = p.percentage_total_guarantor_collateral,
                                rounding_type = p.rounding_type,
                                set_separate_guarantor_collateral = p.set_separate_guarantor_collateral,
                                use_compulsory_savings = p.use_compulsory_savings,
                                use_entry_fees_cycles = p.use_entry_fees_cycles,
                                use_guarantor_collateral = p.use_guarantor_collateral


                            };

                return loans.ToList();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Package"
        #region "SavingProducts and SavingBookProducts"
        public int AddNewSavingProduct(SavingProductModel savingmodel)
        {
            int id = -1;
            try
            {
                SavingProduct _savingproduct = new SavingProduct();
                _savingproduct.name = savingmodel.name;
                _savingproduct.client_type = savingmodel.client_type;
                _savingproduct.initial_amount_min = savingmodel.initial_amount_min;
                _savingproduct.initial_amount_max = savingmodel.initial_amount_max;
                _savingproduct.balance_min = savingmodel.balance_min;
                _savingproduct.balance_max = savingmodel.balance_max;
                _savingproduct.withdraw_min = savingmodel.withdraw_min;
                _savingproduct.withdraw_max = savingmodel.withdraw_max;
                _savingproduct.deposit_min = savingmodel.deposit_min;
                _savingproduct.deposit_max = savingmodel.deposit_max;
                _savingproduct.interest_rate = savingmodel.interest_rate;
                _savingproduct.interest_rate_min = savingmodel.interest_rate_min;
                _savingproduct.interest_rate_max = savingmodel.interest_rate_max;
                _savingproduct.currency_id = savingmodel.currency_id;
                _savingproduct.entry_fees_min = savingmodel.entry_fees_min;
                _savingproduct.entry_fees_max = savingmodel.entry_fees_max;
                _savingproduct.entry_fees = savingmodel.entry_fees;
                _savingproduct.product_type = savingmodel.product_type;
                _savingproduct.code = savingmodel.code;
                _savingproduct.transfer_min = savingmodel.transfer_min;
                _savingproduct.transfer_max = savingmodel.transfer_max;

                db.SavingProducts.AddObject(_savingproduct);
                db.SaveChanges();

                return _savingproduct.id;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return id;
            }
        }
        public void AddNewSavingBookProduct(SavingProductModel savingmodel)
        {
            try
            {
                SavingBookProduct _savingbookproduct = new SavingBookProduct();
                _savingbookproduct.id = savingmodel.savingproductid;
                _savingbookproduct.interest_base = savingmodel.interest_base;
                _savingbookproduct.interest_frequency = savingmodel.interest_frequency;
                _savingbookproduct.calcul_amount_base = savingmodel.calcul_amount_base;
                _savingbookproduct.flat_withdraw_fees_min = savingmodel.flat_withdraw_fees_min;
                _savingbookproduct.flat_withdraw_fees_max = savingmodel.flat_withdraw_fees_max;
                _savingbookproduct.flat_withdraw_fees = savingmodel.flat_withdraw_fees;
                _savingbookproduct.rate_withdraw_fees_min = savingmodel.rate_withdraw_fees_min;
                _savingbookproduct.rate_withdraw_fees_max = savingmodel.rate_withdraw_fees_max;
                _savingbookproduct.rate_withdraw_fees = savingmodel.rate_withdraw_fees;
                _savingbookproduct.transfer_fees_type = savingmodel.transfer_fees_type;
                _savingbookproduct.flat_transfer_fees_min = savingmodel.flat_transfer_fees_min;
                _savingbookproduct.flat_transfer_fees_max = savingmodel.flat_transfer_fees_max;
                _savingbookproduct.flat_transfer_fees = savingmodel.flat_transfer_fees;
                _savingbookproduct.rate_transfer_fees_min = savingmodel.rate_transfer_fees_min;
                _savingbookproduct.rate_transfer_fees_max = savingmodel.rate_transfer_fees_max;
                _savingbookproduct.rate_transfer_fees = savingmodel.rate_transfer_fees;
                _savingbookproduct.deposit_fees = savingmodel.deposit_fees;
                _savingbookproduct.deposit_fees_max = savingmodel.deposit_fees_max;
                _savingbookproduct.deposit_fees_min = savingmodel.deposit_fees_min;
                _savingbookproduct.close_fees = savingmodel.close_fees;
                _savingbookproduct.close_fees_max = savingmodel.close_fees_max;
                _savingbookproduct.close_fees_min = savingmodel.close_fees_min;
                _savingbookproduct.management_fees = savingmodel.management_fees;
                _savingbookproduct.management_fees_max = savingmodel.management_fees_max;
                _savingbookproduct.management_fees_min = savingmodel.management_fees_min;
                _savingbookproduct.management_fees_freq = savingmodel.management_fees_freq;
                _savingbookproduct.overdraft_fees = savingmodel.overdraft_fees;
                _savingbookproduct.overdraft_fees_max = savingmodel.overdraft_fees_max;
                _savingbookproduct.overdraft_fees_min = savingmodel.overdraft_fees_min;
                _savingbookproduct.agio_fees = savingmodel.agio_fees;
                _savingbookproduct.agio_fees_max = savingmodel.agio_fees_max;
                _savingbookproduct.agio_fees_min = savingmodel.agio_fees_min;
                _savingbookproduct.agio_fees_freq = savingmodel.agio_fees_freq;
                _savingbookproduct.cheque_deposit_min = savingmodel.cheque_deposit_min;
                _savingbookproduct.cheque_deposit_max = savingmodel.cheque_deposit_max;
                _savingbookproduct.cheque_deposit_fees = savingmodel.cheque_deposit_fees;
                _savingbookproduct.cheque_deposit_fees_min = savingmodel.cheque_deposit_fees_min;
                _savingbookproduct.cheque_deposit_fees_max = savingmodel.cheque_deposit_fees_max;
                _savingbookproduct.reopen_fees = savingmodel.reopen_fees;
                _savingbookproduct.reopen_fees_min = savingmodel.reopen_fees_min;
                _savingbookproduct.reopen_fees_max = savingmodel.reopen_fees_max;
                _savingbookproduct.is_ibt_fee_flat = savingmodel.is_ibt_fee_flat;
                _savingbookproduct.ibt_fee_min = savingmodel.ibt_fee_min;
                _savingbookproduct.ibt_fee_max = savingmodel.ibt_fee_max;
                _savingbookproduct.ibt_fee = savingmodel.ibt_fee;
                _savingbookproduct.use_term_deposit = savingmodel.use_term_deposit;
                _savingbookproduct.term_deposit_period_min = savingmodel.term_deposit_period_min;
                _savingbookproduct.term_deposit_period_max = savingmodel.term_deposit_period_max;
                _savingbookproduct.posting_frequency = savingmodel.posting_frequency;

                db.SavingBookProducts.AddObject(_savingbookproduct);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSavingsProduct(SavingProductModel savingmodel)
        {
            try
            {
                SavingProduct _savingproduct = db.SavingProducts.First(r => r.id == savingmodel.savingproductid);
                _savingproduct.name = savingmodel.name;
                _savingproduct.client_type = savingmodel.client_type;
                _savingproduct.initial_amount_min = savingmodel.initial_amount_min;
                _savingproduct.initial_amount_max = savingmodel.initial_amount_max;
                _savingproduct.balance_min = savingmodel.balance_min;
                _savingproduct.balance_max = savingmodel.balance_max;
                _savingproduct.withdraw_min = savingmodel.withdraw_min;
                _savingproduct.withdraw_max = savingmodel.withdraw_max;
                _savingproduct.deposit_min = savingmodel.deposit_min;
                _savingproduct.deposit_max = savingmodel.deposit_max;
                _savingproduct.interest_rate = savingmodel.interest_rate;
                _savingproduct.interest_rate_min = savingmodel.interest_rate_min;
                _savingproduct.interest_rate_max = savingmodel.interest_rate_max;
                _savingproduct.currency_id = savingmodel.currency_id;
                _savingproduct.entry_fees_min = savingmodel.entry_fees_min;
                _savingproduct.entry_fees_max = savingmodel.entry_fees_max;
                _savingproduct.entry_fees = savingmodel.entry_fees;
                _savingproduct.product_type = savingmodel.product_type;
                _savingproduct.code = savingmodel.code;
                _savingproduct.transfer_min = savingmodel.transfer_min;
                _savingproduct.transfer_max = savingmodel.transfer_max;

                SavingBookProduct _savingbookproduct = db.SavingBookProducts.First(r => r.id == savingmodel.saving_book_productid);
                _savingbookproduct.interest_base = savingmodel.interest_base;
                _savingbookproduct.interest_frequency = savingmodel.interest_frequency;
                _savingbookproduct.calcul_amount_base = savingmodel.calcul_amount_base;
                _savingbookproduct.flat_withdraw_fees_min = savingmodel.flat_withdraw_fees_min;
                _savingbookproduct.flat_withdraw_fees_max = savingmodel.flat_withdraw_fees_max;
                _savingbookproduct.flat_withdraw_fees = savingmodel.flat_withdraw_fees;
                _savingbookproduct.rate_withdraw_fees_min = savingmodel.rate_withdraw_fees_min;
                _savingbookproduct.rate_withdraw_fees_max = savingmodel.rate_withdraw_fees_max;
                _savingbookproduct.rate_withdraw_fees = savingmodel.rate_withdraw_fees;
                _savingbookproduct.transfer_fees_type = savingmodel.transfer_fees_type;
                _savingbookproduct.flat_transfer_fees_min = savingmodel.flat_transfer_fees_min;
                _savingbookproduct.flat_transfer_fees_max = savingmodel.flat_transfer_fees_max;
                _savingbookproduct.flat_transfer_fees = savingmodel.flat_transfer_fees;
                _savingbookproduct.rate_transfer_fees_min = savingmodel.rate_transfer_fees_min;
                _savingbookproduct.rate_transfer_fees_max = savingmodel.rate_transfer_fees_max;
                _savingbookproduct.rate_transfer_fees = savingmodel.rate_transfer_fees;
                _savingbookproduct.deposit_fees = savingmodel.deposit_fees;
                _savingbookproduct.deposit_fees_max = savingmodel.deposit_fees_max;
                _savingbookproduct.deposit_fees_min = savingmodel.deposit_fees_min;
                _savingbookproduct.close_fees = savingmodel.close_fees;
                _savingbookproduct.close_fees_max = savingmodel.close_fees_max;
                _savingbookproduct.close_fees_min = savingmodel.close_fees_min;
                _savingbookproduct.management_fees = savingmodel.management_fees;
                _savingbookproduct.management_fees_max = savingmodel.management_fees_max;
                _savingbookproduct.management_fees_min = savingmodel.management_fees_min;
                _savingbookproduct.management_fees_freq = savingmodel.management_fees_freq;
                _savingbookproduct.overdraft_fees = savingmodel.overdraft_fees;
                _savingbookproduct.overdraft_fees_max = savingmodel.overdraft_fees_max;
                _savingbookproduct.overdraft_fees_min = savingmodel.overdraft_fees_min;
                _savingbookproduct.agio_fees = savingmodel.agio_fees;
                _savingbookproduct.agio_fees_max = savingmodel.agio_fees_max;
                _savingbookproduct.agio_fees_min = savingmodel.agio_fees_min;
                _savingbookproduct.agio_fees_freq = savingmodel.agio_fees_freq;
                _savingbookproduct.cheque_deposit_min = savingmodel.cheque_deposit_min;
                _savingbookproduct.cheque_deposit_max = savingmodel.cheque_deposit_max;
                _savingbookproduct.cheque_deposit_fees = savingmodel.cheque_deposit_fees;
                _savingbookproduct.cheque_deposit_fees_min = savingmodel.cheque_deposit_fees_min;
                _savingbookproduct.cheque_deposit_fees_max = savingmodel.cheque_deposit_fees_max;
                _savingbookproduct.reopen_fees = savingmodel.reopen_fees;
                _savingbookproduct.reopen_fees_min = savingmodel.reopen_fees_min;
                _savingbookproduct.reopen_fees_max = savingmodel.reopen_fees_max;
                _savingbookproduct.is_ibt_fee_flat = savingmodel.is_ibt_fee_flat;
                _savingbookproduct.ibt_fee_min = savingmodel.ibt_fee_min;
                _savingbookproduct.ibt_fee_max = savingmodel.ibt_fee_max;
                _savingbookproduct.ibt_fee = savingmodel.ibt_fee;
                _savingbookproduct.use_term_deposit = savingmodel.use_term_deposit;
                _savingbookproduct.term_deposit_period_min = savingmodel.term_deposit_period_min;
                _savingbookproduct.term_deposit_period_max = savingmodel.term_deposit_period_max;
                _savingbookproduct.posting_frequency = savingmodel.posting_frequency;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteSavingsProduct(SavingProductModel savingmodel)
        {
            try
            {
                SavingProduct _savingproduct = db.SavingProducts.Where(i => i.id == savingmodel.savingproductid).Single();
                _savingproduct.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<SavingProductModel> GetSavingProductsList()
        {
            try
            {
                var savings = from sp in db.SavingProducts
                              join sbp in db.SavingBookProducts on sp.id equals sbp.id
                              select new SavingProductModel
                              {
                                  agio_fees = sbp.agio_fees,
                                  agio_fees_freq = sbp.agio_fees_freq,
                                  agio_fees_max = sbp.agio_fees_max,
                                  agio_fees_min = sbp.agio_fees_min,
                                  balance_max = sp.balance_max,
                                  balance_min = sp.balance_min,
                                  calcul_amount_base = sbp.calcul_amount_base,
                                  cheque_deposit_fees = sbp.cheque_deposit_fees,
                                  cheque_deposit_fees_max = sbp.cheque_deposit_fees_max,
                                  cheque_deposit_fees_min = sbp.cheque_deposit_fees_min,
                                  cheque_deposit_max = sbp.cheque_deposit_max,
                                  cheque_deposit_min = sbp.cheque_deposit_min,
                                  client_type = sp.client_type,
                                  close_fees = sbp.close_fees,
                                  close_fees_max = sbp.close_fees_max,
                                  close_fees_min = sbp.close_fees_min,
                                  code = sp.code,
                                  currency_id = sp.currency_id,
                                  deleted = sp.deleted,
                                  deposit_fees = sbp.deposit_fees,
                                  deposit_fees_max = sbp.deposit_fees_max,
                                  deposit_fees_min = sbp.deposit_fees_min,
                                  deposit_max = sp.deposit_max,
                                  deposit_min = sp.deposit_min,
                                  entry_fees = sp.entry_fees,
                                  entry_fees_max = sp.entry_fees_max,
                                  entry_fees_min = sp.entry_fees_min,
                                  flat_transfer_fees = sbp.flat_transfer_fees,
                                  flat_transfer_fees_max = sbp.flat_transfer_fees_max,
                                  flat_transfer_fees_min = sbp.flat_transfer_fees_min,
                                  flat_withdraw_fees = sbp.flat_withdraw_fees,
                                  flat_withdraw_fees_max = sbp.flat_withdraw_fees_max,
                                  flat_withdraw_fees_min = sbp.flat_withdraw_fees_min,
                                  ibt_fee = sbp.ibt_fee,
                                  ibt_fee_max = sbp.ibt_fee_max,
                                  ibt_fee_min = sbp.ibt_fee_min,
                                  initial_amount_max = sp.initial_amount_max,
                                  initial_amount_min = sp.initial_amount_min,
                                  interest_base = sbp.interest_base,
                                  interest_frequency = sbp.interest_frequency,
                                  interest_rate = sp.interest_rate,
                                  interest_rate_max = sp.interest_rate_max,
                                  interest_rate_min = sp.interest_rate_min,
                                  is_ibt_fee_flat = sbp.is_ibt_fee_flat,
                                  management_fees = sbp.management_fees,
                                  management_fees_freq = sbp.management_fees_freq,
                                  management_fees_max = sbp.management_fees_max,
                                  management_fees_min = sbp.management_fees_min,
                                  name = sp.name,
                                  overdraft_fees = sbp.overdraft_fees,
                                  overdraft_fees_max = sbp.overdraft_fees_max,
                                  overdraft_fees_min = sbp.overdraft_fees_min,
                                  posting_frequency = sbp.posting_frequency,
                                  product_type = sp.product_type,
                                  rate_transfer_fees = sbp.rate_transfer_fees,
                                  rate_transfer_fees_max = sbp.rate_transfer_fees_max,
                                  rate_transfer_fees_min = sbp.rate_transfer_fees_min,
                                  rate_withdraw_fees = sbp.rate_withdraw_fees,
                                  rate_withdraw_fees_max = sbp.rate_withdraw_fees_max,
                                  rate_withdraw_fees_min = sbp.rate_withdraw_fees_min,
                                  reopen_fees = sbp.reopen_fees,
                                  reopen_fees_max = sbp.reopen_fees_max,
                                  reopen_fees_min = sbp.reopen_fees_min,
                                  saving_book_productid = sbp.id,
                                  savingproductid = sp.id,
                                  term_deposit_period_max = sbp.term_deposit_period_max,
                                  term_deposit_period_min = sbp.term_deposit_period_min,
                                  transfer_fees_type = sbp.transfer_fees_type,
                                  transfer_max = sp.transfer_max,
                                  transfer_min = sp.transfer_min,
                                  use_term_deposit = sbp.use_term_deposit,
                                  withdraw_fees_type = sbp.withdraw_fees_type,
                                  withdraw_max = sp.withdraw_max,
                                  withdraw_min = sp.withdraw_min
                              };

                return savings.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "SavingProducts and SavingBookProducts"
        #region "Currency"
        public void AddNewCurrency(CurrencyModel currency)
        {
            try
            {
                Currency c = new Currency();
                c.name = currency.name;
                c.is_pivot = currency.is_pivot;
                c.code = currency.code;
                c.is_swapped = currency.is_swapped;
                c.use_cents = currency.use_cents;

                db.Currencies.AddObject(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCurrency(CurrencyModel currency)
        {
            try
            {
                Currency c = db.Currencies.First(r => r.id == currency.currencyid);
                c.name = currency.name;
                c.code = currency.code;
                c.is_swapped = currency.is_swapped;
                c.use_cents = currency.use_cents;
                c.is_pivot = currency.is_pivot;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCurrency(CurrencyModel currency)
        {
            try
            {
                Currency c = db.Currencies.Where(i => i.id == currency.currencyid).Single();

                db.Currencies.DeleteObject(c);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CurrencyModel> GetCurrenciesList()
        {
            try
            {
                var currencies = from cr in db.Currencies
                                 select new CurrencyModel
                              {
                                  currencyid = cr.id,
                                  name = cr.name,
                                  is_pivot = cr.is_pivot,
                                  code = cr.code,
                                  is_swapped = cr.is_swapped,
                                  use_cents = cr.use_cents
                              };

                return currencies.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public CurrencyModel GetDefaultCurrency()
        {
            try
            {
                var currency = (from cr in db.Currencies
                                select new CurrencyModel
                                {
                                    currencyid = cr.id,
                                    name = cr.name,
                                    is_pivot = cr.is_pivot,
                                    code = cr.code,
                                    is_swapped = cr.is_swapped,
                                    use_cents = cr.use_cents
                                }).FirstOrDefault();

                return currency;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Currency"
        #region "FundingLine"
        public void AddNewFundingLine(FundingLineModel fundingline)
        {
            try
            {
                FundingLine fl = new FundingLine();
                fl.name = fundingline.name;
                fl.begin_date = fundingline.begin_date;
                fl.end_date = fundingline.end_date;
                fl.amount = fundingline.amount;
                fl.purpose = fundingline.purpose;
                fl.deleted = fundingline.deleted;
                fl.currency_id = fundingline.currency_id;

                db.FundingLines.AddObject(fl);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateFundingLine(FundingLineModel fundingline)
        {
            try
            {
                FundingLine fl = db.FundingLines.First(r => r.id == fundingline.fundinglineid);
                fl.name = fundingline.name;
                fl.begin_date = fundingline.begin_date;
                fl.end_date = fundingline.end_date;
                fl.amount = fundingline.amount;
                fl.purpose = fundingline.purpose;
                fl.deleted = fundingline.deleted;
                fl.currency_id = fundingline.currency_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteFundingLine(FundingLineModel fundingline)
        {
            try
            {
                FundingLine fl = db.FundingLines.Where(r => r.id == fundingline.fundinglineid).Single();

                db.FundingLines.DeleteObject(fl);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<FundingLineModel> GetFundingLinesList()
        {
            try
            {
                var fundinglines = from fl in db.FundingLines
                                   select new FundingLineModel
                                   {
                                       fundinglineid = fl.id,
                                       name = fl.name,
                                       begin_date = fl.begin_date,
                                       end_date = fl.end_date,
                                       amount = fl.amount,
                                       purpose = fl.purpose,
                                       deleted = fl.deleted,
                                       currency_id = fl.currency_id
                                   };

                return fundinglines.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "FundingLine"
        #region "FundingLineEvent"
        public void AddNewFundingLineEvent(FundingLineEventModel fundinglineevent)
        {
            try
            {

                FundingLineEvent fle = new FundingLineEvent();
                fle.code = fundinglineevent.code;
                fle.amount = fundinglineevent.amount;
                fle.fundingline_id = fundinglineevent.fundingline_id;
                fle.deleted = fundinglineevent.deleted;
                fle.creation_date = fundinglineevent.creation_date;
                fle.type = fundinglineevent.type;
                fle.user_id = fundinglineevent.user_id;
                fle.contract_event_id = fundinglineevent.contract_event_id;
                fle.direction = fundinglineevent.direction;

                db.FundingLineEvents.AddObject(fle);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateFundingLineEvent(FundingLineEventModel fundinglineevent)
        {
            try
            {
                FundingLineEvent fle = db.FundingLineEvents.First(r => r.id == fundinglineevent.fundinglineeventid);
                fle.code = fundinglineevent.code;
                fle.amount = fundinglineevent.amount;
                fle.fundingline_id = fundinglineevent.fundingline_id;
                fle.deleted = fundinglineevent.deleted;
                fle.creation_date = fundinglineevent.creation_date;
                fle.type = fundinglineevent.type;
                fle.user_id = fundinglineevent.user_id;
                fle.contract_event_id = fundinglineevent.contract_event_id;
                fle.direction = fundinglineevent.direction;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteFundingLineEvent(FundingLineEventModel fundinglineevent)
        {
            try
            {
                FundingLineEvent fle = db.FundingLineEvents.Where(r => r.id == fundinglineevent.fundinglineeventid).Single();

                db.FundingLineEvents.DeleteObject(fle);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<FundingLineEventModel> GetFundingLineEventsList(int fundinglineid)
        {
            try
            {
                var fundinglineevents = from fundinglineevent in db.FundingLineEvents
                                        where fundinglineevent.fundingline_id == fundinglineid
                                        select new FundingLineEventModel
                                   {
                                       fundinglineeventid = fundinglineevent.id,
                                       code = fundinglineevent.code,
                                       amount = fundinglineevent.amount,
                                       fundingline_id = fundinglineevent.fundingline_id,
                                       deleted = fundinglineevent.deleted,
                                       creation_date = fundinglineevent.creation_date,
                                       type = fundinglineevent.type,
                                       user_id = fundinglineevent.user_id,
                                       contract_event_id = fundinglineevent.contract_event_id,
                                       direction = fundinglineevent.direction
                                   };

                return fundinglineevents.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "FundingLineEvent"
        #region "EconomicActivities"
        public void AddNewEconomicActivity(ActivityModel activity)
        {
            try
            {
                EconomicActivity ea = new EconomicActivity();
                ea.name = activity.name;
                ea.parent_id = activity.parent_id;
                ea.deleted = activity.deleted;

                db.EconomicActivities.AddObject(ea);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateEconomicActivity(ActivityModel activity)
        {
            try
            {
                EconomicActivity ea = db.EconomicActivities.First(r => r.id == activity.activityid);
                ea.name = activity.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public ActivityModel GetEconomicActivity(int activityid)
        {
            try
            {
                var _activitymodelquery = (from ea in db.EconomicActivities
                                           where ea.id == activityid
                                           select new ActivityModel
                                           {
                                               activityid = ea.id,
                                               deleted = ea.deleted,
                                               parent_id = ea.parent_id,
                                               name = ea.name
                                           }).FirstOrDefault();

                ActivityModel _activitymodel = _activitymodelquery;
                return _activitymodel;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public void DeleteEconomicActivity(ActivityModel activity)
        {
            try
            {
                EconomicActivity ea = db.EconomicActivities.Where(r => r.id == activity.activityid).Single();
                ea.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<ActivityModel> GetEconomicActivitiesList()
        {
            try
            {
                List<ActivityModel> _Activities = new List<ActivityModel>();
                var _activitymodelsquery = from ea in db.EconomicActivities
                                           select ea;
                List<EconomicActivity> _activitymodels = _activitymodelsquery.ToList();
                foreach (var am in _activitymodels)
                {
                    ActivityModel _Activity = new ActivityModel();
                    _Activity.activityid = am.id;
                    _Activity.name = am.name;
                    _Activity.parent_id = am.parent_id;
                    _Activity.deleted = am.deleted;

                    _Activities.Add(_Activity);
                }

                return _Activities;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ActivityModel> GetNonDeletedEconomicActivitiesList()
        {
            try
            {
                List<ActivityModel> _Activities = new List<ActivityModel>();
                var _activitymodelsquery = from ea in db.EconomicActivities
                                           where ea.deleted == false
                                           select ea;
                List<EconomicActivity> _activitymodels = _activitymodelsquery.ToList();
                foreach (var am in _activitymodels)
                {
                    ActivityModel _Activity = new ActivityModel();
                    _Activity.activityid = am.id;
                    _Activity.name = am.name;
                    _Activity.parent_id = am.parent_id;
                    _Activity.deleted = am.deleted;

                    _Activities.Add(_Activity);
                }

                return _Activities;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "EconomicActivities"
        #region "StandardBookings"
        public void AddNewStandardBooking(StandardBookingsModel standbook)
        {
            try
            {
                StandardBooking _standbook = new StandardBooking();
                _standbook.Name = standbook.Name;
                _standbook.debit_account_id = standbook.debit_account_id;
                _standbook.credit_account_id = standbook.credit_account_id;

                db.StandardBookings.AddObject(_standbook);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateStandardBooking(StandardBookingsModel standbook)
        {
            try
            {
                StandardBooking _standbook = db.StandardBookings.First(r => r.Id == standbook.standardbookingid);
                _standbook.Name = standbook.Name;
                _standbook.debit_account_id = standbook.debit_account_id;
                _standbook.credit_account_id = standbook.credit_account_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteStandardBooking(StandardBookingsModel standbook)
        {
            try
            {
                StandardBooking _standbook = db.StandardBookings.Where(r => r.Id == standbook.standardbookingid).Single();

                db.StandardBookings.DeleteObject(_standbook);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<StandardBookingsModel> GetAllStandardBookings()
        {
            try
            {
                var _standardbookingsquery = from br in db.StandardBookings
                                             join cracc in db.ChartOfAccounts on br.credit_account_id equals cracc.id
                                             join dracc in db.ChartOfAccounts on br.debit_account_id equals dracc.id

                                             select new StandardBookingsModel
                                             {
                                                 description = br.Name + "  " + cracc.account_number + ":" + cracc.label + "  " + dracc.account_number + ":" + dracc.label,
                                                 credit_account_id = cracc.id,
                                                 debit_account_id = dracc.id,
                                                 Name = br.Name,
                                                 standardbookingid = br.Id
                                             };

                return _standardbookingsquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "StandardBookings"
        #region "EventTypes"
        public void AddNewEventType(EventTypesModel eventtype)
        {
            try
            {
                EventType et = new EventType();
                et.event_type = eventtype.event_type;
                et.description = eventtype.description;
                et.sort_order = eventtype.sort_order;
                et.accounting = eventtype.accounting;

                db.EventTypes.AddObject(et);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateEventType(EventTypesModel eventtype)
        {
            try
            {
                EventType et = db.EventTypes.First(r => r.id == eventtype.eventtypeid);
                et.event_type = eventtype.event_type;
                et.description = eventtype.description;
                et.sort_order = eventtype.sort_order;
                et.accounting = eventtype.accounting;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteEventType(EventTypesModel eventtype)
        {
            try
            {
                EventType ea = db.EventTypes.Where(r => r.id == eventtype.eventtypeid).Single();

                db.EventTypes.DeleteObject(ea);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<EventTypesModel> GetEventTypesList()
        {
            try
            {
                List<EventTypesModel> _EventTypes = new List<EventTypesModel>();
                var _eventtypemodelsquery = from ea in db.EventTypes
                                            select ea;
                List<EventType> _eventtypemodels = _eventtypemodelsquery.ToList();
                foreach (var et in _eventtypemodels)
                {
                    EventTypesModel _EventType = new EventTypesModel();
                    _EventType.eventtypeid = et.id;
                    _EventType.event_type = et.event_type;
                    _EventType.description = et.description;
                    _EventType.sort_order = et.sort_order;
                    _EventType.accounting = et.accounting;

                    _EventTypes.Add(_EventType);
                }

                return _EventTypes;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "EventTypes"
        #region "EventAttributes"
        public void AddNewEventAttribute(EventAttributesModel eventtype)
        {
            try
            {
                EventAttribute ea = new EventAttribute();
                ea.event_type = eventtype.event_type;
                ea.name = eventtype.name;

                db.EventAttributes.AddObject(ea);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateEventAttribute(EventAttributesModel eventattribute)
        {
            try
            {
                EventAttribute ea = db.EventAttributes.First(r => r.id == eventattribute.eventattributeid);
                ea.event_type = eventattribute.event_type;
                ea.name = eventattribute.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteEventAttribute(EventAttributesModel eventattribute)
        {
            try
            {
                EventAttribute ea = db.EventAttributes.Where(r => r.id == eventattribute.eventattributeid).Single();

                db.EventAttributes.DeleteObject(ea);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<EventAttributesModel> GetEventAttributesList()
        {
            try
            {
                List<EventAttributesModel> _EventAttributes = new List<EventAttributesModel>();
                var _eventattributemodelsquery = from ea in db.EventAttributes
                                                 select ea;
                List<EventAttribute> _eventattributemodels = _eventattributemodelsquery.ToList();
                foreach (var ea in _eventattributemodels)
                {
                    EventAttributesModel _EventAttribute = new EventAttributesModel();
                    _EventAttribute.eventattributeid = ea.id;
                    _EventAttribute.event_type = ea.event_type;
                    _EventAttribute.name = ea.name;

                    _EventAttributes.Add(_EventAttribute);
                }

                return _EventAttributes;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<EventAttributesModel> GetEventAttributesList(string event_type)
        {
            try
            {
                List<EventAttributesModel> _EventAttributes = new List<EventAttributesModel>();
                var _eventattributemodelsquery = from ea in db.EventAttributes
                                                 where ea.event_type == event_type
                                                 select ea;
                List<EventAttribute> _eventattributemodels = _eventattributemodelsquery.ToList();
                foreach (var ea in _eventattributemodels)
                {
                    EventAttributesModel _EventAttribute = new EventAttributesModel();
                    _EventAttribute.eventattributeid = ea.id;
                    _EventAttribute.event_type = ea.event_type;
                    _EventAttribute.name = ea.name;

                    _EventAttributes.Add(_EventAttribute);
                }

                return _EventAttributes;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "EventAttributes"
        #region "ChartOfAccounts"
        public void AddNewAccount(AccountModel account)
        {
            try
            {
                ChartOfAccount coa = new ChartOfAccount();
                coa.account_number = account.account_number;
                coa.label = account.label;
                coa.debit_plus = account.debit_plus;
                coa.type_code = account.type_code;
                coa.account_category_id = account.account_category_id;
                coa.type = account.type;
                coa.parent_account_id = account.parent_account_id;
                coa.lft = account.lft;
                coa.rgt = account.rgt;

                db.ChartOfAccounts.AddObject(coa);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAccount(AccountModel account)
        {
            try
            {
                ChartOfAccount coa = db.ChartOfAccounts.First(r => r.id == account.accountid);
                coa.account_number = account.account_number;
                coa.label = account.label;
                coa.debit_plus = account.debit_plus;
                coa.type_code = account.type_code;
                coa.account_category_id = account.account_category_id;
                coa.type = account.type;
                coa.parent_account_id = account.parent_account_id;
                coa.lft = account.lft;
                coa.rgt = account.rgt;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAccount(AccountModel account)
        {
            try
            {
                ChartOfAccount coa = db.ChartOfAccounts.Where(r => r.id == account.accountid).Single();

                db.ChartOfAccounts.DeleteObject(coa);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<AccountModel> GetAccountsList()
        {
            try
            {
                List<AccountModel> _Accounts = new List<AccountModel>();
                var _accountmodelsquery = from ea in db.ChartOfAccounts
                                          select ea;
                List<ChartOfAccount> _accountmodels = _accountmodelsquery.ToList();
                foreach (var account in _accountmodels)
                {
                    AccountModel _Account = new AccountModel();
                    _Account.accountid = account.id;
                    _Account.account_number = account.account_number;
                    _Account.label = account.label;
                    _Account.debit_plus = account.debit_plus;
                    _Account.type_code = account.type_code;
                    _Account.account_category_id = account.account_category_id;
                    _Account.type = account.type;
                    _Account.parent_account_id = account.parent_account_id;
                    _Account.lft = account.lft;
                    _Account.rgt = account.rgt;

                    _Accounts.Add(_Account);
                }

                return _Accounts;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AccountModel> GetGeneralLedgerAccountsList()
        {
            try
            {
                List<AccountModel> _Accounts = new List<AccountModel>();
                var _accountmodelsquery = from ea in db.ChartOfAccounts
                                          orderby ea.account_number ascending
                                          select ea;
                List<ChartOfAccount> _accountmodels = _accountmodelsquery.ToList();
                foreach (var account in _accountmodels)
                {
                    AccountModel _Account = new AccountModel();
                    _Account.accountid = account.id;
                    _Account.account_number = account.account_number;
                    _Account.label = account.account_number + " : " + account.label;
                    _Account.debit_plus = account.debit_plus;
                    _Account.type_code = account.type_code;
                    _Account.account_category_id = account.account_category_id;
                    _Account.type = account.type;
                    _Account.parent_account_id = account.parent_account_id;
                    _Account.lft = account.lft;
                    _Account.rgt = account.rgt;

                    _Accounts.Add(_Account);
                }

                return _Accounts;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AccountCategoryModel> GetAllAccountCategoriesList()
        {
            try
            {
                List<AccountCategoryModel> _Accounts = new List<AccountCategoryModel>();
                var _accountmodelsquery = from ea in db.AccountsCategories
                                          select ea;
                List<AccountsCategory> _accountmodels = _accountmodelsquery.ToList();
                foreach (var account in _accountmodels)
                {
                    AccountCategoryModel _Account = new AccountCategoryModel();
                    _Account.accountcategoryid = account.id;
                    _Account.name = account.name;

                    _Accounts.Add(_Account);
                }

                return _Accounts;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AccountModel> GetAccountCategoryAccountsList(int accountCategoryid)
        {
            try
            {
                List<AccountModel> _Accounts = new List<AccountModel>();
                var _accountmodelsquery = from ea in db.ChartOfAccounts
                                          where ea.account_category_id == accountCategoryid
                                          select ea;
                List<ChartOfAccount> _accountmodels = _accountmodelsquery.ToList();
                foreach (var account in _accountmodels)
                {
                    AccountModel _Account = new AccountModel();
                    _Account.accountid = account.id;
                    _Account.account_number = account.account_number;
                    _Account.label = account.label;
                    _Account.debit_plus = account.debit_plus;
                    _Account.type_code = account.type_code;
                    _Account.account_category_id = account.account_category_id;
                    _Account.type = account.type;
                    _Account.parent_account_id = account.parent_account_id;
                    _Account.lft = account.lft;
                    _Account.rgt = account.rgt;

                    _Accounts.Add(_Account);
                }

                return _Accounts;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AccountModel> GetChildrenAccountsList(int accountid)
        {
            try
            {
                List<AccountModel> _Accounts = new List<AccountModel>();
                var _accountmodelsquery = from ea in db.ChartOfAccounts
                                          where ea.parent_account_id == accountid
                                          select ea;
                List<ChartOfAccount> _accountmodels = _accountmodelsquery.ToList();
                foreach (var account in _accountmodels)
                {
                    AccountModel _Account = new AccountModel();
                    _Account.accountid = account.id;
                    _Account.account_number = account.account_number;
                    _Account.label = account.label;
                    _Account.debit_plus = account.debit_plus;
                    _Account.type_code = account.type_code;
                    _Account.account_category_id = account.account_category_id;
                    _Account.type = account.type;
                    _Account.parent_account_id = account.parent_account_id;
                    _Account.lft = account.lft;
                    _Account.rgt = account.rgt;

                    _Accounts.Add(_Account);
                }

                return _Accounts;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "ChartOfAccounts"
        #region "AccountingRules"
        public void AddNewAccountingRule(AccountingRuleModel accountingrule)
        {
            try
            {
                AccountingRule ar = new AccountingRule();
                ar.rule_type = accountingrule.rule_type;
                ar.deleted = accountingrule.deleted;
                ar.booking_direction = accountingrule.booking_direction;
                ar.event_type = accountingrule.event_type;
                ar.event_attribute_id = accountingrule.event_attribute_id;
                ar.debit_account_number_id = accountingrule.debit_account_number_id;
                ar.credit_account_number_id = accountingrule.credit_account_number_id;
                ar.order = accountingrule.order;
                ar.description = accountingrule.description;

                db.AccountingRules.AddObject(ar);
                db.SaveChanges();

                var _accountingrulequery = (from s in db.AccountingRules
                                            where s.event_type == accountingrule.event_type
                                            where s.event_attribute_id == accountingrule.event_attribute_id
                                            where ar.description == accountingrule.description
                                            select s).FirstOrDefault();
                AccountingRule _AccountingRule = _accountingrulequery;
                if (_AccountingRule != null)
                {
                    ContractAccountingRule car = new ContractAccountingRule();
                    car.id = _AccountingRule.id;
                    car.product_type = accountingrule.product_type;
                    car.loan_product_id = accountingrule.loan_product_id;
                    car.savings_product_id = accountingrule.savings_product_id;
                    car.client_type = accountingrule.client_type;
                    car.activity_id = accountingrule.activity_id;
                    car.currency_id = accountingrule.currency_id;

                    db.ContractAccountingRules.AddObject(car);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAccountingRule(AccountingRuleModel accountingrule)
        {
            try
            {
                AccountingRule ar = db.AccountingRules.First(r => r.id == accountingrule.accountingruleid);
                ar.rule_type = accountingrule.rule_type;
                ar.deleted = accountingrule.deleted;
                ar.booking_direction = accountingrule.booking_direction;
                ar.event_type = accountingrule.event_type;
                ar.event_attribute_id = accountingrule.event_attribute_id;
                ar.debit_account_number_id = accountingrule.debit_account_number_id;
                ar.credit_account_number_id = accountingrule.credit_account_number_id;
                ar.order = accountingrule.order;
                ar.description = accountingrule.description;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                ContractAccountingRule car = db.ContractAccountingRules.First(r => r.id == accountingrule.accountingruleid);
                car.product_type = accountingrule.product_type;
                car.loan_product_id = accountingrule.loan_product_id;
                car.savings_product_id = accountingrule.savings_product_id;
                car.client_type = accountingrule.client_type;
                car.activity_id = accountingrule.activity_id;
                car.currency_id = accountingrule.currency_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAccountingRule(AccountingRuleModel accountingrule)
        {
            try
            {
                ContractAccountingRule car = db.ContractAccountingRules.Where(r => r.id == accountingrule.accountingruleid).Single();

                db.ContractAccountingRules.DeleteObject(car);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);

                AccountingRule ar = db.AccountingRules.Where(r => r.id == accountingrule.accountingruleid).Single();

                db.AccountingRules.DeleteObject(ar);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<AccountingRuleModel> GetAccountingRulesList()
        {
            try
            {
                List<AccountingRuleModel> _AccountingRules = new List<AccountingRuleModel>();
                var _accountingrulesquery = (from ar in db.AccountingRules
                                             join car in db.ContractAccountingRules on ar.id equals car.id
                                             join et in db.EventTypes on ar.event_type equals et.event_type
                                             join ea in db.EventAttributes on et.event_type equals ea.event_type
                                             join drcoa in db.ChartOfAccounts on ar.debit_account_number_id equals drcoa.id
                                             join crcoa in db.ChartOfAccounts on ar.credit_account_number_id equals crcoa.id
                                             orderby ar.event_type, ar.EventAttribute ascending
                                             select new AccountingRuleModel
                                             {
                                                 accountingruleid = ar.id,
                                                 rule_type = ar.rule_type,
                                                 deleted = ar.deleted,
                                                 booking_direction = ar.booking_direction,
                                                 event_type = ar.event_type,
                                                 event_attribute_id = ar.event_attribute_id,
                                                 event_attribute_name = ea.name,
                                                 event_type_description = et.event_type + " : " + et.description,
                                                 craccount_description = crcoa.account_number + " : " + crcoa.label,
                                                 draccount_description = drcoa.account_number + " : " + drcoa.label,

                                                 debit_account_number_id = ar.debit_account_number_id,
                                                 credit_account_number_id = ar.credit_account_number_id,
                                                 order = ar.order,
                                                 description = ar.description,
                                                 contractaccountingruleid = car.id,
                                                 product_type = car.product_type,
                                                 loan_product_id = car.loan_product_id,
                                                 savings_product_id = car.savings_product_id,
                                                 client_type = car.client_type,
                                                 activity_id = car.activity_id,
                                                 currency_id = car.currency_id
                                             }).Distinct();
                _AccountingRules = _accountingrulesquery.ToList();
                return _AccountingRules;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AccountingRules"
        #region "Provinces"
        public void AddNewProvince(ProvinceModel province)
        {
            try
            {
                Province _branch = new Province();
                _branch.name = province.name;
                _branch.deleted = false;

                db.Provinces.AddObject(_branch);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateProvince(ProvinceModel province)
        {
            try
            {
                Province _branch = db.Provinces.First(b => b.id == province.provinceid);
                _branch.name = province.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteProvince(ProvinceModel province)
        {
            try
            {
                Province _branch = db.Provinces.First(b => b.id == province.provinceid);
                _branch.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public ProvinceModel GetProvince(int provinceid)
        {
            try
            {
                var _provincequery = (from pr in db.Provinces
                                      where pr.id == provinceid
                                      where pr.deleted == false
                                      select new ProvinceModel
                                      {
                                          provinceid = pr.id,
                                          name = pr.name,
                                          deleted = pr.deleted
                                      }).FirstOrDefault();

                ProvinceModel _province = _provincequery;
                return _province;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ProvinceModel> GetNonDeletedProvinces()
        {
            try
            {
                List<ProvinceModel> _provinces = new List<ProvinceModel>();
                var _provincesquery = from pr in db.Provinces
                                      where pr.deleted == false
                                      select pr;
                foreach (var province in _provincesquery)
                {
                    ProvinceModel _province = new ProvinceModel();
                    _province.provinceid = province.id;
                    _province.name = province.name;
                    _province.deleted = province.deleted;

                    _provinces.Add(_province);
                }

                return _provinces;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ProvinceModel> GetAllProvinces()
        {
            try
            {
                List<ProvinceModel> _provinces = new List<ProvinceModel>();
                var _provincesquery = from pr in db.Provinces
                                      select pr;
                foreach (var province in _provincesquery)
                {
                    ProvinceModel _province = new ProvinceModel();
                    _province.provinceid = province.id;
                    _province.name = province.name;
                    _province.deleted = province.deleted;

                    _provinces.Add(_province);
                }

                return _provinces;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Provinces"
        #region "Districts"
        public void AddNewDistrict(DistrictModel district)
        {
            try
            {
                District _district = new District();
                _district.name = district.name;
                _district.deleted = false;
                _district.province_id = district.province_id;

                db.Districts.AddObject(_district);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateDistrict(DistrictModel district)
        {
            try
            {
                District _district = db.Districts.First(b => b.id == district.districtid);
                _district.name = district.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteDistrict(DistrictModel district)
        {
            try
            {
                District _district = db.Districts.First(b => b.id == district.districtid);
                _district.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public DistrictModel GetDistrict(int districtid)
        {
            try
            {
                var _districtquery = (from pr in db.Districts
                                      where pr.id == districtid
                                      where pr.deleted == false
                                      select new DistrictModel
                                      {
                                          districtid = pr.id,
                                          province_id = pr.province_id,
                                          name = pr.name,
                                          deleted = pr.deleted
                                      }).FirstOrDefault();

                DistrictModel _district = _districtquery;
                return _district;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<DistrictModel> GetNonDeletedDistricts(int provinceid)
        {
            try
            {
                List<DistrictModel> _districts = new List<DistrictModel>();
                var _districtsquery = from br in db.Districts
                                      where br.deleted == false
                                      where br.province_id == provinceid
                                      select br;
                foreach (var district in _districtsquery)
                {
                    DistrictModel _district = new DistrictModel();
                    _district.districtid = district.id;
                    _district.name = district.name;
                    _district.province_id = district.province_id;
                    _district.deleted = district.deleted;

                    _districts.Add(_district);
                }

                return _districts;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<DistrictModel> GetAllDistricts(int provinceid)
        {
            try
            {
                List<DistrictModel> _districts = new List<DistrictModel>();
                var _districtsquery = from br in db.Districts
                                      where br.province_id == provinceid
                                      select br;
                foreach (var district in _districtsquery)
                {
                    DistrictModel _district = new DistrictModel();
                    _district.districtid = district.id;
                    _district.name = district.name;
                    _district.province_id = district.province_id;
                    _district.deleted = district.deleted;

                    _districts.Add(_district);
                }

                return _districts;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Districts"
        #region "Cities"
        public void AddNewCity(CityModel city)
        {
            try
            {
                City _city = new City();
                _city.name = city.name;
                _city.district_id = city.district_id;
                _city.deleted = city.deleted;

                db.Cities.AddObject(_city);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCity(CityModel city)
        {
            try
            {
                City _city = db.Cities.First(b => b.id == city.cityid);
                _city.name = city.name;
                _city.district_id = city.district_id;
                _city.deleted = city.deleted;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCity(CityModel city)
        {
            try
            {
                City _city = db.Cities.First(b => b.id == city.cityid);
                _city.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public CityModel GetCity(int cityid)
        {
            try
            {
                var _cityquery = (from pr in db.Cities
                                  where pr.id == cityid
                                  where pr.deleted == false
                                  select new CityModel
                                  {
                                      cityid = pr.id,
                                      district_id = pr.district_id,
                                      name = pr.name,
                                      deleted = pr.deleted
                                  }).FirstOrDefault();

                CityModel _city = _cityquery;
                return _city;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CityModel> GetNonDeletedCities()
        {
            try
            {
                List<CityModel> _cities = new List<CityModel>();
                var _citiesquery = from br in db.Cities
                                   where br.deleted == false
                                   select br;
                foreach (var city in _citiesquery)
                {
                    CityModel _city = new CityModel();
                    _city.cityid = city.id;
                    _city.name = city.name;
                    _city.district_id = city.district_id;
                    _city.deleted = city.deleted;

                    _cities.Add(_city);
                }

                return _cities;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CityModel> GetAllCities(int districtid)
        {
            try
            {
                List<CityModel> _cities = new List<CityModel>();
                var _citiesquery = from br in db.Cities
                                   where br.district_id == districtid
                                   select br;
                foreach (var city in _citiesquery)
                {
                    CityModel _city = new CityModel();
                    _city.cityid = city.id;
                    _city.name = city.name;
                    _city.district_id = city.district_id;
                    _city.deleted = city.deleted;

                    _cities.Add(_city);
                }

                return _cities;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Cities"
        #region "ManualAccountingMovements"
        public void AddNewManualEntry(ManualAccountingMovementModel manualentry)
        {
            try
            {
                ManualAccountingMovement _manualentry = new ManualAccountingMovement();
                _manualentry.debit_account_number_id = manualentry.debit_account_number_id;
                _manualentry.credit_account_number_id = manualentry.credit_account_number_id;
                _manualentry.amount = manualentry.amount;
                _manualentry.transaction_date = manualentry.transaction_date;
                _manualentry.export_date = manualentry.export_date;
                _manualentry.currency_id = manualentry.currency_id;
                _manualentry.exchange_rate = manualentry.exchange_rate;
                _manualentry.description = manualentry.description;
                _manualentry.user_id = manualentry.user_id;
                _manualentry.event_id = manualentry.event_id;
                _manualentry.branch_id = manualentry.branch_id;
                _manualentry.closure_id = manualentry.closure_id;
                _manualentry.fiscal_year_id = manualentry.fiscal_year_id;

                db.ManualAccountingMovements.AddObject(_manualentry);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateManualEntry(ManualAccountingMovementModel manualentry)
        {
            try
            {
                ManualAccountingMovement _manualentry = db.ManualAccountingMovements.First(b => b.id == manualentry.manualentryid);
                _manualentry.debit_account_number_id = manualentry.debit_account_number_id;
                _manualentry.credit_account_number_id = manualentry.credit_account_number_id;
                _manualentry.amount = manualentry.amount;
                _manualentry.transaction_date = manualentry.transaction_date;
                _manualentry.export_date = manualentry.export_date;
                _manualentry.currency_id = manualentry.currency_id;
                _manualentry.exchange_rate = manualentry.exchange_rate;
                _manualentry.description = manualentry.description;
                _manualentry.user_id = manualentry.user_id;
                _manualentry.event_id = manualentry.event_id;
                _manualentry.branch_id = manualentry.branch_id;
                _manualentry.closure_id = manualentry.closure_id;
                _manualentry.fiscal_year_id = manualentry.fiscal_year_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void MarkEntryAsExported(ManualAccountingMovementModel manualentry)
        {
            try
            {
                ManualAccountingMovement _manualentry = db.ManualAccountingMovements.First(b => b.id == manualentry.manualentryid);
                _manualentry.is_exported = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ManualAccountingMovementModel> GetNonExportedManualEntries()
        {
            try
            {
                List<ManualAccountingMovementModel> _manualentries = new List<ManualAccountingMovementModel>();
                var _manualentriesquery = from br in db.ManualAccountingMovements
                                          where br.is_exported == false
                                          select br;
                foreach (var manualentry in _manualentriesquery)
                {
                    ManualAccountingMovementModel _manualentry = new ManualAccountingMovementModel();
                    _manualentry.manualentryid = manualentry.id;
                    _manualentry.debit_account_number_id = manualentry.debit_account_number_id;
                    _manualentry.credit_account_number_id = manualentry.credit_account_number_id;
                    _manualentry.amount = manualentry.amount;
                    _manualentry.transaction_date = manualentry.transaction_date;
                    _manualentry.export_date = manualentry.export_date;
                    _manualentry.currency_id = manualentry.currency_id;
                    _manualentry.exchange_rate = manualentry.exchange_rate;
                    _manualentry.description = manualentry.description;
                    _manualentry.user_id = manualentry.user_id;
                    _manualentry.event_id = manualentry.event_id;
                    _manualentry.branch_id = manualentry.branch_id;
                    _manualentry.closure_id = manualentry.closure_id;
                    _manualentry.fiscal_year_id = manualentry.fiscal_year_id;

                    _manualentries.Add(_manualentry);
                }

                return _manualentries;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ManualAccountingMovementModel> GetAllManualEntries()
        {
            try
            {
                List<ManualAccountingMovementModel> _manualentries = new List<ManualAccountingMovementModel>();
                var _manualentriesquery = from br in db.ManualAccountingMovements
                                          where br.is_exported == false
                                          select br;
                foreach (var manualentry in _manualentriesquery)
                {
                    ManualAccountingMovementModel _manualentry = new ManualAccountingMovementModel();
                    _manualentry.manualentryid = manualentry.id;
                    _manualentry.debit_account_number_id = manualentry.debit_account_number_id;
                    _manualentry.credit_account_number_id = manualentry.credit_account_number_id;
                    _manualentry.amount = manualentry.amount;
                    _manualentry.transaction_date = manualentry.transaction_date;
                    _manualentry.export_date = manualentry.export_date;
                    _manualentry.currency_id = manualentry.currency_id;
                    _manualentry.exchange_rate = manualentry.exchange_rate;
                    _manualentry.description = manualentry.description;
                    _manualentry.user_id = manualentry.user_id;
                    _manualentry.event_id = manualentry.event_id;
                    _manualentry.branch_id = manualentry.branch_id;
                    _manualentry.closure_id = manualentry.closure_id;
                    _manualentry.fiscal_year_id = manualentry.fiscal_year_id;

                    _manualentries.Add(_manualentry);
                }

                return _manualentries;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "ManualAccountingMovements"
        #region "LoanAccountingMovements"
        public void AddNewManualEntry(LoanAccountingMovementModel loanaccountingmovement)
        {
            try
            {
                LoanAccountingMovement _loanaccountingmovement = new LoanAccountingMovement();
                _loanaccountingmovement.debit_account_number_id = loanaccountingmovement.debit_account_number_id;
                _loanaccountingmovement.credit_account_number_id = loanaccountingmovement.credit_account_number_id;
                _loanaccountingmovement.amount = loanaccountingmovement.amount;
                _loanaccountingmovement.event_id = loanaccountingmovement.event_id;
                _loanaccountingmovement.transaction_date = loanaccountingmovement.transaction_date;
                _loanaccountingmovement.export_date = loanaccountingmovement.export_date;
                _loanaccountingmovement.is_exported = loanaccountingmovement.is_exported;
                _loanaccountingmovement.currency_id = loanaccountingmovement.currency_id;
                _loanaccountingmovement.exchange_rate = loanaccountingmovement.exchange_rate;
                _loanaccountingmovement.rule_id = loanaccountingmovement.rule_id;
                _loanaccountingmovement.branch_id = loanaccountingmovement.branch_id;
                _loanaccountingmovement.closure_id = loanaccountingmovement.closure_id;
                _loanaccountingmovement.fiscal_year_id = loanaccountingmovement.fiscal_year_id;
                _loanaccountingmovement.booking_type = loanaccountingmovement.booking_type;

                db.LoanAccountingMovements.AddObject(_loanaccountingmovement);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateManualEntry(LoanAccountingMovementModel loanaccountingmovement)
        {
            try
            {
                LoanAccountingMovement _loanaccountingmovement = db.LoanAccountingMovements.First(b => b.id == loanaccountingmovement.loanaccountingid);
                _loanaccountingmovement.debit_account_number_id = loanaccountingmovement.debit_account_number_id;
                _loanaccountingmovement.credit_account_number_id = loanaccountingmovement.credit_account_number_id;
                _loanaccountingmovement.amount = loanaccountingmovement.amount;
                _loanaccountingmovement.event_id = loanaccountingmovement.event_id;
                _loanaccountingmovement.transaction_date = loanaccountingmovement.transaction_date;
                _loanaccountingmovement.export_date = loanaccountingmovement.export_date;
                _loanaccountingmovement.is_exported = loanaccountingmovement.is_exported;
                _loanaccountingmovement.currency_id = loanaccountingmovement.currency_id;
                _loanaccountingmovement.exchange_rate = loanaccountingmovement.exchange_rate;
                _loanaccountingmovement.rule_id = loanaccountingmovement.rule_id;
                _loanaccountingmovement.branch_id = loanaccountingmovement.branch_id;
                _loanaccountingmovement.closure_id = loanaccountingmovement.closure_id;
                _loanaccountingmovement.fiscal_year_id = loanaccountingmovement.fiscal_year_id;
                _loanaccountingmovement.booking_type = loanaccountingmovement.booking_type;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void MarkLoanAccountingMovementAsExported(LoanAccountingMovementModel loanaccountingmovement)
        {
            try
            {
                LoanAccountingMovement _loanaccountingmovement = db.LoanAccountingMovements.First(b => b.id == loanaccountingmovement.loanaccountingid);
                _loanaccountingmovement.is_exported = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<LoanAccountingMovementModel> GetNonExportedLoanAccountingMovements()
        {
            try
            {
                List<LoanAccountingMovementModel> _loanaccountingmovements = new List<LoanAccountingMovementModel>();
                var _loanaccountingmovementsquery = from br in db.LoanAccountingMovements
                                                    where br.is_exported == false
                                                    select br;
                foreach (var loanaccountingmovement in _loanaccountingmovementsquery)
                {
                    LoanAccountingMovementModel _loanaccountingmovement = new LoanAccountingMovementModel();
                    _loanaccountingmovement.loanaccountingid = loanaccountingmovement.id;
                    _loanaccountingmovement.debit_account_number_id = loanaccountingmovement.debit_account_number_id;
                    _loanaccountingmovement.credit_account_number_id = loanaccountingmovement.credit_account_number_id;
                    _loanaccountingmovement.amount = loanaccountingmovement.amount;
                    _loanaccountingmovement.event_id = loanaccountingmovement.event_id;
                    _loanaccountingmovement.transaction_date = loanaccountingmovement.transaction_date;
                    _loanaccountingmovement.export_date = loanaccountingmovement.export_date;
                    _loanaccountingmovement.is_exported = loanaccountingmovement.is_exported;
                    _loanaccountingmovement.currency_id = loanaccountingmovement.currency_id;
                    _loanaccountingmovement.exchange_rate = loanaccountingmovement.exchange_rate;
                    _loanaccountingmovement.rule_id = loanaccountingmovement.rule_id;
                    _loanaccountingmovement.branch_id = loanaccountingmovement.branch_id;
                    _loanaccountingmovement.closure_id = loanaccountingmovement.closure_id;
                    _loanaccountingmovement.fiscal_year_id = loanaccountingmovement.fiscal_year_id;
                    _loanaccountingmovement.booking_type = loanaccountingmovement.booking_type;

                    _loanaccountingmovements.Add(_loanaccountingmovement);
                }

                return _loanaccountingmovements;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<LoanAccountingMovementModel> GetAllLoanAccountingMovements()
        {
            try
            {
                List<LoanAccountingMovementModel> _loanaccountingmovements = new List<LoanAccountingMovementModel>();
                var _loanaccountingmovementsquery = from br in db.LoanAccountingMovements
                                                    select br;
                foreach (var loanaccountingmovement in _loanaccountingmovementsquery)
                {
                    LoanAccountingMovementModel _loanaccountingmovement = new LoanAccountingMovementModel();
                    _loanaccountingmovement.loanaccountingid = loanaccountingmovement.id;
                    _loanaccountingmovement.debit_account_number_id = loanaccountingmovement.debit_account_number_id;
                    _loanaccountingmovement.credit_account_number_id = loanaccountingmovement.credit_account_number_id;
                    _loanaccountingmovement.amount = loanaccountingmovement.amount;
                    _loanaccountingmovement.event_id = loanaccountingmovement.event_id;
                    _loanaccountingmovement.transaction_date = loanaccountingmovement.transaction_date;
                    _loanaccountingmovement.export_date = loanaccountingmovement.export_date;
                    _loanaccountingmovement.is_exported = loanaccountingmovement.is_exported;
                    _loanaccountingmovement.currency_id = loanaccountingmovement.currency_id;
                    _loanaccountingmovement.exchange_rate = loanaccountingmovement.exchange_rate;
                    _loanaccountingmovement.rule_id = loanaccountingmovement.rule_id;
                    _loanaccountingmovement.branch_id = loanaccountingmovement.branch_id;
                    _loanaccountingmovement.closure_id = loanaccountingmovement.closure_id;
                    _loanaccountingmovement.fiscal_year_id = loanaccountingmovement.fiscal_year_id;
                    _loanaccountingmovement.booking_type = loanaccountingmovement.booking_type;

                    _loanaccountingmovements.Add(_loanaccountingmovement);
                }

                return _loanaccountingmovements;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "LoanAccountingMovements"
        #region "PaymentMethods"
        public void AddNewPaymentMethod(PaymentMethodModel paymethod)
        {
            try
            {
                PaymentMethod _paymethod = new PaymentMethod();
                _paymethod.name = paymethod.name;
                _paymethod.description = paymethod.description;
                _paymethod.is_active_for_loans = paymethod.is_active_for_loans;
                _paymethod.is_pending_for_loans = paymethod.is_pending_for_loans;
                _paymethod.is_active_for_savings = paymethod.is_active_for_savings;
                _paymethod.is_pending_for_savings = paymethod.is_pending_for_savings;
                _paymethod.account_id = paymethod.account_id;
                _paymethod.is_deleted = paymethod.is_deleted;

                db.PaymentMethods.AddObject(_paymethod);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdatePaymentMethod(PaymentMethodModel paymethod)
        {
            try
            {
                PaymentMethod _paymethod = db.PaymentMethods.First(b => b.id == paymethod.paymentmethodid);
                _paymethod.name = paymethod.name;
                _paymethod.description = paymethod.description;
                _paymethod.is_active_for_loans = paymethod.is_active_for_loans;
                _paymethod.is_pending_for_loans = paymethod.is_pending_for_loans;
                _paymethod.is_active_for_savings = paymethod.is_active_for_savings;
                _paymethod.is_pending_for_savings = paymethod.is_pending_for_savings;
                _paymethod.account_id = paymethod.account_id;
                _paymethod.is_deleted = paymethod.is_deleted;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeletePaymentMethod(PaymentMethodModel paymethod)
        {
            try
            {
                PaymentMethod _paymethod = db.PaymentMethods.First(b => b.id == paymethod.paymentmethodid);
                _paymethod.is_deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<PaymentMethodModel> GetNonDeletedPaymentMethods()
        {
            try
            {
                List<PaymentMethodModel> _paymethods = new List<PaymentMethodModel>();
                var _paymethodsquery = from br in db.PaymentMethods
                                       where br.is_deleted == false
                                       select br;
                List<PaymentMethod> _pymthds = _paymethodsquery.ToList();
                foreach (var paymethod in _pymthds)
                {
                    PaymentMethodModel _paymethod = new PaymentMethodModel();
                    _paymethod.paymentmethodid = paymethod.id;
                    _paymethod.name = paymethod.name;
                    _paymethod.description = paymethod.description;
                    _paymethod.is_active_for_loans = paymethod.is_active_for_loans;
                    _paymethod.is_pending_for_loans = paymethod.is_pending_for_loans;
                    _paymethod.is_active_for_savings = paymethod.is_active_for_savings;
                    _paymethod.is_pending_for_savings = paymethod.is_pending_for_savings;
                    _paymethod.account_id = paymethod.account_id;
                    _paymethod.is_deleted = paymethod.is_deleted;

                    _paymethods.Add(_paymethod);
                }

                return _paymethods;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<PaymentMethodModel> GetAllPaymentMethods()
        {
            try
            {
                List<PaymentMethodModel> _paymethods = new List<PaymentMethodModel>();
                var _paymethodsquery = from br in db.PaymentMethods
                                       where br.is_deleted == false
                                       select br;
                List<PaymentMethod> _pymthds = _paymethodsquery.ToList();
                foreach (var paymethod in _pymthds)
                {
                    PaymentMethodModel _paymethod = new PaymentMethodModel();
                    _paymethod.paymentmethodid = paymethod.id;
                    _paymethod.name = paymethod.name;
                    _paymethod.description = paymethod.description;
                    _paymethod.is_active_for_loans = paymethod.is_active_for_loans;
                    _paymethod.is_pending_for_loans = paymethod.is_pending_for_loans;
                    _paymethod.is_active_for_savings = paymethod.is_active_for_savings;
                    _paymethod.is_pending_for_savings = paymethod.is_pending_for_savings;
                    _paymethod.account_id = paymethod.account_id;
                    _paymethod.is_deleted = paymethod.is_deleted;

                    _paymethods.Add(_paymethod);
                }

                return _paymethods;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<PaymentMethodModel> GetPaymentMethodsforSavings()
        {
            try
            {
                List<PaymentMethodModel> _paymethods = new List<PaymentMethodModel>();
                var _paymethodsquery = from br in db.PaymentMethods
                                       where br.is_active_for_savings == true
                                       where br.is_deleted == false
                                       select br;
                List<PaymentMethod> _pymthds = _paymethodsquery.ToList();
                foreach (var paymethod in _pymthds)
                {
                    PaymentMethodModel _paymethod = new PaymentMethodModel();
                    _paymethod.name = paymethod.name;
                    _paymethod.description = paymethod.description;
                    _paymethod.is_active_for_loans = paymethod.is_active_for_loans;
                    _paymethod.is_pending_for_loans = paymethod.is_pending_for_loans;
                    _paymethod.is_active_for_savings = paymethod.is_active_for_savings;
                    _paymethod.is_pending_for_savings = paymethod.is_pending_for_savings;
                    _paymethod.account_id = paymethod.account_id;
                    _paymethod.is_deleted = paymethod.is_deleted;

                    _paymethods.Add(_paymethod);
                }

                return _paymethods;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<PaymentMethodModel> GetPaymentMethodsforLoans()
        {
            try
            {
                List<PaymentMethodModel> _paymethods = new List<PaymentMethodModel>();
                var _paymethodsquery = from br in db.PaymentMethods
                                       where br.is_active_for_loans == true
                                       where br.is_deleted == false
                                       select br;
                List<PaymentMethod> _pymthds = _paymethodsquery.ToList();
                foreach (var paymethod in _pymthds)
                {
                    PaymentMethodModel _paymethod = new PaymentMethodModel();
                    _paymethod.name = paymethod.name;
                    _paymethod.description = paymethod.description;
                    _paymethod.is_active_for_loans = paymethod.is_active_for_loans;
                    _paymethod.is_pending_for_loans = paymethod.is_pending_for_loans;
                    _paymethod.is_active_for_savings = paymethod.is_active_for_savings;
                    _paymethod.is_pending_for_savings = paymethod.is_pending_for_savings;
                    _paymethod.account_id = paymethod.account_id;
                    _paymethod.is_deleted = paymethod.is_deleted;

                    _paymethods.Add(_paymethod);
                }

                return _paymethods;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "PaymentMethods"
        #region "Tellers"
        public void AddNewTeller(TellerModel teller)
        {
            try
            {
                Teller _teller = new Teller();
                _teller.name = teller.name;
                _teller.desc = teller.desc;
                _teller.account_id = teller.account_id;
                _teller.deleted = teller.deleted;
                _teller.branch_id = teller.branch_id;
                _teller.currency_id = teller.currency_id;
                _teller.user_id = teller.user_id;
                _teller.amount_min = teller.amount_min;
                _teller.amount_max = teller.amount_max;
                _teller.deposit_amount_min = teller.deposit_amount_min;
                _teller.deposit_amount_max = teller.deposit_amount_max;
                _teller.withdrawal_amount_min = teller.withdrawal_amount_min;
                _teller.withdrawal_amount_max = teller.withdrawal_amount_max;
                _teller.cash_in_min = teller.cash_in_min;
                _teller.cash_in_max = teller.cash_in_max;
                _teller.cash_out_min = teller.cash_out_min;
                _teller.cash_out_max = teller.cash_out_max;
                _teller.balance_min = teller.balance_min;
                _teller.balance_max = teller.balance_max;

                db.Tellers.AddObject(_teller);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateTeller(TellerModel teller)
        {
            try
            {
                Teller _teller = db.Tellers.First(b => b.id == teller.tellerid);
                _teller.name = teller.name;
                _teller.desc = teller.desc;
                _teller.account_id = teller.account_id;
                _teller.deleted = teller.deleted;
                _teller.branch_id = teller.branch_id;
                _teller.currency_id = teller.currency_id;
                _teller.user_id = teller.user_id;
                _teller.amount_min = teller.amount_min;
                _teller.amount_max = teller.amount_max;
                _teller.deposit_amount_min = teller.deposit_amount_min;
                _teller.deposit_amount_max = teller.deposit_amount_max;
                _teller.withdrawal_amount_min = teller.withdrawal_amount_min;
                _teller.withdrawal_amount_max = teller.withdrawal_amount_max;
                _teller.cash_in_min = teller.cash_in_min;
                _teller.cash_in_max = teller.cash_in_max;
                _teller.cash_out_min = teller.cash_out_min;
                _teller.cash_out_max = teller.cash_out_max;
                _teller.balance_min = teller.balance_min;
                _teller.balance_max = teller.balance_max;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteTeller(TellerModel teller)
        {
            try
            {
                Teller _teller = db.Tellers.First(b => b.id == teller.tellerid);
                _teller.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<TellerModel> GetNonDeletedTellers()
        {
            try
            {
                List<TellerModel> _tellers = new List<TellerModel>();
                var _tellersquery = from br in db.Tellers
                                    where br.deleted == false
                                    select br;
                foreach (var teller in _tellersquery)
                {
                    TellerModel _teller = new TellerModel();
                    _teller.tellerid = teller.id;
                    _teller.name = teller.name;
                    _teller.desc = teller.desc;
                    _teller.account_id = teller.account_id;
                    _teller.deleted = teller.deleted;
                    _teller.branch_id = teller.branch_id;
                    _teller.currency_id = teller.currency_id;
                    _teller.user_id = teller.user_id;
                    _teller.amount_min = teller.amount_min;
                    _teller.amount_max = teller.amount_max;
                    _teller.deposit_amount_min = teller.deposit_amount_min;
                    _teller.deposit_amount_max = teller.deposit_amount_max;
                    _teller.withdrawal_amount_min = teller.withdrawal_amount_min;
                    _teller.withdrawal_amount_max = teller.withdrawal_amount_max;
                    _teller.cash_in_min = teller.cash_in_min;
                    _teller.cash_in_max = teller.cash_in_max;
                    _teller.cash_out_min = teller.cash_out_min;
                    _teller.cash_out_max = teller.cash_out_max;
                    _teller.balance_min = teller.balance_min;
                    _teller.balance_max = teller.balance_max;

                    _tellers.Add(_teller);
                }

                return _tellers;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<TellerModel> GetAllTellers()
        {
            try
            {
                List<TellerModel> _tellers = new List<TellerModel>();
                var _tellersquery = from br in db.Tellers
                                    select br;
                foreach (var teller in _tellersquery)
                {
                    TellerModel _teller = new TellerModel();
                    _teller.tellerid = teller.id;
                    _teller.name = teller.name;
                    _teller.desc = teller.desc;
                    _teller.account_id = teller.account_id;
                    _teller.deleted = teller.deleted;
                    _teller.branch_id = teller.branch_id;
                    _teller.currency_id = teller.currency_id;
                    _teller.user_id = teller.user_id;
                    _teller.amount_min = teller.amount_min;
                    _teller.amount_max = teller.amount_max;
                    _teller.deposit_amount_min = teller.deposit_amount_min;
                    _teller.deposit_amount_max = teller.deposit_amount_max;
                    _teller.withdrawal_amount_min = teller.withdrawal_amount_min;
                    _teller.withdrawal_amount_max = teller.withdrawal_amount_max;
                    _teller.cash_in_min = teller.cash_in_min;
                    _teller.cash_in_max = teller.cash_in_max;
                    _teller.cash_out_min = teller.cash_out_min;
                    _teller.cash_out_max = teller.cash_out_max;
                    _teller.balance_min = teller.balance_min;
                    _teller.balance_max = teller.balance_max;

                    _tellers.Add(_teller);
                }

                return _tellers;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Tellers"
        #region "FiscalYears"
        public void AddNewFiscalYear(FiscalYearModel fiscalyear)
        {
            try
            {
                FiscalYear _fiscalyear = new FiscalYear();
                _fiscalyear.name = fiscalyear.name;
                _fiscalyear.open_date = fiscalyear.open_date;
                _fiscalyear.close_date = fiscalyear.close_date;

                db.FiscalYears.AddObject(_fiscalyear);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateFiscalYear(FiscalYearModel fiscalyear)
        {
            try
            {
                FiscalYear _fiscalyear = db.FiscalYears.First(b => b.id == fiscalyear.fiscalyearid);
                _fiscalyear.name = fiscalyear.name;
                _fiscalyear.open_date = fiscalyear.open_date;
                _fiscalyear.close_date = fiscalyear.close_date;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteFiscalYear(FiscalYearModel fiscalyear)
        {
            try
            {
                FiscalYear _fiscalyear = db.FiscalYears.First(b => b.id == fiscalyear.fiscalyearid);

                db.FiscalYears.DeleteObject(_fiscalyear);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void OpenFiscalYear(FiscalYearModel fiscalyear)
        {
            try
            {
                FiscalYear _fiscalyear = db.FiscalYears.First(b => b.id == fiscalyear.fiscalyearid);
                _fiscalyear.open_date = fiscalyear.open_date;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void CloseFiscalYear(FiscalYearModel fiscalyear)
        {
            try
            {
                FiscalYear _fiscalyear = db.FiscalYears.First(b => b.id == fiscalyear.fiscalyearid);
                _fiscalyear.close_date = fiscalyear.close_date;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<FiscalYearModel> GetNonClosedFiscalYears()
        {
            try
            {
                List<FiscalYearModel> _fiscalyears = new List<FiscalYearModel>();
                var _fiscalyearsquery = from br in db.FiscalYears
                                        where br.close_date == null
                                        select br;
                foreach (var fiscalyear in _fiscalyearsquery)
                {
                    FiscalYearModel _fiscalyear = new FiscalYearModel();
                    _fiscalyear.fiscalyearid = fiscalyear.id;
                    _fiscalyear.name = fiscalyear.name;
                    _fiscalyear.open_date = fiscalyear.open_date;
                    _fiscalyear.close_date = fiscalyear.close_date;

                    _fiscalyears.Add(_fiscalyear);
                }

                return _fiscalyears;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<FiscalYearModel> GetAllFiscalYears()
        {
            try
            {
                List<FiscalYearModel> _fiscalyears = new List<FiscalYearModel>();
                var _fiscalyearsquery = from br in db.FiscalYears
                                        select br;
                foreach (var fiscalyear in _fiscalyearsquery)
                {
                    FiscalYearModel _fiscalyear = new FiscalYearModel();
                    _fiscalyear.fiscalyearid = fiscalyear.id;
                    _fiscalyear.name = fiscalyear.name;
                    _fiscalyear.open_date = fiscalyear.open_date;
                    _fiscalyear.close_date = fiscalyear.close_date;

                    _fiscalyears.Add(_fiscalyear);
                }

                return _fiscalyears;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "FiscalYears"
        #region "AdvancedFields"
        public void AddNewAdvancedField(AdvancedFieldsModel advancedfield)
        {
            try
            {
                switch (advancedfield.type_id)
                {
                    case 5:
                        AdvancedField _advncdfield = new AdvancedField();
                        _advncdfield.entity_id = advancedfield.entity_id;
                        _advncdfield.type_id = advancedfield.type_id;
                        _advncdfield.name = advancedfield.name;
                        _advncdfield.desc = "";
                        _advncdfield.is_mandatory = advancedfield.is_mandatory;
                        _advncdfield.is_unique = advancedfield.is_unique;

                        if (!db.AdvancedFields.Any(i => i.entity_id == _advncdfield.entity_id && i.type_id == _advncdfield.type_id && i.name == _advncdfield.name))
                        {
                            db.AdvancedFields.AddObject(_advncdfield);
                            db.SaveChanges();
                        }

                        var _AdvancedFieldsquery = (from s in db.AdvancedFields
                                                    where s.entity_id == advancedfield.entity_id
                                                    where s.name == advancedfield.name
                                                    where s.type_id == advancedfield.type_id
                                                    select s).FirstOrDefault();
                        AdvancedField _AdvancedField = _AdvancedFieldsquery;

                        if (_AdvancedField != null)
                        {

                            char[] delimiters = new char[] { ' ', ';', ',', '\n', '\r' };
                            string[] collections = advancedfield.desc.Split(delimiters);

                            foreach (string collection in collections)
                            {
                                if (!string.IsNullOrEmpty(collection) && !string.IsNullOrWhiteSpace(collection))
                                {
                                    AdvancedFieldsCollectionsModel afcm = new AdvancedFieldsCollectionsModel();
                                    afcm.value = collection;
                                    afcm.field_id = _AdvancedField.id;

                                    this.AddNewAdvancedFieldsCollection(afcm);
                                }
                            }
                        }
                        break;
                    default:
                        AdvancedField _advancedfield = new AdvancedField();
                        _advancedfield.entity_id = advancedfield.entity_id;
                        _advancedfield.type_id = advancedfield.type_id;
                        _advancedfield.name = advancedfield.name;
                        _advancedfield.desc = advancedfield.desc;
                        _advancedfield.is_mandatory = advancedfield.is_mandatory;
                        _advancedfield.is_unique = advancedfield.is_unique;

                        if (!db.AdvancedFields.Any(i => i.entity_id == _advancedfield.entity_id && i.type_id == _advancedfield.type_id && i.name == _advancedfield.name))
                        {
                            db.AdvancedFields.AddObject(_advancedfield);
                            db.SaveChanges();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAdvancedField(AdvancedFieldsModel advancedfield)
        {
            try
            {
                AdvancedField _advancedfield = db.AdvancedFields.First(b => b.id == advancedfield.advfieldsid);
                _advancedfield.entity_id = advancedfield.entity_id;
                _advancedfield.type_id = advancedfield.type_id;
                _advancedfield.name = advancedfield.name;
                _advancedfield.desc = advancedfield.desc;
                _advancedfield.is_mandatory = advancedfield.is_mandatory;
                _advancedfield.is_unique = advancedfield.is_unique;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAdvancedField(AdvancedFieldsModel advancedfield)
        {
            try
            {
                AdvancedField _advancedfield = db.AdvancedFields.First(b => b.id == advancedfield.advfieldsid);
                switch (advancedfield.type_id)
                {
                    case 5:
                        var _AdvancedFieldsquery = from s in db.AdvancedFieldsCollections
                                                   where s.field_id == advancedfield.advfieldsid
                                                   select new AdvancedFieldsCollectionsModel
                                                   {
                                                       advfieldscollectionid = s.id,
                                                       value = s.value,
                                                       field_id = s.field_id
                                                   };
                        List<AdvancedFieldsCollectionsModel> _AdvancedFields = _AdvancedFieldsquery.ToList();
                        foreach (var advncdfld in _AdvancedFields)
                        {
                            this.DeleteAdvancedFieldsCollection(advncdfld);
                        }

                        db.AdvancedFields.DeleteObject(_advancedfield);
                        db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                        break;
                    default:
                        db.AdvancedFields.DeleteObject(_advancedfield);
                        db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AdvancedFieldsModel> GetAllAdvancedFields()
        {
            try
            {
                List<AdvancedFieldsModel> _advancedfields = new List<AdvancedFieldsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFields
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsModel _advancedfield = new AdvancedFieldsModel();
                    _advancedfield.advfieldsid = advancedfield.id;
                    _advancedfield.entity_id = advancedfield.entity_id;
                    _advancedfield.type_id = advancedfield.type_id;
                    _advancedfield.name = advancedfield.name;
                    _advancedfield.desc = advancedfield.desc;
                    _advancedfield.is_mandatory = advancedfield.is_mandatory;
                    _advancedfield.is_unique = advancedfield.is_unique;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CustomizableFieldsModel> GetCustomizableFields()
        {
            try
            {
                List<CustomizableFieldsModel> _customizablefields = new List<CustomizableFieldsModel>();
                var _customizablefieldsquery = (from afe in db.AdvancedFieldsEntities
                                                join af in db.AdvancedFields on afe.id equals af.entity_id
                                                select afe).Distinct();
                List<AdvancedFieldsEntity> _advancedfieldenties = _customizablefieldsquery.ToList();
                foreach (var customizablefield in _advancedfieldenties)
                {
                    CustomizableFieldsModel _customizablefield = new CustomizableFieldsModel();
                    _customizablefield.advfieldsid = customizablefield.id;
                    _customizablefield.entity_id = customizablefield.id;
                    _customizablefield.fieldscount = this.GetAdvancedFieldsCountForEntity(customizablefield.id);
                    _customizablefield.fieldnameslist = this.GetAdvancedFieldnamesForEntity(customizablefield.id);

                    _customizablefields.Add(_customizablefield);
                }

                return _customizablefields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AdvancedFieldsModel> GetAdvancedFields(int entityid)
        {
            try
            {
                List<AdvancedFieldsModel> _advancedfields = new List<AdvancedFieldsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFields
                                           where br.entity_id == entityid
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsModel _advancedfield = new AdvancedFieldsModel();
                    _advancedfield.advfieldsid = advancedfield.id;
                    _advancedfield.entity_id = advancedfield.entity_id;
                    _advancedfield.type_id = advancedfield.type_id;
                    _advancedfield.name = advancedfield.name;
                    _advancedfield.desc = advancedfield.desc;
                    _advancedfield.is_mandatory = advancedfield.is_mandatory;
                    _advancedfield.is_unique = advancedfield.is_unique;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AdvancedFieldsValuesModel> GetAdvancedFieldValues(int field_id)
        {
            try
            {
                List<AdvancedFieldsValuesModel> _advancedfields = new List<AdvancedFieldsValuesModel>();
                var _advancedfieldsquery = from br in db.AdvancedFieldsValues
                                           where br.field_id == field_id
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsValuesModel _advancedfield = new AdvancedFieldsValuesModel();
                    _advancedfield.advfieldsvaluesid = advancedfield.id;
                    _advancedfield.entity_field_id = advancedfield.entity_field_id;
                    _advancedfield.field_id = advancedfield.field_id;
                    _advancedfield.value = advancedfield.value;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public int GetAdvancedFieldsCountForEntity(int entityid)
        {
            try
            {
                List<AdvancedFieldsModel> _advancedfields = new List<AdvancedFieldsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFields
                                           where br.entity_id == entityid
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsModel _advancedfield = new AdvancedFieldsModel();
                    _advancedfield.advfieldsid = advancedfield.id;
                    _advancedfield.entity_id = advancedfield.entity_id;
                    _advancedfield.type_id = advancedfield.type_id;
                    _advancedfield.name = advancedfield.name;
                    _advancedfield.desc = advancedfield.desc;
                    _advancedfield.is_mandatory = advancedfield.is_mandatory;
                    _advancedfield.is_unique = advancedfield.is_unique;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields.Count;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 0;
            }
        }
        public string GetAdvancedFieldnamesForEntity(int entityid)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                var _advancedfieldsquery = (from br in db.AdvancedFields
                                            where br.entity_id == entityid
                                            select br).ToList();
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    sb.Append(advancedfield.name + ", ");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AdvancedFieldsModel> GetAdvancedFieldsWithCollectionItems(int entityid)
        {
            try
            {
                List<AdvancedFieldsModel> _advancedfields = new List<AdvancedFieldsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFields
                                           where br.entity_id == entityid
                                           select br;
                List<AdvancedField> _advncdflds = _advancedfieldsquery.ToList();
                foreach (var advancedfield in _advncdflds)
                {
                    switch (advancedfield.type_id)
                    {
                        case 5:
                            AdvancedFieldsModel _advncdfield = new AdvancedFieldsModel();
                            _advncdfield.advfieldsid = advancedfield.id;
                            _advncdfield.entity_id = advancedfield.entity_id;
                            _advncdfield.type_id = advancedfield.type_id;
                            _advncdfield.name = advancedfield.name;
                            _advncdfield.desc = this.GetFieldCollectionItems(advancedfield.id);
                            _advncdfield.is_mandatory = advancedfield.is_mandatory;
                            _advncdfield.is_unique = advancedfield.is_unique;

                            _advancedfields.Add(_advncdfield);
                            break;
                        default:
                            AdvancedFieldsModel _advancedfield = new AdvancedFieldsModel();
                            _advancedfield.advfieldsid = advancedfield.id;
                            _advancedfield.entity_id = advancedfield.entity_id;
                            _advancedfield.type_id = advancedfield.type_id;
                            _advancedfield.name = advancedfield.name;
                            _advancedfield.desc = advancedfield.desc;
                            _advancedfield.is_mandatory = advancedfield.is_mandatory;
                            _advancedfield.is_unique = advancedfield.is_unique;

                            _advancedfields.Add(_advancedfield);
                            break;
                    }
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClientCustomizableFieldsModel> GetClientCustomizableFields(int entityid, int linkid)
        {
            try
            {
                List<ClientCustomizableFieldsModel> _advancedfields = new List<ClientCustomizableFieldsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFields
                                           join afv in db.AdvancedFieldsValues on br.id equals afv.field_id
                                           join afle in db.AdvancedFieldsLinkEntities on afv.entity_field_id equals afle.id
                                           where br.entity_id == entityid
                                           where afle.link_id == linkid
                                           select new ClientCustomizableFieldsModel
                                           {
                                               advfieldsid = br.id,
                                               entity_id = br.entity_id,
                                               type_id = br.type_id,
                                               name = br.name,
                                               desc = br.desc,
                                               is_mandatory = br.is_mandatory,
                                               is_unique = br.is_unique,
                                               entity_field_id = afv.entity_field_id,
                                               field_id = afv.field_id,
                                               value = afv.value
                                           };
                List<ClientCustomizableFieldsModel> _advncdflds = _advancedfieldsquery.ToList();
                foreach (var advancedfield in _advncdflds)
                {
                    switch (advancedfield.type_id)
                    {
                        case 5:
                            ClientCustomizableFieldsModel _advncdfield = new ClientCustomizableFieldsModel();
                            _advncdfield.advfieldsid = advancedfield.advfieldsid;
                            _advncdfield.entity_id = advancedfield.entity_id;
                            _advncdfield.type_id = advancedfield.type_id;
                            _advncdfield.name = advancedfield.name;
                            _advncdfield.desc = this.GetFieldCollectionItems(advancedfield.advfieldsid);
                            _advncdfield.is_mandatory = advancedfield.is_mandatory;
                            _advncdfield.is_unique = advancedfield.is_unique;
                            _advncdfield.entity_field_id = advancedfield.entity_field_id;
                            _advncdfield.field_id = advancedfield.field_id;
                            _advncdfield.value = advancedfield.value;

                            _advancedfields.Add(_advncdfield);
                            break;
                        default:
                            ClientCustomizableFieldsModel _advancedfield = new ClientCustomizableFieldsModel();
                            _advancedfield.advfieldsid = advancedfield.advfieldsid;
                            _advancedfield.entity_id = advancedfield.entity_id;
                            _advancedfield.type_id = advancedfield.type_id;
                            _advancedfield.name = advancedfield.name;
                            _advancedfield.desc = advancedfield.desc;
                            _advancedfield.is_mandatory = advancedfield.is_mandatory;
                            _advancedfield.is_unique = advancedfield.is_unique;

                            _advancedfields.Add(_advancedfield);
                            break;
                    }
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClientCustomizableFieldsModel> GetLoanContractCustomizableFields(int entityid, int linkid)
        {
            try
            {
                List<ClientCustomizableFieldsModel> _advancedfields = new List<ClientCustomizableFieldsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFields
                                           join afv in db.AdvancedFieldsValues on br.id equals afv.field_id
                                           join afle in db.AdvancedFieldsLinkEntities on afv.entity_field_id equals afle.id
                                           where br.entity_id == entityid
                                           where afle.link_id == linkid
                                           select new ClientCustomizableFieldsModel
                                           {
                                               advfieldsid = br.id,
                                               entity_id = br.entity_id,
                                               type_id = br.type_id,
                                               name = br.name,
                                               desc = br.desc,
                                               is_mandatory = br.is_mandatory,
                                               is_unique = br.is_unique,
                                               entity_field_id = afv.entity_field_id,
                                               field_id = afv.field_id,
                                               value = afv.value
                                           };
                List<ClientCustomizableFieldsModel> _advncdflds = _advancedfieldsquery.ToList();
                foreach (var advancedfield in _advncdflds)
                {
                    switch (advancedfield.type_id)
                    {
                        case 5:
                            ClientCustomizableFieldsModel _advncdfield = new ClientCustomizableFieldsModel();
                            _advncdfield.advfieldsid = advancedfield.advfieldsid;
                            _advncdfield.entity_id = advancedfield.entity_id;
                            _advncdfield.type_id = advancedfield.type_id;
                            _advncdfield.name = advancedfield.name;
                            _advncdfield.desc = this.GetFieldCollectionItems(advancedfield.advfieldsid);
                            _advncdfield.is_mandatory = advancedfield.is_mandatory;
                            _advncdfield.is_unique = advancedfield.is_unique;
                            _advncdfield.entity_field_id = advancedfield.entity_field_id;
                            _advncdfield.field_id = advancedfield.field_id;
                            _advncdfield.value = advancedfield.value;

                            _advancedfields.Add(_advncdfield);
                            break;
                        default:
                            ClientCustomizableFieldsModel _advancedfield = new ClientCustomizableFieldsModel();
                            _advancedfield.advfieldsid = advancedfield.advfieldsid;
                            _advancedfield.entity_id = advancedfield.entity_id;
                            _advancedfield.type_id = advancedfield.type_id;
                            _advancedfield.name = advancedfield.name;
                            _advancedfield.desc = advancedfield.desc;
                            _advancedfield.is_mandatory = advancedfield.is_mandatory;
                            _advancedfield.is_unique = advancedfield.is_unique;

                            _advancedfields.Add(_advancedfield);
                            break;
                    }
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClientCustomizableFieldsModel> GetLoanContractCustomizableFields(int entityid)
        {
            try
            {
                List<ClientCustomizableFieldsModel> _advancedfields = new List<ClientCustomizableFieldsModel>();
                var _advancedfieldsquery = from af in db.AdvancedFields
                                           where af.entity_id == entityid
                                           select new ClientCustomizableFieldsModel
                                           {
                                               advfieldsid = af.id,
                                               entity_id = af.entity_id,
                                               type_id = af.type_id,
                                               name = af.name,
                                               desc = af.desc,
                                               is_mandatory = af.is_mandatory,
                                               is_unique = af.is_unique,
                                               field_id = af.id,
                                               entity_field_id = af.entity_id
                                           };
                List<ClientCustomizableFieldsModel> _advncdflds = _advancedfieldsquery.ToList();
                foreach (var advancedfield in _advncdflds)
                {
                    switch (advancedfield.type_id)
                    {
                        case 5:
                            ClientCustomizableFieldsModel _advncdfield = new ClientCustomizableFieldsModel();
                            _advncdfield.advfieldsid = advancedfield.advfieldsid;
                            _advncdfield.entity_id = advancedfield.entity_id;
                            _advncdfield.type_id = advancedfield.type_id;
                            _advncdfield.name = advancedfield.name;
                            _advncdfield.desc = this.GetFieldCollectionItems(advancedfield.advfieldsid);
                            _advncdfield.is_mandatory = advancedfield.is_mandatory;
                            _advncdfield.is_unique = advancedfield.is_unique;
                            _advncdfield.entity_field_id = advancedfield.entity_field_id;
                            _advncdfield.field_id = advancedfield.field_id;
                            _advncdfield.value = advancedfield.value;

                            _advancedfields.Add(_advncdfield);
                            break;
                        default:
                            ClientCustomizableFieldsModel _advancedfield = new ClientCustomizableFieldsModel();
                            _advancedfield.advfieldsid = advancedfield.advfieldsid;
                            _advancedfield.entity_id = advancedfield.entity_id;
                            _advancedfield.type_id = advancedfield.type_id;
                            _advancedfield.name = advancedfield.name;
                            _advancedfield.desc = advancedfield.desc;
                            _advancedfield.is_mandatory = advancedfield.is_mandatory;
                            _advancedfield.is_unique = advancedfield.is_unique;

                            _advancedfields.Add(_advancedfield);
                            break;
                    }
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClientCustomizableFieldsModel> GetSavingContractCustomizableFields(int entityid, int linkid)
        {
            try
            {
                List<ClientCustomizableFieldsModel> _advancedfields = new List<ClientCustomizableFieldsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFields
                                           join afv in db.AdvancedFieldsValues on br.id equals afv.field_id
                                           join afle in db.AdvancedFieldsLinkEntities on afv.entity_field_id equals afle.id
                                           where br.entity_id == entityid
                                           where afle.link_id == linkid
                                           select new ClientCustomizableFieldsModel
                                           {
                                               advfieldsid = br.id,
                                               entity_id = br.entity_id,
                                               type_id = br.type_id,
                                               name = br.name,
                                               desc = br.desc,
                                               is_mandatory = br.is_mandatory,
                                               is_unique = br.is_unique,
                                               entity_field_id = afv.entity_field_id,
                                               field_id = afv.field_id,
                                               value = afv.value
                                           };
                List<ClientCustomizableFieldsModel> _advncdflds = _advancedfieldsquery.ToList();
                foreach (var advancedfield in _advncdflds)
                {
                    switch (advancedfield.type_id)
                    {
                        case 5:
                            ClientCustomizableFieldsModel _advncdfield = new ClientCustomizableFieldsModel();
                            _advncdfield.advfieldsid = advancedfield.advfieldsid;
                            _advncdfield.entity_id = advancedfield.entity_id;
                            _advncdfield.type_id = advancedfield.type_id;
                            _advncdfield.name = advancedfield.name;
                            _advncdfield.desc = this.GetFieldCollectionItems(advancedfield.advfieldsid);
                            _advncdfield.is_mandatory = advancedfield.is_mandatory;
                            _advncdfield.is_unique = advancedfield.is_unique;
                            _advncdfield.entity_field_id = advancedfield.entity_field_id;
                            _advncdfield.field_id = advancedfield.field_id;
                            _advncdfield.value = advancedfield.value;

                            _advancedfields.Add(_advncdfield);
                            break;
                        default:
                            ClientCustomizableFieldsModel _advancedfield = new ClientCustomizableFieldsModel();
                            _advancedfield.advfieldsid = advancedfield.advfieldsid;
                            _advancedfield.entity_id = advancedfield.entity_id;
                            _advancedfield.type_id = advancedfield.type_id;
                            _advancedfield.name = advancedfield.name;
                            _advancedfield.desc = advancedfield.desc;
                            _advancedfield.is_mandatory = advancedfield.is_mandatory;
                            _advancedfield.is_unique = advancedfield.is_unique;

                            _advancedfields.Add(_advancedfield);
                            break;
                    }
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClientCustomizableFieldsModel> GetSavingContractCustomizableFields(int entityid)
        {
            try
            {
                List<ClientCustomizableFieldsModel> _advancedfields = new List<ClientCustomizableFieldsModel>();
                var _advancedfieldsquery = from af in db.AdvancedFields
                                           where af.entity_id == entityid
                                           select new ClientCustomizableFieldsModel
                                           {
                                               advfieldsid = af.id,
                                               entity_id = af.entity_id,
                                               type_id = af.type_id,
                                               name = af.name,
                                               desc = af.desc,
                                               is_mandatory = af.is_mandatory,
                                               is_unique = af.is_unique,
                                               field_id = af.id,
                                               entity_field_id = af.entity_id
                                           };
                List<ClientCustomizableFieldsModel> _advncdflds = _advancedfieldsquery.ToList();
                foreach (var advancedfield in _advncdflds)
                {
                    switch (advancedfield.type_id)
                    {
                        case 5:
                            ClientCustomizableFieldsModel _advncdfield = new ClientCustomizableFieldsModel();
                            _advncdfield.advfieldsid = advancedfield.advfieldsid;
                            _advncdfield.entity_id = advancedfield.entity_id;
                            _advncdfield.type_id = advancedfield.type_id;
                            _advncdfield.name = advancedfield.name;
                            _advncdfield.desc = this.GetFieldCollectionItems(advancedfield.advfieldsid);
                            _advncdfield.is_mandatory = advancedfield.is_mandatory;
                            _advncdfield.is_unique = advancedfield.is_unique;
                            _advncdfield.entity_field_id = advancedfield.entity_field_id;
                            _advncdfield.field_id = advancedfield.field_id;
                            _advncdfield.value = advancedfield.value;

                            _advancedfields.Add(_advncdfield);
                            break;
                        default:
                            ClientCustomizableFieldsModel _advancedfield = new ClientCustomizableFieldsModel();
                            _advancedfield.advfieldsid = advancedfield.advfieldsid;
                            _advancedfield.entity_id = advancedfield.entity_id;
                            _advancedfield.type_id = advancedfield.type_id;
                            _advancedfield.name = advancedfield.name;
                            _advancedfield.desc = advancedfield.desc;
                            _advancedfield.is_mandatory = advancedfield.is_mandatory;
                            _advancedfield.is_unique = advancedfield.is_unique;

                            _advancedfields.Add(_advancedfield);
                            break;
                    }
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AdvancedFields"
        #region "AdvancedFieldsCollections"
        public void AddNewAdvancedFieldsCollection(AdvancedFieldsCollectionsModel advancedfield)
        {
            try
            {
                AdvancedFieldsCollection _advancedfield = new AdvancedFieldsCollection();
                _advancedfield.field_id = advancedfield.field_id;
                _advancedfield.value = advancedfield.value;

                if (!db.AdvancedFieldsCollections.Any(i => i.field_id == _advancedfield.field_id && i.value == _advancedfield.value))
                {
                    db.AdvancedFieldsCollections.AddObject(_advancedfield);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAdvancedFieldsCollection(AdvancedFieldsCollectionsModel advancedfield)
        {
            try
            {
                AdvancedFieldsCollection _advancedfield = db.AdvancedFieldsCollections.First(b => b.id == advancedfield.advfieldscollectionid);
                _advancedfield.field_id = advancedfield.field_id;
                _advancedfield.value = advancedfield.value;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAdvancedFieldsCollection(AdvancedFieldsCollectionsModel advancedfield)
        {
            try
            {
                AdvancedFieldsCollection _advancedfield = db.AdvancedFieldsCollections.First(b => b.id == advancedfield.advfieldscollectionid);

                db.AdvancedFieldsCollections.DeleteObject(_advancedfield);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AdvancedFieldsCollectionsModel> GetAllAdvancedFieldsCollections()
        {
            try
            {
                List<AdvancedFieldsCollectionsModel> _advancedfields = new List<AdvancedFieldsCollectionsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFieldsCollections
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsCollectionsModel _advancedfield = new AdvancedFieldsCollectionsModel();
                    _advancedfield.advfieldscollectionid = advancedfield.id;
                    _advancedfield.field_id = advancedfield.field_id;
                    _advancedfield.value = advancedfield.value;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AdvancedFieldsCollectionsModel> GetAdvancedFieldsCollectionsforField(int fieldid)
        {
            try
            {
                List<AdvancedFieldsCollectionsModel> _advancedfields = new List<AdvancedFieldsCollectionsModel>();
                var _advancedfieldsquery = from br in db.AdvancedFieldsCollections
                                           where br.field_id == fieldid
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsCollectionsModel _advancedfield = new AdvancedFieldsCollectionsModel();
                    _advancedfield.advfieldscollectionid = advancedfield.id;
                    _advancedfield.field_id = advancedfield.field_id;
                    _advancedfield.value = advancedfield.value;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public string GetFieldCollectionItems(int fieldid)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                var _advancedfieldsquery = from br in db.AdvancedFieldsCollections
                                           where br.field_id == fieldid
                                           select br;
                List<AdvancedFieldsCollection> _cols = _advancedfieldsquery.ToList();
                foreach (var advancedfield in _cols)
                {
                    sb.Append(advancedfield.value + ", ");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AdvancedFieldsCollections"
        #region "AdvancedFieldsEntities"
        public void AddNewAdvancedFieldsEntity(AdvancedFieldsEntitiesModel advancedfield)
        {
            try
            {
                AdvancedFieldsEntity _advancedfield = new AdvancedFieldsEntity();
                _advancedfield.name = advancedfield.name;

                db.AdvancedFieldsEntities.AddObject(_advancedfield);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAdvancedFieldsEntity(AdvancedFieldsEntitiesModel advancedfield)
        {
            try
            {
                AdvancedFieldsEntity _advancedfield = db.AdvancedFieldsEntities.First(b => b.id == advancedfield.advfieldsentitiesid);
                _advancedfield.name = advancedfield.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAdvancedFieldsEntity(AdvancedFieldsEntitiesModel advancedfield)
        {
            try
            {
                AdvancedFieldsEntity _advancedfield = db.AdvancedFieldsEntities.First(b => b.id == advancedfield.advfieldsentitiesid);

                var _advancedfieldsquery = from br in db.AdvancedFields
                                           where br.entity_id == _advancedfield.id
                                           select new AdvancedFieldsModel
                                           {
                                               advfieldsid = br.id,
                                               desc = br.desc,
                                               entity_id = br.entity_id,
                                               is_mandatory = br.is_mandatory,
                                               is_unique = br.is_unique,
                                               name = br.name,
                                               type_id = br.type_id
                                           };
                List<AdvancedFieldsModel> _advncdflds = _advancedfieldsquery.ToList();
                foreach (var advncdfld in _advncdflds)
                {
                    var _advncdfieldscolquery = from br in db.AdvancedFieldsCollections
                                                where br.field_id == advncdfld.advfieldsid
                                                select new AdvancedFieldsCollectionsModel
                                                {
                                                    advfieldscollectionid = br.id,
                                                    field_id = br.field_id,
                                                    value = br.value
                                                };
                    List<AdvancedFieldsCollectionsModel> _cols = _advncdfieldscolquery.ToList();
                    foreach (var col in _cols)
                    {
                        this.DeleteAdvancedFieldsCollection(col);
                    }
                    this.DeleteAdvancedField(advncdfld);
                }

                //db.AdvancedFieldsEntities.DeleteObject(_advancedfield);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AdvancedFieldsEntitiesModel> GetAllAdvancedFieldsEntities()
        {
            try
            {
                List<AdvancedFieldsEntitiesModel> _advancedfields = new List<AdvancedFieldsEntitiesModel>();
                var _advancedfieldsquery = from br in db.AdvancedFieldsEntities
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsEntitiesModel _advancedfield = new AdvancedFieldsEntitiesModel();
                    _advancedfield.advfieldsentitiesid = advancedfield.id;
                    _advancedfield.name = advancedfield.name;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public AdvancedFieldsEntitiesModel GetAdvancedFieldEntity(int entityid)
        {
            try
            {
                AdvancedFieldsEntitiesModel _advancedfieldentity = new AdvancedFieldsEntitiesModel();
                var _advancedfieldentityquery = (from br in db.AdvancedFieldsEntities
                                                 where br.id == entityid
                                                 select new AdvancedFieldsEntitiesModel
                                                 {
                                                     advfieldsentitiesid = br.id,
                                                     name = br.name
                                                 }).FirstOrDefault();
                _advancedfieldentity = _advancedfieldentityquery;

                return _advancedfieldentity;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AdvancedFieldsEntities"
        #region "AdvancedFieldsLinkEntities"
        public void AddNewAdvancedFieldsLinkEntity(AdvancedFieldsLinkEntitiesModel advancedfield)
        {
            try
            {
                AdvancedFieldsLinkEntity _advancedfield = new AdvancedFieldsLinkEntity();
                _advancedfield.link_type = advancedfield.link_type;
                _advancedfield.link_id = advancedfield.link_id;

                db.AdvancedFieldsLinkEntities.AddObject(_advancedfield);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAdvancedFieldsLinkEntity(AdvancedFieldsLinkEntitiesModel advancedfield)
        {
            try
            {
                AdvancedFieldsLinkEntity _advancedfield = db.AdvancedFieldsLinkEntities.First(b => b.id == advancedfield.advfieldslinkentitiesid);
                _advancedfield.link_type = advancedfield.link_type;
                _advancedfield.link_id = advancedfield.link_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAdvancedFieldsLinkEntity(AdvancedFieldsLinkEntitiesModel advancedfield)
        {
            try
            {
                AdvancedFieldsLinkEntity _advancedfield = db.AdvancedFieldsLinkEntities.First(b => b.id == advancedfield.advfieldslinkentitiesid);

                db.AdvancedFieldsLinkEntities.DeleteObject(_advancedfield);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AdvancedFieldsLinkEntitiesModel> GetAllAdvancedFieldsLinkEntities()
        {
            try
            {
                List<AdvancedFieldsLinkEntitiesModel> _advancedfields = new List<AdvancedFieldsLinkEntitiesModel>();
                var _advancedfieldsquery = from br in db.AdvancedFieldsLinkEntities
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsLinkEntitiesModel _advancedfield = new AdvancedFieldsLinkEntitiesModel();
                    _advancedfield.advfieldslinkentitiesid = advancedfield.id;
                    _advancedfield.link_type = advancedfield.link_type;
                    _advancedfield.link_id = advancedfield.link_id;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AdvancedFieldsLinkEntities"
        #region "AdvancedFieldsTypes"
        public void AddNewAdvancedFieldsType(AdvancedFieldsTypesModel advancedfield)
        {
            try
            {
                AdvancedFieldsType _advancedfield = new AdvancedFieldsType();
                _advancedfield.name = advancedfield.name;

                db.AdvancedFieldsTypes.AddObject(_advancedfield);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAdvancedFieldsType(AdvancedFieldsTypesModel advancedfield)
        {
            try
            {
                AdvancedFieldsType _advancedfield = db.AdvancedFieldsTypes.First(b => b.id == advancedfield.advfieldstypesid);
                _advancedfield.name = advancedfield.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAdvancedFieldsType(AdvancedFieldsTypesModel advancedfield)
        {
            try
            {
                AdvancedFieldsType _advancedfield = db.AdvancedFieldsTypes.First(b => b.id == advancedfield.advfieldstypesid);

                db.AdvancedFieldsTypes.DeleteObject(_advancedfield);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AdvancedFieldsTypesModel> GetAllAdvancedFieldsTypes()
        {
            try
            {
                List<AdvancedFieldsTypesModel> _advancedfields = new List<AdvancedFieldsTypesModel>();
                var _advancedfieldsquery = from br in db.AdvancedFieldsTypes
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsTypesModel _advancedfield = new AdvancedFieldsTypesModel();
                    _advancedfield.advfieldstypesid = advancedfield.id;
                    _advancedfield.name = advancedfield.name;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public string GetAdvancedFieldTypeName(int advancedfieldtypeid)
        {
            try
            {
                AdvancedFieldsType _advancedfieldtypequery = (from aft in db.AdvancedFieldsTypes
                                                              where aft.id == advancedfieldtypeid
                                                              select aft).FirstOrDefault();

                return _advancedfieldtypequery.name;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AdvancedFieldsTypes"
        #region "AdvancedFieldsValues"
        public void AddNewAdvancedFieldsValue(AdvancedFieldsValuesModel advancedfield)
        {
            try
            {
                AdvancedFieldsValue _advancedfield = new AdvancedFieldsValue();
                _advancedfield.entity_field_id = advancedfield.entity_field_id;
                _advancedfield.field_id = advancedfield.field_id;
                _advancedfield.value = advancedfield.value;

                db.AdvancedFieldsValues.AddObject(_advancedfield);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAdvancedFieldsValue(AdvancedFieldsValuesModel advancedfield)
        {
            try
            {
                AdvancedFieldsValue _advancedfield = db.AdvancedFieldsValues.First(b => b.id == advancedfield.advfieldsvaluesid);
                _advancedfield.entity_field_id = advancedfield.entity_field_id;
                _advancedfield.field_id = advancedfield.field_id;
                _advancedfield.value = advancedfield.value;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAdvancedFieldsValue(AdvancedFieldsValuesModel advancedfield)
        {
            try
            {
                AdvancedFieldsValue _advancedfield = db.AdvancedFieldsValues.First(b => b.id == advancedfield.advfieldsvaluesid);

                db.AdvancedFieldsValues.DeleteObject(_advancedfield);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AdvancedFieldsValuesModel> GetAllAdvancedFieldsValues()
        {
            try
            {
                List<AdvancedFieldsValuesModel> _advancedfields = new List<AdvancedFieldsValuesModel>();
                var _advancedfieldsquery = from br in db.AdvancedFieldsValues
                                           select br;
                foreach (var advancedfield in _advancedfieldsquery)
                {
                    AdvancedFieldsValuesModel _advancedfield = new AdvancedFieldsValuesModel();
                    _advancedfield.entity_field_id = advancedfield.entity_field_id;
                    _advancedfield.field_id = advancedfield.field_id;
                    _advancedfield.value = advancedfield.value;

                    _advancedfields.Add(_advancedfield);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AdvancedFieldsValues"
        #region "GeneralParameters"
        public void AddNewGeneralParameter(GeneralParametersModel generalparameter)
        {
            try
            {
                GeneralParameter _generalparameter = new GeneralParameter();
                _generalparameter.key = generalparameter.key;
                _generalparameter.value = generalparameter.value;

                db.GeneralParameters.AddObject(_generalparameter);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateGeneralParameter(GeneralParametersModel generalparameter)
        {
            try
            {
                GeneralParameter _generalparameter = db.GeneralParameters.First(b => b.key == generalparameter.key);
                _generalparameter.value = generalparameter.value;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteGeneralParameter(GeneralParametersModel generalparameter)
        {
            try
            {
                GeneralParameter _generalparameter = db.GeneralParameters.First(b => b.key == generalparameter.key);

                db.GeneralParameters.DeleteObject(_generalparameter);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<GeneralParametersModel> GetAllGeneralParameters()
        {
            try
            {
                List<GeneralParametersModel> _generalparameters = new List<GeneralParametersModel>();
                var _generalparametersquery = from br in db.GeneralParameters
                                              select br;
                List<GeneralParameter> _gnrlprmtrs = _generalparametersquery.ToList();
                foreach (var generalparameter in _gnrlprmtrs)
                {
                    GeneralParametersModel _generalparameter = new GeneralParametersModel();
                    _generalparameter.key = generalparameter.key;
                    _generalparameter.value = generalparameter.value;

                    _generalparameters.Add(_generalparameter);
                }

                return _generalparameters;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "GeneralParameters"
        #region "LoanScales"
        public void AddNewLoanScale(LoanScaleModel loanscale)
        {
            try
            {
                LoanScale _loanscale = new LoanScale();
                _loanscale.ScaleMin = loanscale.ScaleMin;
                _loanscale.ScaleMax = loanscale.ScaleMax;

                db.LoanScales.AddObject(_loanscale);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateLoanScale(LoanScaleModel loanscale)
        {
            try
            {
                LoanScale _loanscale = db.LoanScales.First(b => b.id == loanscale.loanscaleid);
                _loanscale.ScaleMin = loanscale.ScaleMin;
                _loanscale.ScaleMax = loanscale.ScaleMax;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteLoanScale(LoanScaleModel loanscale)
        {
            try
            {
                LoanScale _loanscale = db.LoanScales.First(b => b.id == loanscale.loanscaleid);

                db.LoanScales.DeleteObject(_loanscale);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<LoanScaleModel> GetAllLoanScales()
        {
            try
            {
                List<LoanScaleModel> _loanscales = new List<LoanScaleModel>();
                var _loanscalesquery = from br in db.LoanScales
                                       select br;
                List<LoanScale> _lnscls = _loanscalesquery.ToList();
                foreach (var loanscale in _lnscls)
                {
                    LoanScaleModel _loanscale = new LoanScaleModel();
                    _loanscale.loanscaleid = loanscale.id;
                    _loanscale.ScaleMin = loanscale.ScaleMin;
                    _loanscale.ScaleMax = loanscale.ScaleMax;

                    _loanscales.Add(_loanscale);
                }

                return _loanscales;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "LoanScales"
        #region "ProvisioningRules"
        public void AddNewProvisioningRule(ProvisioningRuleModel provisioningrule)
        {
            try
            {
                ProvisioningRule _provisioningrule = new ProvisioningRule();
                _provisioningrule.number_of_days_min = provisioningrule.number_of_days_min;
                _provisioningrule.number_of_days_max = provisioningrule.number_of_days_max;
                _provisioningrule.provisioning_value = provisioningrule.provisioning_value;

                db.ProvisioningRules.AddObject(_provisioningrule);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateProvisioningRule(ProvisioningRuleModel provisioningrule)
        {
            try
            {
                ProvisioningRule _provisioningrule = db.ProvisioningRules.First(b => b.id == provisioningrule.provisioningruleid);
                _provisioningrule.number_of_days_min = provisioningrule.number_of_days_min;
                _provisioningrule.number_of_days_max = provisioningrule.number_of_days_max;
                _provisioningrule.provisioning_value = provisioningrule.provisioning_value;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteProvisioningRule(ProvisioningRuleModel provisioningrule)
        {
            try
            {
                ProvisioningRule _provisioningrule = db.ProvisioningRules.First(b => b.id == provisioningrule.provisioningruleid);

                db.ProvisioningRules.DeleteObject(_provisioningrule);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ProvisioningRuleModel> GetAllProvisioningRules()
        {
            try
            {
                List<ProvisioningRuleModel> _provisioningrules = new List<ProvisioningRuleModel>();
                var _provisioningrulesquery = from br in db.ProvisioningRules
                                              select br;
                List<ProvisioningRule> _prvsnngrls = _provisioningrulesquery.ToList();
                foreach (var provisioningrule in _prvsnngrls)
                {
                    ProvisioningRuleModel _provisioningrule = new ProvisioningRuleModel();
                    _provisioningrule.provisioningruleid = provisioningrule.id;
                    _provisioningrule.number_of_days_min = provisioningrule.number_of_days_min;
                    _provisioningrule.number_of_days_max = provisioningrule.number_of_days_max;
                    _provisioningrule.provisioning_value = provisioningrule.provisioning_value;

                    _provisioningrules.Add(_provisioningrule);
                }

                return _provisioningrules;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "ProvisioningRules"
        #region "PublicHolidays"
        public void AddNewPublicHoliday(PublicHolidayModel publicholiday)
        {
            try
            {
                PublicHoliday _publicholiday = new PublicHoliday();
                _publicholiday.date = publicholiday.date;
                _publicholiday.name = publicholiday.name;

                db.PublicHolidays.AddObject(_publicholiday);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdatePublicHoliday(PublicHolidayModel publicholiday)
        {
            try
            {
                PublicHoliday _publicholiday = db.PublicHolidays.First(b => b.name == publicholiday.name && b.date == publicholiday.date);
                _publicholiday.date = publicholiday.date;
                _publicholiday.name = publicholiday.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeletePublicHoliday(PublicHolidayModel publicholiday)
        {
            try
            {
                PublicHoliday _publicholiday = db.PublicHolidays.First(b => b.name == publicholiday.name && b.date == publicholiday.date);

                db.PublicHolidays.DeleteObject(_publicholiday);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<PublicHolidayModel> GetAllPublicHolidays()
        {
            try
            {
                List<PublicHolidayModel> _publicholidays = new List<PublicHolidayModel>();
                var _publicholidaysquery = from br in db.PublicHolidays
                                           select br;
                List<PublicHoliday> _pblchldys = _publicholidaysquery.ToList();
                foreach (var publicholiday in _pblchldys)
                {
                    PublicHolidayModel _publicholiday = new PublicHolidayModel();
                    _publicholiday.date = publicholiday.date;
                    _publicholiday.name = publicholiday.name;

                    _publicholidays.Add(_publicholiday);
                }

                return _publicholidays;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "PublicHolidays"
        #region "InstallmentTypes"
        public void AddNewInstallmentType(InstallmentTypesModel installmenttype)
        {
            try
            {
                InstallmentType _installmenttype = new InstallmentType();
                _installmenttype.name = installmenttype.name;
                _installmenttype.nb_of_days = installmenttype.nb_of_days;
                _installmenttype.nb_of_months = installmenttype.nb_of_months;

                db.InstallmentTypes.AddObject(_installmenttype);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateInstallmentType(InstallmentTypesModel installmenttype)
        {
            try
            {
                InstallmentType _installmenttype = db.InstallmentTypes.First(b => b.id == installmenttype.installmenttypesid);
                _installmenttype.name = installmenttype.name;
                _installmenttype.nb_of_days = installmenttype.nb_of_days;
                _installmenttype.nb_of_months = installmenttype.nb_of_months;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteInstallmentType(InstallmentTypesModel installmenttype)
        {
            try
            {
                InstallmentType _installmenttype = db.InstallmentTypes.First(b => b.id == installmenttype.installmenttypesid);

                db.InstallmentTypes.DeleteObject(_installmenttype);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<InstallmentTypesModel> GetAllInstallmentTypes()
        {
            try
            {
                List<InstallmentTypesModel> _installmenttypes = new List<InstallmentTypesModel>();
                var _installmenttypesquery = from br in db.InstallmentTypes
                                             select br;
                List<InstallmentType> _nstllmnttyps = _installmenttypesquery.ToList();
                foreach (var installmenttype in _nstllmnttyps)
                {
                    InstallmentTypesModel _installmenttype = new InstallmentTypesModel();
                    _installmenttype.installmenttypesid = installmenttype.id;
                    _installmenttype.name = installmenttype.name;
                    _installmenttype.nb_of_days = installmenttype.nb_of_days;
                    _installmenttype.nb_of_months = installmenttype.nb_of_months;

                    _installmenttypes.Add(_installmenttype);
                }

                return _installmenttypes;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "InstallmentTypes"
        #region "Installments"
        public void AddNewInstallment(InstallmentsModel installment)
        {
            try
            {
                Installment _installment = new Installment();
                _installment.expected_date = installment.expected_date;
                _installment.interest_repayment = installment.interest_repayment;
                _installment.capital_repayment = installment.capital_repayment;
                _installment.contract_id = installment.contract_id;
                _installment.number = installment.number;
                _installment.paid_interest = installment.paid_interest;
                _installment.paid_capital = installment.paid_capital;
                _installment.fees_unpaid = installment.fees_unpaid;
                _installment.paid_date = installment.paid_date;
                _installment.paid_fees = installment.paid_fees;
                _installment.comment = installment.comment;
                _installment.pending = installment.pending;
                _installment.start_date = installment.start_date;
                _installment.olb = installment.olb;

                db.Installments.AddObject(_installment);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateInstallment(InstallmentsModel installment)
        {
            try
            {
                Installment _installment = db.Installments.First(b => b.contract_id == installment.contract_id && b.number == installment.number);
                _installment.expected_date = installment.expected_date;
                _installment.interest_repayment = installment.interest_repayment;
                _installment.capital_repayment = installment.capital_repayment;
                _installment.contract_id = installment.contract_id;
                _installment.number = installment.number;
                _installment.paid_interest = installment.paid_interest;
                _installment.paid_capital = installment.paid_capital;
                _installment.fees_unpaid = installment.fees_unpaid;
                _installment.paid_date = installment.paid_date;
                _installment.paid_fees = installment.paid_fees;
                _installment.comment = installment.comment;
                _installment.pending = installment.pending;
                _installment.start_date = installment.start_date;
                _installment.olb = installment.olb;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteInstallment(InstallmentsModel installment)
        {
            try
            {
                Installment _installment = db.Installments.First(b => b.contract_id == installment.contract_id && b.number == installment.number);

                db.Installments.DeleteObject(_installment);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<InstallmentsModel> GetAllInstallments()
        {
            try
            {
                List<InstallmentsModel> _installments = new List<InstallmentsModel>();
                var _installmentsquery = from br in db.Installments
                                         select br;
                List<Installment> _nstllmnts = _installmentsquery.ToList();
                foreach (var installment in _nstllmnts)
                {
                    InstallmentsModel _installment = new InstallmentsModel();
                    _installment.expected_date = installment.expected_date;
                    _installment.interest_repayment = installment.interest_repayment;
                    _installment.capital_repayment = installment.capital_repayment;
                    _installment.contract_id = installment.contract_id;
                    _installment.number = installment.number;
                    _installment.paid_interest = installment.paid_interest;
                    _installment.paid_capital = installment.paid_capital;
                    _installment.fees_unpaid = installment.fees_unpaid;
                    _installment.paid_date = installment.paid_date;
                    _installment.paid_fees = installment.paid_fees;
                    _installment.comment = installment.comment;
                    _installment.pending = installment.pending;
                    _installment.start_date = installment.start_date;
                    _installment.olb = installment.olb;

                    _installments.Add(_installment);
                }

                return _installments;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<InstallmentsModel> GetAllContractInstallments(int _contact_id)
        {
            try
            {
                List<InstallmentsModel> _installments = new List<InstallmentsModel>();
                var _installmentsquery = from br in db.Installments
                                         where br.contract_id == _contact_id
                                         select br;
                List<Installment> _nstllmnts = _installmentsquery.ToList();
                foreach (var installment in _nstllmnts)
                {
                    InstallmentsModel _installment = new InstallmentsModel();
                    _installment.expected_date = installment.expected_date;
                    _installment.interest_repayment = installment.interest_repayment;
                    _installment.capital_repayment = installment.capital_repayment;
                    _installment.contract_id = installment.contract_id;
                    _installment.number = installment.number;
                    _installment.paid_interest = installment.paid_interest;
                    _installment.paid_capital = installment.paid_capital;
                    _installment.fees_unpaid = installment.fees_unpaid;
                    _installment.paid_date = installment.paid_date;
                    _installment.paid_fees = installment.paid_fees;
                    _installment.comment = installment.comment;
                    _installment.pending = installment.pending;
                    _installment.start_date = installment.start_date;
                    _installment.olb = installment.olb;

                    _installments.Add(_installment);
                }

                return _installments;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Installments"
        #region "AccountingClosures"
        public void AddNewAccountingClosure(AccountingClosureModel accountingclosure)
        {
            try
            {
                AccountingClosure _accountingclosure = new AccountingClosure();
                _accountingclosure.user_id = accountingclosure.user_id;
                _accountingclosure.date_of_closure = accountingclosure.date_of_closure;
                _accountingclosure.count_of_transactions = accountingclosure.count_of_transactions;
                _accountingclosure.is_deleted = accountingclosure.is_deleted;

                db.AccountingClosures.AddObject(_accountingclosure);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateAccountingClosure(AccountingClosureModel accountingclosure)
        {
            try
            {
                AccountingClosure _accountingclosure = db.AccountingClosures.First(b => b.id == accountingclosure.accountingclosureid);
                _accountingclosure.user_id = accountingclosure.user_id;
                _accountingclosure.date_of_closure = accountingclosure.date_of_closure;
                _accountingclosure.count_of_transactions = accountingclosure.count_of_transactions;
                _accountingclosure.is_deleted = accountingclosure.is_deleted;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteAccountingClosure(AccountingClosureModel accountingclosure)
        {
            try
            {
                AccountingClosure _accountingclosure = db.AccountingClosures.First(b => b.id == accountingclosure.accountingclosureid);

                _accountingclosure.is_deleted = true;
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<AccountingClosureModel> GetNonDeletedAccountingClosures()
        {
            try
            {
                List<AccountingClosureModel> _accountingclosures = new List<AccountingClosureModel>();
                var _accountingclosuresquery = from br in db.AccountingClosures
                                               where br.is_deleted == false
                                               select br;
                List<AccountingClosure> _ccntngclsrs = _accountingclosuresquery.ToList();
                foreach (var accountingclosure in _ccntngclsrs)
                {
                    AccountingClosureModel _accountingclosure = new AccountingClosureModel();
                    _accountingclosure.accountingclosureid = accountingclosure.id;
                    _accountingclosure.user_id = accountingclosure.user_id;
                    _accountingclosure.date_of_closure = accountingclosure.date_of_closure;
                    _accountingclosure.count_of_transactions = accountingclosure.count_of_transactions;
                    _accountingclosure.is_deleted = accountingclosure.is_deleted;

                    _accountingclosures.Add(_accountingclosure);
                }

                return _accountingclosures;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<AccountingClosureModel> GetAllAccountingClosures()
        {
            try
            {
                List<AccountingClosureModel> _accountingclosures = new List<AccountingClosureModel>();
                var _accountingclosuresquery = from br in db.AccountingClosures
                                               select br;
                List<AccountingClosure> _ccntngclsrs = _accountingclosuresquery.ToList();
                foreach (var accountingclosure in _ccntngclsrs)
                {
                    AccountingClosureModel _accountingclosure = new AccountingClosureModel();
                    _accountingclosure.accountingclosureid = accountingclosure.id;
                    _accountingclosure.user_id = accountingclosure.user_id;
                    _accountingclosure.date_of_closure = accountingclosure.date_of_closure;
                    _accountingclosure.count_of_transactions = accountingclosure.count_of_transactions;
                    _accountingclosure.is_deleted = accountingclosure.is_deleted;

                    _accountingclosures.Add(_accountingclosure);
                }

                return _accountingclosures;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "AccountingClosures"
        #region "StoredProcedures"
        public IEnumerable<AccountBookingsModel> GetAccountBookings(DateTime begindate, DateTime enddate, int accountid, int currencyid, bool isexported, int branchid)
        {
            try
            {
                var _accountmodelsquery = from ea in db.GetAccountBookings(begindate, enddate, accountid, currencyid, isexported, branchid)
                                          select new AccountBookingsModel
                                          {
                                              amount = ea.amount,
                                              contract_code = ea.contract_code,
                                              credit_local_account_number = ea.credit_local_account_number,
                                              date = ea.date,
                                              debit_local_account_number = ea.debit_local_account_number,
                                              event_code = ea.event_code,
                                              exchange_rate = ea.exchange_rate,
                                              is_exported = ea.is_exported
                                          };

                return _accountmodelsquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IEnumerable<ExportAccounting_Transaction_with_datesModel> GetExportAccounting_Transaction_with_dates(DateTime begindate, DateTime enddate)
        {
            try
            {
                var _exportmodelsquery = from ea in db.ExportAccounting_Transaction_with_dates(begindate, enddate)
                                         select new ExportAccounting_Transaction_with_datesModel
                                         {
                                             amount = ea.amount,
                                             contract_code = ea.contract_code,
                                             credit_local_account_number = ea.credit_local_account_number,
                                             date = ea.date,
                                             debit_local_account_number = ea.debit_local_account_number,
                                             event_code = ea.event_code,
                                             exchange_rate = ea.exchange_rate,
                                             currency_id = ea.currency_id,
                                             currency_name = ea.currency_name,
                                             elementary_id = ea.elementary_id,
                                             fundingLine = ea.fundingLine,
                                             type = ea.type
                                         };

                return _exportmodelsquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IEnumerable<ExportAccounting_TransactionsModel> GetExportAccounting_Transactions()
        {
            try
            {
                var _exportmodelsquery = from ea in db.ExportAccounting_Transactions()
                                         select new ExportAccounting_TransactionsModel
                                         {
                                             amount = ea.amount,
                                             contract_code = ea.contract_code,
                                             credit_local_account_number = ea.credit_local_account_number,
                                             date = ea.date,
                                             debit_local_account_number = ea.debit_local_account_number,
                                             event_code = ea.event_code,
                                             exchange_rate = ea.exchange_rate,
                                             currency_id = ea.currency_id,
                                             currency_name = ea.currency_name,
                                             elementary_id = ea.elementary_id,
                                             fundingLine = ea.fundingLine,
                                             type = ea.type
                                         };

                return _exportmodelsquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IEnumerable<ExportAccounting_Transactions_DetModel> GetExportAccounting_Transactions_Det()
        {
            try
            {
                var _exportmodelsquery = from ea in db.ExportAccounting_Transactions_Det()
                                         select new ExportAccounting_Transactions_DetModel
                                         {
                                             ACCNT = ea.ACCNT,
                                             AMOUNT = ea.AMOUNT,
                                             CLASS = ea.CLASS,
                                             DATE = ea.DATE,
                                             DOCNUM = ea.DOCNUM,
                                             MEMO = ea.MEMO,
                                             NAME = ea.NAME,
                                             TRNS = ea.TRNS,
                                             TRNSID = ea.TRNSID,
                                             TRNSTYPE = ea.TRNSTYPE
                                         };

                return _exportmodelsquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IEnumerable<ExportAccounting_Transactions_QModel> GetExportAccounting_Transactions_Q()
        {
            try
            {
                var _exportmodelsquery = from ea in db.ExportAccounting_Transactions_Q()
                                         select new ExportAccounting_Transactions_QModel
                                         {
                                             ACCNT = ea.ACCNT,
                                             AMOUNT = ea.AMOUNT,
                                             DATE = ea.DATE,
                                             NAME = ea.NAME,
                                             TRNS = ea.TRNS,
                                             TRNSTYPE = ea.TRNSTYPE,
                                             ID = ea.ID,
                                             Loan = ea.Loan
                                         };

                return _exportmodelsquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IEnumerable<ClientPersonalInformationModel> GetClientPersonalInformation(int personid, int branchid)
        {
            try
            {
                var _clientinfoquery = from ci in db.Rep_Client_Personal_Information(personid, branchid)
                                       select new ClientPersonalInformationModel
                                       {
                                           address = ci.address,
                                           city = ci.city,
                                           district = ci.district,
                                           father_name = ci.father_name,
                                           first_name = ci.first_name,
                                           gender = ci.gender,
                                           id_number = ci.id_number,
                                           last_name = ci.last_name,
                                           phone = ci.phone,
                                           picture = ci.picture,
                                           picture2 = ci.picture2,
                                           sec_address = ci.sec_address,
                                           sec_city = ci.sec_city,
                                           sec_district = ci.sec_district,
                                           sec_pers_phone = ci.sec_pers_phone,
                                           sec_phone = ci.sec_phone
                                       };

                return _clientinfoquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IEnumerable<ClientPersonalInformationCreditModel> GetClientPersonalInformationCredit(int personid, int branchid)
        {
            try
            {
                var _clientinfoquery = from ci in db.Rep_Client_Personal_Information_Credit(personid, branchid)
                                       select new ClientPersonalInformationCreditModel
                                       {
                                           amount = ci.amount,
                                           close_date = ci.close_date,
                                           contract_code = ci.contract_code,
                                           creation_date = ci.creation_date,
                                           group_name = ci.group_name,
                                           has_atr = ci.has_atr,
                                           olb = ci.olb,
                                           start_date = ci.start_date,
                                           status = ci.status,
                                           total_late_days = ci.total_late_days
                                       };

                return _clientinfoquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public IEnumerable<ClientPersonalInformationSavingsModel> GetClientPersonalInformationSavings(int personid, int branchid)
        {
            try
            {
                var _clientinfoquery = from ci in db.Rep_Client_Personal_Information_Savings(personid)
                                       select new ClientPersonalInformationSavingsModel
                                       {
                                           balance_amount = ci.balance_amount,
                                           closed_date = ci.closed_date,
                                           creation_date = ci.creation_date,
                                           product_code = ci.product_code,
                                           product_name = ci.product_name,
                                           product_type = ci.product_type,
                                           savings_code = ci.savings_code
                                       };

                return _clientinfoquery;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "StoredProcedures"
        #region "Contracts and Credits and Projects"
        public int AddNewLoanProject(ClientLoanContractModel loanmodel)
        {
            int id = -1;
            try
            {
                Project _project = new Project();
                _project.tiers_id = loanmodel.tiers_id;
                _project.status = loanmodel.project_status;
                _project.name = loanmodel.project_name;
                _project.code = loanmodel.project_code;
                _project.aim = loanmodel.aim;
                _project.begin_date = loanmodel.project_begin_date;
                _project.abilities = loanmodel.abilities;
                _project.experience = loanmodel.experience;
                _project.market = loanmodel.market;
                _project.concurrence = loanmodel.concurrence;
                _project.purpose = loanmodel.purpose;
                _project.corporate_name = loanmodel.corporate_name;
                _project.corporate_juridicStatus = loanmodel.corporate_juridicStatus;
                _project.corporate_FiscalStatus = loanmodel.corporate_FiscalStatus;
                _project.corporate_siret = loanmodel.corporate_siret;
                _project.corporate_CA = loanmodel.corporate_CA;
                _project.corporate_nbOfJobs = loanmodel.corporate_nbOfJobs;
                _project.corporate_financialPlanType = loanmodel.corporate_financialPlanType;
                _project.corporateFinancialPlanAmount = loanmodel.corporateFinancialPlanAmount;
                _project.corporate_financialPlanTotalAmount = loanmodel.corporate_financialPlanTotalAmount;
                _project.address = loanmodel.address;
                _project.city = loanmodel.city;
                _project.zipCode = loanmodel.zipCode;
                _project.district_id = loanmodel.district_id;
                _project.home_phone = loanmodel.home_phone;
                _project.personalPhone = loanmodel.personalPhone;
                _project.Email = loanmodel.Email;
                _project.hometype = loanmodel.hometype;
                _project.corporate_registre = loanmodel.corporate_registre;


                db.Projects.AddObject(_project);
                db.SaveChanges();

                return _project.id;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return id;
            }
        }
        public int AddNewLoanContract(ClientLoanContractModel loanmodel)
        {
            int id = -1;
            try
            {
                Contract _contract = new Contract();
                _contract.contract_code = loanmodel.contract_code;
                _contract.branch_code = loanmodel.branch_code;
                _contract.creation_date = loanmodel.creation_date;
                _contract.start_date = loanmodel.start_date;
                _contract.close_date = loanmodel.close_date;
                _contract.closed = loanmodel.closed;
                _contract.project_id = loanmodel.project_id;
                _contract.status = loanmodel.status;
                _contract.credit_commitee_date = loanmodel.credit_commitee_date;
                _contract.credit_commitee_comment = loanmodel.credit_commitee_comment;
                _contract.credit_commitee_code = loanmodel.credit_commitee_code;
                _contract.align_disbursed_date = loanmodel.align_disbursed_date;
                _contract.loan_purpose = loanmodel.loan_purpose;
                _contract.comments = loanmodel.comments;
                _contract.nsg_id = loanmodel.nsg_id;
                _contract.activity_id = loanmodel.activity_id;
                _contract.first_installment_date = loanmodel.first_installment_date;

                db.Contracts.AddObject(_contract);
                db.SaveChanges();

                return _contract.id;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return id;
            }
        }
        public void AddNewLoanCredit(ClientLoanContractModel loanmodel)
        {
            try
            {
                Credit _credit = new Credit();
                _credit.id = loanmodel.creditid;
                _credit.package_id = loanmodel.package_id;
                _credit.amount = loanmodel.amount;
                _credit.interest_rate = loanmodel.interest_rate;
                _credit.installment_type = loanmodel.installment_type;
                _credit.nb_of_installment = loanmodel.nb_of_installment;
                _credit.anticipated_total_repayment_penalties = loanmodel.anticipated_total_repayment_penalties;
                _credit.disbursed = loanmodel.disbursed;
                _credit.loanofficer_id = loanmodel.loanofficer_id;
                _credit.grace_period = loanmodel.grace_period;
                _credit.written_off = loanmodel.written_off;
                _credit.rescheduled = loanmodel.rescheduled;
                _credit.bad_loan = loanmodel.bad_loan;
                _credit.non_repayment_penalties_based_on_overdue_principal = loanmodel.non_repayment_penalties_based_on_overdue_principal;
                _credit.non_repayment_penalties_based_on_initial_amount = loanmodel.non_repayment_penalties_based_on_initial_amount;
                _credit.non_repayment_penalties_based_on_olb = loanmodel.non_repayment_penalties_based_on_olb;
                _credit.non_repayment_penalties_based_on_overdue_interest = loanmodel.non_repayment_penalties_based_on_overdue_interest;
                _credit.fundingLine_id = loanmodel.fundingLine_id;
                _credit.synchronize = loanmodel.synchronize;
                _credit.interest = loanmodel.interest;
                _credit.grace_period_of_latefees = loanmodel.grace_period_of_latefees;
                _credit.anticipated_partial_repayment_penalties = loanmodel.anticipated_partial_repayment_penalties;
                _credit.number_of_drawings_loc = loanmodel.number_of_drawings_loc;
                _credit.amount_under_loc = loanmodel.amount_under_loc;
                _credit.maturity_loc = loanmodel.maturity_loc;
                _credit.anticipated_partial_repayment_base = loanmodel.anticipated_partial_repayment_base;
                _credit.anticipated_total_repayment_base = loanmodel.anticipated_total_repayment_base;
                _credit.schedule_changed = loanmodel.schedule_changed;
                _credit.amount_min = loanmodel.amount_min;
                _credit.amount_max = loanmodel.amount_max;
                _credit.ir_min = loanmodel.ir_min;
                _credit.ir_max = loanmodel.ir_max;
                _credit.nmb_of_inst_min = loanmodel.nmb_of_inst_min;
                _credit.nmb_of_inst_max = loanmodel.nmb_of_inst_max;
                _credit.loan_cycle = loanmodel.loan_cycle;
                _credit.insurance = loanmodel.insurance;
                _credit.exotic_id = loanmodel.exotic_id;

                db.Credits.AddObject(_credit);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateLoanContractCode(ClientLoanContractModel loanmodel)
        {
            try
            {
                Contract _contract = db.Contracts.First(b => b.id == loanmodel.contractid);
                _contract.contract_code = loanmodel.contract_code;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateLoanContract(ClientLoanContractModel loanmodel)
        {
            try
            {
                Contract _contract = db.Contracts.First(b => b.id == loanmodel.contractid);
                _contract.start_date = loanmodel.start_date;
                _contract.close_date = loanmodel.close_date;
                _contract.align_disbursed_date = loanmodel.align_disbursed_date;
                _contract.loan_purpose = loanmodel.loan_purpose;
                _contract.comments = loanmodel.comments;
                _contract.activity_id = loanmodel.activity_id;
                _contract.first_installment_date = loanmodel.first_installment_date;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateLoanContractOnDisbursement(ClientLoanContractModel loanmodel)
        {
            try
            {
                Contract _contract = db.Contracts.First(b => b.id == loanmodel.contractid);
                _contract.status = loanmodel.status;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateLoanCredit(ClientLoanContractModel loanmodel)
        {
            try
            {
                Credit _credit = db.Credits.First(b => b.id == loanmodel.creditid);
                _credit.amount = loanmodel.amount;
                _credit.interest_rate = loanmodel.interest_rate;
                _credit.installment_type = loanmodel.installment_type;
                _credit.nb_of_installment = loanmodel.nb_of_installment;
                _credit.anticipated_total_repayment_penalties = loanmodel.anticipated_total_repayment_penalties;
                _credit.loanofficer_id = loanmodel.loanofficer_id;
                _credit.anticipated_total_repayment_penalties = loanmodel.anticipated_total_repayment_penalties;
                _credit.grace_period = loanmodel.grace_period;
                _credit.non_repayment_penalties_based_on_overdue_principal = loanmodel.non_repayment_penalties_based_on_overdue_principal;
                _credit.non_repayment_penalties_based_on_initial_amount = loanmodel.non_repayment_penalties_based_on_initial_amount;
                _credit.non_repayment_penalties_based_on_olb = loanmodel.non_repayment_penalties_based_on_olb;
                _credit.non_repayment_penalties_based_on_overdue_interest = loanmodel.non_repayment_penalties_based_on_overdue_interest;
                _credit.fundingLine_id = loanmodel.fundingLine_id;
                _credit.amount_under_loc = loanmodel.amount_under_loc;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateLoanContractCreditCommittee(ClientLoanContractModel loanmodel)
        {
            try
            {
                Contract _contract = db.Contracts.First(b => b.id == loanmodel.contractid);
                Credit _credit = db.Credits.First(b => b.id == loanmodel.creditid);
                _contract.status = loanmodel.status;
                _contract.credit_commitee_date = loanmodel.credit_commitee_date;
                _contract.credit_commitee_comment = loanmodel.credit_commitee_comment;
                _contract.credit_commitee_code = loanmodel.credit_commitee_code;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteClientLoanContract(ClientLoanContractModel loanmodel)
        {
            try
            {
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ClientLoanContractModel> GetAllClientLoanContracts(int clientid)
        {
            try
            {
                var _loanmodelsquery = from co in db.Contracts
                                       join cr in db.Credits on co.id equals cr.id
                                       join pr in db.Projects on co.project_id equals pr.id
                                       join pk in db.Packages on cr.package_id equals pk.id
                                       join tr in db.Tiers on pr.tiers_id equals tr.id
                                       join fl in db.FundingLines on cr.fundingLine_id equals fl.id
                                       where tr.id == clientid
                                       select new ClientLoanContractModel
                             {
                                 contractid = co.id,
                                 contract_code = co.contract_code,
                                 packagename = pk.name,
                                 branch_code = co.branch_code,
                                 creation_date = co.creation_date,
                                 start_date = co.start_date,
                                 close_date = co.close_date,
                                 closed = co.closed,
                                 project_id = co.project_id,
                                 status = co.status,
                                 credit_commitee_date = co.credit_commitee_date,
                                 credit_commitee_comment = co.credit_commitee_comment,
                                 credit_commitee_code = co.credit_commitee_code,
                                 align_disbursed_date = co.align_disbursed_date,
                                 loan_purpose = co.loan_purpose,
                                 comments = co.comments,
                                 nsg_id = co.nsg_id,
                                 activity_id = co.activity_id,
                                 first_installment_date = co.first_installment_date,
                                 creditid = cr.id,
                                 package_id = cr.package_id,
                                 amount = cr.amount,
                                 interest_rate = cr.interest_rate,
                                 installment_type = cr.installment_type,
                                 nb_of_installment = cr.nb_of_installment,
                                 anticipated_total_repayment_penalties = cr.anticipated_total_repayment_penalties,
                                 disbursed = cr.disbursed,
                                 loanofficer_id = cr.loanofficer_id,
                                 grace_period = cr.grace_period,
                                 grace_period_max = pk.grace_period_max,
                                 grace_period_min = pk.grace_period_min,
                                 written_off = cr.written_off,
                                 rescheduled = cr.rescheduled,
                                 bad_loan = cr.bad_loan,
                                 non_repayment_penalties_based_on_overdue_principal = cr.non_repayment_penalties_based_on_overdue_principal,
                                 non_repayment_penalties_based_on_initial_amount = cr.non_repayment_penalties_based_on_initial_amount,
                                 non_repayment_penalties_based_on_olb = cr.non_repayment_penalties_based_on_olb,
                                 non_repayment_penalties_based_on_overdue_interest = cr.non_repayment_penalties_based_on_overdue_interest,
                                 fundingLine_id = cr.fundingLine_id,
                                 currency_id = fl.currency_id,
                                 synchronize = cr.synchronize,
                                 interest = cr.interest,
                                 interest_rate_max = pk.interest_rate_max,
                                 interest_rate_min = pk.interest_rate_min,
                                 grace_period_of_latefees = cr.grace_period_of_latefees,
                                 anticipated_partial_repayment_penalties = cr.anticipated_partial_repayment_penalties,
                                 number_of_drawings_loc = cr.number_of_drawings_loc,
                                 amount_under_loc = cr.amount_under_loc,
                                 maturity_loc = cr.maturity_loc,
                                 anticipated_partial_repayment_base = cr.anticipated_partial_repayment_base,
                                 anticipated_total_repayment_base = cr.anticipated_total_repayment_base,
                                 schedule_changed = cr.schedule_changed,
                                 amount_min = cr.amount_min,
                                 amount_max = cr.amount_max,
                                 ir_min = cr.ir_min,
                                 ir_max = cr.ir_max,
                                 nmb_of_inst_min = cr.nmb_of_inst_min,
                                 nmb_of_inst_max = cr.nmb_of_inst_max,
                                 loan_cycle = cr.loan_cycle,
                                 insurance = cr.insurance,
                                 exotic_id = cr.exotic_id,
                                 insurance_max = pk.insurance_max,
                                 insurance_min = pk.insurance_min,
                                 //savingcontractid = sc.id,
                                 abilities = pr.abilities,
                                 address = pr.address,
                                 aim = pr.aim,
                                 city = pr.city,
                                 compulsory_amount = pk.compulsory_amount,
                                 compulsory_amount_min = pk.compulsory_amount_min,
                                 concurrence = pr.concurrence,
                                 corporate_CA = pr.corporate_CA,
                                 corporate_financialPlanTotalAmount = pr.corporate_financialPlanTotalAmount,
                                 corporate_financialPlanType = pr.corporate_financialPlanType,
                                 corporate_FiscalStatus = pr.corporate_FiscalStatus,
                                 corporate_juridicStatus = pr.corporate_juridicStatus,
                                 corporate_name = pr.corporate_name,
                                 corporate_nbOfJobs = pr.corporate_nbOfJobs,
                                 corporate_registre = pr.corporate_registre,
                                 corporate_siret = pr.corporate_siret,
                                 corporateFinancialPlanAmount = pr.corporateFinancialPlanAmount,
                                 district_id = pr.district_id,
                                 Email = pr.Email,
                                 experience = pr.experience,
                                 home_phone = pr.home_phone,
                                 hometype = pr.hometype,
                                 market = pr.market,
                                 personalPhone = pr.personalPhone,
                                 project_begin_date = pr.begin_date,
                                 project_code = pr.code,
                                 project_name = pr.name,
                                 project_status = pr.status,
                                 projectid = pr.id,
                                 purpose = pr.purpose,
                                 tiers_id = pr.tiers_id,
                                 zipCode = pr.zipCode

                             };
                return _loanmodelsquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Contracts and Credits and Projects"
        #region "SavingContracts and SavingBookContracts"
        public void AddNewClientSavingContract(ClientSavingContractModel savingmodel)
        {
            try
            {
                SavingContract _contract = new SavingContract();
                _contract.product_id = savingmodel.product_id;
                _contract.user_id = savingmodel.user_id;
                _contract.code = savingmodel.code;
                _contract.tiers_id = savingmodel.tiers_id;
                _contract.creation_date = savingmodel.creation_date;
                _contract.interest_rate = savingmodel.interest_rate;
                _contract.status = savingmodel.status;
                _contract.closed_date = savingmodel.closed_date;
                _contract.savings_officer_id = savingmodel.savings_officer_id;
                _contract.initial_amount = savingmodel.initial_amount;
                _contract.entry_fees = savingmodel.entry_fees;
                _contract.nsg_id = savingmodel.nsg_id;

                db.SavingContracts.AddObject(_contract);
                db.SaveChanges();

                SavingBookContract _bookcontract = new SavingBookContract();
                _bookcontract.id = savingmodel.savingcontractid;
                _bookcontract.flat_withdraw_fees = savingmodel.flat_withdraw_fees;
                _bookcontract.rate_withdraw_fees = savingmodel.rate_withdraw_fees;
                _bookcontract.flat_transfer_fees = savingmodel.flat_transfer_fees;
                _bookcontract.rate_transfer_fees = savingmodel.rate_transfer_fees;
                _bookcontract.flat_deposit_fees = savingmodel.flat_deposit_fees;
                _bookcontract.flat_close_fees = savingmodel.flat_close_fees;
                _bookcontract.flat_management_fees = savingmodel.flat_management_fees;
                _bookcontract.flat_overdraft_fees = savingmodel.flat_overdraft_fees;
                _bookcontract.in_overdraft = savingmodel.in_overdraft;
                _bookcontract.rate_agio_fees = savingmodel.rate_agio_fees;
                _bookcontract.cheque_deposit_fees = savingmodel.cheque_deposit_fees;
                _bookcontract.flat_reopen_fees = savingmodel.flat_reopen_fees;
                _bookcontract.flat_ibt_fee = savingmodel.flat_ibt_fee;
                _bookcontract.rate_ibt_fee = savingmodel.rate_ibt_fee;
                _bookcontract.use_term_deposit = savingmodel.use_term_deposit;
                _bookcontract.term_deposit_period = savingmodel.term_deposit_period;
                _bookcontract.term_deposit_period_min = savingmodel.term_deposit_period_min;
                _bookcontract.term_deposit_period_max = savingmodel.term_deposit_period_max;
                _bookcontract.transfer_account = savingmodel.transfer_account;
                _bookcontract.rollover = savingmodel.rollover;
                _bookcontract.next_maturity = savingmodel.next_maturity;

                db.SavingBookContracts.AddObject(_bookcontract);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public int AddNewSavingContract(ClientSavingContractModel savingmodel)
        {
            int id = -1;
            try
            {
                SavingContract _contract = new SavingContract();
                _contract.product_id = savingmodel.product_id;
                _contract.user_id = savingmodel.user_id;
                _contract.code = savingmodel.code;
                _contract.tiers_id = savingmodel.tiers_id;
                _contract.creation_date = savingmodel.creation_date;
                _contract.interest_rate = savingmodel.interest_rate;
                _contract.status = savingmodel.status;
                _contract.closed_date = savingmodel.closed_date;
                _contract.savings_officer_id = savingmodel.savings_officer_id;
                _contract.initial_amount = savingmodel.initial_amount;
                _contract.entry_fees = savingmodel.entry_fees;
                _contract.nsg_id = savingmodel.nsg_id;

                db.SavingContracts.AddObject(_contract);
                db.SaveChanges();

                return _contract.id;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return id;
            }
        }
        public void AddNewSavingBookContract(ClientSavingContractModel savingmodel)
        {
            try
            {
                SavingBookContract _bookcontract = new SavingBookContract();
                _bookcontract.id = savingmodel.savingbookcontractid;
                _bookcontract.flat_withdraw_fees = savingmodel.flat_withdraw_fees;
                _bookcontract.rate_withdraw_fees = savingmodel.rate_withdraw_fees;
                _bookcontract.flat_transfer_fees = savingmodel.flat_transfer_fees;
                _bookcontract.rate_transfer_fees = savingmodel.rate_transfer_fees;
                _bookcontract.flat_deposit_fees = savingmodel.flat_deposit_fees;
                _bookcontract.flat_close_fees = savingmodel.flat_close_fees;
                _bookcontract.flat_management_fees = savingmodel.flat_management_fees;
                _bookcontract.flat_overdraft_fees = savingmodel.flat_overdraft_fees;
                _bookcontract.in_overdraft = savingmodel.in_overdraft;
                _bookcontract.rate_agio_fees = savingmodel.rate_agio_fees;
                _bookcontract.cheque_deposit_fees = savingmodel.cheque_deposit_fees;
                _bookcontract.flat_reopen_fees = savingmodel.flat_reopen_fees;
                _bookcontract.flat_ibt_fee = savingmodel.flat_ibt_fee;
                _bookcontract.rate_ibt_fee = savingmodel.rate_ibt_fee;
                _bookcontract.use_term_deposit = savingmodel.use_term_deposit;
                _bookcontract.term_deposit_period = savingmodel.term_deposit_period;
                _bookcontract.term_deposit_period_min = savingmodel.term_deposit_period_min;
                _bookcontract.term_deposit_period_max = savingmodel.term_deposit_period_max;
                _bookcontract.transfer_account = savingmodel.transfer_account;
                _bookcontract.rollover = savingmodel.rollover;
                _bookcontract.next_maturity = savingmodel.next_maturity;

                db.SavingBookContracts.AddObject(_bookcontract);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSavingContract(ClientSavingContractModel savingmodel)
        {
            try
            {
                SavingContract _contract = db.SavingContracts.First(b => b.id == savingmodel.savingcontractid);
                SavingBookContract _bookcontract = db.SavingBookContracts.First(b => b.id == savingmodel.savingbookcontractid);

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateClientSavingContract(ClientSavingContractModel savingmodel)
        {
            try
            {
                SavingContract _contract = db.SavingContracts.First(b => b.id == savingmodel.savingcontractid);
                SavingBookContract _bookcontract = db.SavingBookContracts.First(b => b.id == savingmodel.savingbookcontractid);

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteClientSavingContract(ClientSavingContractModel savingmodel)
        {
            try
            {
                SavingContract _savingproduct = db.SavingContracts.Where(i => i.id == savingmodel.savingcontractid).Single();
                SavingBookContract _savingbookproduct = db.SavingBookContracts.Where(i => i.id == savingmodel.savingbookcontractid).Single();

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ClientSavingContractModel> GetAllClientSavingContracts(int clientid)
        {
            try
            {
                var _loanmodelsquery = from sc in db.SavingContracts
                                       join sbc in db.SavingBookContracts on sc.id equals sbc.id
                                       join sp in db.SavingProducts on sc.product_id equals sp.id
                                       join sbp in db.SavingBookProducts on sp.id equals sbp.id
                                       join tr in db.Tiers on sc.tiers_id equals tr.id
                                       where tr.id == clientid
                                       where sp.deleted == false
                                       select new ClientSavingContractModel
                                       {
                                           savingcontractid = sc.id,
                                           product_id = sc.product_id,
                                           user_id = sc.user_id,
                                           code = sc.code,
                                           description = sp.name,
                                           tiers_id = sc.tiers_id,
                                           creation_date = sc.creation_date,
                                           interest_rate = sc.interest_rate,
                                           status = sc.status,
                                           closed_date = sc.closed_date,
                                           savings_officer_id = sc.savings_officer_id,
                                           initial_amount = sc.initial_amount,
                                           entry_fees = sc.entry_fees,
                                           nsg_id = sc.nsg_id,
                                           savingbookcontractid = sbc.id,
                                           flat_withdraw_fees = sbc.flat_withdraw_fees,
                                           rate_withdraw_fees = sbc.rate_withdraw_fees,
                                           flat_transfer_fees = sbc.flat_transfer_fees,
                                           rate_transfer_fees = sbc.rate_transfer_fees,
                                           flat_deposit_fees = sbc.flat_deposit_fees,
                                           flat_close_fees = sbc.flat_close_fees,
                                           flat_management_fees = sbc.flat_management_fees,
                                           flat_overdraft_fees = sbc.flat_overdraft_fees,
                                           in_overdraft = sbc.in_overdraft,
                                           rate_agio_fees = sbc.rate_agio_fees,
                                           cheque_deposit_fees = sbc.cheque_deposit_fees,
                                           flat_reopen_fees = sbc.flat_reopen_fees,
                                           flat_ibt_fee = sbc.flat_ibt_fee,
                                           rate_ibt_fee = sbc.rate_ibt_fee,
                                           use_term_deposit = sbc.use_term_deposit,
                                           term_deposit_period = sbc.term_deposit_period,
                                           term_deposit_period_min = sbc.term_deposit_period_min,
                                           term_deposit_period_max = sbc.term_deposit_period_max,
                                           transfer_account = sbc.transfer_account,
                                           rollover = sbc.rollover,
                                           next_maturity = sbc.next_maturity,
                                           agio_fees = sbp.agio_fees,
                                           agio_fees_freq = sbp.agio_fees_freq,
                                           agio_fees_max = sbp.agio_fees_max,
                                           agio_fees_min = sbp.agio_fees_min,
                                           balance_max = sp.balance_max,
                                           balance_min = sp.balance_min,
                                           calcul_amount_base = sbp.calcul_amount_base,
                                           cheque_deposit_fees_max = sbp.cheque_deposit_fees_max,
                                           cheque_deposit_fees_min = sbp.cheque_deposit_fees_min,
                                           cheque_deposit_max = sbp.cheque_deposit_max,
                                           cheque_deposit_min = sbp.cheque_deposit_min,
                                           client_type = sp.client_type,
                                           close_fees = sbp.close_fees,
                                           close_fees_max = sbp.close_fees_max,
                                           close_fees_min = sbp.close_fees_min,
                                           currency_id = sp.currency_id,
                                           deleted = sp.deleted,
                                           deposit_fees = sbp.deposit_fees,
                                           deposit_fees_max = sbp.deposit_fees_max,
                                           deposit_fees_min = sbp.deposit_fees_min,
                                           deposit_max = sp.deposit_max,
                                           deposit_min = sp.deposit_min,
                                           entry_fees_max = sp.entry_fees_max,
                                           entry_fees_min = sp.entry_fees_min,
                                           flat_transfer_fees_max = sbp.flat_transfer_fees_max,
                                           flat_transfer_fees_min = sbp.flat_transfer_fees_min,
                                           flat_withdraw_fees_max = sbp.flat_withdraw_fees_max,
                                           flat_withdraw_fees_min = sbp.flat_withdraw_fees_min,
                                           ibt_fee = sbp.ibt_fee,
                                           ibt_fee_max = sbp.ibt_fee_max,
                                           ibt_fee_min = sbp.ibt_fee_min,
                                           initial_amount_max = sp.initial_amount_max,
                                           initial_amount_min = sp.initial_amount_min,
                                           interest_base = sbp.interest_base,
                                           interest_frequency = sbp.interest_frequency,
                                           interest_rate_max = sp.interest_rate_max,
                                           interest_rate_min = sp.interest_rate_min,
                                           is_ibt_fee_flat = sbp.is_ibt_fee_flat,
                                           management_fees = sbp.management_fees,
                                           management_fees_freq = sbp.management_fees_freq,
                                           management_fees_max = sbp.management_fees_max,
                                           management_fees_min = sbp.management_fees_min,
                                           name = sp.name,
                                           overdraft_fees = sbp.overdraft_fees,
                                           overdraft_fees_max = sbp.overdraft_fees_max,
                                           overdraft_fees_min = sbp.overdraft_fees_min,
                                           posting_frequency = sbp.posting_frequency,
                                           product_type = sp.product_type,
                                           rate_transfer_fees_max = sbp.rate_transfer_fees_max,
                                           rate_transfer_fees_min = sbp.rate_transfer_fees_min,
                                           rate_withdraw_fees_max = sbp.rate_withdraw_fees_max,
                                           rate_withdraw_fees_min = sbp.rate_withdraw_fees_min,
                                           reopen_fees = sbp.reopen_fees,
                                           reopen_fees_max = sbp.reopen_fees_max,
                                           reopen_fees_min = sbp.reopen_fees_min,
                                           saving_book_productid = sbp.id,
                                           savingproductid = sp.id,
                                           transfer_fees_type = sbp.transfer_fees_type,
                                           transfer_max = sp.transfer_max,
                                           transfer_min = sp.transfer_min,
                                           withdraw_fees_type = sbp.withdraw_fees_type,
                                           withdraw_max = sp.withdraw_max,
                                           withdraw_min = sp.withdraw_min
                                       };

                return _loanmodelsquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public string GetIMFCodefromSettings(string key)
        {
            try
            {
                string imfcode = "";
                var _imfcodequery = (from br in db.GeneralParameters
                                     where br.key == key
                                     select br.value).FirstOrDefault();
                if (_imfcodequery != null)
                {
                    imfcode = _imfcodequery;
                }
                return imfcode;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public int GetClientSavingContractsCount(int clientid)
        {
            try
            {
                var _savingscontractscountquery = from sc in db.SavingContracts
                                                  join sbc in db.SavingBookContracts on sc.id equals sbc.id
                                                  join sp in db.SavingProducts on sc.product_id equals sp.id
                                                  join sbp in db.SavingBookProducts on sp.id equals sbp.id
                                                  join tr in db.Tiers on sc.tiers_id equals tr.id
                                                  where tr.id == clientid
                                                  where sp.deleted == false
                                                  select sc;

                return _savingscontractscountquery.Count() + 1;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 0;
            }
        }
        public int GetNextSavingContractId(int clientid)
        {
            try
            {
                var _savingscontractscountquery = (from sc in db.SavingContracts
                                                   join sbc in db.SavingBookContracts on sc.id equals sbc.id
                                                   join sp in db.SavingProducts on sc.product_id equals sp.id
                                                   join sbp in db.SavingBookProducts on sp.id equals sbp.id
                                                   join tr in db.Tiers on sc.tiers_id equals tr.id
                                                   where tr.id == clientid
                                                   where sp.deleted == false
                                                   orderby sc.id descending
                                                   select sc.id).FirstOrDefault();

                return _savingscontractscountquery + 1;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 0;
            }
        }
        public decimal GetNextSavingContractId(int clientid, int contractid)
        {
            try
            {
                decimal _savingsbalance = 0;
                var _savingscontractscountquery = from se in db.SavingEvents
                                                  join sc in db.SavingContracts on se.contract_id equals sc.id
                                                  join sbc in db.SavingBookContracts on sc.id equals sbc.id
                                                  join sp in db.SavingProducts on sc.product_id equals sp.id
                                                  join sbp in db.SavingBookProducts on sp.id equals sbp.id
                                                  join tr in db.Tiers on sc.tiers_id equals tr.id
                                                  where tr.id == clientid
                                                  where se.contract_id == contractid
                                                  where sp.deleted == false
                                                  orderby sc.id descending
                                                  select se;
                _savingsbalance = _savingscontractscountquery.Sum(i => i.amount);
                return _savingsbalance;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 0;
            }
        }
        #endregion "SavingContracts and SavingBookContracts"
        #region "Statuses"
        public void AddNewStatus(StatusModel status)
        {
            try
            {
                Status _status = new Status();
                _status.status_name = status.status_name;

                db.Statuses.AddObject(_status);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateStatus(StatusModel status)
        {
            try
            {
                Status _status = db.Statuses.First(b => b.id == status.statusid);
                _status.status_name = status.status_name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteStatus(StatusModel status)
        {
            try
            {
                Status _status = db.Statuses.First(b => b.id == status.statusid);

                db.Statuses.DeleteObject(_status);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<StatusModel> GetAllStatuses()
        {
            try
            {
                List<StatusModel> _statuses = new List<StatusModel>();
                var _statusesquery = from br in db.Statuses
                                     select br;
                List<Status> _sttss = _statusesquery.ToList();
                foreach (var status in _sttss)
                {
                    StatusModel _status = new StatusModel();
                    _status.statusid = status.id;
                    _status.status_name = status.status_name;

                    _statuses.Add(_status);
                }

                return _statuses;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Statuses"
        #region "CollateralProducts"
        public void AddNewCollateralProduct(CollateralProductsModel collateralproduct)
        {
            try
            {
                CollateralProduct _collateralproduct = new CollateralProduct();
                _collateralproduct.name = collateralproduct.name;
                _collateralproduct.desc = collateralproduct.desc;
                _collateralproduct.deleted = collateralproduct.deleted;

                if (!db.CollateralProducts.Any(i => i.name == _collateralproduct.name))
                {
                    db.CollateralProducts.AddObject(_collateralproduct);
                    db.SaveChanges();
                }

                var _CollateralProductquery = (from s in db.CollateralProducts
                                               where s.name == collateralproduct.name
                                               where s.desc == collateralproduct.desc
                                               select s).FirstOrDefault();
                CollateralProduct _ColltrlProduct = _CollateralProductquery;

                if (_ColltrlProduct != null)
                {
                    foreach (var colprop in collateralproduct.productProperties)
                    {
                        CollateralPropertiesModel _collateralproperty = new CollateralPropertiesModel();
                        _collateralproperty.product_id = _ColltrlProduct.id;
                        _collateralproperty.type_id = colprop.type_id;
                        _collateralproperty.name = colprop.name;
                        _collateralproperty.desc = colprop.desc;
                        _collateralproperty.productname = _ColltrlProduct.name;

                        this.AddNewCollateralProperty(_collateralproperty);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCollateralProduct(CollateralProductsModel collateralproperty)
        {
            try
            {
                CollateralProduct _collateralproperty = db.CollateralProducts.First(b => b.id == collateralproperty.collateralproductid);
                _collateralproperty.name = collateralproperty.name;
                _collateralproperty.desc = collateralproperty.desc;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCollateralProduct(CollateralProductsModel collateralproperty)
        {
            try
            {
                CollateralProduct _collateralproperty = db.CollateralProducts.First(b => b.id == collateralproperty.collateralproductid);
                _collateralproperty.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CollateralProductsModel> GetAllCollateralProducts()
        {
            try
            {
                List<CollateralProductsModel> _advancedfields = new List<CollateralProductsModel>();
                var _collateralpropertiesquery = from br in db.CollateralProducts
                                                 select br;
                List<CollateralProduct> _clltrlprprts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprprts)
                {
                    CollateralProductsModel _collateralproperty = new CollateralProductsModel();
                    _collateralproperty.collateralproductid = collateralproperty.id;
                    _collateralproperty.name = collateralproperty.name;
                    _collateralproperty.desc = collateralproperty.desc;
                    _collateralproperty.deleted = collateralproperty.deleted;

                    _advancedfields.Add(_collateralproperty);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CollateralProductsModel> GetNonCollateralProducts()
        {
            try
            {
                List<CollateralProductsModel> _advancedfields = new List<CollateralProductsModel>();
                var _collateralpropertiesquery = from br in db.CollateralProducts
                                                 where br.deleted == false
                                                 select br;
                List<CollateralProduct> _clltrlprprts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprprts)
                {
                    CollateralProductsModel _collateralproperty = new CollateralProductsModel();
                    _collateralproperty.collateralproductid = collateralproperty.id;
                    _collateralproperty.name = collateralproperty.name;
                    _collateralproperty.desc = collateralproperty.desc;
                    _collateralproperty.deleted = collateralproperty.deleted;

                    _advancedfields.Add(_collateralproperty);
                }

                return _advancedfields;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CollateralProducts"
        #region "CollateralProperties"
        public void AddNewCollateralProperty(CollateralPropertiesModel collateralproperty)
        {
            try
            {
                switch (collateralproperty.type_id)
                {
                    case 4:
                        CollateralProperty _collateralproperty = new CollateralProperty();
                        _collateralproperty.product_id = collateralproperty.product_id;
                        _collateralproperty.type_id = collateralproperty.type_id;
                        _collateralproperty.name = collateralproperty.name;
                        _collateralproperty.desc = "";

                        if (!db.CollateralProperties.Any(i => i.product_id == _collateralproperty.product_id && i.type_id == _collateralproperty.type_id && i.name == _collateralproperty.name))
                        {
                            db.CollateralProperties.AddObject(_collateralproperty);
                            db.SaveChanges();
                        }

                        var _CollateralPropertiesquery = (from s in db.CollateralProperties
                                                          where s.product_id == collateralproperty.product_id
                                                          where s.name == collateralproperty.name
                                                          where s.type_id == collateralproperty.type_id
                                                          select s).FirstOrDefault();
                        CollateralProperty _ColltrlProperty = _CollateralPropertiesquery;

                        if (_ColltrlProperty != null)
                        {

                            char[] delimiters = new char[] { ' ', ';', ',', '\n', '\r' };
                            string[] collections = collateralproperty.desc.Split(delimiters);

                            foreach (string collection in collections)
                            {
                                if (!string.IsNullOrEmpty(collection) && !string.IsNullOrWhiteSpace(collection))
                                {
                                    CollateralPropertyCollectionsModel cpcm = new CollateralPropertyCollectionsModel();
                                    cpcm.value = collection;
                                    cpcm.property_id = _ColltrlProperty.id;
                                    cpcm.propertyname = _ColltrlProperty.name;

                                    this.AddNewCollateralPropertyCollection(cpcm);
                                }
                            }
                        }
                        break;
                    default:
                        CollateralProperty _clltrlproperty = new CollateralProperty();
                        _clltrlproperty.product_id = collateralproperty.product_id;
                        _clltrlproperty.type_id = collateralproperty.type_id;
                        _clltrlproperty.name = collateralproperty.name;
                        _clltrlproperty.desc = collateralproperty.desc;

                        if (!db.CollateralProperties.Any(i => i.product_id == _clltrlproperty.product_id && i.type_id == _clltrlproperty.type_id && i.name == _clltrlproperty.name))
                        {
                            db.CollateralProperties.AddObject(_clltrlproperty);
                            db.SaveChanges();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCollateralProperty(CollateralPropertiesModel collateralproperty)
        {
            try
            {
                CollateralProperty _collateralproperty = db.CollateralProperties.First(b => b.id == collateralproperty.collateralpropertyid);
                _collateralproperty.product_id = collateralproperty.product_id;
                _collateralproperty.type_id = collateralproperty.type_id;
                _collateralproperty.name = collateralproperty.name;
                _collateralproperty.desc = collateralproperty.desc;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCollateralProperty(CollateralPropertiesModel collateralproperty)
        {
            try
            {
                CollateralProperty _collateralproperty = db.CollateralProperties.First(b => b.id == collateralproperty.collateralpropertyid);
                switch (collateralproperty.type_id)
                {
                    case 4:
                        var _CollateralPropertyCollectionsquery = from s in db.CollateralPropertyCollections
                                                                  where s.property_id == collateralproperty.collateralpropertyid
                                                                  select new CollateralPropertyCollectionsModel
                                                                  {
                                                                      property_id = s.property_id,
                                                                      value = s.value
                                                                  };
                        List<CollateralPropertyCollectionsModel> _CollateralPropertyCollections = _CollateralPropertyCollectionsquery.ToList();
                        foreach (var ClltrlPrprtyCllctns in _CollateralPropertyCollections)
                        {
                            this.DeleteCollateralPropertyCollection(ClltrlPrprtyCllctns);
                        }

                        db.CollateralProperties.DeleteObject(_collateralproperty);
                        db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                        break;
                    default:
                        db.CollateralProperties.DeleteObject(_collateralproperty);
                        db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CollateralPropertiesModel> GetAllCollateralProperties()
        {
            try
            {
                List<CollateralPropertiesModel> _collateralproperties = new List<CollateralPropertiesModel>();
                var _collateralpropertiesquery = from br in db.CollateralProperties
                                                 select br;
                List<CollateralProperty> _clltrlprpts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprpts)
                {
                    CollateralPropertiesModel _collateralproperty = new CollateralPropertiesModel();
                    _collateralproperty.collateralpropertyid = collateralproperty.id;
                    _collateralproperty.product_id = collateralproperty.product_id;
                    _collateralproperty.type_id = collateralproperty.type_id;
                    _collateralproperty.name = collateralproperty.name;
                    _collateralproperty.desc = collateralproperty.desc;

                    _collateralproperties.Add(_collateralproperty);
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CollateralPropertiesModel> GetAllCollateralProductProperties(int productid)
        {
            try
            {
                List<CollateralPropertiesModel> _collateralproperties = new List<CollateralPropertiesModel>();
                var _collateralpropertiesquery = from br in db.CollateralProperties
                                                 where br.product_id == productid
                                                 select br;
                List<CollateralProperty> _clltrlprpts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprpts)
                {
                    CollateralPropertiesModel _collateralproperty = new CollateralPropertiesModel();
                    _collateralproperty.collateralpropertyid = collateralproperty.id;
                    _collateralproperty.product_id = collateralproperty.product_id;
                    _collateralproperty.type_id = collateralproperty.type_id;
                    _collateralproperty.name = collateralproperty.name;
                    _collateralproperty.desc = collateralproperty.desc;

                    _collateralproperties.Add(_collateralproperty);
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CollateralPropertiesModel> GetCollateralProductPropertiesforProduct(int productid)
        {
            try
            {
                List<CollateralPropertiesModel> _collateralproperties = new List<CollateralPropertiesModel>();
                var _collateralpropertiesquery = from br in db.CollateralProperties
                                                 where br.product_id == productid
                                                 select new CollateralPropertiesModel
                                                 {
                                                     collateralpropertyid = br.id,
                                                     desc = br.desc,
                                                     name = br.name,
                                                     product_id = br.product_id,
                                                     type_id = br.type_id
                                                 };
                _collateralproperties = _collateralpropertiesquery.ToList();
                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CollateralPropertiesModel> GetCollateralPropertiesWithCollectionItems(int productid)
        {
            try
            {
                List<CollateralPropertiesModel> _collateralproperties = new List<CollateralPropertiesModel>();
                var _collateralpropertiesquery = from br in db.CollateralProperties
                                                 where br.product_id == productid
                                                 select br;
                List<CollateralProperty> _clltrlprpts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprpts)
                {
                    switch (collateralproperty.type_id)
                    {
                        case 4:
                            CollateralPropertiesModel _colltrlproperty = new CollateralPropertiesModel();
                            _colltrlproperty.collateralpropertyid = collateralproperty.id;
                            _colltrlproperty.product_id = collateralproperty.product_id;
                            _colltrlproperty.type_id = collateralproperty.type_id;
                            _colltrlproperty.name = collateralproperty.name;
                            _colltrlproperty.desc = this.GetPropertyCollectionItems(collateralproperty.id);

                            _collateralproperties.Add(_colltrlproperty);
                            break;
                        default:
                            CollateralPropertiesModel _collateralproperty = new CollateralPropertiesModel();
                            _collateralproperty.collateralpropertyid = collateralproperty.id;
                            _collateralproperty.product_id = collateralproperty.product_id;
                            _collateralproperty.type_id = collateralproperty.type_id;
                            _collateralproperty.name = collateralproperty.name;
                            _collateralproperty.desc = collateralproperty.desc;

                            _collateralproperties.Add(_collateralproperty);
                            break;
                    }
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public int GetCollateralLinkContractid(int contractid)
        {
            try
            {
                var colcontidquery = (from lk in db.CollateralsLinkContracts
                                      where lk.contract_id == contractid
                                      select lk).FirstOrDefault();
                return colcontidquery.id;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 0;
            }
        }
        #endregion "CollateralProperties"
        #region "CollateralPropertyCollections"
        public void AddNewCollateralPropertyCollection(CollateralPropertyCollectionsModel collateralproperty)
        {
            try
            {
                CollateralPropertyCollection _collateralproperty = new CollateralPropertyCollection();
                _collateralproperty.property_id = collateralproperty.property_id;
                _collateralproperty.value = collateralproperty.value;

                if (!db.CollateralPropertyCollections.Any(i => i.property_id == collateralproperty.property_id && i.value == collateralproperty.value))
                {
                    db.CollateralPropertyCollections.AddObject(_collateralproperty);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCollateralPropertyCollection(CollateralPropertyCollectionsModel collateralproperty)
        {
            try
            {
                CollateralPropertyCollection _collateralproperty = db.CollateralPropertyCollections.First(b => b.property_id == collateralproperty.property_id);
                _collateralproperty.value = collateralproperty.value;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCollateralPropertyCollection(CollateralPropertyCollectionsModel collateralproperty)
        {
            try
            {
                CollateralPropertyCollection _collateralproperty = db.CollateralPropertyCollections.First(b => b.property_id == collateralproperty.property_id);

                db.CollateralPropertyCollections.DeleteObject(_collateralproperty);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CollateralPropertyCollectionsModel> GetAllCollateralPropertyCollections()
        {
            try
            {
                List<CollateralPropertyCollectionsModel> _collateralproperties = new List<CollateralPropertyCollectionsModel>();
                var _collateralpropertiesquery = from br in db.CollateralPropertyCollections
                                                 select br;
                List<CollateralPropertyCollection> _clltrlprprts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprprts)
                {
                    CollateralPropertyCollectionsModel _collateralproperty = new CollateralPropertyCollectionsModel();
                    _collateralproperty.property_id = collateralproperty.property_id;
                    _collateralproperty.value = collateralproperty.value;

                    _collateralproperties.Add(_collateralproperty);
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public string GetPropertyCollectionItems(int property_id)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                var _CollateralPropertyCollectionsquery = from br in db.CollateralPropertyCollections
                                                          where br.property_id == property_id
                                                          select br;
                List<CollateralPropertyCollection> _cols = _CollateralPropertyCollectionsquery.ToList();
                foreach (var advancedfield in _cols)
                {
                    sb.Append(advancedfield.value + ", ");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CollateralPropertyCollectionsModel> GetCollateralPropertyCollectionItemsList(int propertyid)
        {
            try
            {
                List<CollateralPropertyCollectionsModel> _collateralproperties = new List<CollateralPropertyCollectionsModel>();
                var _collateralpropertiesquery = from br in db.CollateralPropertyCollections
                                                 where br.property_id == propertyid
                                                 select br;
                List<CollateralPropertyCollection> _clltrlprprts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprprts)
                {
                    CollateralPropertyCollectionsModel _collateralproperty = new CollateralPropertyCollectionsModel();
                    _collateralproperty.property_id = collateralproperty.property_id;
                    _collateralproperty.value = collateralproperty.value;

                    _collateralproperties.Add(_collateralproperty);
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CollateralPropertyCollections"
        #region "CollateralPropertyTypes"
        public void AddNewCollateralPropertyType(CollateralPropertyTypesModel collateralproperty)
        {
            try
            {
                CollateralPropertyType _collateralproperty = new CollateralPropertyType();
                _collateralproperty.name = collateralproperty.name;

                db.CollateralPropertyTypes.AddObject(_collateralproperty);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCollateralPropertyType(CollateralPropertyTypesModel collateralproperty)
        {
            try
            {
                CollateralPropertyType _collateralproperty = db.CollateralPropertyTypes.First(b => b.id == collateralproperty.collateralpropertytypeid);
                _collateralproperty.name = collateralproperty.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCollateralPropertyType(CollateralPropertyTypesModel collateralproperty)
        {
            try
            {
                CollateralPropertyType _collateralproperty = db.CollateralPropertyTypes.First(b => b.id == collateralproperty.collateralpropertytypeid);

                db.CollateralPropertyTypes.DeleteObject(_collateralproperty);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CollateralPropertyTypesModel> GetAllCollateralPropertyTypes()
        {
            try
            {
                List<CollateralPropertyTypesModel> _collateralproperties = new List<CollateralPropertyTypesModel>();
                var _collateralpropertiesquery = from br in db.CollateralPropertyTypes
                                                 select br;
                List<CollateralPropertyType> _clltrlprprts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprprts)
                {
                    CollateralPropertyTypesModel _collateralproperty = new CollateralPropertyTypesModel();
                    _collateralproperty.collateralpropertytypeid = collateralproperty.id;
                    _collateralproperty.name = collateralproperty.name;

                    _collateralproperties.Add(_collateralproperty);
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public string GetCollateralPropertyTypeName(int collateraltypeid)
        {
            try
            {
                CollateralPropertyType _collateralpropertyquery = (from aft in db.CollateralPropertyTypes
                                                                   where aft.id == collateraltypeid
                                                                   select aft).FirstOrDefault();

                return _collateralpropertyquery.name;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CollateralPropertyTypes"
        #region "CollateralPropertyValues"
        public void AddNewCollateralPropertyValue(CollateralPropertyValuesModel collateralproperty)
        {
            try
            {
                CollateralPropertyValue _collateralproperty = new CollateralPropertyValue();
                _collateralproperty.contract_collateral_id = collateralproperty.contract_collateral_id;
                _collateralproperty.property_id = collateralproperty.property_id;
                _collateralproperty.value = collateralproperty.value;

                db.CollateralPropertyValues.AddObject(_collateralproperty);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCollateralPropertyValue(CollateralPropertyValuesModel collateralproperty)
        {
            try
            {
                CollateralPropertyValue _collateralproperty = db.CollateralPropertyValues.First(b => b.id == collateralproperty.collateralpropertyvalueid);
                _collateralproperty.contract_collateral_id = collateralproperty.contract_collateral_id;
                _collateralproperty.property_id = collateralproperty.property_id;
                _collateralproperty.value = collateralproperty.value;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCollateralPropertyValue(CollateralPropertyValuesModel collateralproperty)
        {
            try
            {
                CollateralPropertyValue _collateralproperty = db.CollateralPropertyValues.First(b => b.id == collateralproperty.collateralpropertyvalueid);

                db.CollateralPropertyValues.DeleteObject(_collateralproperty);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CollateralPropertyValuesModel> GetAllCollateralPropertyValues()
        {
            try
            {
                List<CollateralPropertyValuesModel> _collateralproperties = new List<CollateralPropertyValuesModel>();
                var _collateralpropertiesquery = from br in db.CollateralPropertyValues
                                                 select br;
                List<CollateralPropertyValue> _clltrlprprts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprprts)
                {
                    CollateralPropertyValuesModel _collateralproperty = new CollateralPropertyValuesModel();
                    _collateralproperty.collateralpropertyvalueid = collateralproperty.id;
                    _collateralproperty.contract_collateral_id = collateralproperty.contract_collateral_id;
                    _collateralproperty.property_id = collateralproperty.property_id;
                    _collateralproperty.value = collateralproperty.value;

                    _collateralproperties.Add(_collateralproperty);
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CollateralPropertyValuesModel> GetCollateralPropertyValues(int productid)
        {
            try
            {
                List<CollateralPropertyValuesModel> _collateralproperties = new List<CollateralPropertyValuesModel>();
                var _collateralpropertiesquery = from cpv in db.CollateralPropertyValues
                                                 join cp in db.CollateralProperties on cpv.property_id equals cp.id
                                                 join cpr in db.CollateralProducts on cp.product_id equals cpr.id
                                                 where cpr.id == productid
                                                 select new CollateralPropertyValuesModel
                                                 {
                                                     collateralpropertyid = cp.id,
                                                     desc = cp.desc,
                                                     name = cp.name,
                                                     product_id = cpr.id,
                                                     productname = cpr.name,
                                                     property_desc = cp.desc,
                                                     property_name = cp.name,
                                                     type_id = cp.type_id,
                                                     value = cpv.value,
                                                     contract_collateral_id = cpv.contract_collateral_id,
                                                     property_id = cpv.property_id,
                                                     collateralpropertyvalueid = cpv.id
                                                 };
                _collateralproperties = _collateralpropertiesquery.ToList();

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CollateralPropertyValuesModel> GetCollateralPropertyValuesforContract(int contractid, int _productid)
        {
            try
            {
                List<CollateralPropertyValuesModel> _collateralproperties = new List<CollateralPropertyValuesModel>();
                var _collateralpropertyvaluesquery = from cpv in db.CollateralPropertyValues
                                                     join clc in db.CollateralsLinkContracts on cpv.contract_collateral_id equals clc.id
                                                     join cp in db.CollateralProperties on cpv.property_id equals cp.id
                                                     join cpt in db.CollateralProducts on cp.product_id equals cpt.id
                                                     where clc.contract_id == contractid
                                                     where cpt.id == _productid
                                                     select new CollateralPropertyValuesModel
                                                     {
                                                         collateralpropertyvalueid = cpv.id,
                                                         contract_collateral_id = cpv.contract_collateral_id,
                                                         property_id = cp.id,
                                                         type_id = cp.type_id,
                                                         value = cpv.value,
                                                         property_desc = cp.desc,
                                                         property_name = cp.name
                                                     };
                _collateralproperties = _collateralpropertyvaluesquery.ToList();

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<ClientContractCollateralsModel> GetCollateralPropertyValuesforContract(int contractid)
        {
            try
            {
                List<ClientContractCollateralsModel> _collateralproperties = new List<ClientContractCollateralsModel>();
                var _collateralpropertyvaluesquery = from cpt in db.CollateralProducts
                                                     join cpp in db.CollateralProperties on cpt.id equals cpp.product_id
                                                     join cpv in db.CollateralPropertyValues on cpp.id equals cpv.property_id
                                                     join ctpt in db.CollateralPropertyTypes on cpp.type_id equals ctpt.id
                                                     join clc in db.CollateralsLinkContracts on cpv.contract_collateral_id equals clc.id
                                                     where clc.contract_id == contractid
                                                     select new ClientContractCollateralsModel
                                                     {
                                                         collateralpropertyvalueid = cpv.id,
                                                         contract_collateral_id = cpv.contract_collateral_id,
                                                         property_id = cpp.id,
                                                         type_id = cpp.type_id,
                                                         value = cpv.value,
                                                         property_desc = cpp.desc,
                                                         property_name = cpp.name,
                                                         contract_id = clc.contract_id,
                                                         deleted = cpt.deleted,
                                                         product_desc = cpt.desc,
                                                         product_id = cpp.product_id,
                                                         product_name = cpt.name
                                                     };
                _collateralproperties = _collateralpropertyvaluesquery.ToList();
                int _rowid = 1;
                foreach (var collateralproperty in _collateralproperties)
                {
                    collateralproperty.clientcontractcollateralid = _rowid;
                    _rowid++;
                }
                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CollateralPropertyValues"
        #region "CollateralsLinkContracts"
        public void AddNewCollateralsLinkContract(CollateralsLinkContractsModel collateralproperty)
        {
            try
            {
                CollateralsLinkContract _collateralproperty = new CollateralsLinkContract();
                _collateralproperty.contract_id = collateralproperty.contract_id;

                db.CollateralsLinkContracts.AddObject(_collateralproperty);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCollateralsLinkContract(CollateralsLinkContractsModel collateralproperty)
        {
            try
            {
                CollateralsLinkContract _collateralproperty = db.CollateralsLinkContracts.First(b => b.id == collateralproperty.collaterallinkscontractid);
                _collateralproperty.contract_id = collateralproperty.contract_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCollateralsLinkContract(CollateralsLinkContractsModel collateralproperty)
        {
            try
            {
                CollateralsLinkContract _collateralproperty = db.CollateralsLinkContracts.First(b => b.id == collateralproperty.collaterallinkscontractid);

                db.CollateralsLinkContracts.DeleteObject(_collateralproperty);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CollateralsLinkContractsModel> GetAllCollateralsLinkContracts()
        {
            try
            {
                List<CollateralsLinkContractsModel> _collateralproperties = new List<CollateralsLinkContractsModel>();
                var _collateralpropertiesquery = from br in db.CollateralsLinkContracts
                                                 select br;
                List<CollateralsLinkContract> _clltrlprprts = _collateralpropertiesquery.ToList();
                foreach (var collateralproperty in _clltrlprprts)
                {
                    CollateralsLinkContractsModel _collateralproperty = new CollateralsLinkContractsModel();
                    _collateralproperty.collaterallinkscontractid = collateralproperty.id;
                    _collateralproperty.contract_id = collateralproperty.contract_id;

                    _collateralproperties.Add(_collateralproperty);
                }

                return _collateralproperties;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CollateralsLinkContracts"
        #region "EntryFees"
        public void AddNewEntryFee(EntryFeesModel entryfee)
        {
            try
            {
                EntryFee _entryfee = new EntryFee();
                _entryfee.id_product = entryfee.id_product;
                _entryfee.name_of_fee = entryfee.name_of_fee;
                _entryfee.min = entryfee.min;
                _entryfee.max = entryfee.max;
                _entryfee.value = entryfee.value;
                _entryfee.rate = entryfee.rate;
                _entryfee.is_deleted = entryfee.is_deleted;
                _entryfee.fee_index = entryfee.fee_index;
                _entryfee.cycle_id = entryfee.cycle_id;

                db.EntryFees.AddObject(_entryfee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateEntryFee(EntryFeesModel entryfee)
        {
            try
            {
                EntryFee _entryfee = db.EntryFees.First(b => b.id == entryfee.entryfeeid);
                _entryfee.id_product = entryfee.id_product;
                _entryfee.name_of_fee = entryfee.name_of_fee;
                _entryfee.min = entryfee.min;
                _entryfee.max = entryfee.max;
                _entryfee.value = entryfee.value;
                _entryfee.rate = entryfee.rate;
                _entryfee.is_deleted = entryfee.is_deleted;
                _entryfee.fee_index = entryfee.fee_index;
                _entryfee.cycle_id = entryfee.cycle_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteEntryFee(EntryFeesModel entryfee)
        {
            try
            {
                EntryFee _entryfee = db.EntryFees.First(b => b.id == entryfee.entryfeeid);

                db.EntryFees.DeleteObject(_entryfee);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<EntryFeesModel> GetAllEntryFees()
        {
            try
            {
                List<EntryFeesModel> _entryfees = new List<EntryFeesModel>();
                var _entryfeesquery = from br in db.EntryFees
                                      select br;
                List<EntryFee> _ntryfs = _entryfeesquery.ToList();
                foreach (var entryfee in _ntryfs)
                {
                    EntryFeesModel _entryfee = new EntryFeesModel();
                    _entryfee.entryfeeid = entryfee.id;
                    _entryfee.id_product = entryfee.id_product;
                    _entryfee.name_of_fee = entryfee.name_of_fee;
                    _entryfee.min = entryfee.min;
                    _entryfee.max = entryfee.max;
                    _entryfee.value = entryfee.value;
                    if (entryfee.value == null)
                    {
                        _entryfee.value = entryfee.min;
                    }
                    _entryfee.rate = entryfee.rate;
                    _entryfee.is_deleted = entryfee.is_deleted;
                    _entryfee.fee_index = entryfee.fee_index;
                    _entryfee.cycle_id = entryfee.cycle_id;

                    _entryfees.Add(_entryfee);
                }

                return _entryfees;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<EntryFeesModel> GetPackageEntryFees(int _package_id)
        {
            try
            {
                List<EntryFeesModel> _entryfees = new List<EntryFeesModel>();
                var _entryfeesquery = from ef in db.EntryFees
                                      join pk in db.Packages on ef.id_product equals pk.id
                                      where ef.is_deleted == false
                                      where pk.id == _package_id
                                      select ef;
                List<EntryFee> _ntryfs = _entryfeesquery.ToList();
                foreach (var entryfee in _ntryfs)
                {
                    EntryFeesModel _entryfee = new EntryFeesModel();
                    _entryfee.entryfeeid = entryfee.id;
                    _entryfee.id_product = entryfee.id_product;
                    _entryfee.name_of_fee = entryfee.name_of_fee;
                    _entryfee.min = entryfee.min;
                    _entryfee.max = entryfee.max;
                    _entryfee.value = entryfee.value;
                    _entryfee.rate = entryfee.rate;
                    _entryfee.is_deleted = entryfee.is_deleted;
                    _entryfee.fee_index = entryfee.fee_index;
                    _entryfee.cycle_id = entryfee.cycle_id;

                    _entryfees.Add(_entryfee);
                }

                return _entryfees;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "EntryFees"
        #region "CreditEntryFees"
        public void AddNewCreditEntryFee(CreditEntryFeesModel entryfee)
        {
            try
            {
                CreditEntryFee _entryfee = new CreditEntryFee();
                _entryfee.credit_id = entryfee.credit_id;
                _entryfee.entry_fee_id = entryfee.entry_fee_id;
                _entryfee.fee_value = entryfee.fee_value;

                if (!db.CreditEntryFees.Any(i => i.credit_id == _entryfee.credit_id && i.entry_fee_id == _entryfee.entry_fee_id))
                {
                    db.CreditEntryFees.AddObject(_entryfee);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCreditEntryFee(CreditEntryFeesModel entryfee)
        {
            try
            {
                CreditEntryFee _entryfee = db.CreditEntryFees.First(b => b.id == entryfee.creditentryfeeid);
                _entryfee.credit_id = entryfee.credit_id;
                _entryfee.entry_fee_id = entryfee.entry_fee_id;
                _entryfee.fee_value = entryfee.fee_value;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCreditEntryFee(CreditEntryFeesModel entryfee)
        {
            try
            {
                CreditEntryFee _entryfee = db.CreditEntryFees.First(b => b.id == entryfee.creditentryfeeid);

                db.CreditEntryFees.DeleteObject(_entryfee);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CreditEntryFeesModel> GetAllCreditEntryFees()
        {
            try
            {
                List<CreditEntryFeesModel> _entryfees = new List<CreditEntryFeesModel>();
                var _entryfeesquery = from br in db.CreditEntryFees
                                      select br;
                List<CreditEntryFee> _ntryfs = _entryfeesquery.ToList();
                foreach (var entryfee in _ntryfs)
                {
                    CreditEntryFeesModel _entryfee = new CreditEntryFeesModel();
                    _entryfee.creditentryfeeid = entryfee.id;
                    _entryfee.credit_id = entryfee.credit_id;
                    _entryfee.entry_fee_id = entryfee.entry_fee_id;
                    _entryfee.fee_value = entryfee.fee_value;

                    _entryfees.Add(_entryfee);
                }

                return _entryfees;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CreditEntryFeesModel> GetLoanPackageEntryFees(int _package_id)
        {
            try
            {
                List<CreditEntryFeesModel> _entryfees = new List<CreditEntryFeesModel>();
                var _entryfeesquery = from ef in db.EntryFees
                                      join pk in db.Packages on ef.id_product equals pk.id
                                      where ef.is_deleted == false
                                      where pk.id == _package_id
                                      select ef;
                List<EntryFee> _ntryfs = _entryfeesquery.ToList();
                foreach (var entryfee in _ntryfs)
                {
                    CreditEntryFeesModel _entryfee = new CreditEntryFeesModel();
                    _entryfee.entryfeeid = entryfee.id;
                    _entryfee.id_product = entryfee.id_product;
                    _entryfee.name_of_fee = entryfee.name_of_fee;
                    _entryfee.min = entryfee.min;
                    _entryfee.max = entryfee.max;
                    _entryfee.value = entryfee.value;
                    _entryfee.rate = entryfee.rate;
                    _entryfee.is_deleted = entryfee.is_deleted;
                    _entryfee.fee_index = entryfee.fee_index;
                    _entryfee.cycle_id = entryfee.cycle_id;

                    _entryfees.Add(_entryfee);
                }

                return _entryfees;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CreditEntryFeesModel> GetLoanCreditEntryFees(int creditid)
        {
            try
            {
                var _entryfeesquery = from ce in db.CreditEntryFees
                                      join ef in db.EntryFees on ce.entry_fee_id equals ef.id
                                      join cr in db.Credits on ce.credit_id equals cr.id
                                      where ce.credit_id == creditid
                                      select new CreditEntryFeesModel
                                      {
                                          creditentryfeeid = ce.id,
                                          name_of_fee = ef.name_of_fee,
                                          credit_id = ce.credit_id,
                                          entry_fee_id = ce.entry_fee_id,
                                          fee_index = ef.fee_index,
                                          max = ef.max,
                                          min = ef.min,
                                          rate = ef.rate,
                                          value = ef.value,
                                          fee_value = ce.fee_value
                                      };
                List<CreditEntryFeesModel> _entryfees = _entryfeesquery.ToList();
                return _entryfees;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CreditEntryFees"
        #region "Setting"
        public string SettingLookup(string Key)
        {
            try
            {
                var setting = db.Settings.FirstOrDefault(s => s.SSKey == Key);
                if (setting != null)
                    return setting.SSValue;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<Setting> GetSettings()
        {
            try
            {
                return db.Settings.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public void EditSetting(DAL.Setting setting, string ssvalue)
        {
            try
            {
                Setting _setting = db.Settings.First(s => s.SSKey == setting.SSKey);
                _setting.SSValue = ssvalue;

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<SettingsGroup> GetSettingsGroup()
        {
            try
            {
                return db.SettingsGroups.Include("Settings").ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Setting"
        #region "LoansLinkSavingsBooks"
        public void AddNewLoansLinkSavingsBook(LoansLinkSavingsBookModel loanslinksaving)
        {
            try
            {
                LoansLinkSavingsBook _loanslinksaving = new LoansLinkSavingsBook();
                _loanslinksaving.loan_id = loanslinksaving.loan_id;
                _loanslinksaving.savings_id = loanslinksaving.savings_id;
                _loanslinksaving.loan_percentage = loanslinksaving.loan_percentage;

                if (!db.LoansLinkSavingsBooks.Any(i => i.loan_id == _loanslinksaving.loan_id && i.savings_id == _loanslinksaving.savings_id))
                {
                    db.LoansLinkSavingsBooks.AddObject(_loanslinksaving);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateLoansLinkSavingsBook(LoansLinkSavingsBookModel loanslinksaving)
        {
            try
            {
                LoansLinkSavingsBook _loanslinksaving = db.LoansLinkSavingsBooks.First(b => b.loan_id == loanslinksaving.loan_id);
                _loanslinksaving.savings_id = loanslinksaving.savings_id;
                _loanslinksaving.loan_percentage = loanslinksaving.loan_percentage;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteLoansLinkSavingsBook(LoansLinkSavingsBookModel loanslinksaving)
        {
            try
            {
                LoansLinkSavingsBook _loanslinksaving = db.LoansLinkSavingsBooks.First(b => b.id == loanslinksaving.loanlinksavingid);

                db.LoansLinkSavingsBooks.DeleteObject(_loanslinksaving);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<LoansLinkSavingsBookModel> GetAllLoansLinkSavingsBooks()
        {
            try
            {
                List<LoansLinkSavingsBookModel> _loanslinksavings = new List<LoansLinkSavingsBookModel>();
                var _loanslinksavingsquery = from br in db.LoansLinkSavingsBooks
                                             select br;
                List<LoansLinkSavingsBook> _lnscls = _loanslinksavingsquery.ToList();
                foreach (var loanslinksavings in _lnscls)
                {
                    LoansLinkSavingsBookModel _loanslinksaving = new LoansLinkSavingsBookModel();
                    _loanslinksaving.loanlinksavingid = loanslinksavings.id;
                    _loanslinksaving.loan_id = loanslinksavings.loan_id;
                    _loanslinksaving.savings_id = loanslinksavings.savings_id;
                    _loanslinksaving.loan_percentage = loanslinksavings.loan_percentage;

                    _loanslinksavings.Add(_loanslinksaving);
                }

                return _loanslinksavings;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "LoansLinkSavingsBooks"
        #region "SavingEvents"
        public void AddNewSavingsContractEvent(SavingsEventsModel savingmodel)
        {
            try
            {
                SavingEvent _savingsevent = new SavingEvent();
                _savingsevent.user_id = savingmodel.user_id;
                _savingsevent.contract_id = savingmodel.contract_id;
                _savingsevent.code = savingmodel.code;
                _savingsevent.amount = savingmodel.amount;
                _savingsevent.description = savingmodel.description;
                _savingsevent.deleted = savingmodel.deleted;
                _savingsevent.creation_date = savingmodel.creation_date;
                _savingsevent.cancelable = savingmodel.cancelable;
                _savingsevent.is_fired = savingmodel.is_fired;
                _savingsevent.related_contract_code = savingmodel.related_contract_code;
                _savingsevent.fees = savingmodel.fees;
                _savingsevent.is_exported = savingmodel.is_exported;
                _savingsevent.savings_method = savingmodel.savings_method;
                _savingsevent.pending = savingmodel.pending;
                _savingsevent.pending_event_id = savingmodel.pending_event_id;
                _savingsevent.teller_id = savingmodel.teller_id;
                _savingsevent.loan_event_id = savingmodel.loan_event_id;
                _savingsevent.cancel_date = savingmodel.cancel_date;

                db.SavingEvents.AddObject(_savingsevent);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSavingsContractEvent(SavingsEventsModel savingmodel)
        {
            try
            {
                SavingEvent _savingsevent = db.SavingEvents.First(b => b.id == savingmodel.savingseventid);
                _savingsevent.user_id = savingmodel.user_id;
                _savingsevent.contract_id = savingmodel.contract_id;
                _savingsevent.code = savingmodel.code;
                _savingsevent.amount = savingmodel.amount;
                _savingsevent.description = savingmodel.description;
                _savingsevent.deleted = savingmodel.deleted;
                _savingsevent.creation_date = savingmodel.creation_date;
                _savingsevent.cancelable = savingmodel.cancelable;
                _savingsevent.is_fired = savingmodel.is_fired;
                _savingsevent.related_contract_code = savingmodel.related_contract_code;
                _savingsevent.fees = savingmodel.fees;
                _savingsevent.is_exported = savingmodel.is_exported;
                _savingsevent.savings_method = savingmodel.savings_method;
                _savingsevent.pending = savingmodel.pending;
                _savingsevent.pending_event_id = savingmodel.pending_event_id;
                _savingsevent.teller_id = savingmodel.teller_id;
                _savingsevent.loan_event_id = savingmodel.loan_event_id;
                _savingsevent.cancel_date = savingmodel.cancel_date;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateSavingsContractEventPending(SavingsEventsModel savingmodel)
        {
            try
            {
                SavingEvent _savingsevent = db.SavingEvents.First(b => b.id == savingmodel.savingseventid);
                _savingsevent.pending = savingmodel.pending;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteSavingsContractEvent(SavingsEventsModel savingmodel)
        {
            try
            {
                SavingEvent _savingsevent = db.SavingEvents.Where(i => i.id == savingmodel.savingseventid).Single();
                _savingsevent.deleted = true;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<SavingsEventsModel> GetSavingsContractEvents(int contract_id)
        {
            try
            {
                var _savingseventsquery = from se in db.SavingEvents
                                          join sc in db.SavingContracts on se.contract_id equals sc.id
                                          join sbc in db.SavingBookContracts on sc.id equals sbc.id
                                          join sp in db.SavingProducts on sc.product_id equals sp.id
                                          join sbp in db.SavingBookProducts on sp.id equals sbp.id
                                          join tr in db.Tiers on sc.tiers_id equals tr.id
                                          where se.contract_id == contract_id
                                          select new SavingsEventsModel
                                          {
                                              amount = se.amount,
                                              cancel_date = se.cancel_date,
                                              cancelable = se.cancelable,
                                              code = se.code,
                                              contract_id = se.contract_id,
                                              creation_date = se.creation_date,
                                              deleted = se.deleted,
                                              description = se.description,
                                              fees = se.fees,
                                              is_exported = se.is_exported,
                                              is_fired = se.is_fired,
                                              loan_event_id = se.loan_event_id,
                                              pending = se.pending,
                                              pending_event_id = se.pending_event_id,
                                              related_contract_code = se.related_contract_code,
                                              savings_method = se.savings_method,
                                              savingseventid = se.id,
                                              teller_id = se.teller_id,
                                              user_id = se.user_id
                                          };

                return _savingseventsquery.ToList();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "SavingEvents"
        #region "Cycles"
        public void AddNewCycle(CyclesModel cycle)
        {
            try
            {
                Cycle _cycle = new Cycle();
                _cycle.name = cycle.name;

                db.Cycles.AddObject(_cycle);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCycle(CyclesModel cycle)
        {
            try
            {
                Cycle _cycle = db.Cycles.First(b => b.id == cycle.cycleid);
                _cycle.name = cycle.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCycle(CyclesModel cycle)
        {
            try
            {
                Cycle _cycle = db.Cycles.First(b => b.id == cycle.cycleid);

                db.Cycles.DeleteObject(_cycle);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CyclesModel> GetAllCycles()
        {
            try
            {
                List<CyclesModel> _cycles = new List<CyclesModel>();
                var _cyclesquery = from br in db.Cycles
                                   select br;
                List<Cycle> _cycls = _cyclesquery.ToList();
                foreach (var cycle in _cycls)
                {
                    CyclesModel _cycle = new CyclesModel();
                    _cycle.cycleid = cycle.id;
                    _cycle.name = cycle.name;

                    _cycles.Add(_cycle);
                }

                return _cycles;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Cycles"
        #region "CycleObjects"
        public void AddNewCycleObject(CycleObjectsModel cycle)
        {
            try
            {
                CycleObject _cycle = new CycleObject();
                _cycle.name = cycle.name;

                db.CycleObjects.AddObject(_cycle);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCycleObject(CycleObjectsModel cycle)
        {
            try
            {
                CycleObject _cycle = db.CycleObjects.First(b => b.id == cycle.cycleobjectid);
                _cycle.name = cycle.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCycleObject(CycleObjectsModel cycle)
        {
            try
            {
                CycleObject _cycle = db.CycleObjects.First(b => b.id == cycle.cycleobjectid);

                db.CycleObjects.DeleteObject(_cycle);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CycleObjectsModel> GetAllCycleObjects()
        {
            try
            {
                List<CycleObjectsModel> _cycles = new List<CycleObjectsModel>();
                var _cyclesquery = from br in db.CycleObjects
                                   select br;
                List<CycleObject> _cycls = _cyclesquery.ToList();
                foreach (var cycle in _cycls)
                {
                    CycleObjectsModel _cycle = new CycleObjectsModel();
                    _cycle.cycleobjectid = cycle.id;
                    _cycle.name = cycle.name;

                    _cycles.Add(_cycle);
                }

                return _cycles;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CycleObjects"
        #region "CycleParameters"
        public void AddNewCycleParameter(CycleParametersModel cycle)
        {
            try
            {
                CycleParameter _cycle = new CycleParameter();
                _cycle.loan_cycle = cycle.loan_cycle;
                _cycle.min = cycle.min;
                _cycle.max = cycle.max;
                _cycle.cycle_object_id = cycle.cycle_object_id;
                _cycle.cycle_id = cycle.cycle_id;

                db.CycleParameters.AddObject(_cycle);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCycleParameter(CycleParametersModel cycle)
        {
            try
            {
                CycleParameter _cycle = db.CycleParameters.First(b => b.id == cycle.cycleparameterid);
                _cycle.loan_cycle = cycle.loan_cycle;
                _cycle.min = cycle.min;
                _cycle.max = cycle.max;
                _cycle.cycle_object_id = cycle.cycle_object_id;
                _cycle.cycle_id = cycle.cycle_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCycleParameter(CycleParametersModel cycle)
        {
            try
            {
                CycleParameter _cycle = db.CycleParameters.First(b => b.id == cycle.cycleparameterid);

                db.CycleParameters.DeleteObject(_cycle);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<CycleParametersModel> GetAllCycleParameters()
        {
            try
            {
                List<CycleParametersModel> _cycles = new List<CycleParametersModel>();
                var _cyclesquery = from br in db.CycleParameters
                                   select br;
                List<CycleParameter> _cycls = _cyclesquery.ToList();
                foreach (var cycle in _cycls)
                {
                    CycleParametersModel _cycle = new CycleParametersModel();
                    _cycle.cycleparameterid = cycle.id;
                    _cycle.loan_cycle = cycle.loan_cycle;
                    _cycle.min = cycle.min;
                    _cycle.max = cycle.max;
                    _cycle.cycle_object_id = cycle.cycle_object_id;
                    _cycle.cycle_id = cycle.cycle_id;

                    _cycles.Add(_cycle);
                }

                return _cycles;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public CycleParametersModel GetCycleParameter(int id)
        {
            try
            {
                var _cycleparametersquery = (from cp in db.CycleParameters
                                             where cp.id == id
                                             select new CycleParametersModel
                                             {
                                                 cycleparameterid = cp.id,
                                                 cycle_id = cp.cycle_id,
                                                 cycle_object_id = cp.cycle_object_id,
                                                 loan_cycle = cp.loan_cycle,
                                                 max = cp.max,
                                                 min = cp.min
                                             }).FirstOrDefault();
                CycleParametersModel _cycleparam = _cycleparametersquery;
                return _cycleparam;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        public List<CycleParametersModel> GetCycleParameters(int cycle_id, int cycle_object_id)
        {
            try
            {
                var _cycleparametersquery = from cp in db.CycleParameters
                                            where cp.cycle_id == cycle_id
                                            where cp.cycle_object_id == cycle_object_id
                                            select new CycleParametersModel
                                            {
                                                cycleparameterid = cp.id,
                                                cycle_id = cp.cycle_id,
                                                cycle_object_id = cp.cycle_object_id,
                                                loan_cycle = cp.loan_cycle,
                                                max = cp.max,
                                                min = cp.min
                                            };
                List<CycleParametersModel> _cycleparams = _cycleparametersquery.ToList();
                return _cycleparams;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "CycleParameters"
        #region "Exotics"
        public void AddNewExotic(ExoticsModel exotic)
        {
            try
            {
                Exotic _exotic = new Exotic();
                _exotic.name = exotic.name;

                db.Exotics.AddObject(_exotic);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateExotic(ExoticsModel exotic)
        {
            try
            {
                Exotic _exotic = db.Exotics.First(b => b.id == exotic.exoticid);
                _exotic.name = exotic.name;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteExotic(ExoticsModel exotic)
        {
            try
            {
                Exotic _exotic = db.Exotics.First(b => b.id == exotic.exoticid);

                db.Exotics.DeleteObject(_exotic);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ExoticsModel> GetAllExotics()
        {
            try
            {
                List<ExoticsModel> _exotics = new List<ExoticsModel>();
                var _cyclesquery = from br in db.Exotics
                                   select br;
                List<Exotic> _extcs = _cyclesquery.ToList();
                foreach (var exotic in _extcs)
                {
                    ExoticsModel _exotic = new ExoticsModel();
                    _exotic.exoticid = exotic.id;
                    _exotic.name = exotic.name;

                    _exotics.Add(_exotic);
                }

                return _exotics;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "Exotics"
        #region "ExoticInstallments"
        public void AddNewExoticInstallment(ExoticInstallmentsModel exotic)
        {
            try
            {
                ExoticInstallment _exotic = new ExoticInstallment();
                _exotic.number = exotic.number;
                _exotic.principal_coeff = exotic.principal_coeff;
                _exotic.interest_coeff = exotic.interest_coeff;
                _exotic.exotic_id = exotic.exotic_id;

                db.ExoticInstallments.AddObject(_exotic);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateExoticInstallment(ExoticInstallmentsModel exotic)
        {
            try
            {
                ExoticInstallment _exotic = db.ExoticInstallments.First(b => b.exotic_id == exotic.exotic_id && b.number == exotic.number);
                _exotic.number = exotic.number;
                _exotic.principal_coeff = exotic.principal_coeff;
                _exotic.interest_coeff = exotic.interest_coeff;
                _exotic.exotic_id = exotic.exotic_id;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteExoticInstallment(ExoticInstallmentsModel exotic)
        {
            try
            {
                ExoticInstallment _exotic = db.ExoticInstallments.First(b => b.exotic_id == exotic.exotic_id && b.number == exotic.number);

                db.ExoticInstallments.DeleteObject(_exotic);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public List<ExoticInstallmentsModel> GetAllExoticInstallments(int exoticid)
        {
            try
            {
                List<ExoticInstallmentsModel> _exotics = new List<ExoticInstallmentsModel>();
                var _cyclesquery = from br in db.ExoticInstallments
                                   where br.exotic_id == exoticid
                                   select br;
                List<ExoticInstallment> _extcs = _cyclesquery.ToList();
                foreach (var exotic in _extcs)
                {
                    ExoticInstallmentsModel _exotic = new ExoticInstallmentsModel();
                    _exotic.number = exotic.number;
                    _exotic.principal_coeff = exotic.principal_coeff;
                    _exotic.interest_coeff = exotic.interest_coeff;
                    _exotic.exotic_id = exotic.exotic_id;

                    _exotics.Add(_exotic);
                }

                return _exotics;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "ExoticInstallments"
        #region "Corporate"
        public void AddNewCorporate(Corporate _corporate)
        {
            try
            {
                Corporate corporate = new Corporate();
                corporate.id = _corporate.id;
                corporate.name = _corporate.name;
                corporate.deleted = _corporate.deleted;
                corporate.sigle = _corporate.sigle;
                corporate.small_name = _corporate.small_name;
                corporate.volunteer_count = _corporate.volunteer_count;
                corporate.agrement_date = _corporate.agrement_date;
                corporate.agrement_solidarity = _corporate.agrement_solidarity;
                corporate.employee_count = _corporate.employee_count;
                corporate.siret = _corporate.siret;
                corporate.activity_id = _corporate.activity_id;
                corporate.establishment_date = _corporate.establishment_date;
                corporate.fiscal_status = _corporate.fiscal_status;
                corporate.registre = _corporate.registre;
                corporate.legalForm = _corporate.legalForm;
                corporate.insertionType = _corporate.insertionType;
                corporate.loan_officer_id = _corporate.loan_officer_id;
                corporate.photo = _corporate.photo;

                db.Corporates.AddObject(corporate);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void UpdateCorporate(Corporate _corporate)
        {
            try
            {
                Corporate corporate = db.Corporates.First(r => r.id == _corporate.id);
                corporate.name = _corporate.name;
                corporate.deleted = _corporate.deleted;
                corporate.sigle = _corporate.sigle;
                corporate.small_name = _corporate.small_name;
                corporate.volunteer_count = _corporate.volunteer_count;
                corporate.agrement_date = _corporate.agrement_date;
                corporate.agrement_solidarity = _corporate.agrement_solidarity;
                corporate.employee_count = _corporate.employee_count;
                corporate.siret = _corporate.siret;
                corporate.activity_id = _corporate.activity_id;
                corporate.establishment_date = _corporate.establishment_date;
                corporate.fiscal_status = _corporate.fiscal_status;
                corporate.registre = _corporate.registre;
                corporate.legalForm = _corporate.legalForm;
                corporate.insertionType = _corporate.insertionType;
                corporate.loan_officer_id = _corporate.loan_officer_id;
                corporate.photo = _corporate.photo;

                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        public void DeleteCorporate(Corporate _Corporate)
        {
            try
            {
                Corporate corporate = db.Corporates.Where(r => r.id == _Corporate.id).Single();

                db.Corporates.DeleteObject(corporate);
                db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }

        }
        public List<Corporate> GetCorporatesList()
        {
            try
            {
                List<Corporate> _Corporates = new List<Corporate>();
                var _Corporatequery = from co in db.Corporates
                                      select co;
                List<Corporate> _lst_corporates = _Corporatequery.ToList();
                foreach (var _corporate in _lst_corporates)
                {
                    Corporate corporate = new Corporate();
                    corporate.id = _corporate.id;
                    corporate.name = _corporate.name;
                    corporate.deleted = _corporate.deleted;
                    corporate.sigle = _corporate.sigle;
                    corporate.small_name = _corporate.small_name;
                    corporate.volunteer_count = _corporate.volunteer_count;
                    corporate.agrement_date = _corporate.agrement_date;
                    corporate.agrement_solidarity = _corporate.agrement_solidarity;
                    corporate.employee_count = _corporate.employee_count;
                    corporate.siret = _corporate.siret;
                    corporate.activity_id = _corporate.activity_id;
                    corporate.establishment_date = _corporate.establishment_date;
                    corporate.fiscal_status = _corporate.fiscal_status;
                    corporate.registre = _corporate.registre;
                    corporate.legalForm = _corporate.legalForm;
                    corporate.insertionType = _corporate.insertionType;
                    corporate.loan_officer_id = _corporate.loan_officer_id;
                    corporate.photo = _corporate.photo;

                    _Corporates.Add(corporate);
                }

                return _Corporates;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
 
        #endregion "Corporates"
        #region "audit"
        public void AddNewAuditLog(tbl_audit _audit_log)
        {
            try
            {
                tbl_audit audit_log = new tbl_audit();
                audit_log.id = _audit_log.id;
                audit_log.system = Utils.APP_NAME;
                audit_log.logged_in_user = _audit_log.logged_in_user;
                audit_log.role = _audit_log.role;
                audit_log.event_name = _audit_log.event_name;
                audit_log.description = _audit_log.description;
                audit_log.entity = _audit_log.entity;
                audit_log.created_date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                audit_db.tbl_audit.AddObject(audit_log);
                audit_db.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        #endregion "audit"
        public int get_no_of_records_per_page()
        {
            try
            {
                var setting = db.Settings.FirstOrDefault(s => s.SSKey == "RECORDS_PER_PAGE");
                if (setting != null)
                    return int.Parse(setting.SSValue);
                else
                    return 10;
             
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return 10;
            }
        }
        #endregion "public Methods"





















    }
}