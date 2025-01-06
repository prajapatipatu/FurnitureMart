using FluentValidation;
using Nop.Core.Domain.Orders;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Orders;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Orders
{
    public partial class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator(ILocalizationService localizationService,
        OrderSettings orderSettings)
        {
            if (orderSettings.CustomerRequired)
            {
                RuleFor(x => x.CustomerId)
                .NotEqual(0)
                .WithMessageAwait(localizationService.GetResourceAsync("Admin.Order.Customers.Required"));
            }
        }
    }
}
