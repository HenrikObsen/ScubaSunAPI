using System.Web.Http;
using System.Collections.Generic;
using System;

namespace ScubaSunAPI.Controllers
{

	 public class CourseApiController : ApiController
	{

		 AutoFac<Course> af = new AutoFac<Course>();

		 [HttpGet] 
		 [Route("Course/Get/{id}")] 
		 public Course Get(int id) 
		 { 
			 return af.Get(id); 
		 } 

		 [HttpGet] 
		 [Route("Course/GetAll")] 
		 public IEnumerable<Course> GetAll() 
		 { 
			 return af.GetAll(); 
		 } 

		 [HttpGet] 
		 [Route("Course/GetAll/{column}/{direction}")] 
		 public IEnumerable<Course> GetAll(string column, string direction) 
		 { 
			 return af.GetAll(column, direction); 
		 } 

		 [HttpGet] 
		 [Route("Course/GetAll/{column}/{direction}/{amount}")] 
		 public IEnumerable<Course> GetAll(string column, string direction, int amount) 
		 { 
			 return af.GetAll(column, direction, amount); 
		 } 

		 [HttpGet] 
		 [Route("Course/GetBy/{column}/{value}")] 
		 public IEnumerable<Course> GetBy(string column, object value) 
		 { 
			 return af.GetBy(column, value); 
		 } 

		 [HttpGet] 
		 [Route("Course/GetBy/{column}/{value}/{ordercolumn}/{direction}")] 
		 public IEnumerable<Course> GetBy(string column, object value, string ordercolumn, string direction) 
		 { 
			 return af.GetBy(column, value, ordercolumn, direction); 
		 } 

		 [HttpGet] 
		 [Route("Course/Count")] 
		 public int Count() 
		 { 
			 return af.Count(); 
		 } 

		 [HttpGet] 
		 [Route("Course/Count/{column}/{value}")] 
		 public int Count(string column, object value) 
		 { 
			 return af.Count(column, value); 
		 } 

		 [HttpGet] 
		 [Route("Course/Delete/{id}")] 
		 public void Delete(int id) 
		 { 
			 af.Delete(id); 
		 } 

		 [HttpGet] 
		 [Route("Course/DeleteBy/{column}/{value}")] 
		 public void DeleteBy(string column, object value) 
		 { 
			 af.DeleteBy(column, value); 
		 } 

		 [HttpPost] 
		 [Route("Course/Insert")] 
		 public int Insert(Course model) 
		 { 
			 return af.Insert(model); 
		 } 

		 [HttpPost] 
		 [Route("Course/Update")] 
		 public void Update(Course model) 
		 { 
			 af.Update(model); 
		 } 

		 [HttpPost] 
		 [Route("Course/UpdateColumn")] 
		 public void UpdateColumn(string column, object value, int id) 
		 { 
			 af.UpdateColumn(column, value, id); 
		 } 

	 }

}
