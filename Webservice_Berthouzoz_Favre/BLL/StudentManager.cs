using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentManager : IStudentManager
    {
        private IStudentDB StudentDb { get; }

        public StudentManager(IStudentDB studentDb)
        {
            StudentDb = studentDb;
        }
        public Student GetStudentById(int id)
        {
            return StudentDb.GetStudentById(id);
        }

        public int AddStudent(string Username, decimal Balance)
        {
            Student student = new Student();
            student.Username = Username;
            student.Balance = Balance;

            return StudentDb.AddStudent(student);
        }

        public void ChargeAccount(int id, decimal balance)
        {
            var student = StudentDb.GetStudentById(id);
            balance += student.Balance;
            StudentDb.ChargeAccount(id,balance);
        }

        public int GetQuotaById(int id)
        {
            var student = StudentDb.GetStudentById(id);
            double calcul = (double) student.Balance / 0.08;
            int Quota = (int)Math.Floor(calcul);
            return Quota;
        }

        public int GetQuotaByUsername(string Username)
        {
            var student = StudentDb.GetStudentByUsername(Username);
            double calcul = (double) student.Balance / 0.08;
            int Quota = (int)Math.Floor(calcul);
            return Quota;
        }

        public Student GetStudentByUsername(string Username)
        {
            return StudentDb.GetStudentByUsername(Username);
        }

        public int Print(int id, int NbPages)
        {
           int balance=0;
           var student = StudentDb.GetStudentById(id);
           balance = ((int)student.Balance-NbPages);
           StudentDb.ChargeAccount(id, balance);
            return balance;
        }
    }
}
