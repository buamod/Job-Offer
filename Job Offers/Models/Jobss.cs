using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Job_Offers.Models
{
    public class Jobss
    {
        public int Id { get; set; }

        [DisplayName("اسم الوظيفة")]
        public string JobTitle { get; set; }

        [DisplayName("وصف الوظيفة")]
        public string JibContent { get; set; }

        [DisplayName("صورة الوظيفة")]
        public string JobImage { get; set; }

        [DisplayName("نوع الوظيفة")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

    }
}