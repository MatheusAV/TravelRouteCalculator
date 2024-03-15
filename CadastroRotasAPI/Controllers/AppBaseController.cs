using CadastroRotasServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroRotasAPI.Controllers
{
    public class AppBaseController : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly IRotaService _service;
        public AppBaseController(IServiceProvider serviceProvider, IRotaService service)
        {
            serviceProvider = _serviceProvider;
            _service = service;
        }
    }
}
