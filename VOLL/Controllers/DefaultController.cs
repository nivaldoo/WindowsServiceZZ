using System.Web.Http;
using VOLL.Models;

namespace VOLL.Controllers
{
    public class DefaultController : ApiController
    {
        public void Post([FromBody]DefaultViewModel value)
        {
            DefaultModel.Include(value);
        }
    }
}
