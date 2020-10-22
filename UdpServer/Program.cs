using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UdpEchoServer
{
    public class Program
    {
       public static void Main(string[] args)
        {
            string data = "";
            bool isRunning = true;

            Console.WriteLine(" S E R V E R   IS   S T A R T E D ");
            Console.WriteLine("* Waiting for Client...");

            UdpClient server1 = new UdpClient(1000);
            UdpClient server2 = new UdpClient();

            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            var m = new ManualResetEventSlim();
            m.Reset();

            Task.Run(() =>
            {
                while (isRunning)
                {
                    Console.WriteLine("Rx waiting");
                    byte[] receivedBytes = server1.Receive(ref remoteIPEndPoint);
                    data = Encoding.ASCII.GetString(receivedBytes);
                    Console.WriteLine("Handling client at " + remoteIPEndPoint + " - ");
                    Console.WriteLine("Message Received " + data.TrimEnd());
                    m.Set();
                }
            });

            Task.Run(() =>
            {
                while (isRunning)
                {
                    m.Wait();
                    m.Reset();
                    var b = Encoding.Default.GetBytes(data);
                    server2.Send(b, b.Length, remoteIPEndPoint);
                    Console.WriteLine("Message Echoed to" + remoteIPEndPoint + data);
                }
            });

            Console.WriteLine("Press Enter Program Finished");
            Console.ReadLine(); //delay end of program
            server2.Close();  //close the connection
            server1.Close();
        }
    }
}
