using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class FileStreamTest
    {
        private static readonly String FilePath = @"D:\aliyuncli\regions.txt";

        public void GetFileBytes()
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            {
                Int32 bytesRead = fs.ReadByte();

                Console.WriteLine("Bytes Read={0}", bytesRead);
            }

            using (FileStream fs =
                new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.None, 100, FileOptions.Asynchronous))
            {
                Int32 bytesCount = fs.ReadByte();
                var bytesCountAsync = fs.ReadAsync(new byte[] { }, 0, 100);

                Console.WriteLine("Bytes Count={0}", bytesCount);
                Console.WriteLine("Bytes Count async={0}", bytesCountAsync);
            }
        }

        /// <summary>
        /// async  会将代码转变成 状态机 的一个类型
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task<String> IssueClientRequestAsync(String serverName, String message)
        {
            using (var pipe = new NamedPipeClientStream(
                serverName,
                "PipeName",
                PipeDirection.InOut,
                PipeOptions.Asynchronous | PipeOptions.WriteThrough))
            {
                pipe.Connect();
                pipe.ReadMode = PipeTransmissionMode.Message;

                Byte[] request = Encoding.UTF8.GetBytes(message);
                await pipe.WriteAsync(request, 0, request.Length);


                Byte[] response = new byte[1000];

                Int32 bytesRead = await pipe.ReadAsync(response, 0, response.Length);

                return Encoding.UTF8.GetString(response, 0, bytesRead);
            }
        }
    }
}
