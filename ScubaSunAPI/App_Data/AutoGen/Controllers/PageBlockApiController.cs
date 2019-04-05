using System.Web.Http;
using System.Collections.Generic;
using System;

namespace ScubaSunAPI.Controllers
{

	 public class PageBlockApiController : ApiController
	{

		 AutoFac<PageBlock> af = new AutoFac<PageBlock>();

		 [HttpGet] 
		 [Route("PageBlock/Get/{id}")] 
		 public PageBlock Get(int id) 
		 { 
			 return af.Get(id); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/GetAll")] 
		 public IEnumerable<PageBlock> GetAll() 
		 { 
			 return af.GetAll(); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/GetAll/{column}/{direction}")] 
		 public IEnumerable<PageBlock> GetAll(string column, string direction) 
		 { 
			 return af.GetAll(column, direction); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/GetAll/{column}/{direction}/{amount}")] 
		 public IEnumerable<PageBlock> GetAll(string column, string direction, int amount) 
		 { 
			 return af.GetAll(column, direction, amount); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/GetBy/{column}/{value}")] 
		 public IEnumerable<PageBlock> GetBy(string column, object value) 
		 { 
			 return af.GetBy(column, value); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/GetBy/{column}/{value}/{ordercolumn}/{direction}")] 
		 public IEnumerable<PageBlock> GetBy(string column, object value, string ordercolumn, string direction) 
		 { 
			 return af.GetBy(column, value, ordercolumn, direction); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/Count")] 
		 public int Count() 
		 { 
			 return af.Count(); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/Count/{column}/{value}")] 
		 public int Count(string column, object value) 
		 { 
			 return af.Count(column, value); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/Delete/{id}")] 
		 public void Delete(int id) 
		 { 
			 af.Delete(id); 
		 } 

		 [HttpGet] 
		 [Route("PageBlock/DeleteBy/{column}/{value}")] 
		 public void DeleteBy(string column, object value) 
		 { 
			 af.DeleteBy(column, value); 
		 } 

		 [HttpPost] 
		 [Route("PageBlock/Insert")] 
		 public int Insert(PageBlock model) 
		 { 
			 return af.Insert(model); 
		 } 

		 [HttpPost] 
		 [Route("PageBlock/Update")] 
		 public void Update(PageBlock model) 
		 { 
			 af.Update(model); 
		 } 

		 [HttpPost] 
		 [Route("PageBlock/UpdateColumn")] 
		 public void UpdateColumn(string column, object value, int id) 
		 { 
			 af.UpdateColumn(column, value, id); 
		 } 

	 }

}
