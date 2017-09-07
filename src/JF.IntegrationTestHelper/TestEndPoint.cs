using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace JF.IntegrationTestHelper
{
    public class TestEndPoint<TFixture> : IClassFixture<TFixture> where TFixture : Fixture
    {
        public HttpClient _client;
        public TestServer _server;

        public TestEndPoint(TFixture fixture)
        {
            _client = fixture.Client;
            _server = fixture.Server;
        }
    }
}
