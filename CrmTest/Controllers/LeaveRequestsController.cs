using Microsoft.AspNetCore.Mvc;

namespace CrmTest.Controllers
{
    public class LeaveRequestsController : Controller
    {

        public async Task<IActionResult> MyLeaveRequests()
        {

            return View();
        }
    }
}
