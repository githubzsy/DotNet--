/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Animal
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/20 16:10:10
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
namespace WebApiDemo.Models
{
    /// <summary>
    /// 动物Dto
    /// </summary>
    public class AnimalDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
    }
}
