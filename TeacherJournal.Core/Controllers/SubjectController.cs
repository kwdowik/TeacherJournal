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
    public class SubjectController : Controller
    {
        private readonly MarkService _markService;
        private readonly SubjectService _subjectService;

        private readonly StudentService _studentService;

        public SubjectController(MarkService markService, SubjectService subjectService, StudentService studentService)
        {
            _markService = markService;
            _subjectService = subjectService;
            _studentService = studentService;
        }

        //GET: AddMark
        public async Task<IActionResult> AddMark(string subjectName, int? studentID, int? newMark)
        {
            var subject = await _subjectService.GetByNameAsync(subjectName);
            if(subject == null) 
                return NotFound();
            await _markService.Create(studentID, subject.SubjectID, newMark);
            return RedirectToAction("Details", "Student", new {id = studentID});
        }

        //GET: AddSubject
        public IActionResult AddSubject(int? studentID)
        {
            var subjectViewModel = new SubjectViewModel { StudentID = studentID.Value};
            return View(subjectViewModel);
        }

        //POST: AddSubject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubject(SubjectViewModel subjectViewModel)
        {
            int subjectID;
            var subject = await _subjectService.GetByNameAsync(subjectViewModel.Name);
            if(subject == null)   
            {
                subjectID = await _subjectService.Create(subjectViewModel.Name);
            }else 
            {
                subjectID = subject.SubjectID;
            }       
            await _markService.Create(subjectViewModel.StudentID, subjectID, subjectViewModel.Mark);
            return RedirectToAction("Index", "Student");
        }


        
    }
}