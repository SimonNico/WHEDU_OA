using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WHEDU_OA_WEBAPI.Models;


namespace WHEDU_OA_WEBAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/WorkFlow")]
    public class WorkFlowController : ApiController
    {
        private string userid = string.Empty;
        public WorkFlowController()
        {
           userid=User.Identity.GetUserId();
        }
        
        


    }
}
