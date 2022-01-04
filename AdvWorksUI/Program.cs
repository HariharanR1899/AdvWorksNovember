using AdvWorksBL;
using AdvWorksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvWorksUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to Adventure Works");
                AdvWorksBusinessLayer blObj = new AdvWorksBusinessLayer();
                int result = blObj.ConnectToDB();
                if (result == 1)
                {
                    Console.WriteLine("Database connection established");
                    List<DepartmentDetailsDTO> lstFromBL=blObj.GetAllDepartmentNames();

                    foreach (var dept in lstFromBL)
                    {
                        Console.WriteLine(dept.DeptName+" belongs to "+dept.DeptGroupName);
                    }
                }
                else
                {
                    Console.WriteLine("Database connection failed");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Our Developers goofed it up again. We will fix it");
            }
        }
    }
}
