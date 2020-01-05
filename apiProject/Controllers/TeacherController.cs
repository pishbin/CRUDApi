using apiProject.DTOs;
using apiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiProject.Controllers
{
    public class TeacherController : ApiController
    {


        public IHttpActionResult PostAddstdent(TeacherViewModel teacher)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("اطلاعات وارد شده صحیح نیست");

                using (var _db = new DbForApiEntities())
                {
                    var newTeacher = new teacher()
                    {
                        
                        name = teacher.name,
                        family = teacher.family

                    };
                    _db.teachers.Add(newTeacher);
                    _db.SaveChanges();
                    return Ok(newTeacher);
                }


            }
            catch (Exception)
            {

                return BadRequest("عملیات با خطا مواجه شد");
            }

        }

    }
}
