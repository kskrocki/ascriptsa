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

      InputModel IContainRequestInformation.map<InputModel>()
      {
        object department = new DepartmentItem();
        return (InputModel) department;
      }
    }
  }
}