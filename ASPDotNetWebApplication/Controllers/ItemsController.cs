using ASPDotNetWebApplication.Context;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ASPDotNetWebApplication.Controllers
{
    public class ItemsController : Controller
    {
        private AppDbContext _context;

        public ItemsController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Item
        public ActionResult Example(int Id)
        {
            var Item = _context.Items.Include(it => it.Features).SingleOrDefault(i => i.Id == Id);
            if (Item == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(Item);
            }
        }

        [Route("items/bystatus/{status}")]
        public ActionResult ByStatus(int status)
        {
            return Content(status.ToString());
        }
    }
}