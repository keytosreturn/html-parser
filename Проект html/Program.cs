using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
public class MyProject
{
   private const string myString = "https://wingram.org";
   private readonly Uri myUri;
   public MyProject()
   {
    myUri = new Uri(myString);
   }
    private string GetHtmlFromUrl(string url)
        {

            if (!string.IsNullOrEmpty(url))
            { 
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows NT 6.1; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0";
                string jsonPath = "useragent.json";
                if(File.Exists(jsonPath))
                {
                string jsonString = File.ReadAllText(jsonPath);
                var data = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
                var desktopList = data["Desktop"];
                var datas = new Queue<string>(desktopList);
                HashSet<string> searched = new HashSet<string>(desktopList);
                if(datas.Count > 0)
                {
                    string current = datas.Dequeue();
                    myHttpWebRequest.UserAgent = current;
                datas.Enqueue(current);
                    if(searched.Add(current))
                    {
                       System.Console.WriteLine($"Added unique json file =========>>>{current}" );
                    
                    }
                }
                }

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                var stream = myHttpWebResponse.GetResponseStream();
                var reader = new StreamReader(stream);
                var html = reader.ReadToEnd();
                myHttpWebResponse.Close();
                System.Console.WriteLine(html);
                return html;
            }
            else { return "NO URL"; }
        }
public void getInfo()
    {
        GetHtmlFromUrl(myString);
        
    }

internal class Program
{
    static void Main(string[]args)
        {
            var myproject = new MyProject();
            myproject.getInfo();
        }
}}