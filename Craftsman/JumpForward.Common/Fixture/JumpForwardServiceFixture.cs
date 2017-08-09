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

        public Lazy<ComplianceServiceClient> ComplianceService { get; protected set; }

        public JumpForwardServiceFixture()
        {
            this.CoachService = new Lazy<CoachServiceClient>();
            this.ComplianceService = new Lazy<ComplianceServiceClient>();
        }

        public void Dispose() { }
    }
}
