using AdvWorksDAL;
using AdvWorksDTO;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvWorksBL
{
    public class AdvWorksBusinessLayer
    {
        public int ConnectToDB()
        {
            try
            {
                AdvWorksDataAccessLayer dalObj = new AdvWorksDataAccessLayer();
                return dalObj.ConnectionToDB();
            }
            catch (Exception ex)
            {

                return -89;
            }
        }

        public List<DepartmentDetailsDTO> GetAllDepartmentNames()
        {
            AdvWorksDataAccessLayer dalObj=new AdvWorksDataAccessLayer();
            List<DepartmentDetailsDTO> lstFromDB= dalObj.FetchAllDepartments();
            return lstFromDB;
            
        }
    }
}
