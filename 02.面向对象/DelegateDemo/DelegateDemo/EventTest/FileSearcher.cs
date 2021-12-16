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
        /// <summary>
        /// 事件 - 找到了文件
        /// </summary>
        public event EventHandler<FileFoundArgs> FileFound;

        public void Search(string directory, string searchPattern)
        {
            foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
            {
                // 触发事件
               FileFound?.Invoke(this, new FileFoundArgs(file));
            }
        }


        public FileSearcher()
        {
            // 内部订阅
            FileFound += FileSearcher_FileFound;
        }


        public void FileSearcher_FileFound(object? sender, FileFoundArgs e)
        {
            Console.WriteLine("FileSearcher_FileFound 找到了文件:"+e.FoundFile);
        }
    }
}
