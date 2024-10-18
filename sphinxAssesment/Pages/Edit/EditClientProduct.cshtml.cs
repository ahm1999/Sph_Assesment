using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sphinxAssesment.Pages.Edit
{
    public class EditClientProductModel : PageModel
    {
        private readonly IClientProductService _clientProductService;
        public EditClientProductModel(IClientProductService clientProductService)
        {
            _clientProductService = clientProductService;
        }


        [BindProperty]
        public ViewModelClientProduct ViewModel { get; set; }
        public async Task<IActionResult> OnGetAsync() { 
        

            ViewModel = new ViewModelClientProduct();
            int clientCode = int.TryParse(Request.Query["clientCode"], out clientCode) ? clientCode : 1;
            Guid ProductId = Guid.TryParse(Request.Query["ProductId"], out ProductId) ? ProductId : Guid.Empty;

            ClientProductServiceResponse serviceResponse = await _clientProductService.GetClientProductByIdAsync(clientCode, ProductId);

            ViewModel.CurrentCliPro = serviceResponse.ClientProducts[0];

            if (!serviceResponse.success)
            {

                return RedirectToPage("/Client");

            }
            return Page();
        }
                
             
       

        public async Task<IActionResult> OnPostEditAsync()
        {
            ClientProductServiceResponse serviceResponse = await _clientProductService.UpdateClientProductAsync(ViewModel.CurrentCliPro);

            if (!serviceResponse.success)
            {
                return RedirectToPage("/ClientPage", new { clientCode = ViewModel.CurrentCliPro.ClientCode, Messege = serviceResponse.Messege });
            }
            return RedirectToPage("/Edit/EditClientProduct", new { ProductId = ViewModel.CurrentCliPro.ProductId.ToString() , clientCode = ViewModel.CurrentCliPro.ClientCode });

        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            ClientProductServiceResponse serviceResponse = await _clientProductService.DeleteClientProductAsync(ViewModel.CurrentCliPro.ClientCode,ViewModel.CurrentCliPro.ProductId);

            if (!serviceResponse.success)
            {
                return RedirectToPage("/Edit/EditClientProduct", new { ProductId = ViewModel.CurrentCliPro.ProductId.ToString(), clientCode = ViewModel.CurrentCliPro.ClientCode });

            }
            return RedirectToPage("/ClientPage", new { clientCode = ViewModel.CurrentCliPro.ClientCode, Messege = serviceResponse.Messege });


        }


        public class ViewModelClientProduct {
            public ClientProduct CurrentCliPro { get; set; } = new ClientProduct();

        };
    }
}
