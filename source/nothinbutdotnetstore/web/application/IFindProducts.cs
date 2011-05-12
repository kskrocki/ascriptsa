using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.application
{
    public interface IFindProducts
    {
        IEnumerable<ProductItem> get_products_in(DepartmentItem testdepartment);
    }
}