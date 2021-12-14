/*
 *┌──────────────────────────────────────────┐
 *│  描   述: FileSearcher
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 17:26:07
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public class FileSearcher
    {
        public event EventHandler<FileFoundArgs> FileFound;

        public void Search(string directory, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                FileFound?.Invoke(this, new FileFoundArgs(file));
            }
        }


        public FileSearcher()
        {
            FileFound += FileSearcher_FileFound;
        }

        private void FileSearcher_FileFound(object? sender, FileFoundArgs e)
        {

        }
    }
}
