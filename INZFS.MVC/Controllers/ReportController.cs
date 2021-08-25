﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INZFS.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        public async Task<FileContentResult> GeneratePdf()
        {
            byte[] bytes = await _reportService.GeneratePdfReport(User.Identity.Name);
            string type = "application/pdf";
            string name = $"EEF_application_summary.pdf";

            return File(bytes, type, name);
        }
        public async Task<FileContentResult> GenerateOdt()
        {
            byte[] bytes = await _reportService.GenerateOdtReport(User.Identity.Name);
            string type = "application/docx";
            string name = "EEF_accessible_summary.docx";

            return File(bytes, type, name);
        }
    }
}