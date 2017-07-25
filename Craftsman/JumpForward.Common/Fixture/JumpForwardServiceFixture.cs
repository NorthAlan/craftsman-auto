using JumpForward.Common.ServiceCall;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JumpForward.Common.Fixture
{
    public class JumpForwardServiceFixture : IDisposable
    {
        public Lazy<CoachServiceClient> CoachService { get; protected set; }


        public JumpForwardServiceFixture()
        {
            CoachService = new Lazy<CoachServiceClient>();
        }
       
        public void Dispose() { }
    }
}
