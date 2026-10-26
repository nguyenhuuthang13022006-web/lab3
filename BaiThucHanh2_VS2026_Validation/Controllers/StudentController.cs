using BaiThucHanh2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaiThucHanh2.Controllers;

public class StudentController : Controller
{
    private static readonly List<Student> Students = new()
    {
        new() { Id = 101, Name = "Hải Nam", Email = "nam@gmail.com", Password = "12345678", Branch = "IT", IsRegular = true, DateOfBirth = new DateTime(2001, 1, 1), Gender = "Male", Address = "A1-2018", Score = 8.2f },
        new() { Id = 102, Name = "Minh Tú", Email = "tu@gmail.com", Password = "12345678", Branch = "Business", IsRegular = true, DateOfBirth = new DateTime(2001, 1, 1), Gender = "Female", Address = "A1-2019", Score = 7.5f },
        new() { Id = 103, Name = "Hoàng Phong", Email = "phong@gmail.com", Password = "12345678", Branch = "CE", IsRegular = false, DateOfBirth = new DateTime(2002, 1, 1), Gender = "Male", Address = "A1-2020", Score = 9.0f },
        new() { Id = 104, Name = "Xuân Mai", Email = "mai@gmail.com", Password = "12345678", Branch = "English", IsRegular = false, DateOfBirth = new DateTime(2003, 1, 1), Gender = "Female", Address = "A1-2021", Score = 8.8f }
    };

    private void PopulateDropdowns()
    {
        ViewBag.AllGenders = new List<SelectListItem>
        {
            new() { Text = "Nam", Value = "Male" },
            new() { Text = "Nữ", Value = "Female" }
        };

        ViewBag.AllBranches = new List<SelectListItem>
        {
            new() { Text = "CE", Value = "CE" },
            new() { Text = "IT", Value = "IT" },
            new() { Text = "BE", Value = "Business" },
            new() { Text = "EE", Value = "English" }
        };
    }

    public IActionResult Index(string? search)
    {
        IEnumerable<Student> result = Students;
        if (!string.IsNullOrWhiteSpace(search))
        {
            result = result.Where(s => s.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                || s.Email.Contains(search, StringComparison.OrdinalIgnoreCase)
                || s.Id.ToString().Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        ViewData["Search"] = search ?? string.Empty;
        return View(result.ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        PopulateDropdowns();
        return View(new Student { DateOfBirth = new DateTime(2000, 1, 1), IsRegular = true });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            PopulateDropdowns();
            return View(student);
        }

        student.Id = Students.Count == 0 ? 101 : Students.Max(s => s.Id) + 1;
        Students.Add(student);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();
        PopulateDropdowns();
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Student updatedStudent)
    {
        if (id != updatedStudent.Id) return BadRequest();

        if (!ModelState.IsValid)
        {
            PopulateDropdowns();
            return View(updatedStudent);
        }

        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        student.Name = updatedStudent.Name;
        student.Email = updatedStudent.Email;
        student.Password = updatedStudent.Password;
        student.Branch = updatedStudent.Branch;
        student.IsRegular = updatedStudent.IsRegular;
        student.DateOfBirth = updatedStudent.DateOfBirth;
        student.Gender = updatedStudent.Gender;
        student.Address = updatedStudent.Address;
        student.Score = updatedStudent.Score;

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();
        Students.Remove(student);
        return RedirectToAction(nameof(Index));
    }
}
