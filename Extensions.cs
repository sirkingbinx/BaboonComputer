using System.Collections.Generic;

namespace BaboonComputer;

public static class Extensions
{
    private static readonly Dictionary<string, string> RealKeyNames = new Dictionary<string, string>(){
        {"One", "1"},
        {"Two", "2"},
        {"Three", "3"},
        {"Four", "4"},
        {"Five", "5"},
        {"Six", "6"},
        {"Seven", "7"},
        {"Eight", "8"},
        {"Nine", "9"},
        {"Zero", "0"},

        {"Opt1", "Option 1"},
        {"Opt2", "Option 2"},
        {"Opt3", "Option 3"}
    };

    /// <summary>
    /// Converts the ComputerKey to it's human-readable name (such as "E" or "Option 1").
    /// </summary>
    public static string ToRealKeyName(this ComputerKey key) => RealKeyNames[nameof(key)] ?? nameof(key);
}