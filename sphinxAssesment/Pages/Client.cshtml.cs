using Azure.Identity;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Entities;
using DTOs.ClientDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sphinxAssesment.Pages
{
    public class ClientModel : PageModel
    {
        private readonly IClientService _clientService;
        public ClientModel (IClientService clientService)
        {
            _clientService = clientService;
        }


        [BindProperty]
        public ClientPageViewModel clientPageViewModel { get; set; }


        public async Task OnGetAsync()
        {
             int page = int.TryParse(Request.Query["pageNo"], out page) ? page : 0;
             clientPageViewModel = new ClientPageViewModel();
             clientPageViewModel.CurrentPage = page;   
             ClientServiceResponse clientServiceResponse = await _clientService.GetALlClientsAsync(page);
             int noOfClients = clientServiceResponse.ClientCount;
             int numberOfPages = (int)Math.Ceiling((double)noOfClients / 10);
             clientPageViewModel.noOfPages = numberOfPages;

             clientPageViewModel.Clients = clientServiceResponse.Clients;
             

        }




        public async Task<IActionResult> OnPostAsync() {

            if (!ModelState.IsValid)
            {
                return RedirectToPage("/Client",new { pageNo = clientPageViewModel.CurrentPage  } );
            }

            ClientServiceResponse clientServiceResponse = await _clientService.CreateClient(clientPageViewModel.createCLientDTO);

            return RedirectToPage("/Client", new { pageNo = clientPageViewModel.CurrentPage });
        }

       
    }

    public class ClientPageViewModel
    {
        public int noOfPages { get; set; }

        public int CurrentPage { get; set; }
        public CreateCLientDTO createCLientDTO { get; set; } = new CreateCLientDTO();

        public List<Client> Clients { get; set; } = new List<Client>() ;


    };

}
