using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneUniqueRequest>
  {
    public IEnumerator<IProcessOneUniqueRequest> GetEnumerator()
    {
      yield return new ProcessOneUniqueRequest(x => true, new ViewTheMainDepartmentsInTheStore());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}