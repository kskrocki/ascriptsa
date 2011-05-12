using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentsInTheStore : IProcessApplicationSpecificBehaviour
  {
    IFindDepartments department_repository;
    IDisplayReportModels reporting_engine;

    public ViewTheMainDepartmentsInTheStore() : this(new StubDepartmentsRepository(),
                                                     new StubReportEngine())
    {
    }

    public ViewTheMainDepartmentsInTheStore(IFindDepartments department_repository,
                                            IDisplayReportModels reporting_engine)
    {
      this.department_repository = department_repository;
      this.reporting_engine = reporting_engine;
    }

    public void run(IContainRequestInformation request)
    {
      reporting_engine.display(department_repository.get_the_main_departments_in_the_store());
    }
  }
}