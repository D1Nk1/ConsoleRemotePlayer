using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRemotePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServer ws = new WebServer(SendResponse, "http://192.168.142.11:7777/test/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format(@"<!DOCTYPE HTML>
<html><head><title>Remote player control panel</title></head><body>
<form method=""post"" action=""test"">
<p><b>Enter your command here: </b><br>
<input type=""text"" name=""myname"" size=""40""></p>
<p><input type=""submit"" value=""Send""></p>
</form></body></html>");
            //return string.Format("<HTML><BODY>My web page.<br>{0}</BODY></HTML>", DateTime.Now);
        }
    }
}
