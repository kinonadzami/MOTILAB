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
        public IActionResult UpdateJudge(int LNum, string judgeName)
        {
            LPR lpr = db.LPRs.First(x => x.LNum == LNum);
            lpr.LName = judgeName;
            db.LPRs.Update(lpr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditAlternative(int ANum)
        {
            Alternative alternative = db.Alternatives.First(x => x.ANum == ANum);
            return View(alternative);
        }

        [HttpPost]
        public IActionResult UpdateAlternative(int ANum, string alternativeName)
        {
            Alternative Alt =db.Alternatives.First(x => x.ANum == ANum);
            Alt.AName = alternativeName;
            db.Alternatives.Update(Alt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditCriterion(int CNum)
        {
            Criterion criterion = db.Criterions.First(x => x.CNum == CNum);
            List<SelectListItem> variants = new List<SelectListItem>
        {
            new SelectListItem { Value = "quality", Text = "Качественный" },
            new SelectListItem { Value = "quantity", Text = "Количественный" }
        };
            if (criterion.CType == "quality")
            {
                variants.First(x => x.Value == "quality").Selected = true;
            }
            ViewBag.Type = variants;
            List<SelectListItem> optims = new List<SelectListItem>
        {
            new SelectListItem { Value = "min", Text = "Минимум" },
            new SelectListItem { Value = "max", Text = "Максимум" }
        };
            if (criterion.OptimType == "min")
            {
                optims.First(x => x.Value == "min").Selected = true;
            }
            ViewBag.Optim = optims;
            List<SelectListItem> scales = new List<SelectListItem>
        {
            new SelectListItem { Value = "num", Text = "Числовая" },
            new SelectListItem { Value = "point", Text = "Бальная" },
            new SelectListItem { Value = "range", Text = "Ранговая" }
        };
            switch (criterion.ScaleType)
            {
                case "num":
                    scales.First(x => x.Value == "num").Selected = true;
                    break;
                case "point":
                    scales.First(x => x.Value == "point").Selected = true;
                    break;
                case "range":
                    scales.First(x => x.Value == "range").Selected = true;
                    break;
                default:
                    break;
            }
            ViewBag.Scales = scales;
            return View(criterion);
        }

        [HttpPost]
        public IActionResult UpdateCriterion(int CNum, string CName, string CType, string OptimType, string EdIzmer, string ScaleType)
        {
            Criterion newCriterion = new Criterion();
            newCriterion.CName = CName;
            newCriterion.CType = CType;
            newCriterion.OptimType = OptimType;
            newCriterion.Edizmer = EdIzmer;
            newCriterion.ScaleType = ScaleType;
            db.Criterions.Update(newCriterion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditMark(int MNum)
        {
            Mark mark = db.Marks.First(x => x.MNum == MNum);
            List<Criterion> list = db.Criterions.ToList();
            List<SelectListItem> selects = new List<SelectListItem>();
            foreach (Criterion item in list)
            {
                selects.Add(new SelectListItem { Value = "" + item.CNum, Text = item.CName });
                if (item.CNum == mark.CNum)
                {
                    selects.Add(new SelectListItem { Value = "" + item.CNum, Text = item.CName, Selected = true });
                }
                else
                {
                    selects.Add(new SelectListItem { Value = "" + item.CNum, Text = item.CName });
                }
            }
            ViewBag.Select = selects;
            return View(mark);
        }

        [HttpPost]
        public IActionResult UpdateMark(int MNum, string MName, int CNum)
        {
            Mark mark = db.Marks.First(x => x.MNum == MNum);
            mark.MNAme = MName;
            mark.CNum = CNum;
            db.Marks.Add(mark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditVector(int VNum)
        {
            Vector vector = db.Vectors.First(x => x.VNum == VNum);
            List<SelectListItem> alts = new List<SelectListItem>();
            foreach (Alternative item in db.Alternatives.ToList())
            {
                if (item.ANum == vector.Anum)
                {
                    alts.Add(new SelectListItem { Value = "" + item.ANum, Text = item.AName, Selected = true });
                }
                else
                {
                    alts.Add(new SelectListItem { Value = "" + item.ANum, Text = item.AName });
                }
            }
            List<SelectListItem> marks = new List<SelectListItem>();
            foreach (Mark item in db.Marks.ToList())
            {
                marks.Add(new SelectListItem { Value = "" + item.MNum, Text = item.MNAme });
                if (item.MNum == vector.MNum)
                {
                    marks.Add(new SelectListItem { Value = "" + item.MNum, Text = item.MNAme, Selected = true});
                }
                else
                {
                    marks.Add(new SelectListItem { Value = "" + item.MNum, Text = item.MNAme });
                }
            }
            ViewBag.alts = alts;
            ViewBag.marks = marks;
            return View(vector);
        }

        [HttpPost]
        public IActionResult UpdateVector(int VNum, int ANum, int MNum)
        {
            Vector Vector = db.Vectors.First(x => x.VNum == VNum);
            Vector.Anum = ANum;
            Vector.MNum = MNum;
            db.Vectors.Update(Vector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteJudge(int LNum)
        {
            LPR lpr = db.LPRs.First(x => x.LNum == LNum);
            db.LPRs.Remove(lpr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAlternative(int ANum)
        {
            Alternative alternative = db.Alternatives.First(x => x.ANum == ANum);
            db.Alternatives.Remove(alternative);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMark(int MNum)
        {
            Mark mark = db.Marks.First(x => x.MNum == MNum);
            db.Marks.Remove(mark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCriterion(int CNum)
        {
            Criterion criterion = db.Criterions.First(x => x.CNum == CNum);
            db.Criterions.Remove(criterion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteVector(int VNum)
        {
            Vector vector = db.Vectors.First(x => x.VNum == VNum);
            db.Vectors.Remove(vector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
