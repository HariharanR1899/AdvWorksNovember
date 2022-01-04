using AdvWorksDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvWorksDAL
{
    public class AdvWorksDataAccessLayer
    {
        //Reference Variable
        SqlConnection conObj;
        SqlCommand cmdObj;
        //Constructor
        public AdvWorksDataAccessLayer()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvWorksConStr"].ConnectionString);
        }
        //Sample Method
        public int ConnectionToDB()
        {
            try
            {
                string sqlConStr = ConfigurationManager.ConnectionStrings["AdvWorksConStr"].ConnectionString;
                SqlConnection conObj = new SqlConnection(sqlConStr);
                conObj.Open();
                if (conObj.State.ToString() == "Open")
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            } 
            catch (Exception ex)
            {

                return -99;
            }
           
        }

        //GetAllCustomerDetails

        public List<DepartmentDetailsDTO>  FetchAllDepartments()
        {
            try
            {
                cmdObj = new SqlCommand(@"SELECT Name,GroupName FROM HumanResources.Department",conObj);
                conObj.Open();
                SqlDataReader drDepartment=cmdObj.ExecuteReader();
                //Dirty code : CW should not be part of DAL
                //while(drDepartment.Read())
                //{
                //    Console.WriteLine(drDepartment["Name"]+"|"+drDepartment["GroupName"]);
                //}

                //Created an empty list to store values from the DB

                List<DepartmentDetailsDTO> lstDepartment = new List<DepartmentDetailsDTO>();

                //For every record the DataReader is reading
                while (drDepartment.Read())
                {
                    DepartmentDetailsDTO departFromReader = new DepartmentDetailsDTO();
                    departFromReader.DeptName= drDepartment["Name"].ToString();
                    departFromReader.DeptGroupName=drDepartment["GroupName"].ToString();
                    //Adding the above department details to the list
                    lstDepartment.Add(departFromReader);

                }
                
                return lstDepartment;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conObj.Close();
            }
        }
    }
}
