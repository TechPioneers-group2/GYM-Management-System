using gym_management_system_front_end.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace gym_management_system_front_end.Components
{
    public class GetAllGymsViewComponent : ViewComponent
    {
        private readonly GymsController _gymsController;

        public GetAllGymsViewComponent(GymsController gymsController)
        {
            _gymsController = gymsController;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var gymsViewResult = (ViewResult)await _gymsController.Index();

            return View(gymsViewResult.Model);

        }
    }
}
