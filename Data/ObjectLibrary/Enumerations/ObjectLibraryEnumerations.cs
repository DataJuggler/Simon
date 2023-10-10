

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum GenderEnum : int
    /// <summary>
    /// This enum is only here so that the Enumerations reference compiles.
    /// You can remove this but if you do you also need to remove the reference
    /// in DataManager for this object.
    /// </summary>
    public enum GenderEnum : int
    {
        Both = 0,
        Female = 1,
        Male = 2
    }
    #endregion

    #region enum CountryEnum
    /// <summary>
    /// This is used to Filter by country
    /// </summary>
    public enum CountryEnum : int
    {
        All = 0,
        Australia = 1,
        Great_Britain = 2,
        Canada = 3,
        Hong_Kong = 4,
        Indiaj = 5,
        Ireland = 6,
        Kenya = 7,
        New_Zealand = 8,
        Nigeria = 9,
        Philippines = 10,
        Singapore = 11,
        South_Africa = 12,
        Tanzania = 13,
        United_States = 14
    }
    #endregion

}
