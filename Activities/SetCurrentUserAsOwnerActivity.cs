using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Core.Common.Models;
using Orchard.Localization;
using Orchard.Security;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;
using Rimango.Workflows;

namespace Rimango.Utilities.Activities
{
    public class SetCurrentUserAsOwnerActivity : Task {
        private IOrchardServices _orchardServices;
        private IMembershipService _membershipService;
        public SetCurrentUserAsOwnerActivity(IOrchardServices orchardServices, IMembershipService membershipService) {
            _orchardServices = orchardServices;
            _membershipService = membershipService;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }
        public override string Name {
            get { return "SetCurrentUserAsOwner"; }
        }

        public override LocalizedString Category {
            get { return T("Content"); }
        }

        public override LocalizedString Description {
            get { return T("Takes the current User and sets it to the owner of the actual contentItem."); }
        }

        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext workflowContext, ActivityContext activityContext) {
            return new[] {T("Success"), T("Error")};
        }

        public override string Form {
            get { return Globals.Forms.SetCurrentUserForm; }
        }

        public override IEnumerable<LocalizedString> Execute(WorkflowContext workflowContext, ActivityContext activityContext) {

            var outcome = T("Success");
            var commonPart = workflowContext.Content.ContentItem.As<CommonPart>();
            var defaultUserName = activityContext.GetState<string>(Globals.WorkflowParams.DefaultUserName);

            if (commonPart == null) {
                workflowContext.SetState("Error", "No common part attached to the current contentitem.");
                outcome = T("Error");
            }
            else {
                try
                {
                    var currentUser = _orchardServices.WorkContext.CurrentUser ?? _membershipService.GetUser(defaultUserName);
                    commonPart.Owner = currentUser;
                    _orchardServices.ContentManager.Publish(commonPart.ContentItem);
                }
                catch (Exception exc)
                {
                    workflowContext.SetState("Error", exc.Message);
                    outcome = T("Error");
                }
            }

            yield return outcome;

        }
    }
}