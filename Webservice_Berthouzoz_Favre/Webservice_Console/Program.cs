using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Webservice_Console
{
    class Program
    {
       

        static void Main(string[] args)
        {
            WebserviceRef.Webservice_Berthouzoz_FavreClient student = new WebserviceRef.Webservice_Berthouzoz_FavreClient();

            string Username = "leonard";
            float Balance = 50;

            var result = student.AddStudent(Username,Balance);
            Console.ReadKey();

            var studenttest = student.GetStudentByUsername(Username);

            Console.WriteLine(studenttest.Id + "  " + studenttest.Username);

            Console.ReadKey();

            var studenttest2 = student.GetStudentById(studenttest.Id);

            Console.WriteLine(studenttest2.Id + "  " + studenttest2.Username);

            Console.ReadKey();

            var Quota = student.GetQuotaById(studenttest2.Id);

            Console.WriteLine(Quota);

            Console.ReadKey();

            student.ChargeAccount(studenttest2.Id, 10);

            Console.ReadKey();

            var Quota2 = student.GetQuotaByUsername(studenttest2.Username);

            Console.WriteLine(Quota2);

            Console.ReadKey();




            /*while(Console.ReadKey().Key != ConsoleKey.Enter){
             *Console.WriteLine("Bonjour");
             *}
             */


            Console.WriteLine("Les Carottes sont cuites mon salaud");



            Console.ReadKey();
        }
    }
}
