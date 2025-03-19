using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWhaddonShowClassLibrary.Models
{
    public class CowboyShoutOut
    {
        bool ShowDaysTillOpeningNight { get; set; } = true;
        bool ShowCastingStatistics { get; set; } = true;
        DateTime? NextRehearsalDate { get; set; } = null;
        string? AdditionalMessage { get; set; } = null;

    }
}
