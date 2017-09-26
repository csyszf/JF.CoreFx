using System;
using System.Collections.Generic;
using System.Text;

namespace JF.Domain.Command
{
    public class CommandResult : IEquatable<CommandResult>
    {
        public static CommandResult Ok = new CommandResult { Succeed = true };
        public static CommandResult Error(string errorMessage) =>
            new CommandResult
            {
                Succeed = false,
                ErrorMessage = errorMessage
            };

        public bool Succeed { get; protected set; }
        public string ErrorMessage { get; protected set; }

        public virtual bool Equals(CommandResult other)
        {
            if (Succeed)
                return other.Succeed;
            else
                return (!other.Succeed && ErrorMessage == ErrorMessage);
        }
    }

    public class CommandResult<TPayload> : CommandResult, IEquatable<CommandResult<TPayload>>
        where TPayload : IEquatable<TPayload>
    {
        public TPayload Payload { get; protected set; }

        public virtual bool Equals(CommandResult<TPayload> other)
        {
            if (Succeed)
                return (other.Succeed && Payload.Equals(other.Payload));
            else
                return (!other.Succeed && ErrorMessage == ErrorMessage);
        }
    }

}
