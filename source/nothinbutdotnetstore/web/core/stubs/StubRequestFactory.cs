using System;
using System.Web;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IContainRequestInformation create_request_from(HttpContext an_incoming_http_context)
    {
      return new StubRequest();
    }

    class StubRequest : IContainRequestInformation
    {
        public DepartmentItem SelectedDepartment
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
  }
}