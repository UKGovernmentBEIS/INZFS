﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Users;
using OrchardCore.Users.Models;
using INZFS.MVC.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using INZFS.MVC.Attributes;
using INZFS.MVC.Models.ListApplicationsApiModels;
using INZFS.MVC.Services.AntiForgery;

namespace INZFS.MVC.Controllers
{
    [ApiKey]
    //[Authorize]
    [Route("api/listapplications")]
    [ApiController]
    public class ListApplicationsController : Controller
    {
        private readonly IContentRepository _contentRepository;
        private readonly ApplicationDefinition _applicationDefinition;
        private ApplicationContent _applicationContent;
        private readonly UserManager<IUser> _userManager;
        private readonly IUserService _getUserList;
        private readonly YesSql.ISession _session;
        private readonly IAntiforgeryTokenGenerator _antiforgery;
        public ListApplicationsController(IContentRepository contentRepository, ApplicationDefinition applicationDefinition, UserManager<IUser> userManager, IUserService getUserList, YesSql.ISession session, IAntiforgeryTokenGenerator antiforgery)
        {

            _contentRepository = contentRepository;
            _applicationDefinition = applicationDefinition;
            _getUserList = getUserList;
            _session = session;
            _userManager = userManager;
            _antiforgery = antiforgery;
        }
  
        [HttpGet]
        public async Task<ActionResult<List<ApplicationStatusModel>>> GetListOfApplications()
        {
            List<ApplicationStatusModel> allresults = new List<ApplicationStatusModel>();
            
            var users = _getUserList.GetAllUsers();
            foreach (string user in users)
            {
                ApplicationStatusModel statusModel = new ApplicationStatusModel();
                _applicationContent = await _contentRepository.GetApplicationContent(user);
                
                var applicationNumber = _applicationContent.ApplicationNumber;
                var applicationFullNameField = _applicationContent.Fields.Where(field => field.Name == "full-name").FirstOrDefault();
                var applicationCompanyName = _applicationContent.Fields.Where(field => field.Name == "organisation-name").FirstOrDefault();
                
                statusModel.DocumentId = _applicationContent.Id;
                statusModel.ApplicationId = applicationNumber == null ? "" : applicationNumber;
                statusModel.ApplicantName = applicationFullNameField.Data == null ? "" : applicationFullNameField.Data;
                statusModel.ApplicationStatus = _applicationContent.ApplicationStatus;
                statusModel.CompanyName = applicationCompanyName == null ? "" : applicationCompanyName.Data;

                _antiforgery.SetAntiforgeryResponseHeader();

                allresults.Add(statusModel);
            }
            return allresults;
        }

        [HttpPut("{id}")]
        [AutoValidateAntiforgeryToken]
        public ActionResult<string> ChangeApplicationStatus(int id, [FromBody] ApplicationStatusModel applicationStatus)
        {
            var _applicationContent = _contentRepository.GetApplicationContentById(id).Result;
            _applicationContent.ApplicationStatus = applicationStatus.ApplicationStatus;
            _session.Save(_applicationContent);

            return "The status for Document ID "+ id +" has been changed to "+ applicationStatus.ApplicationStatus + "."+ " The current status is "+ applicationStatus.ApplicationStatus;
        }
    }
}
