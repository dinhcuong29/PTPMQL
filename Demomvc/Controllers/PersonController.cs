using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demomvc.Data;
using Demomvc.Models;
using Demomvc.Models.Process;
using OfficeOpenXml;
using X.PagedList;
using X.PagedList.Extensions;


namespace Demomvc.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Person
        // public async Task<IActionResult> Index()
        // {
        //     return View(await _context.Person.ToListAsync());
        // }

        //Search

        // [HttpPost]

        // public async Task<IActionResult> Index(string searchString)
        // {
        //     if (_context.Person == null)
        //     {
        //         return Problem("Entity set 'ApplicationDbContext.Person'  is null.");
        //     }

        //     var person = from m in _context.Person select m;

        //     if (!String.IsNullOrEmpty(searchString))
        //     {
        //         // person = person.Where(s => s.FullName != null && 
        //         //            s.FullName.ToUpper().Contains(searchString.ToUpper()));
        //         person = person.Where(s => s.FullName != null &&
        //                            EF.Functions.Like(s.FullName, $"%{searchString.Trim()}%"));

        //     }

        //     return View(await person.ToListAsync());
        // }

        //Phân Trang 
        public async Task<IActionResult> Index(int? page)
        {
            var model = _context.Person.ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }

        // Tìm Kiếm + Phân Trang
        [HttpPost]
        public async Task<IActionResult> Index(int? page, string searchString)
        {
            if (_context.Person == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Person' is null.");
            }

            var person = from m in _context.Person select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                person = person.Where(s => s.FullName != null &&
                                           EF.Functions.Like(s.FullName, $"%{searchString.Trim()}%"));
            }

            var pagedModel = person.ToPagedList(page ?? 1, 5);

            return View(pagedModel);
        }



        // GET: Person/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,FullName,Address")] Person person)
        {
            if (ModelState.IsValid)
            // Kiểm tra thỏa mãn các điều kiện ở model
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                //Data Anotation
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,FullName,Address")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonID))
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
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person != null)
            {
                _context.Person.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id)
        {
            return _context.Person.Any(e => e.PersonID == id);
        }





        //Upload
        public async Task<IActionResult> Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Upload(IFormFile file)

        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to server
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from excel file fill DataTable
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        // using for loop to read data from dt 
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create new Person object
                            var ps = new Person();
                            //set value to attributes

                            ps.PersonID = dt.Rows[i][0].ToString();
                            ps.FullName = dt.Rows[i][1].ToString();
                            ps.Address = dt.Rows[i][2].ToString();
                            //add object to context
                            _context.Add(ps);

                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();

        }

        //DownLoad
        public async Task<IActionResult> DownLoad()
        {
            // Đặt tên cho file khi tải xuống
            var fileName = "Person.xlsx";

            // Sử dụng "using" để đảm bảo ExcelPackage được giải phóng tài nguyên sau khi sử dụng
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                // Đặt tiêu đề cho các cột
                worksheet.Cells["A1"].Value = "PersonID";
                worksheet.Cells["B1"].Value = "FullName";
                worksheet.Cells["C1"].Value = "Address";

                // Lấy danh sách Person
                var personList = _context.Person.ToList();

                worksheet.Cells["A2"].LoadFromCollection(personList, false, OfficeOpenXml.Table.TableStyles.Medium2);

                var stream = new MemoryStream(await excelPackage.GetAsByteArrayAsync());

                // Tải file xuống
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

    }
}
