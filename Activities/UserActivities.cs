namespace Rimango.Utilities.Activities
{
    using System.Collections.Generic;

    using Orchard.Environment.Extensions;
    using Orchard.Localization;
    using Orchard.Workflows.Models;
    using Orchard.Workflows.Services;

    using Rimango.Workflows;

    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public abstract class UserActivity : Event
    {
        public Localizer T { get; set; }
        public override LocalizedString Category
        {
            get
            {
                return this.T("User");
            }
        }

        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            return new[] { this.T("Done") };
        }

        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext)
        {
            yield return this.T("Done");
        }
        public override bool CanStartWorkflow
        {
            get
            {
                return true;
            }
        }
    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserLoggedInActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserLoggedIn;
            }
        }

        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired after user logged in.");
            }
        }
    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserLoggedOutActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserLoggedOut;
            }
        }

        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired after user logged out.");
            }
        }


    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserAccessDeniedActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserAccessDenied;
            }
        }
        
        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired if access is denied to a user.");
            }
        }


    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserApprovedActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserApproved;
            }
        }

        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired after the user is approved.");
            }
        }


    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserChangedPasswordActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserChangedPassword;
            }
        }

        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired after user changed the password.");
            }
        }


    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserCreatedActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserCreated;
            }
        }

        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired after the user is created.");
            }
        }


    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserEmailConfirmedActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserEmailConfirmed;
            }
        }

        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired after the user confirmed the email address.");
            }
        }

    }
    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserSendChallengMailActivity : UserActivity
    {
        public override string Name
        {
            get
            {
                return Globals.EventNames.UserSentChallengeMail;
            }
        }

        public override LocalizedString Description
        {
            get
            {
                return this.T("Event fired after the challenge mails was send.");
            }
        }


    }
}