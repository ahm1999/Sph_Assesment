using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Entities;
using DTOs.ProductDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sphinxAssesment.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductService _productService;
        public ProductsModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductsViewModel ViewModel { get; set; }

        public async Task OnGetAsync()
        {
            int page = int.TryParse(Request.Query["pageNo"], out page) ? page : 0;
            ViewModel = new ProductsViewModel();
            ProductServiceResponse response =  await _productService.GetProductsAsync(page);
            ViewModel.products = response.Products;
            int numberOfPages = (int)Math.Ceiling((double)response.ProductCount/ 10);
            ViewModel.numberOfpages = numberOfPages;
        }

        public async Task<IActionResult> OnPostAsync() {
            await _productService.CreateProductsAsync(ViewModel.createProductDTO);

            return RedirectToPage();
        }

    }

    public class ProductsViewModel {


        public int numberOfpages { get; set; } = 1;
        public CreateProductDTO createProductDTO { get; set; } = new CreateProductDTO();

        public List<Product> products { get; set; } = new List<Product>();


    };

}
