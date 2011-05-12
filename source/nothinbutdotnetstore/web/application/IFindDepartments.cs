using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.application
{
  public interface IFindDepartments
  {
    IEnumerable<DepartmentItem> get_the_main_departments_in_the_store();
    IEnumerable<DepartmentItem> get_departments_in_the_department(DepartmentItem main_department);
  }
}