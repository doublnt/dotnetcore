using System;
using System.Collections.Generic;
using System.IO;
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

                Console.WriteLine("Bytes Read: {0}", bytesRead);
            }
        }
    }
}
