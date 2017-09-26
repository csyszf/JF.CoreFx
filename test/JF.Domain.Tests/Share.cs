using System;
using System.Collections.Generic;
using System.Text;
using JF.Domain.Command;

namespace JF.Domain.Tests
{
    public class StringResult : CommandResult<string>
    {
        public new static StringResult Ok(string payload) =>
            new StringResult
            {
                Succeed = true,
                Payload = payload
            };

        public new static StringResult Error(string errMsg) =>
            new StringResult
            {
                Succeed = false,
                ErrorMessage = errMsg
            };
    }
}
