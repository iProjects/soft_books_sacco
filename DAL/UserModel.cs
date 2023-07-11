using System;
using System.Net;



namespace DAL
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string password_hash { get; set; }

        public string password_salt { get; set; }

        public int? RoleId { get; set; }

        public bool? Locked { get; set; }

        public UserModel()
        {

        }

        public UserModel(int userid, string username, string fullname, string pwd, int role, bool locked)
        {
            this.UserId = userid;
            this.UserName = username;
            this.Password = pwd;
            this.RoleId = role;
            this.Locked = locked;
        }


        public UserModel(int userid, string username, string fullname, string pwd, int role, bool locked, string hash, string salt)
        {
            this.UserId = userid;
            this.UserName = username;
            this.Password = pwd;
            this.password_hash = hash;
            this.password_salt = salt;
            this.RoleId = role;
            this.Locked = locked;
        }

    }


    public class UserModel_dto
    {
        public int userid { get; set; }

        public int role_id { get; set; }

        public string user_name { get; set; }

        public string user_pass { get; set; }

        public string role_code { get; set; }

        public string full_name
        {
            get { return this.first_name + " " + this.last_name; }
        }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string mail { get; set; }

        public string sex { get; set; }

        public string phone { get; set; }

        public bool deleted { get; set; }

        public UserModel_dto()
        {

        }
        public UserModel_dto(int id, string user_name, string user_pass, string role_code, string mail, string sex, string phone, bool deleted, int roleid)
        {
            this.userid = id;
            this.role_id = roleid;
            this.user_name = user_name;
            this.user_pass = user_pass;
            this.role_code = role_code;
            this.mail = mail;
            this.sex = sex;
            this.phone = phone;
            this.deleted = deleted;
        }
    }
}
