using healthcareappbackend.Data;
using healthcareappbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthcareappbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly DataContext administratorContext; //create an object        

        public AdministratorController(DataContext administratorContext)
        {
            this.administratorContext = administratorContext;
        }
        [HttpGet]
        [Route("GetAdministrators")]
        public List<Administrator> GetAdministrators()
        {
            return administratorContext.Administrators.ToList(); //return a list of P...
        }
        [HttpGet]
        [Route("GetAdministrators/{id}")]
        public Administrator GetAdministrators(int id)
        {
            return administratorContext.Administrators.Where(x => x.Id == id).FirstOrDefault(); //return a list of P...
        }

        [HttpPost]
        [Route("AddAdministrator")]
        public string AddAdministrator(Administrator administrator)
        {
            string response = string.Empty;
            administratorContext.Administrators.Add(administrator);
            administratorContext.SaveChanges();
            return "Administrator successfully added";
        }


        [HttpPut]
        [Route("UpdateAdministrator/{id}")]
        public string UpdateAdministrator(Administrator administrator)
        {
            administratorContext.Entry(administrator).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            administratorContext.SaveChanges();
            return "Administrator successfully updated";

        }
        [HttpDelete]
        [Route("DeleteAdministrator/{id}")]
        public string DeleteAdministrator(int id)
        {
            Administrator administrator = administratorContext.Administrators.Where(x => x.Id == id).FirstOrDefault();
            if (administrator != null)
            {
                administratorContext.Administrators.Remove(administrator);
                administratorContext.SaveChanges();
                return "Administrator successfully deleted";
            }
            else
            {
                return "Administrator not found";
            }
        }

    }
}