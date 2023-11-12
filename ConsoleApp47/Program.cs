using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp47
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (StreamWriter sw = new StreamWriter("result.txt", true))
            {

                using (StreamReader sr = new StreamReader("client_import.csv", Encoding.UTF8))
                {
                    string line;
                    string[] output = new string[9];
                    while ((line = sr.ReadLine()) != null)
                    {
                        StringBuilder resultphone  = new StringBuilder();
                        string result = string.Empty;
                        string resultpol= string.Empty;
                        
                        int x = 0;
                        string[] array = line.Trim().Split(';');
                        string family = array[0].Trim();
                        string name = array[1].Trim();
                        string pat = array[2].Trim();
                        string pol = array[3].Trim();
                        string phone = array[4].Trim();
                        string photo = array[5].Trim();
                        string BornDate = array[6].Trim();
                        string email = array[7].Trim();
                        string registrdate = array[8].Trim();
                        int Lenght = photo.Length;
                        if (photo.Contains("\\"))
                        {
                            x = photo.IndexOf("\\");
                            result = photo.Substring(x + 1);
                        }
                        resultpol = pol.Substring(0, 1).ToLower();
                        if (resultpol.Contains("м"))
                        {
                            resultpol = "1";
                        }
                        else
                        {
                            resultpol = "2";
                        }
                        foreach (var item in phone)
                        {
                            if (Char.IsDigit(item))
                            {
                                resultphone.Append(item);
                            }

                        }
                        string rez = @"^\w+\s\w+\s\w+$";
                        if (Regex.Match(family, rez,
                        RegexOptions.IgnoreCase).Success)
                        {
                            string[] split = family.Split();
                            family = split[0].Trim();
                            name = split[1].Trim();
                           family = split[2].Trim();
                        }
                        output[0] = family;
                        output[1] = name;
                        output[2] = pat;
                        output[3] = resultpol.ToLower();
                        output[4] = resultphone.ToString();
                        output[5] = result.ToString();
                        output[6] = BornDate;
                        output[7] = email;
                        output[8] = registrdate;



                        sw.WriteLine($"{String.Join("/", output)}");

                    }
                }
            }
        }
    }
}

