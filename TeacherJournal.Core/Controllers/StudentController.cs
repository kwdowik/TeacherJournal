using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeacherJournal.BusinessLogic;
using TeacherJournal.Core.Models;


namespace TeacherJournal.Core.Controllers
{
    [Authorize]    
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        private readonly MarkService _markService;
        
        
        public StudentController(StudentService studentService, MarkService markService)
        {
            _studentService = studentService;
            _markService = markService;
        }

        //GET: Index
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAll();
            return View(students);
        }

        //GET: Details
        public async Task<IActionResult> Details(int? id)
        {
            var student = await _studentService.GetByIdAsync(id);
            
            if(student == null)
                return NotFound();

            var grpMarks = student.Marks
                .GroupBy(m => m.Subject.Name, m => m.Grade)
                .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

            var studentViewModel = new StudentViewModel {
                ID = student.ID,  
                FirstName = student.FirstName,
                LastName = student.LastName,
                Marks = grpMarks
            };
            return View(studentViewModel);
        }

        //GET: AddStudent
        public IActionResult AddStudent()
        {
            var student = new Student();
            return View(student);
        }

        //POST: AddStudent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _studentService.Create(student.FirstName, student.LastName);
            return RedirectToAction("Index");
        }

        //GET: DeleteStudent
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            if(id == null)
                return NotFound();
            await _studentService.Remove(id.Value);
            return RedirectToAction("Index");
        }
        
        

    }

}