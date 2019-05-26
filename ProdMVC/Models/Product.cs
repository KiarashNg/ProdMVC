using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name ="دسته بندی")]
        [Required]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name ="شرکت تولیدکننده")]
        [Required]
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [Display(Name ="نام محصول")]
        [Required]
        public string ModelName { get; set; }
        [Display(Name ="توضیحات")]
        public string Description { get; set; }
    }
}