using Nop.Services.Configuration;
using Nop.Services.Helpers;

namespace Nop.Service.Helpers;

public class DropDownValueHelper : IDropDownValueHelper
{
    #region Fields
    private readonly ISettingService _settingService;
    #endregion

    #region Ctor
    public DropDownValueHelper(ISettingService settingService)
    {
        _settingService = settingService;
    }
    #endregion

    public async Task<List<string>> GetDropDownValue(string key)
    {
        List<string> dropDownValue = new List<string>();
        if (!string.IsNullOrEmpty(key))
        {
            var dropdownSettingValue = await _settingService.GetSettingByKeyAsync<string>(key);
            if (dropdownSettingValue != null)
            {
                return dropdownSettingValue.Split('|').ToList();
            }
        }
        return dropDownValue;
    }
}
