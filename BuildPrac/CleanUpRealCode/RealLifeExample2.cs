using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace BuildPrac.CleanUpRealCode
{
 
    public class RealLifeExample2
    {
        private readonly SmtpClient _mailClient = new SmtpClient();
      
        public ActionResult Process(string csv)
        {
            foreach (string[] c in CSVLine(csv))
            {

                int id = int.Parse(c[0]);

                if (id == 0)
                    continue;

                var existing = WorkerRepository.GetById(id);
                if(existing != null)
                {
                    ModelState.AddModelError("", $"Worker with {id} already exists.");
                    return View();
                }

                var worker = new Worker()
                {
                    Id = id,
                    FirstName = c[1],
                    LastName = c[2],
                    Email = c[3].ToLower(),
                    Telephone = c[4],
                    Street = c[5],
                    PostalCode = c[6],
                    City = c[7],
                    Password = Utils.CreateRandomPassword()
                };
                      
                SendMailWithPassword(worker);

                WorkerRepository.Add(worker);

            }
            return View();
        }

        private static IEnumerable<string[]> CSVLine(string csv)
        {
            return csv.Split(new[] { Environment.NewLine },
                            StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(line => line.Split(new[] { ',' }));
        }

        private void SendMailWithPassword(Worker worker)
        {
            var msg = new MailMessage(new MailAddress("admin@factory.com", "Admin"), new MailAddress(worker.Email, worker.FirstName + worker.LastName))
            {
                Body = string.Format("Hi {0},{1}{1}Welcome to the Refactoring Factory.{1}These are your login data.{1}Username: {3}{1}Password: {2}",
                                    worker.FirstName,
                                    Environment.NewLine,
                                   worker.Password,
                                    worker.Email),
                Subject = "New Worker In The Refactoring Factory",
            };
            _mailClient.Send(msg);
        }

        private ActionResult View()
        {
            return new ActionResult();
        }
    }

    #region Other Classes

    internal class Utils
    {
        internal static string CreateRandomPassword()
        {
            return null;
        }
    }

    internal class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Password { get; internal set; }
    }

    internal class WorkerRepository
    {
        internal static void Add(Worker worker)
        {
        }

        internal static Worker GetById(int id)
        {
            return new Worker();
        }
    }

    public class ActionResult
    {
    }

    public class ModelState
    {
        public static void AddModelError(string key, string errorMessage)
        { }
    }

    #endregion
}
