using System.Web.Http;
using System.Collections.Generic;
using System;

namespace ScubaSunAPI.Controllers
{

	 public class CourseStartApiController : ApiController
	{

		 AutoFac<CourseStart> af = new AutoFac<CourseStart>();

		 [HttpGet] 
		 [Route("CourseStart/Get/{id}")] 
		 public CourseStart Get(int id) 
		 { 
			 return af.Get(id); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/GetAll")] 
		 public IEnumerable<CourseStart> GetAll() 
		 { 
			 return af.GetAll(); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/GetAll/{column}/{direction}")] 
		 public IEnumerable<CourseStart> GetAll(string column, string direction) 
		 { 
			 return af.GetAll(column, direction); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/GetAll/{column}/{direction}/{amount}")] 
		 public IEnumerable<CourseStart> GetAll(string column, string direction, int amount) 
		 { 
			 return af.GetAll(column, direction, amount); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/GetBy/{column}/{value}")] 
		 public IEnumerable<CourseStart> GetBy(string column, object value) 
		 { 
			 return af.GetBy(column, value); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/GetBy/{column}/{value}/{ordercolumn}/{direction}")] 
		 public IEnumerable<CourseStart> GetBy(string column, object value, string ordercolumn, string direction) 
		 { 
			 return af.GetBy(column, value, ordercolumn, direction); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/Count")] 
		 public int Count() 
		 { 
			 return af.Count(); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/Count/{column}/{value}")] 
		 public int Count(string column, object value) 
		 { 
			 return af.Count(column, value); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/Delete/{id}")] 
		 public void Delete(int id) 
		 { 
			 af.Delete(id); 
		 } 

		 [HttpGet] 
		 [Route("CourseStart/DeleteBy/{column}/{value}")] 
		 public void DeleteBy(string column, object value) 
		 { 
			 af.DeleteBy(column, value); 
		 } 

		 [HttpPost] 
		 [Route("CourseStart/Insert")] 
		 public int Insert(CourseStart model) 
		 { 
			 return af.Insert(model); 
		 } 

		 [HttpPost] 
		 [Route("CourseStart/Update")] 
		 public void Update(CourseStart model) 
		 { 
			 af.Update(model); 
		 } 

		 [HttpPost] 
		 [Route("CourseStart/UpdateColumn")] 
		 public void UpdateColumn(string column, object value, int id) 
		 { 
			 af.UpdateColumn(column, value, id); 
		 } 

	 }

}
