namespace Task_MOPMAR.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void FillDropDown()
        {
            ViewBag.Governorates = _context.Governorates.ToList();
            ViewBag.Centers = _context.Centers.ToList();
            ViewBag.Villages = _context.Villages.ToList();
        }
        public IActionResult GetCentersByGovernorate(int governorateId)
        {
            var centers = _context.Centers
                .Where(c => c.GovernorateId == governorateId)
                .Select(c => new { value = c.Id, text = c.Name })
                .ToList();
            return Json(centers);
        }
        public IActionResult GetVillagesByCenter(int centerId)
        {
            var villages = _context.Villages
                .Where(v => v.CenterId == centerId)
                .Select(v => new { value = v.Id, text = v.Name })
                .ToList();
            return Json(villages);
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            FillDropDown();
            return View();
        }
        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Writer,Admin")]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(model);
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            FillDropDown();
            return View(model);
        }
        [Authorize(Roles = "Editor,Admin")]
        public async Task<IActionResult> Update(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<EmployeeViewModel>(employee);
            FillDropDown();
            return View(model);
        }
        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Editor,Admin")]
        public async Task<IActionResult> Update(int id, EmployeeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }
                _mapper.Map(model, employee);
                _context.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            FillDropDown();
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}