using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UEditor.Core;

namespace CMS.Controllers
{
    public class UEditorController : Controller
    {
        public ContentResult Upload()
        {
            var response = UEditorService.Instance.UploadAndGetResponse(HttpContext.ApplicationInstance.Context);
            return Content(response.Result, response.ContentType);
        }
    }
}