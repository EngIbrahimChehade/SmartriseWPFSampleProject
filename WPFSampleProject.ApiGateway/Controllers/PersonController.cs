namespace WPFSampleProject.ApiGateway.Controllers
{
    using System.Web.Http;
    using System.Collections.Generic;
    using WPFSampleProject.Model;
    using WPFSampleProject.ApiGateway.ViewModels;
    using Newtonsoft.Json.Linq;

    [RoutePrefix("Person")]
    public class PersonController : ApiController
    {
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

        [HttpGet]
        [Route]
        public IEnumerable<Models.Person> Get()
        {
            var res = manager.GetPersonCollection();
            return new Models.Person().ToViewModel(res);
        }

        //[HttpGet]
        //[Route("{personId}")]
        //public Person Get(int personId)
        //{
        //    return manager.GetPersonById(personId);
        //}

        [HttpPost]
        [Route]
        public void Create([FromBody] CreatePersonViewModel model)
        {
            manager.CreatePerson(model.ToModel());
        }

        [HttpPut]
        [Route]
        public void Update([FromBody] UpdatePersonViewModel model)
        {
            manager.UpdatePerson(model.ToModel());
        }

        [HttpDelete]
        [Route("{personId}")]
        public void Delete(int personId)
        {
            manager.DeletePerson(personId);
        }
    }
}