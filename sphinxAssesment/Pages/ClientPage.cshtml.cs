using Azure;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Entities;
using DTOs.ClientProductDTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sphinxAssesment.Pages
{
    public class ClientPageModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IClientService _clientService;
        private readonly IClientProductService _clientProductService;
        public ClientPageModel(IProductService productService,IClientService clientService,IClientProductService clientProductService)
        {
            _productService = productService;
            _clientService = clientService;
            _clientProductService = clientProductService;
        }


        [BindProperty]
        public ViewModelClientPage ViewModel { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewModel = new ViewModelClientPage();
            int clientCode = int.TryParse(Request.Query["clientCode"], out clientCode) ? clientCode : 1;
            int page = int.TryParse(Request.Query["pageNo"], out page) ? page : 0;
            ProductServiceResponse productServiceResponse   = await _productService.GetActiveProductsAsync(page);
            ClientServiceResponse clientServiceResponse = await _clientService.GetClientByCodeAsync(clientCode);
            int numberOfPages = (int)Math.Ceiling((double)productServiceResponse.ProductCount / 10);
            ViewModel.numberOfpages = numberOfPages;
            if (!clientServiceResponse.Success)
            {
                return RedirectToPage("/Client");
            }

            ViewModel.ActiveProducts = productServiceResponse.Products;
            ViewModel.CurrentClient = clientServiceResponse.Clients[0];

            return Page();
        }

        public async Task<IActionResult> OnPostAddClientProductAsync() {
            ClientProductServiceResponse serviceResponse =  await _clientProductService.AddClientProductAsync(ViewModel.CreateClientProduct);
            if (!serviceResponse.success)
            {
                return RedirectToPage("/ClientPage", new { clientCode = ViewModel.CreateClientProduct.ClientCode ,ErrorMessege =serviceResponse.Messege});
            }
            return RedirectToPage("/ClientPage", new { clientCode = ViewModel.CreateClientProduct.ClientCode });
        }

    }

    public class ViewModelClientPage
    {
       public int numberOfpages { get; set; } = 1;
       public Client CurrentClient { get; set; } = new Client();

       public List<Product> ActiveProducts { get; set; } = new List<Product>();

       public CreateClientProductDTO CreateClientProduct { get; set; } = new CreateClientProductDTO();

    }
}