using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sphinxAssesment.Pages.Edit
{
    public class EditProductModel : PageModel
    {
        private readonly IProductService _productService;
        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }


        [BindProperty]
        public ViewModelEditProduct ViewModel { get; set; }
        public async Task<IActionResult> OnGet()
        {

            ViewModel = new ViewModelEditProduct(); 
            Guid ProductId =  Guid.TryParse(Request.Query["ProductId"], out ProductId) ? ProductId : Guid.Empty;
            ProductServiceResponse serviceResponse =await _productService.GetProductById(ProductId);

            if (!serviceResponse.Success)
            {
                return RedirectToPage("/Products");

            }
            ViewModel.CurrentProduct = serviceResponse.Products[0];

            return Page();

        }

        public async Task<IActionResult> OnPostEditAsync() {
        ProductServiceResponse serviceResponse = await _productService.UpdateProductsAsync(ViewModel.CurrentProduct);
        if (!serviceResponse.Success)
        {
            return RedirectToPage("/Products",new { Messege = serviceResponse.messege});
        }
        return RedirectToPage("/Edit/EditProduct" , new  { ProductId = ViewModel.CurrentProduct.ProductId.ToString() });

        }


        public async Task<IActionResult> OnPostDeleteAsync()
        {
            ProductServiceResponse serviceResponse = await _productService.DeleteProductsAsync(ViewModel.CurrentProduct.ProductId);
            if (!serviceResponse.Success)
            {
                return RedirectToPage("/Products", new { Messege = serviceResponse.messege });
            }
            return RedirectToPage("/Products");

        }


    }

    public class ViewModelEditProduct {

        public Product CurrentProduct { get; set; } = new Product();

    }
}
