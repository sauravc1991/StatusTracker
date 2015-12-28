namespace DataAccessLayer.DataAccessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LoginRepository
    {
        protected Entity.EmidsIHStatEntities myDataContext;

        public LoginRepository()
        {
            myDataContext = new Entity.EmidsIHStatEntities();
        }

        public string[] ValidateLogin(string name, string password)
        {
            var RetUserID = new System.Data.Objects.ObjectParameter("RetUserID", typeof(int));
            var RetName = new System.Data.Objects.ObjectParameter("RetName", typeof(string));
            var RetGroupID = new System.Data.Objects.ObjectParameter("RetGroupID", typeof(int));
            var RetRoleID = new System.Data.Objects.ObjectParameter("RetRoleID", typeof(int));
            myDataContext.AuthenticateUser(name, password, RetUserID, RetName, RetGroupID, RetRoleID);
            string[] sessionArr = new string[4];
            string Test = RetUserID.Value.ToString();
            if (Test != String.Empty)
            {
                var UserID = (int)RetUserID.Value;
                var Name = RetName.Value.ToString();
                var GroupID = (int)RetGroupID.Value;
                var RoleID = (int)RetRoleID.Value;

                sessionArr[0] = UserID.ToString();
                sessionArr[1] = Name.ToString();
                sessionArr[2] = GroupID.ToString();
                sessionArr[3] = RoleID.ToString();
                return sessionArr;
            }
            else return null;
          
        }
    }
}
