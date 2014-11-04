using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rimango.Workflows
{
    public class Globals
    {
        public struct EventNames
        {
            public static readonly string UserLoggedIn = "UserLoggedIn";

            public static readonly string UserCreated = "UserCreated";

            public static readonly string UserLoggedOut = "UserLoggedOut";

            public static readonly string UserAccessDenied = "UserAccessDenied";

            public static readonly string UserChangedPassword = "UserChangedPassword";

            public static readonly string UserSentChallengeMail = "UserSentChallengeMail";

            public static readonly string UserEmailConfirmed = "UserEmailConfirmed";

            public static readonly string UserApproved = "UserApproved";
        }    
    }


}