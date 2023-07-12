using Auto.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Auto.HttpApi
{
    public abstract class AutoController : AbpControllerBase
    {
        protected AutoController()
        {
            LocalizationResource = typeof(AutoResource);
        }
    }
}