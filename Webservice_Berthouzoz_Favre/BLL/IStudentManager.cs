using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStudentManager
    {
        Student GetStudentById(int id);
        Student GetStudentByUsername(string Username);
        int AddStudent(string Username, decimal Balance);
        void ChargeAccount(int id, decimal balance);
        int getQuotaById(int id);
        int getQuotaByUsername(string Username);
    }
   
}
