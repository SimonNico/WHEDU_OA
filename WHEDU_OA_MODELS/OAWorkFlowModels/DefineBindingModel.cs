using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WHEDU_OA_MODELS
{

   public class DefineBindingModel
    {
        [Required]
        [Display(Name ="流程名称")]
        public string Model_Name { get; set; }

        [Required]
        [Display(Name ="流程定义")]
        public string Model_Json { get; set; }
        
    }
}
