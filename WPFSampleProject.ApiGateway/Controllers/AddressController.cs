namespace WPFSampleProject.ApiGateway.Controllers
{
    using System.Web.Http;
    using System.Collections.Generic;
    using WPFSampleProject.Model;
    using WPFSampleProject.ApiGateway.ViewModels;

    [RoutePrefix("Address")]
    public class AddressController : ApiController
    {
        WPFSampleProjectManager manager = new WPFSampleProjectManager();

        [HttpGet]
        [Route]
        public IEnumerable<Address> Get()
        {
            return manager.GetAddressCollection();
        }

        [HttpGet]
        [Route("{addressId}")]
        public Address Get(int addressId)
        {
            return manager.GetAddressById(addressId);
        }

        [HttpGet]
        [Route("GetAddressCollectionByPersonId/{personId}")]
        public IEnumerable<Address> GetAddressCollectionByPersonId(int personId)
        {
            return manager.GetAddressCollectionByPersonId(personId);
        }

        [HttpPost]
        [Route]
        public void Create(CreateAddressViewModel model)
        {
            manager.CreateAddress(model.ToModel());
        }

        [HttpPut]
        [Route]
        public void Update(UpdateAddressViewModel model)
        {
            manager.UpdateAddress(model.ToModel());
        }

        [HttpDelete]
        [Route("{addressId}")]
        public void DeleteAddress(int addressId)
        {
            manager.DeleteAddress(addressId);
        }
    }
}