using System;
using System.Collections.Generic;
using System.Text;

namespace JF.Domain.Command
{
    public class CommandResult
    {
        public static CommandResult Ok => new CommandResult();
        public static CommandResult Error(string errorMessage) => new CommandResult(errorMessage);

        public CommandResult()
        { }
        public CommandResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Succeed = false;
        }
        public bool Succeed { get; private set; } = true;
        public string ErrorMessage { get; private set; }
    }

    public class CommandResult<TPayload>: CommandResult
    {
        public new static CommandResult<TPayload> Ok(TPayload payload) =>
            new CommandResult<TPayload>(payload);

        public CommandResult(TPayload payload)
        {
            Payload = payload;
        }

        public TPayload Payload { get; set; }
    }
}
