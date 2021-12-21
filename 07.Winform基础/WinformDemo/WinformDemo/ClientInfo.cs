/*
 *┌──────────────────────────────────────────┐
 *│  描   述: ClinetInfo
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/21 11:13:33
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinformDemo
{
    public class ClientInfo: INotifyPropertyChanged
    {
        public string Name {
            get => name;
            set
            {
                if (value != Name)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string Text { get => text; set
            {
                if (value != text)
                {
                    text = value;
                    NotifyPropertyChanged();
                }
            }

        }

        private string name;
        private string text;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
