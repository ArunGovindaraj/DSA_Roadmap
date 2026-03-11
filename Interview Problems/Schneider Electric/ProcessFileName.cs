using System;
using System.Collections.Generic;
using System.Text;

namespace DSARoadmap.InterviewProblems.SchneiderElectric
{
    public interface IMessageService
    {
        void Send();
    }

    public class EmailService : IMessageService
    {
        public void Send()
        {
            Console.WriteLine("Email sent");
        }
    }

    public class FaxService : IMessageService
    {
        public void Send()
        {
            Console.WriteLine("Fax sent");
        }
    }

    public class SmsService : IMessageService
    {
        public void Send()
        {
            Console.WriteLine("SMS sent");
        }
    }

    public class SenderFactory
    {
        public static IMessageService GetSender(string type)
        {
            if (type == "email")
                return new EmailService();

            if (type == "sms")
                return new SmsService();

            if (type == "fax")
                return new FaxService();

            throw new Exception("Invalid sender type");
        }
    }

    public class ProcessFileMain
    {
        public void ProcessFile(string path)
        {
            var x = Process(path);

            IMessageService sender = SenderFactory.GetSender(x);

            sender.Send();
        }

        private string Process(string path)
        {
            // Example logic
            if (path.Contains("email"))
                return "email";

            if (path.Contains("sms"))
                return "sms";

            if (path.Contains("fax"))
                return "fax";

            return "email";
        }
    }

    //public class ProcessFileMain
    //{
    //    public void ProcessFile(string path, IMessageService service)
    //    {
    //        var x = process(path);

    //        service.Send();
    //    }   

    //    //public void ProcessFile(string path)
    //    //{
    //    //    var send = new Send();

    //    //    var x = process(path);

    //    //    if (x == "email")
    //    //    {
    //    //        send.SendEmail();
    //    //    }
    //    //    else
    //    //    {
    //    //        send.SendSMS();
    //    //    }
    //    //}

    //    private string process(string path)
    //    {
    //        return $"File in {path} Processed";
    //    }
    //}

    class Send
    {
        public void SendEmail()
        {
            Console.WriteLine("Email sent");
        }

        public void SendSMS()
        {
            Console.WriteLine("SMS sent");
        }
    }
}
