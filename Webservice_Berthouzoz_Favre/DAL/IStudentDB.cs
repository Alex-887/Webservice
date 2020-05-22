using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStudentDB
    {
        Student GetStudentById(int id);
        Student GetStudentByUsername(string Username);
        int AddStudent(Student student);
        void ChargeAccount(int id, decimal balance);
    }
}
