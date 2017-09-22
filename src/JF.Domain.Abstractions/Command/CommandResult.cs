using System;
using System.Collections.Generic;
using System.Text;

namespace JF.Domain.Command
{
    public class CommandResult
    {
        public static CommandResult Ok => new CommandResult { Succeed = true };
        public static CommandResult Error(string errorMessage) =>
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
        public new static CommandResult<TPayload> Ok(TPayload payload) =>
            new CommandResult<TPayload>
            {
                Succeed = true,
                Payload = payload
            };

        public new static CommandResult<TPayload> Error(string errorMessage) =>
            new CommandResult<TPayload>
            {
                Succeed = false,
                ErrorMessage = errorMessage
            };

        public TPayload Payload { get; private set; }
    }
}
