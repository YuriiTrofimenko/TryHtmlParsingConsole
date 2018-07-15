using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Web;

namespace TryHtmlParsingConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*1*/
            /*System.Net.WebClient web = new System.Net.WebClient();
            web.Encoding = UTF8Encoding.UTF8;
            string str = web.DownloadString("https://www.gismeteo.ua/weather-mariupol-5104/hourly/#wdaily1");
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(str);*/
            /*1*/

            /*
            HtmlNode node = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='cleft']/div[@class='wrap']/div[@id='weather']/div[@class='fcontent']/div[@class='section higher']/div[@class='temp']/dd[@class='value m_temp c']");
            Console.WriteLine(node.InnerHtml.ElementAt(0).ToString() + node.InnerHtml.ElementAt(1).ToString());
            */

            /*1*/
            /*HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='cleft']/div[@class='wrap']/div[@id='weather']/div[@class='fcontent']/div[@class='section higher']/div[@class='temp']/dd[@class='value m_temp c']");
            Console.WriteLine(nodes.ElementAt(0).ChildNodes.ElementAt(0).InnerText + "°C");
            Console.ReadLine();*/
            /*1*/

            /*HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='cleft']/div[@class='wrap']/div[@id='weather']/div[@class='fcontent']/div[@class='section higher']/div[@class='temp']/dd[@class='value m_temp c']");
            foreach (var node in nodes)
            {
                Console.WriteLine(node.InnerHtml.ElementAt(0).ToString() + node.InnerHtml.ElementAt(1).ToString());
            }
            Console.ReadLine();*/

            System.Net.WebClient web = new System.Net.WebClient();
            web.Encoding = UTF8Encoding.UTF8;
            string str = web.DownloadString("http://localhost:50044/");
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(str);

            HtmlNodeCollection nodes =
                htmlDocument.DocumentNode.SelectNodes("//input");

            string param = "";
            int count = 0;
            foreach (var item in nodes)
            {
                count++;
                param += item.Attributes["name"].Value + "=";
                //Console.WriteLine(item.Attributes["name"].Value);
                if (item.Attributes["value"] != null)
                {
                    //Console.WriteLine(item.Attributes["value"].Value);

                    if (count >= 4 && count != nodes.Count)
                    {
                        param += "helloluserhelloluserhelloluser";
                    }
                    else
                    {
                        param += HttpUtility.UrlEncode(item.Attributes["value"].Value, Encoding.UTF8);
                    }
                }
                else {
                    if (item.Attributes["name"].Value != "lastname")
                    {
                        param += "helloluserhelloluserhelloluser";
                    }
                    
                }
                param += "&";
            }
            param = param.Remove(param.Length - 1);
            //Console.WriteLine(param);
            Console.WriteLine("http://localhost:50044/?" + param);

            //param = HttpUtility.UrlEncode(param, Encoding.UTF8);

            //Console.WriteLine();
            //Console.WriteLine("http://localhost:50044/?" + param);

            string respString =
                web.DownloadString("http://localhost:50044/?" + param);

            Console.WriteLine();
            Console.WriteLine(respString);

            /*for (int i = 0; i < 10; i++)
            {
                web.DownloadString("http://localhost:50044/?" + param);
            }*/
            //Console.WriteLine(nodes.ElementAt(0).ChildNodes.ElementAt(0).InnerText + "°C");
            Console.ReadLine();
        }
    }
}
