﻿using System;
using System.IO;
using System.Net;
using System.Text;

namespace HTTPListener
{
    class Program
    {
        static void Main()
        {
            HttpListener listener = new HttpListener();
            // port which will be listened..
            listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Start();
            Console.WriteLine("Waiting for requests...");
            while (true)
            { 
                HttpListenerContext context = listener.GetContextAsync().Result;
                HttpListenerRequest request = context.Request;
                Console.WriteLine("Received: " + request.HttpMethod + "\n");
                HttpListenerResponse response = context.Response;

                string responsestring = "<html>" +
                                            "<head>" +
                                                    "<meta charset='utf8'>" +
                                            "</head>" +
                                                "<body>" +
                                                        "Hello from C# code" +
                                                "</body>" +
                                        "</html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responsestring);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}
