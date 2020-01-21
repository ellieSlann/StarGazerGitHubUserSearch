using System.Threading.Tasks;
using System.Web.Mvc;

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
            ViewData.Model = true;
            return View("SearchPage");
        }

        [HttpPost]
        public async Task<ActionResult> Index(string searchUserName)
        {
            var userName = HelperMethods.RemoveWhitespace(searchUserName);
            try
            {
                var model = await _userModelBuilder.Build(userName);
                return View("ResultsPage", model);
            }
            catch
            {
                ViewData.Model = false;
                return View("SearchPage");
            }
        }
    }
}
