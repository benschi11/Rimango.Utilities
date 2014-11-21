using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Forms.Services;
using Orchard.Localization;
using Orchard.Security;
using Orchard.Users.Models;
using Rimango.Workflows;

namespace Rimango.Utilities.Forms
{
    public class SetCurrentUserForm : IFormProvider
    {
        public dynamic New { get; set; }

        public Localizer T { get; set; }

        private IContentManager _contentManager;

        public SetCurrentUserForm(IShapeFactory shapeFactory, IContentManager contentManager) {
            T = NullLocalizer.Instance;
            New = shapeFactory;
            _contentManager = contentManager;
        }
        public void Describe(DescribeContext context) {
            Func<IShapeFactory, dynamic> formFactory =
               shape =>
               {

                   var form = New.Form(
                       Id: "CreateBlogPostActivtiy",
                       _Type: New.FieldSet(
                           Title: T("Title"),
                           _UserId: New.SelectList(
                               Id: Globals.WorkflowParams.DefaultUserName, Name: Globals.WorkflowParams.DefaultUserName,
                               Title: T("Default User"),
                               Description: T("The Username which is set, if the current user is null."),
                               Size: 10,
                               Multiple: false)

                           ));

                   var userList = _contentManager.Query<UserPart>().List<IUser>();

                   // Default is not fallback
                   form._Type._UserId.Add(new SelectListItem {Value = "", Text = "No default user"});

                   foreach (var user in userList) {
                       form._Type._UserId.Add(new SelectListItem {Value = user.UserName, Text = user.UserName});
                   }

                   return form;
               };

            context.Form(Globals.Forms.SetCurrentUserForm, formFactory);
        }
    }
}