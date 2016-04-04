using System;

namespace WargamingTypesLibrary.Enums
{
    [Flags]
    public enum Nation
    {
        Ussr = 1,
        Germany = 2,
        Usa = 4,
        France = 8,
        Uk = 16,
        China = 32,
        Japan = 64,
        All = Ussr | Germany | Usa | France | Uk | China | Japan,
    }
}