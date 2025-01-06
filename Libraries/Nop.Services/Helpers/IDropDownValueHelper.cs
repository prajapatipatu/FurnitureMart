using System;

namespace Nop.Services.Helpers;

public interface IDropDownValueHelper
{
    /// <summary>
    /// Returns a list of the dropdown value
    /// </summary>
    Task<List<string>> GetDropDownValue(string key);
}
