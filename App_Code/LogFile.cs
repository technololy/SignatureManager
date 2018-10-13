using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web;
using log4net;

namespace CentralBilling
{
    public class JobLog
    {
       
        public JobLog(string filename,string fileContent)
        {
            string pth = ConfigurationManager.AppSettings["HtmlPath"];
           
           

            string err = fileContent;
            DateTime dt = DateTime.Now;
            string folderName = @"~/GeneratedTempSignatureHTML";
            string fullDirectory = HttpContext.Current.Server.MapPath(folderName);
            pth = fullDirectory + "\\" + filename + ".html";
            if (!File.Exists(pth))
            {
                using (StreamWriter sw = File.CreateText(pth))
                {
                    sw.WriteLine(err);
                    sw.WriteLine(" ");
                    sw.Close();
                    sw.Dispose();
                }
            }
            else
            {
                File.Delete(fullDirectory);
                using (StreamWriter sw = File.CreateText(fullDirectory))
                {
                    sw.WriteLine(err);
                    sw.WriteLine(" ");
                    sw.Close();
                    sw.Dispose();
                }
            }
            HttpContext.Current.Session["HTMLPath"] = pth;
        }
    }

    public class ErrorLog
    {
        public ErrorLog(Exception ex)
        {
            new ErrorLog(ex.ToString());
        }
        public ErrorLog(string ex)
        {
            string pth = ConfigurationManager.AppSettings["errorlog"];
            string pth2 = ConfigurationManager.AppSettings["errorlogCdrive"];
            string err = ex;
            DateTime dt = DateTime.Now;
            string fld = dt.ToString("yyyy") + "_" + dt.ToString("MM") + "_";
            pth += fld + dt.ToString("dd") + ".txt";
            pth2 += fld + dt.ToString("dd") + ".txt";
            try
            {
                if (!File.Exists(pth))
                {
                    //Directory.CreateDirectory(pth);
                    using (StreamWriter sw = File.CreateText(pth))
                    {
                        sw.WriteLine(dt.ToString() + " : " + err);
                        sw.WriteLine(" ");
                        sw.Close();
                        sw.Dispose();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(pth))
                    {
                        sw.WriteLine(dt.ToString() + " : " + err);
                        sw.WriteLine(" ");
                        sw.Close();
                        sw.Dispose();
                    }
                }

            }
            catch (Exception)
            {
                if (!Directory.Exists(ConfigurationManager.AppSettings["errorlogCdrive"].ToString()))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["errorlogCdrive"].ToString());
                }
                if (!File.Exists(pth2))
                {
                    
                    using (StreamWriter sw = File.CreateText(pth2))
                    {
                        sw.WriteLine(dt.ToString() + " : " + err);
                        sw.WriteLine(" ");
                        sw.Close();
                        sw.Dispose();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(pth2))
                    {
                        sw.WriteLine(dt.ToString() + " : " + err);
                        sw.WriteLine(" ");
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
            
        }
    }

    public class Log4net
    {
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }

}
