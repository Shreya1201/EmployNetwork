using EmployNet.Data;
using EmployNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Finance")]
public class PayrollController : Controller
{
    private readonly ApplicationDbContext _context;

    // Constructor to initialize the database context
    public PayrollController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Display a list of payroll entries
    public IActionResult Index()
    {
        var payrolls = _context.Payrolls.Include(p => p.Employee).ToList();
        return View(payrolls);
    }

    // Display form to create a new payroll entry
    public IActionResult Create()
    {
        return View();
    }

    // Handle form submission to create a new payroll entry
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PayrollDto payrollDto)
    {
        if (ModelState.IsValid)
        {
            // Check if the EmployeeId exists in the Employee table
            var employeeExists = _context.Employees.Any(e => e.Id == payrollDto.EmployeeId);
            if (!employeeExists)
            {
                ModelState.AddModelError("EmployeeId", "The Employee ID provided does not exist.");
                return View(payrollDto);
            }

            // Check for existing payroll with the same EmployeeId and PayDate
            var payrollExists = _context.Payrolls
                .Any(p => p.EmployeeId == payrollDto.EmployeeId && p.PayDate.Date == payrollDto.PayDate.Date);
            if (payrollExists)
            {
                ModelState.AddModelError("PayDate", "A payroll entry for this employee on the given date already exists.");
                return View(payrollDto);
            }

            // Create a new Payroll record
            var payroll = new Payroll
            {
                EmployeeId = payrollDto.EmployeeId,
                BaseSalary = payrollDto.BaseSalary,
                Bonus = payrollDto.Bonus,
                Deductions = payrollDto.Deductions,
                PayDate = payrollDto.PayDate,

            };

            // Add the payroll entry to the database
            _context.Add(payroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Return the view with validation errors if ModelState is not valid
        return View(payrollDto);
    }

    // Display form to edit an existing payroll entry
    public IActionResult Edit(int id)
    {
        var payroll = _context.Payrolls.Find(id);
        if (payroll == null)
        {
            return NotFound();
        }
        return View(payroll);
    }

    // Handle form submission to edit an existing payroll entry
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Payroll payroll)
    {
        if (id != payroll.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // Update the payroll entry in the database
                _context.Update(payroll);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Payrolls.Any(e => e.Id == payroll.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(payroll);
    }

    // Handle form submission to delete a payroll entry
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var payroll = _context.Payrolls.Find(id);
        if (payroll != null)
        {
            _context.Payrolls.Remove(payroll);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
