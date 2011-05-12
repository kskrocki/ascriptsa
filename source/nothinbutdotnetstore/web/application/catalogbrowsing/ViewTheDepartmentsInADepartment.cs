using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewTheDepartmentsInADepartment : IProcessApplicationSpecificBehaviour
  {
    IFindDepartments department_repository;
    IDisplayReportModels report_engine;

    public ViewTheDepartmentsInADepartment():this(new StubDepartmentsRepository(),
      new StubReportEngine())
    {
    }

    public ViewTheDepartmentsInADepartment(IFindDepartments department_repository, IDisplayReportModels report_engine)
    {
      this.department_repository = department_repository;
      this.report_engine = report_engine;
    }

    public void run(IContainRequestInformation request)
    {
      report_engine.display(department_repository.get_departments_in(request.map<DepartmentItem>()));
    }
  }
}