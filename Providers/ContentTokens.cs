namespace Rimango.Utilities.Providers
{
    using Orchard.ContentManagement;
    using Orchard.Environment.Extensions;
    using Orchard.Localization;
    using Orchard.Tokens;
    using Orchard.Users.Models;

    [OrchardFeature("Rimango.Tokens.ContentTokens")]
    public class ContentTokens : ITokenProvider
    {
        private readonly IContentManager _contentManager;
        public Localizer T { get; set; }

        public ContentTokens(IContentManager contentManager)
        {
            this._contentManager = contentManager;

            this.T = NullLocalizer.Instance;
        }
        public void Describe(DescribeContext context)
        {
            context.For("Content", this.T("Content Items"), this.T("Content Items"))
                .Token("User", this.T("User"), this.T("Gets the Username"));
        }

        public void Evaluate(EvaluateContext context)
        {
            context.For<IContent>("Content")
                .Token("User", content => content.As<UserPart>() != null ? content.As<UserPart>().UserName : null)
                .Chain("User", "User", content => content.As<UserPart>() ?? null);

        }
    }
}