using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IProcessApplicationSpecificBehaviour,
                                      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        department_repository = depends.on<IFindDepartments>();
        the_main_departments = new List<DepartmentItem> {new DepartmentItem()};
        report_engine = depends.on<IDisplayReportModels>();

        department_repository.setup(x => x.get_the_main_departments_in_the_store()).Return(the_main_departments);
      };

      Because b = () =>
        sut.run(request);


      It should_display_the_main_departments =
        () =>
          report_engine.received(x => x.display(the_main_departments));


      static IContainRequestInformation request;
      static IFindDepartments department_repository;
      static IDisplayReportModels report_engine;
      static IEnumerable<DepartmentItem> the_main_departments;
    }
  }
}