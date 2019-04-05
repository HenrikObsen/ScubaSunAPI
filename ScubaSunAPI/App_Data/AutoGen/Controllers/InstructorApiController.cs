using System.Web.Http;
using System.Collections.Generic;
using System;

namespace ScubaSunAPI.Controllers
{

	 public class InstructorApiController : ApiController
	{

		 AutoFac<Instructor> af = new AutoFac<Instructor>();

		 [HttpGet] 
		 [Route("Instructor/Get/{id}")] 
		 public Instructor Get(int id) 
		 { 
			 return af.Get(id); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/GetAll")] 
		 public IEnumerable<Instructor> GetAll() 
		 { 
			 return af.GetAll(); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/GetAll/{column}/{direction}")] 
		 public IEnumerable<Instructor> GetAll(string column, string direction) 
		 { 
			 return af.GetAll(column, direction); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/GetAll/{column}/{direction}/{amount}")] 
		 public IEnumerable<Instructor> GetAll(string column, string direction, int amount) 
		 { 
			 return af.GetAll(column, direction, amount); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/GetBy/{column}/{value}")] 
		 public IEnumerable<Instructor> GetBy(string column, object value) 
		 { 
			 return af.GetBy(column, value); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/GetBy/{column}/{value}/{ordercolumn}/{direction}")] 
		 public IEnumerable<Instructor> GetBy(string column, object value, string ordercolumn, string direction) 
		 { 
			 return af.GetBy(column, value, ordercolumn, direction); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/Count")] 
		 public int Count() 
		 { 
			 return af.Count(); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/Count/{column}/{value}")] 
		 public int Count(string column, object value) 
		 { 
			 return af.Count(column, value); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/Delete/{id}")] 
		 public void Delete(int id) 
		 { 
			 af.Delete(id); 
		 } 

		 [HttpGet] 
		 [Route("Instructor/DeleteBy/{column}/{value}")] 
		 public void DeleteBy(string column, object value) 
		 { 
			 af.DeleteBy(column, value); 
		 } 

		 [HttpPost] 
		 [Route("Instructor/Insert")] 
		 public int Insert(Instructor model) 
		 { 
			 return af.Insert(model); 
		 } 

		 [HttpPost] 
		 [Route("Instructor/Update")] 
		 public void Update(Instructor model) 
		 { 
			 af.Update(model); 
		 } 

		 [HttpPost] 
		 [Route("Instructor/UpdateColumn")] 
		 public void UpdateColumn(string column, object value, int id) 
		 { 
			 af.UpdateColumn(column, value, id); 
		 } 

	 }

}
