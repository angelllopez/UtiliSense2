﻿using UtiliSense.Gas.BizRules.Contracts;

namespace UtiliSense.Gas.BizRules;

public class CoreServices : ICoreServices
{
    /// <summary>
    /// Checks if the date is within a valid range.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public bool IsDateValid(DateTime date)
    {
        if (date < new DateTime(2023, 1, 1) || date > DateTime.UtcNow)
        {
            return false;
        }

        return true;
    }
}
