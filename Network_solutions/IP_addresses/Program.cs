﻿using System;
using System.Net;
namespace IP_addresses
{
    class Program
    {
        static void Main()
        {
            IPHostEntry host1 = Dns.GetHostEntry("Google.com");
            Console.WriteLine(host1.HostName);
            foreach (IPAddress ip in host1.AddressList)
            {
                Console.WriteLine(ip.ToString());
            }
            // Delay !!

            Console.Read();
        }
    }
}
