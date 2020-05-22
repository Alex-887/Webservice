using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;

namespace Webservice_Berthouzoz_Favre
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Webservice_Berthouzoz_Favre" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Webservice_Berthouzoz_Favre.svc or Webservice_Berthouzoz_Favre.svc.cs at the Solution Explorer and start debugging.
    public class Webservice_Berthouzoz_Favre : IWebservice_Berthouzoz_Favre
    {
        public int AddStudent(string Username, decimal Balance)
        {
            IStudentDB studentDb = new StudentDB();
            IStudentManager studentManager = new StudentManager(studentDb);
            var student = studentManager.AddStudent(Username,Balance);
            return student;
        }

        public void ChargeAccount(int id, decimal balance)
        {
            IStudentDB studentDb = new StudentDB();
            IStudentManager studentManager = new StudentManager(studentDb);
            studentManager.ChargeAccount(id, balance);
        }

        public int GetQuotaById(int id)
        {
            IStudentDB studentDb = new StudentDB();
            IStudentManager studentManager = new StudentManager(studentDb);
            int Quota = studentManager.getQuotaById(id);
            return Quota;
        }

        public int GetQuotaByUsername(string Username)
        {
            IStudentDB studentDb = new StudentDB();
            IStudentManager studentManager = new StudentManager(studentDb);
            int Quota = studentManager.getQuotaByUsername(Username);
            return Quota;
        }

        public Student GetStudentById(int id)
        {
            IStudentDB studentDb = new StudentDB();
            IStudentManager studentManager = new StudentManager(studentDb);
            var student = studentManager.GetStudentById(id);
            return student;
        }

        public Student GetStudentByUsername(string Username)
        {
            IStudentDB studentDb = new StudentDB();
            IStudentManager studentManager = new StudentManager(studentDb);
            var student = studentManager.GetStudentByUsername(Username);
            return student;
        }
    }
}
