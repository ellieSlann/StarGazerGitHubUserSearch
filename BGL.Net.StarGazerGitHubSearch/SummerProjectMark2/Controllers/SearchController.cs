using System.Threading.Tasks;
using System.Web.Mvc;
using BGL.Net.StarGazerGitHubSearch.Models;

namespace BGL.Net.StarGazerGitHubSearch.Controllers
{
    public class SearchController : Controller
    {
        public IUserModelBuilder _userModelBuilder;

        public SearchController(IUserModelBuilder userModelBuilder)
        {
            _userModelBuilder = userModelBuilder;
        }

        public ActionResult Index()
        {
            return View("SearchPage");
        }

        [HttpPost]
        public async Task<ActionResult> Index(string searchUserName)
        {
            try
            {
                var model = await _userModelBuilder.Build(searchUserName);
                return View("ResultsPage", model);
            }
            catch
            {
                return View("SearchPage",new User());
            }
        }
        
    }
}
