using System;
using System.Collections.Generic;
using System.Text;

namespace JF.Domain.Command
{
    public class CommandResult
    {
        private static CommandResult Ok => new CommandResult { Succeed = true };
        private static CommandResult Error(string errorMessage) =>
            new CommandResult
            {
                Succeed = false,
                ErrorMessage = errorMessage
            };

        public bool Succeed { get; protected set; }
        public string ErrorMessage { get; protected set; }
    }

    public class CommandResult<TPayload> : CommandResult
    {
        public TPayload Payload { get; protected set; }
    }



}
