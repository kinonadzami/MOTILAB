using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using moti_lab1_core2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace moti_lab1_core2.Controllers
{
    public class HomeController : Controller
    {
        private LabContext db;

        public HomeController(LabContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    
        [HttpGet]
        public IActionResult AddJudge()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJudge(string judgeName)
        {
            LPR newJudge = new LPR();
            newJudge.LName = judgeName;
            newJudge.LRange = 1;
            db.LPRs.Add(newJudge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddAlternative()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAlternative(string alternativeName)
        {
            Alternative newAlt = new Alternative();
            newAlt.AName = alternativeName;
            db.Alternatives.Add(newAlt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCriterion()
        {
            List<SelectListItem> variants = new List<SelectListItem>
        {
            new SelectListItem { Value = "quality", Text = "Качественный" },
            new SelectListItem { Value = "quantity", Text = "Количественный" }
        };
            ViewBag.Type = variants;
            List<SelectListItem> optims = new List<SelectListItem>
        {
            new SelectListItem { Value = "min", Text = "Минимум" },
            new SelectListItem { Value = "max", Text = "Максимум" }
        };
            ViewBag.Optim = optims;
            List<SelectListItem> scales = new List<SelectListItem>
        {
            new SelectListItem { Value = "num", Text = "Числовая" },
            new SelectListItem { Value = "point", Text = "Бальная" },
            new SelectListItem { Value = "range", Text = "Ранговая" }
        };
            ViewBag.Scales = scales;
            return View();
        }

        [HttpPost]
        public IActionResult AddCriterion(string CName, string CType, string OptimType, string EdIzmer, string ScaleType)
        {
            Criterion newCriterion = new Criterion();
            newCriterion.CName = CName;
            newCriterion.CType = CType;
            newCriterion.OptimType = OptimType;
            newCriterion.Edizmer = EdIzmer;
            newCriterion.ScaleType = ScaleType;
            db.Criterions.Add(newCriterion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddMark()
        {
            List<Criterion> list = db.Criterions.ToList();
            List<SelectListItem> selects = new List<SelectListItem>();
            foreach (Criterion item in list)
            {
                selects.Add(new SelectListItem { Value = "" + item.CNum, Text = item.CName });
            }
            ViewBag.Select = selects;
            return View();
        }

        [HttpPost]
        public IActionResult AddMark(string MName, int CNum)
        {
            Mark newMark = new Mark();
            newMark.MNAme = MName;
            newMark.CNum = CNum;
            db.Marks.Add(newMark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddVector()
        {
            List<SelectListItem> alts = new List<SelectListItem>();
            foreach (Alternative item in db.Alternatives.ToList())
            {
                alts.Add(new SelectListItem { Value = "" + item.ANum, Text = item.AName });
            }
            List<SelectListItem> marks = new List<SelectListItem>();
            foreach (Mark item in db.Marks.ToList())
            {
                marks.Add(new SelectListItem { Value = "" + item.MNum, Text = item.MNAme });
            }
            ViewBag.alts = alts;
            ViewBag.marks = marks;
            return View();
        }

        [HttpPost]
        public IActionResult AddVector(int ANum, int MNum)
        {
            Vector newVector = new Vector();
            newVector.Anum = ANum;
            newVector.MNum = MNum;
            db.Vectors.Add(newVector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditJudge(int LNum)
        {
            LPR lpr = db.LPRs.First(x => x.LNum == LNum);
            return View(lpr);
        }

        [HttpPost]
        public IActionResult EditJudge(int LNum, string judgeName)
        {
            LPR newJudge = new LPR();
            newJudge.LName = judgeName;
            newJudge.LRange = 1;
            db.LPRs.Add(newJudge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditAlternative(int ANum)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditAlternative(int ANum, string alternativeName)
        {
            Alternative newAlt = new Alternative();
            newAlt.AName = alternativeName;
            db.Alternatives.Add(newAlt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditCriterion(int CNum)
        {
            List<SelectListItem> variants = new List<SelectListItem>
        {
            new SelectListItem { Value = "quality", Text = "Качественный" },
            new SelectListItem { Value = "quantity", Text = "Количественный" }
        };
            ViewBag.Type = variants;
            List<SelectListItem> optims = new List<SelectListItem>
        {
            new SelectListItem { Value = "min", Text = "Минимум" },
            new SelectListItem { Value = "max", Text = "Максимум" }
        };
            ViewBag.Optim = optims;
            List<SelectListItem> scales = new List<SelectListItem>
        {
            new SelectListItem { Value = "num", Text = "Числовая" },
            new SelectListItem { Value = "point", Text = "Бальная" },
            new SelectListItem { Value = "range", Text = "Ранговая" }
        };
            ViewBag.Scales = scales;
            return View();
        }

        [HttpPost]
        public IActionResult EditCriterion(int CNum, string CName, string CType, string OptimType, string EdIzmer, string ScaleType)
        {
            Criterion newCriterion = new Criterion();
            newCriterion.CName = CName;
            newCriterion.CType = CType;
            newCriterion.OptimType = OptimType;
            newCriterion.Edizmer = EdIzmer;
            newCriterion.ScaleType = ScaleType;
            db.Criterions.Add(newCriterion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditMark(int MNum)
        {
            List<Criterion> list = db.Criterions.ToList();
            List<SelectListItem> selects = new List<SelectListItem>();
            foreach (Criterion item in list)
            {
                selects.Add(new SelectListItem { Value = "" + item.CNum, Text = item.CName });
            }
            ViewBag.Select = selects;
            return View();
        }

        [HttpPost]
        public IActionResult EditMark(int MNum, string MName, int CNum)
        {
            Mark newMark = new Mark();
            newMark.MNAme = MName;
            newMark.CNum = CNum;
            db.Marks.Add(newMark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditVector(int VNum)
        {
            List<SelectListItem> alts = new List<SelectListItem>();
            foreach (Alternative item in db.Alternatives.ToList())
            {
                alts.Add(new SelectListItem { Value = "" + item.ANum, Text = item.AName });
            }
            List<SelectListItem> marks = new List<SelectListItem>();
            foreach (Mark item in db.Marks.ToList())
            {
                marks.Add(new SelectListItem { Value = "" + item.MNum, Text = item.MNAme });
            }
            ViewBag.alts = alts;
            ViewBag.marks = marks;
            return View();
        }

        [HttpPost]
        public IActionResult EditVector(int VNum, int ANum, int MNum)
        {
            Vector newVector = new Vector();
            newVector.Anum = ANum;
            newVector.MNum = MNum;
            db.Vectors.Add(newVector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
