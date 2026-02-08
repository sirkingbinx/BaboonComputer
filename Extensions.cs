using System.Collections.Generic;

namespace BaboonComputer;

public static class Extensions
{
    public static readonly Dictionary<string, string> RealKeyNames = new Dictionary<string, string>(){
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
    };

    public static string ToRealKeyName(this ComputerKey key) => RealKeyNames[nameof(key)] ?? nameof(key);
}