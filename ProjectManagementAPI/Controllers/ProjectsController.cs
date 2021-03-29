using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer;
using MvcProjectManagement.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcProjectManagement.Controllers
{
    public class ProjectsController : Controller
    {

        [HttpGet]
        [Route("api/projects")]
        public List<Project> Get()
        {
            ProjectManagementDbContext db = new ProjectManagementDbContext();
            List<Project> projects = db.Projects.ToList();
            return projects; //at runtime it will convert to a JSON format
        }

        [HttpGet]
        [Route("api/projects/search/{searchby}/{searchtext}")]
        public List<Project> Search(string searchBy, string searchText)
        {
            ProjectManagementDbContext db = new ProjectManagementDbContext();
            List<Project> projects = null;
            if (searchBy == "ProjectID")
                projects = db.Projects.Where(temp => temp.ProjectID.ToString().Contains(searchText)).ToList();
            else if (searchBy == "ProjectName")
                projects = db.Projects.Where(temp => temp.ProjectName.Contains(searchText)).ToList();
            if (searchBy == "DateOfStart")
                projects = db.Projects.Where(temp => temp.DateOfStart.ToString().Contains(searchText)).ToList();
            if (searchBy == "TeamSize")
                projects = db.Projects.Where(temp => temp.TeamSize.ToString().Contains(searchText)).ToList();

            return projects;
        }

        [HttpPost]
        [Route("api/projects")]
        public Project Post([FromBody] Project project)
        {
            ProjectManagementDbContext db = new ProjectManagementDbContext();
            db.Projects.Add(project);
            db.SaveChanges();
            return project; //return updated as response
        }


        [HttpPut]
        [Route("api/projects")]
        public Project Put([FromBody] Project project)
        {
            ProjectManagementDbContext db = new ProjectManagementDbContext();
            Project existingProject = db.Projects.Where(temp => temp.ProjectID == project.ProjectID).FirstOrDefault();
            if (existingProject != null)
            {
                existingProject.ProjectName = project.ProjectName;
                existingProject.DateOfStart = project.DateOfStart;
                existingProject.TeamSize = project.TeamSize;
                db.SaveChanges();
                return existingProject;
            }
            else
            {
                return null;
            }
        }


        [HttpDelete]
        [Route("api/projects")]
        public int Delete(int ProjectID)
        {
            ProjectManagementDbContext db = new ProjectManagementDbContext();
            Project existingProject = db.Projects.Where(temp => temp.ProjectID == ProjectID).FirstOrDefault();
            if (existingProject != null)
            {
                db.Projects.Remove(existingProject);
                db.SaveChanges();
                return ProjectID;
            }
            else
            {
                return -1;
            }
        }
    }
}