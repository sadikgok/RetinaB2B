using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Renci.SshNet;
using System.Net;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
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

        public string FileSaveToSftp(IFormFile file)
        {
            string host = "b2b.retinabilisim.com.tr";
            string username = "retinabilisim-b2b";
            string password = "zQpFIr6sZ7S9lVMl1iFf";
            int port = 22;
            string remoteDirectory = "/home/retinabilisim-b2b/htdocs/b2b.retinabilisim.com.tr/assets/img/";

            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();
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

        public void FileDeleteToFtp(string path)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("sftp://b2b.retinabilisim.com.tr/assets/img/" + path);
                request.Credentials = new NetworkCredential("retinabilisim-b2b", "zQpFIr6sZ7S9lVMl1iFf");
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
            }
        }
    }
}
