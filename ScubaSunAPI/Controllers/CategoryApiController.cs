using System.Web.Http;
using System.Collections.Generic;
using System;

namespace ScubaSunAPI.Controllers
{

	 public class CategoryApiController : ApiController
	{

		 AutoFac<Category> af = new AutoFac<Category>();

		 [HttpGet] 
		 [Route("Category/Get/{id}")] 
		 public Category Get(int id) 
		 { 
			 return af.Get(id); 
		 } 

		 [HttpGet] 
		 [Route("Category/GetAll")] 
		 public IEnumerable<Category> GetAll() 
		 { 
			 return af.GetAll(); 
		 } 

		 [HttpGet] 
		 [Route("Category/GetAll/{column}/{direction}")] 
		 public IEnumerable<Category> GetAll(string column, string direction) 
		 { 
			 return af.GetAll(column, direction); 
		 } 

		 [HttpGet] 
		 [Route("Category/GetAll/{column}/{direction}/{amount}")] 
		 public IEnumerable<Category> GetAll(string column, string direction, int amount) 
		 { 
			 return af.GetAll(column, direction, amount); 
		 } 

		 [HttpGet] 
		 [Route("Category/GetBy/{column}/{value}")] 
		 public IEnumerable<Category> GetBy(string column, object value) 
		 { 
			 return af.GetBy(column, value); 
		 } 

		 [HttpGet] 
		 [Route("Category/GetBy/{column}/{value}/{ordercolumn}/{direction}")] 
		 public IEnumerable<Category> GetBy(string column, object value, string ordercolumn, string direction) 
		 { 
			 return af.GetBy(column, value, ordercolumn, direction); 
		 } 

		 [HttpGet] 
		 [Route("Category/Count")] 
		 public int Count() 
		 { 
			 return af.Count(); 
		 } 

		 [HttpGet] 
		 [Route("Category/Count/{column}/{value}")] 
		 public int Count(string column, object value) 
		 { 
			 return af.Count(column, value); 
		 } 

		 [HttpGet] 
		 [Route("Category/Delete/{id}")] 
		 public void Delete(int id) 
		 { 
			 af.Delete(id); 
		 } 

		 [HttpGet] 
		 [Route("Category/DeleteBy/{column}/{value}")] 
		 public void DeleteBy(string column, object value) 
		 { 
			 af.DeleteBy(column, value); 
		 } 

		 [HttpPost] 
		 [Route("Category/Insert")] 
		 public int Insert(Category model) 
		 { 
			 return af.Insert(model); 
		 } 

		 [HttpPost] 
		 [Route("Category/Update")] 
		 public void Update(Category model) 
		 { 
			 af.Update(model); 
		 } 

		 [HttpPost] 
		 [Route("Category/UpdateColumn")] 
		 public void UpdateColumn(string column, object value, int id) 
		 { 
			 af.UpdateColumn(column, value, id); 
		 } 

	 }

}
