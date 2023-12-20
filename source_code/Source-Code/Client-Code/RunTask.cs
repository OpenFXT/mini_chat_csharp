using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Client_Code
{
    internal class RunTask
    {
        public static string GetCurrentDateTime3()
        {
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("HH-mm-ss__dd-MM-yyyy");
            return formattedDateTime;
        }


        static public List<string> GetFtpDirectoryListing(string username, string password, string ftpServerIP, string directoryPath)
        {
            UriBuilder uriBuilder = new UriBuilder("ftp", ftpServerIP);
            uriBuilder.Path = directoryPath;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uriBuilder.Uri);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(username, password);

            List<string> directoryListing = new List<string>();
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
            {
                while (!reader.EndOfStream)
                {
                    string fileName = reader.ReadLine();
                    directoryListing.Add(fileName);
                }
            }

            return directoryListing;
        }

        static public string[] ListDirectories(string username, string password, string ftpServerIP, string directoryPath)
        {
            string[] directories = null;
            List<string> directoryList = new List<string>();

            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + ftpServerIP + "/" + directoryPath);
                ftpRequest.Credentials = new NetworkCredential(username, password);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                Stream responseStream = ftpResponse.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.StartsWith("d")) 
                    {
                        string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        string directoryName = tokens[tokens.Length - 1];
                        directoryList.Add(directoryName);
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                responseStream.Close();
                ftpResponse.Close();
            }
            catch (Exception ex)
            {
                directoryList = new List<string>() { ex.Message };
            }
            directories = directoryList.ToArray();
            return directories;
        }

        static public string GetCurrentDateTime()
        {
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("HH:mm dd-MM-yyyy");
            return formattedDateTime;
        }

        static public string GetCurrentDateTime2()
        {
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("HH:mm - dd/MM/yy");
            return formattedDateTime;
        }

        static public string ChuyenDoi(int soGiay)
        {
            int phut = soGiay / 60;
            int giay = soGiay % 60;
            return string.Format("{0:00}:{1:00}", phut, giay);
        }

        static public string DownloadFileFromFTP(string username, string password, string serverAddress, string filePath, string fileLocal)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverAddress + "/" + filePath);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(username, password);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                byte[] bytes = new byte[2048];
                int bytesRead = responseStream.Read(bytes, 0, bytes.Length);
                FileStream fileStream = new FileStream(fileLocal, FileMode.Create);
                while (bytesRead > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                    bytesRead = responseStream.Read(bytes, 0, bytes.Length);
                }
                fileStream.Close();
                reader.Close();
                response.Close();

                return string.Empty;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }

        static public string DeleteFileFromFTP(string username, string password, string ipFtpServer, string filePath)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ipFtpServer + "/" + filePath);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(username, password);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return String.Empty;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string UploadFileToFTP(string username, string password, string ftpServerAddress, string localFilePath, string remoteFilePath)
        {
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential(username, password);

            try
            {
                client.UploadFile("ftp://" + ftpServerAddress + "/" + remoteFilePath, localFilePath);
                return string.Empty;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }


        static public string CryptionCode(string normalString)
        {
            normalString = normalString.Trim();
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string input = normalString;
            string unicodeString = "";
            foreach (char c in input)
            {
                unicodeString += ((int)c).ToString("X4") + " ";
            }
            return unicodeString;
        }

        static public string DecryptionCode(string decode)
        {
            decode = decode.Trim();
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string input = decode;
            string[] unicodeChars = input.Split(' ');
            string vietnameseString = "";

            foreach (string unicodeChar in unicodeChars)
            {
                int code = int.Parse(unicodeChar, System.Globalization.NumberStyles.HexNumber);
                char c = (char)code;
                vietnameseString += c;
            }
            return vietnameseString;
        }

        static public string StandardizeString(string sourceString)
        {
            sourceString = sourceString.Trim();
            string[] arrChuoi = sourceString.Split(' ');
            sourceString = "";
            foreach (string tu in arrChuoi)
            {
                if (tu != "")
                {
                    sourceString += tu.Substring(0, 1).ToUpper() + tu.Substring(1).ToLower() + " ";
                }
            }
            sourceString = sourceString.Trim();

            return sourceString;
        }

        public static void SendEmail(string userMail, string passwordMail, string titleEmail, string contentEmail, string desMail)
        {
            var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(userMail, passwordMail),
                EnableSsl = true
            };
            var message = new MailMessage(userMail, desMail, titleEmail, contentEmail);
            smtpClient.Send(message);
        }

        public static string RamdomCode()
        {
            Random rand = new Random();
            int length = rand.Next(6, 9); 
            int minValue = (int)Math.Pow(10, length - 1); 
            int maxValue = (int)Math.Pow(10, length) - 1; 
            int randomNumber = rand.Next(minValue, maxValue + 1);
            return randomNumber + "";
        }
    }
}
