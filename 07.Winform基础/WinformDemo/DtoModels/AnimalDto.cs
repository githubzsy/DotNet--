/*
 *┌──────────────────────────────────────────┐
 *│  描   述: AnimalService
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/21 16:05:41
 *│  说   明:
 *└──────────────────────────────────────────┘
 */

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DtoModels
{
    /// <summary>
    /// 动物Dto
    /// </summary>
    public class AnimalDto : INotifyPropertyChanged
    {
        public string Id
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        private string id;


        public string Name
        {
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

        private string name;

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age
        {
            get => age;
            set
            {
                age = value;
                NotifyPropertyChanged();
            }
        }

        private int? age;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}