using System.Linq;
using SIS.HTTP.Responses;
using TorshiaWebApp.ViewModels.Home;
using TorshiaWebApp.ViewModels.Tasks;

namespace TorshiaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user != null)
            {
                var viewModel = new LoggedInIndexViewModel();
                viewModel.YourTasks = this.Db.Tasks.Where(
                        x => x.IsReported == false)
                    .Select(x => new BaseTaskViewModel
                    {
                        Id = x.Id,
                        Name = x.Title,
                        Level = x.AffectedSectors.Count.ToString()
                    }).ToList();

                return this.View("Home/LoggedIn-Index", viewModel);
            }
            else
            {
                return this.View();
            }
        }
    }
}
