using System.ComponentModel;

namespace ChoicesSuperMarket.Domain.Enums
{
    public enum EUnitOfMeasurement : byte
    {
        [Description("UNIT")]
        Unit = 1,

        [Description("DZN")]
        Dozen = 2,

        [Description("MG")]
        Milligram = 3,

        [Description("G")]
        Gram = 4,

        [Description("KG")]
        Kilogram = 5,

        [Description("L")]
        Liter = 6,

        [Description("ML")]
        MilliLiter = 7
    }
}