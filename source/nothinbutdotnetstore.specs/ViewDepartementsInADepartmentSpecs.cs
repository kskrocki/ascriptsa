using System.Collections.Generic;
 using developwithpassion.specifications.rhinomocks;
 using Machine.Specifications;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{   
    public class ViewDepartementsInADepartmentSpecs
    {
        public abstract class concern : Observes<IProcessApplicationSpecificBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        
        }

        [Subject(typeof(ViewTheDepartmentsInADepartment))]
        public class when_run : concern
        {
              Establish c = () =>
              {
                request = fake.an<IContainRequestInformation>();
                var testdepartment = new DepartmentItem();

                department_repository = depends.on<IFindDepartments>();
                the_sub_departments = new List<DepartmentItem> {new DepartmentItem()};
                report_engine = depends.on<IDisplayReportModels>();

                request.setup(x => x.map<DepartmentItem>()).Return(testdepartment);
                department_repository.setup(x => x.get_departments_in(testdepartment)).Return(the_sub_departments);
              };

              Because b = () =>
                sut.run(request);


              It should_display_the_departments_in_the_department =
                () =>
                  report_engine.received(x => x.display(the_sub_departments));


              static IContainRequestInformation request;
              static IFindDepartments department_repository;
              static IDisplayReportModels report_engine;
              static IEnumerable<DepartmentItem> the_sub_departments;
            }                
        }
}
