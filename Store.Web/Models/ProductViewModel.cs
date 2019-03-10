using Microsoft.AspNetCore.Http;
using Store.Web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
