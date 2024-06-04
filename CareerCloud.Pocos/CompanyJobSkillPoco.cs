using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
    public class CompanyJobSkillPoco : IPoco
    {
        [Key]
        public Guid Id { set; get; }

        [Column("Skill_Level")]
        public string SkillLevel { set; get; }

        [Column("Time_Stamp")]
        [NotMapped]
        public byte[] TimeStamp { set; get; }

        [Column("Skill")]
        public string Skill { set; get; }

        [Column("Importance")]
        public int Importance { set; get; }

        [Column("Job")]
        public Guid Job { set; get; }

        public virtual CompanyJobPoco CompanyJob { get; set; }



    }
}
