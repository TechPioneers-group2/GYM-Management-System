using gym_management_system_front_end.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace gym_management_system_front_end.Components
{
    public class GetAllSupplementsViewComponent : ViewComponent
    {
        private readonly SupplementController _supplementController;

        public GetAllSupplementsViewComponent(SupplementController supplementController)
        {
            _supplementController = supplementController;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var supplementsViewResult = (ViewResult)await _supplementController.Index();

            return View(supplementsViewResult.Model);
        }
    }
}
