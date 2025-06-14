using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebFormRegister.Models;
using WebFormRegister.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebFormRegister.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index(int? editId)
    {
        var vm = new UserViewModel
        {
            Users = _db.Users.ToList()
        };

        if (editId.HasValue)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == editId.Value);
            if (user != null)
                vm.NewUser = user;
        }

        return View(vm);
    }

    [HttpPost]
    public IActionResult Index(UserViewModel vm)
    {
        if (vm.NewUser.Id == 0)
        {
            // Thêm mới
            if (ModelState.IsValid)
            {
                _db.Users.Add(vm.NewUser);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        else
        {
            // Sửa
            if (ModelState.IsValid)
            {
                var user = _db.Users.FirstOrDefault(u => u.Id == vm.NewUser.Id);
                if (user != null)
                {
                    user.FullName = vm.NewUser.FullName;
                    user.DateOfBirth = vm.NewUser.DateOfBirth;
                    user.Phone = vm.NewUser.Phone;
                    user.Email = vm.NewUser.Email;
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        vm.Users = _db.Users.ToList();
        return View(vm);
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
