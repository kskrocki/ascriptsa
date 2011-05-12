using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.application.stubs
{
  public class StubDepartmentsRepository : IFindDepartments
  {
    public IEnumerable<DepartmentItem> get_the_main_departments_in_the_store()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem{name = x.ToString("Department 0")});
    }
  }
}