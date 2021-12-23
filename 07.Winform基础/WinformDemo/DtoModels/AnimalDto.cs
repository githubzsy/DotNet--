/*
 *┌──────────────────────────────────────────┐
 *│  描   述: AnimalService
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/21 16:05:41
 *│  说   明:
 *└──────────────────────────────────────────┘
 */

using System.ComponentModel.DataAnnotations;

namespace DtoModels
{
    /// <summary>
    /// 动物Dto
    /// </summary>
    public class AnimalDto
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }
    }
}