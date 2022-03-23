using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    [Table("EQUIPMENT")]
    public class Equipment
    {
        [Key]
        [Column("ID")]
        public string Id { get; set; }

        [Column("EQUIPMENT_GROUP_ID")]
        public string EquipmentGroupId { get; set; }

        [Column("EQUIPMENT_NAME")]
        public string EquipmentName { get; set; }

        public List<EquipmentType> EQUIPMENT_TYPES { get; set; }
    }

    public enum EquipmentType
    {
        TBJ=1,
        GY=2
    }
}
