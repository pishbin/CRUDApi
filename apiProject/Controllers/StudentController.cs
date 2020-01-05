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
    public class StudentController : ApiController
    {
        //----------------- Get Student List--------------------------------->
        public IHttpActionResult GetStudentAll()
        {
            IEnumerable<StudentViewModel> ListStudent = null;
            using (var _db = new DbForApiEntities())
            {
                ListStudent = _db.students
                            .Select(s => new StudentViewModel()
                            {
                                id = s.id,
                                name = s.name,
                                family = s.family
                            }).ToList();
            }

            if (ListStudent == null)
            {
                return NotFound();
            }
            return Ok(ListStudent);
        }

        //-----------------Get Student List with selected Unit----------------->
        public IHttpActionResult GetListStudentWithSelectVahed(bool includeSelectVahed)
        {
            try
            {
                IEnumerable<StudentViewModel> ListStudent = null;
                using (var _db=new DbForApiEntities())
                {
                    ListStudent = _db.students
                            .Select(stu => new StudentViewModel()
                            {
                                id = stu.id,
                                name = stu.name,
                                family = stu.family,
                                UnitSelects = stu.UnitSelects.Select(su => new UnitSelectViewModel()
                                {
                                    courseName = su.Cours.name,
                                    id = su.id,
                                    studentName = su.student.name
                                }).ToList()

                            }).ToList();
                   
                    if (ListStudent == null)
                    {
                        return NotFound();
                    }
                    else return Ok(ListStudent);

                }
            }
            catch (Exception)
            {
                //var errMsg = "error in operation  please contact to admin";
                //return errMsg;
                return NotFound();


            }
        }

        //-------------------------find student per Id------------------------->
        public ResultApi GetstudentPerId(int id)
        {
            var resultApi = new ResultApi()
            {
               
                Errorcode = 0,
                ErrorType = "error",
                ErrorMessage = "عملیات با خطامواجه شد",
                ModelDto = null
            };
            try
            {
               

                if (id == 0 || id == null)
                {
                    resultApi = new ResultApi()
                    {
                        Errorcode = -1,
                        ErrorType = "error",
                        ErrorMessage = "کد دانشجو راوارد نمایید",
                        ModelDto = null
                    };
                    return resultApi;
                }
                using (var _db=new DbForApiEntities())
                {
                    var student = _db.students.Where(stud => stud.id == id).FirstOrDefault();
                    if (student == null)
                    {
                        resultApi = new ResultApi()
                        {
                            Errorcode = -2,
                            ErrorType = "error",
                            ErrorMessage = " دانشجویی با این کد یافت نشد ",
                            ModelDto = null
                        };
                    }
                    resultApi = new ResultApi()
                    {
                        Errorcode = 1,
                        ErrorType = "success",
                        ErrorMessage = "  ",
                        ModelDto = student
                    };
                    return resultApi;
                }

            }
            catch (Exception)
            {

                return resultApi;
            }
          



        }


        //---------------------------delete student per student-------------------------------->
        public ResultApi DeleteStudent(int id)
        {
            var resultApi = new ResultApi()
            {

                Errorcode = 0,
                ErrorType = "error",
                ErrorMessage = "عملیات با خطامواجه شد",
                ModelDto = null
            };
            try
            {
                if (id == 0)
                {
                     resultApi = new ResultApi()
                    {
                        Errorcode = -1,
                        ErrorType = "error",
                        ErrorMessage = "کد دانشجو راوارد نمایید",
                        ModelDto = null
                    };
                    return resultApi;

                }
                using (var _db=new DbForApiEntities())
                {
                    var deleteStudent = _db.students.Find(id);
                    if (deleteStudent==null)
                    {
                        resultApi = new ResultApi()
                        {

                            Errorcode = -2,
                            ErrorType = "error",
                            ErrorMessage = "دانشجویی با این کد در سامانه ثبت نشده است",
                            ModelDto = null
                        };
                        return resultApi;
                    }
                    _db.students.Remove(deleteStudent);
                    _db.SaveChanges();

                    resultApi = new ResultApi()
                    {

                        Errorcode =1,
                        ErrorType = "success",
                        ErrorMessage = "دانشجو با موفقیت حذف شد",
                        ModelDto = null
                    };
                    return resultApi;
                }
            }
            catch (Exception)
            {

                 return resultApi;
            }
        }


        //-------------add student------------------------------------------------------------->
        //public IHttpActionResult PostAddstdent(StudentViewModel student)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest("اطلاعات وارد شده صحیح نیست");

        //        using (var _db=new DbForApiEntities())
        //        {
        //            var newStudent = new student()
        //            {
        //                address = student.address,
        //                family = student.family,
        //                name = student.name
        //            };
        //            _db.students.Add(newStudent);
        //            _db.SaveChanges();
        //            return Ok(newStudent);
        //        }


        //    }
        //    catch (Exception)
        //    {

        //        return BadRequest("عملیات با خطا مواجه شد");
        //    }

        //}

    }
}
