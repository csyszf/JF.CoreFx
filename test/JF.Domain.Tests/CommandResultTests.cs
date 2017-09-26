using System;
using System.Collections.Generic;
using System.Text;
using JF.Domain.Command;
using Xunit;

namespace JF.Domain.Tests
{
    public class CommandResultTests
    {
        [Fact]
        public void CommandResultEquatableCast()
        {
            var cr1 = CommandResult.Ok;
            var cr2 = CommandResult.Ok;
            var cr3 = CommandResult.Error("err1");
            var cr4 = CommandResult.Error(cr3.ErrorMessage);
            var cr5 = CommandResult.Error("err2");

            var sr6 = StringResult.Ok("RESULT1");
            var sr7 = StringResult.Ok(sr6.Payload);
            var sr8 = StringResult.Ok("RESULT2");
            var sr9 = StringResult.Error(cr3.ErrorMessage);
            var sr10 = StringResult.Error(cr3.ErrorMessage);
            var sr11 = StringResult.Error(cr5.ErrorMessage);

            Assert.True(cr1.Equals(cr2), "ok result");
            Assert.False(cr1.Equals(cr3), "ok and err result");
            Assert.True(cr3.Equals(cr4), "err result");
            Assert.False(cr3.Equals(cr5), "err result with diff msg");

            Assert.True(sr6.Equals(sr7), "ok string result");
            Assert.False(sr6.Equals(sr8), "ok string result with diff payload");
            Assert.True(sr9.Equals(sr10), "err string result");
            Assert.False(sr9.Equals(sr11), "err string result with diff msg");

            Assert.False(cr1.Equals(sr6), "ok result and string result");
            Assert.False(cr3.Equals(sr9), "err result and string result");
            Assert.False(sr6.Equals(cr1), "err string result and result");
        }
    }

}
