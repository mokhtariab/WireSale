using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dataset
{
    public class Users
    {

        public static bool InsertUser(string UserName, string Name, string Family, string ReNewPass)
        {
            try
            {
                DataClassesWireDataContext DCDC = new DataClassesWireDataContext();

                var prd = from p in DCDC.TBL_Users
                          where p.UserName == UserName
                          select p;
                if (prd.Count() != 0)
                    return false;

                TBL_User thf = new TBL_User
                {
                    UserName = UserName,
                    FirstName = Name,
                    LastName = Family,
                    Password = ReNewPass,
                    CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    UserPermission = "buttonItem_Users,buttonItem_HFRecive,buttonItem_CFRecive,buttonItem_DesignRep,buttonItem_AgencySet,buttonItem_SetSystem,buttonItem_Rst,",
                    UserPrmHouseFor = ""//Function_Cls.ReadFromParameter(Global_Cls.HouseFor)
                };
                DCDC.TBL_Users.InsertOnSubmit(thf);
                DCDC.SubmitChanges();
            }
            catch
            {
                //Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "لطفا با کمی فاصله دوباره تایید کنید!");
                return false;
            }
            return true;
        }



        public static int EditUser(int UserID, string User_Name, string UserName, string Name, string Family, string PrePass, string ReNewPass)
        {
            try
            {
                DataClassesWireDataContext DCDC = new DataClassesWireDataContext();

                //Check PrePassword Entry 
                var PPass = from pp in DCDC.TBL_Users
                            where (pp.UserCode == UserID) && (pp.Password != PrePass)
                            select pp;
                if (PPass.Count() != 0)
                    return 0;

                //Search For Username's Duplex
                if (UserName != User_Name)
                {
                    var UName = from UN in DCDC.TBL_Users
                                where UN.UserName == UserName
                                select UN;
                    if (UName.Count() != 0)
                        return 1;
                }


                //Update In Users Table
                TBL_User tbu = DCDC.TBL_Users.First(hu => hu.UserCode.Equals(UserID));
                tbu.FirstName = Name;
                tbu.LastName = Family;
                tbu.UserName = UserName;
                tbu.Password = ReNewPass;
                DCDC.SubmitChanges();
            }
            catch
            {
                //Global_Cls.Message_Sara(0, Global_Cls.MessageType.SError, false, "لطفا با کمی فاصله دوباره تایید کنید!");
                return 0;
            }

            return 2;
        }
    }
}
