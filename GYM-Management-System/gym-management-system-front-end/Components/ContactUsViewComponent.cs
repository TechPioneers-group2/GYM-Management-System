using Microsoft.AspNetCore.Mvc;

namespace gym_management_system_front_end.Components
{
    public class ContactUsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
