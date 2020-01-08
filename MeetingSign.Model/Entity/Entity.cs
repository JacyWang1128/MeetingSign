using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeetingSign.Model.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("tb_meetingroom")]
    public class MeetingRoom
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public int createrid { get; set; }
        public string createtime { get; set; }
    }

    [Table("tb_person")]
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int deptid { get; set; }
        public string feature { get; set; }
        public string photouri { get; set; }
        public int createrid { get; set; }
        public string createtime { get; set; }
    }

    [Table("tb_meeting")]
    public class Meeting
    {
        [Key]
        public int id { get; set; }
        public string date { get; set; }
        public int meetingroomid { get; set; }
        public string meetname { get; set; }
        public string attendpersonid { get; set; }
        public string unattendpersonid { get; set; }
        public string replacepersonid { get; set; }
        public int createrid { get; set; }
        public string creaetetime { get; set; }
    }

    [Table("tb_dept")]
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string deptname { get; set; }
        public int creater_id { get; set; }
        public string createtime { get; set; }
    }

    [Table("tb_sign")]
    public class Sign
    {
        [Key]
        public int id { get; set; }
        public int meetid { get; set; }
        public string signdate { get; set; }
        public int personid { get; set; }
        public int islate { get; set; }
    }

    [Table("tb_user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string createrid { get; set; }
        public string createtime { get; set; }
    }
    class Entity
    {
    }
}
