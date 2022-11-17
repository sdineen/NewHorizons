using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Entity;
using ClassLibrary.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MvcApp
{
    public class Page1Model : PageModel
    {
        private IEcommerceService ecommerceService;

        public Page1Model(IEcommerceService ecommerceService)
        {
            this.ecommerceService = ecommerceService;
        }

        public string Message { get; set; }
        public void OnGet()
        {
            Message = $" Server time is { DateTime.Now }";
        }


        [BindProperty]
        public Product Product { get; set; }
        public async Task OnPostAsync()
        {
            bool created = await ecommerceService.CreateProductAsync(Product);
        }
    }
}
