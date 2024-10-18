using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sphinxAssesment.Pages.Edit
{
    public class EditClientModel : PageModel
    {
        private readonly IClientService _clientService;
        public EditClientModel(IClientService clientService)
        {
            _clientService = clientService; 
        }

        [BindProperty]
        public ViewModelEditClient ViewModel { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ViewModel = new ViewModelEditClient();

            int clientCode = int.TryParse(Request.Query["clientCode"], out clientCode) ? clientCode : 1;
            ClientServiceResponse serviceResponse =  await _clientService.GetJustClientByCodeAsync(clientCode);
            if (!serviceResponse.Success) {
                return RedirectToPage("/Client");
            }
            ViewModel.CurrentCLient = serviceResponse.Clients[0];

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync() {

            ClientServiceResponse serviceRespnose = await _clientService.DeleteClientAsync(ViewModel.CurrentCLient.Code);
            if (!serviceRespnose.Success) { 
                return RedirectToPage("/Edit/EditClient",new { clientCode = ViewModel.CurrentCLient.Code });
            }
            return RedirectToPage("/Client" ,new {Messege ="deleted succesfully" });



        }

        public async Task<IActionResult> OnPostEditAsync()
        {

            ClientServiceResponse serviceRespnose = await _clientService.EditClientAsync(ViewModel.CurrentCLient);
            if (!serviceRespnose.Success)
            {
                return RedirectToPage("/Edit/EditClient", new { clientCode = ViewModel.CurrentCLient.Code,Messege =serviceRespnose.Messege });
            }
            return RedirectToPage("/Edit/EditClient", new { clientCode = ViewModel.CurrentCLient.Code });

        }


    }

    public class ViewModelEditClient
    {
        public Client toBeEditedClient { get; set; } = new Client();
        public Client CurrentCLient { get; set; } = new Client();

    }


}
