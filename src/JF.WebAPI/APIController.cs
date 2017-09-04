using System;
using JF.Common;
using Microsoft.AspNetCore.Mvc;

namespace JF.WebAPI
{
    public class APIController: ControllerBase
    {
        public virtual IActionResult Error(XError error)
        {
            return BadRequest(error);
        }
    }
}
