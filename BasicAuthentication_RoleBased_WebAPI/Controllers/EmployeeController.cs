using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuthentication_RoleBased_WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        [Authorize(Roles = "Admin")]
        [Route("api/GetAdminReport")]
        public IHttpActionResult getAdminReport()
        {
            using (OfficeEntities obj = new OfficeEntities())
            {
                return Ok(obj.Reports.Where(emp => emp.R_Head.ToLower() == "admin"));
            }
        }

        [Authorize(Roles = "HR")]
        [Route("api/GetHRReport")]
        public IHttpActionResult getHRReport()
        {
            using (OfficeEntities obj = new OfficeEntities())
            {
                return Ok(obj.Reports.Where(emp => emp.R_Head.ToLower() == "hr"));
            }
        }

        [Authorize(Roles = "Manager")]
        [Route("api/GetManagerReport")]
        public IHttpActionResult getManagerReport()
        {
            using (OfficeEntities obj = new OfficeEntities())
            {
                return Ok(obj.Reports.Where(emp => emp.R_Head.ToLower() == "manager"));
            }
        }
    }
}
