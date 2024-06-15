using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Renci.SshNet;
using System.Net;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        string host = "b2b.technobox.tv";
        string username = "technobox-b2b";
        string password = "mcYZMZqgS9ULVXqjgmAy";
        int port = 22;
        string remoteDirectory = "/home/technobox-b2b/htdocs/b2b.technobox.tv/assets/img/";

        //string host = "b2b.retinabilisim.com.tr";
        //string username = "retinabilisim-b2b";
        //string password = "zQpFIr6sZ7S9lVMl1iFf";
        //int port = 22;
        //string remoteDirectory = "/home/retinabilisim-b2b/htdocs/b2b.retinabilisim.com.tr/assets/img/";

        public string FileSaveToServer(IFormFile file, string filePath)
        {
            var fileFormat = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            fileFormat = fileFormat.ToLower();
            string fileName = Guid.NewGuid().ToString() + fileFormat;
            string path = filePath + fileName;
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }

        public void FileDeleteToServer(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception)
            {
            }
        }

        public string FileSaveToFtp(IFormFile file)
        {
            var fileFormat = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            fileFormat = fileFormat.ToLower();
            string fileName = Guid.NewGuid().ToString() + fileFormat;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://home/retinabilisim-b2b/htdocs/b2b.retinabilisim.com.tr/assets/img/" + fileName);
            request.Credentials = new NetworkCredential("retinabilisim-b2b-ftp", "ZShNBsLrwj2jv5DXlAoQ");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            using (Stream ftpStream = request.GetRequestStream())
            {
                file.CopyTo(ftpStream);
            }

            return fileName;
        }

        public void FileDeleteToFtp(string path)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("sftp://b2b.technobox.tv/assets/img/" + path);
                request.Credentials = new NetworkCredential("technobox-b2b", "mcYZMZqgS9ULVXqjgmAy");
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
            }
        }

        public string FileSaveToSftp(IFormFile file)
        {
            try
            {
                using (var client = new SftpClient(host, port, username, password))
                {
                    client.Connect();

                    if (!client.IsConnected)
                    {
                        throw new Exception("Unable to connect to the SFTP server.");
                    }

                    var fileFormat = Path.GetExtension(file.FileName).ToLower();
                    string fileName = Guid.NewGuid().ToString() + fileFormat;

                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        memoryStream.Position = 0;
                        client.UploadFile(memoryStream, Path.Combine(remoteDirectory, fileName));
                    }

                    client.Disconnect();
                    return fileName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public void FileDeleteToSftp(string path)
        {
            string host = "b2b.technobox.tv";
            string username = "technobox-b2b";
            string password = "mcYZMZqgS9ULVXqjgmAy";
            int port = 22;
            string remoteDirectory = "/home/technobox-b2b/htdocs/b2b.technobox.tv/assets/img/";

            try
            {
                using (var client = new SftpClient(host, port, username, password))
                {
                    client.Connect();

                    if (!client.IsConnected)
                    {
                        throw new Exception("Unable to connect to the SFTP server.");
                    }

                    string fullPath = Path.Combine(remoteDirectory, path);
                    if (client.Exists(fullPath))
                    {
                        client.DeleteFile(fullPath);
                    }
                    else
                    {
                        throw new FileNotFoundException("The specified file does not exist on the SFTP server.");
                    }

                    client.Disconnect();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you could use a logging framework)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public byte[] FileConvertByteArrayToDatabase(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                var fileBytes = memoryStream.ToArray();
                string fileString = Convert.ToBase64String(fileBytes);
                return fileBytes;
            }
        }

    }
}
