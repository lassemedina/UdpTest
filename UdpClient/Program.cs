using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpEchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "";
            byte[] sendBytes = new Byte[1024];
            byte[] rcvPacket = new Byte[1024];
            UdpClient client = new UdpClient();
            
            client.Connect(IPAddress.Parse("127.0.0.1"), 1000);
            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Client is Started");
            Console.WriteLine("Type your message");

            while (data != "q")
            {
                data = Console.ReadLine();
                sendBytes = Encoding.ASCII.GetBytes(DateTime.Now + " " + data);
                client.Send(sendBytes, sendBytes.GetLength(0));
                rcvPacket = client.Receive(ref remoteIPEndPoint);

                string rcvData = Encoding.Default.GetString(rcvPacket);
                Console.WriteLine("Handling client at " + remoteIPEndPoint + " - ");

                Console.WriteLine("Message Received: " + rcvData);
            }
            Console.WriteLine("Close Port Command Sent");  //user feedback
            Console.ReadLine();
            client.Close();  //close connection

        }
    }
}
    