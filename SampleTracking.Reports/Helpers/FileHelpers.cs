using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Models.File;

namespace Helpers
{
    public class FileHelpers
    {
        public static IEnumerable<UpdatedFile> MonitorFolder(string directory, DateTime lastReadDateTime)
        {
            var fileScans = new List<UpdatedFile>();
            var dir = new DirectoryInfo(directory);

            foreach (var flInfo in dir.GetFiles().Where(f => f.Extension==".csv" && f.LastWriteTime > lastReadDateTime))
            {
                var fileScan = new UpdatedFile()
                {
                    Name = flInfo.Name,
                    Size = flInfo.Length,
                    CreationDateTime = flInfo.CreationTime,
                    LastWriteDateTime = flInfo.LastWriteTime
                };
                fileScans.Add(fileScan);
            }

            return fileScans;
        }

    }
}
