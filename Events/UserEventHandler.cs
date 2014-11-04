namespace Rimango.Utilities.Events
{
    using System.Collections.Generic;

    using Orchard.Environment.Extensions;
    using Orchard.Security;
    using Orchard.Users.Events;
    using Orchard.Workflows.Services;

    using Rimango.Workflows;

    [OrchardFeature("Rimango.Workflows.UserActivities")]
    public class UserEventHandler : IUserEventHandler
    {
        private readonly IWorkflowManager _workflowManager;
        public UserEventHandler(IWorkflowManager workflowManager)
        {
            this._workflowManager = workflowManager;
        }
        public void Creating(UserContext context)
        {
            
        }

        public void Created(UserContext context)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserCreated,
                    context.User.ContentItem, () =>
                                new Dictionary<string, object>
                                    {
                                        { "User", context.User }
                                    });
        }

        public void LoggedIn(IUser user)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserLoggedIn, 
                    user.ContentItem, () => 
                                new Dictionary<string, object>
                                    {
                                        { "User", user },
                                        {"Content", user.ContentItem}
                                    });
        }

        public void LoggedOut(IUser user)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserLoggedOut,
                user.ContentItem, () =>
                    new Dictionary<string, object>
                                    {
                                        { "User", user }
                                    });
        }

        public void AccessDenied(IUser user)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserAccessDenied,
                user.ContentItem, () =>
                    new Dictionary<string, object>
                                    {
                                        { "User", user }
                                    });
        }

        public void ChangedPassword(IUser user)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserChangedPassword,
                user.ContentItem, () =>
                    new Dictionary<string, object>
                                    {
                                        { "User", user }
                                    });
        }

        public void SentChallengeEmail(IUser user)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserSentChallengeMail,
                user.ContentItem, () =>
                    new Dictionary<string, object>
                                    {
                                        { "User", user }
                                    });
        }

        public void ConfirmedEmail(IUser user)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserEmailConfirmed,
                user.ContentItem, () =>
                    new Dictionary<string, object>
                                    {
                                        { "User", user }
                                    });
        }

        public void Approved(IUser user)
        {
            this._workflowManager.TriggerEvent(Globals.EventNames.UserApproved,
                user.ContentItem, () =>
                    new Dictionary<string, object>
                                    {
                                        { "User", user }
                                    });
        }
    }
}