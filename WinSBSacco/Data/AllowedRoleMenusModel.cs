using System;
using System.Net;



namespace WinSBSacco
{
    public class AllowedRoleMenusModel
    {
        public int user_id { get; set; }

        public int role_id { get; set; }

        public string role_code { get; set; }

        public int menu_item_id { get; set; }

        public bool allowed { get; set; } 

        public string component_name { get; set; }
         

        public AllowedRoleMenusModel()
        {

        }
        public AllowedRoleMenusModel(int id, int roleid, string rolecode, int menuitemid, bool _allowed, string componentname)
        {
            this.user_id = id;
            this.role_id = roleid;
            this.role_code = rolecode;
            this.menu_item_id = menuitemid; 
            this.allowed = _allowed;
            this.component_name = componentname; 
        }
    }
}
