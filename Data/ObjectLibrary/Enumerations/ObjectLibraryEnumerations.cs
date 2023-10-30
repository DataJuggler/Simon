    

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

    #region EmotionEnum : int
    /// <summary>
    /// This enum is used for the style to read in
    /// </summary>
    public enum EmotionEnum : int
    {
        Advertisement_Upbeat = 1,
        Affectionate = 2,
        Angry = 3,
        Assistant = 4,
        Calm = 5,
        Chat = 6,
        Cheerful = 7,
        CustomerService = 8,
        Depressed = 9,
        Disgruntled = 10,
        Documentary_Narration = 11,
        Embarrassed = 12,
        Empathetic = 13,
        Envious = 14,
        Excited = 15,
        Fearful = 16,
        Friendly = 17,
        Gentle = 18,
        Hopeful = 19,
        Lyrical = 20,
        Narration_Professional = 21,
        Narration_Relaxed_Reading = 22,
        Newscast = 23,
        Newscast_Casual = 24,
        Newscast_Formal = 25,
        Poetry_Reading = 26,
        Shouting = 27,
        Sports_Commentary = 28,
        Sports_Commentary_Excited = 29,
        Whispering = 30,
        Terrified = 31,
        Unfriendly = 32
    }
    #endregion

    #region RoleEnum : int
    /// <summary>
    /// This enum is used for the type of role
    /// </summary>
    public enum RoleEnum : int
    {
        Girl = 1,
        Boy = 2
    }
    #endregion

}
