using System.Collections.Generic;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core
{
  public interface IDisplayReportModels
  {
    void display(IEnumerable<DepartmentItem> departments);
  }
}