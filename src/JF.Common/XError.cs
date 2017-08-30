using System;

namespace JF.Common
{
    public class XError : IEquatable<XError>
    {
        public static XError Ok = new XError();

        public XError()
        { }

        public XError(string errorCode)
        {
            ErrorCode = errorCode;
            IsOk = false;
        }
        public XError(string errorCode, params string[] args)
        {
            ErrorCode = string.Join(";", errorCode, args);
            IsOk = false;
        }

        public string ErrorCode { get; private set; }

        public bool IsOk { get; private set; } = true;

        public bool Equals(XError other)
        {
            return ErrorCode == other.ErrorCode;
        }
    }
}
