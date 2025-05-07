namespace LetGetAPass.Generation
{
    //41 - now largest pow of 2 used
    [Flags]
    public enum PasswordRequirements : ulong
    {
        /// <summary>End-pass will generated using defaults</summary>
        None = 0,

        #region End-pass MUST have

        /// <summary>End-pass will have AT LEAST one upper-case char (A-Z)</summary>
        HaveUppercase = 1UL << 0,
        /// <summary>End-pass will have AT LEAST one lower-case char (a-z)</summary>
        HaveLowercase = 1UL << 1,
        /// <summary>End-pass will have AT LEAST one special char (!, -, _...)</summary>
        HaveSpecial = 1UL << 2,
        /// <summary>End-pass will have AT LEAST one digit char (0-9)</summary>
        HaveDigit = 1UL << 3,
        /// <summary>End-pass will have AT LEAST one letter char (a-Z)</summary>
        HaveLetter = 1UL << 4,

        #endregion

        #region End-pass MUST have NO

        /// <summary>End-pass will don't have upper-case chars (A-Z)</summary>
        NoUppercase = 1UL << 5,
        /// <summary>End-pass will don't have lower-case chars (a-z)</summary>
        NoLowercase = 1UL << 6,
        /// <summary>End-pass will don't have special chars (!, -, _...)</summary>
        NoSpecial = 1UL << 7,
        /// <summary>End-pass will don't have digit chars (0-9)</summary>
        NoDigits = 1UL << 8,
        /// <summary>End-pass will don't have letter chars (a-Z)</summary>
        NoLetters = NoUppercase | NoLowercase,
        /// <summary>End-pass will don't have ambiguous chars (1 and I, O and 0...)</summary>
        NoAmbiguousChars = 1UL << 31,

        #endregion

        #region End-pass MUST have last

        /// <summary>End-pass will have last char upper-case (A-Z)</summary>
        [Obsolete("Not implemented")]
        LastUppercase = 1UL << 9,
        /// <summary>End-pass will have last char lower-case (a-z)</summary>
        [Obsolete("Not implemented")]
        LastLowercase = 1UL << 10,
        /// <summary>End-pass will have last char special (!, -, _...)</summary>
        [Obsolete("Not implemented")]
        LastSpecial = 1UL << 11,
        /// <summary>End-pass will have last char digit (0-9)</summary>
        [Obsolete("Not implemented")]
        LastDigit = 1UL << 12,
        /// <summary>End-pass will have last char letter (a-Z)</summary>
        [Obsolete("Not implemented")]
        LastLetter = 1UL << 13,

        #endregion

        #region End-pass MUST have first

        /// <summary>End-pass will have first char upper-case (A-Z)</summary>
        [Obsolete("Not implemented")]
        FirstUppercase = 1UL << 14,
        /// <summary>End-pass will have first char lower-case (a-z)</summary>
        [Obsolete("Not implemented")]
        FirstLowercase = 1UL << 15,
        /// <summary>End-pass will have first char special (!, -, _...)</summary>
        [Obsolete("Not implemented")]
        FirstSpecial = 1UL << 16,
        /// <summary>End-pass will have first char digit (0-9)</summary>
        [Obsolete("Not implemented")]
        FirstDigit = 1UL << 17,
        /// <summary>End-pass will have first char letter (a-Z)</summary>
        [Obsolete("Not implemented")]
        FirstLetter = 1UL << 18,

        #endregion

        #region End-pass MUST have NO last

        /// <summary>End-pass will don't have last char upper-case (A-Z)</summary>
        [Obsolete("Not implemented")]
        NoLastUppercase = 1UL << 19,
        /// <summary>End-pass will don't have last char lower-case (a-z)</summary>
        [Obsolete("Not implemented")]
        NoLastLowercase = 1UL << 20,
        /// <summary>End-pass will don't have last char special (!, -, _...)</summary>
        [Obsolete("Not implemented")]
        NoLastSpecial = 1UL << 21,
        /// <summary>End-pass will don't have last char digit (0-9)</summary>
        [Obsolete("Not implemented")]
        NoLastDigit = 1UL << 22,
        /// <summary>End-pass will don't have last char letter (a-Z)</summary>
        [Obsolete("Not implemented")]
        NoLastLetter = NoLastUppercase | NoLastLowercase,

        #endregion

        #region End-pass MUST have NO first

        /// <summary>End-pass will don't have first char upper-case (A-Z)</summary>
        [Obsolete("Not implemented")]
        NoFirstUppercase = 1UL << 23,
        /// <summary>End-pass will don't have first char lower-case (a-z)</summary>
        [Obsolete("Not implemented")]
        NoFirstLowercase = 1UL << 24,
        /// <summary>End-pass will don't have first char special (!, -, _...)</summary>
        [Obsolete("Not implemented")]
        NoFirstSpecial = 1UL << 25,
        /// <summary>End-pass will don't have first char digit (0-9)</summary>
        [Obsolete("Not implemented")]
        NoFirstDigit = 1UL << 26,
        /// <summary>End-pass will don't have first char letter (a-Z)</summary>
        [Obsolete("Not implemented")]
        NoFirstLetter = NoFirstUppercase | NoFirstLowercase,

        #endregion

        #region End-pass MUST have sequence of

        /// <summary>End-pass will have sequence of sequentially digits (123, 01, 89)</summary>
        [Obsolete("Not implemented")]
        HaveSequentiallyDigits = 1UL << 27,
        /// <summary>End-pass will have sequence of sequentially letters (abc, bc, xyz)</summary>
        [Obsolete("Not implemented")]
        HaveSequentiallyLetters = 1UL << 28,
        /// <summary>End-pass will have sequence of digits (132, 123, 90)</summary>
        [Obsolete("Not implemented")]
        HaveSequenceOfDigits = 1UL << 38,
        /// <summary>End-pass will have sequence of letters (abc, cba, help)</summary>
        [Obsolete("Not implemented")]
        HaveSequenceOfLetters = 1UL << 39,

        #endregion

        #region End-pass MUST have NO sequence of

        /// <summary>End-pass will don't have sequence of sequentially digits (123, 01, 89)</summary>
        [Obsolete("Not implemented")]
        NoSequentiallyDigits = 1UL << 29,
        /// <summary>End-pass will don't have sequence of sequentially letters (abc, bc, xyz)</summary>
        [Obsolete("Not implemented")]
        NoSequentiallyLetters = 1UL << 30,
        /// <summary>End-pass will don't have sequence of digits (132, 123, 90)</summary>
        [Obsolete("Not implemented")]
        NoSequenceOfDigits = 1UL << 40,
        /// <summary>End-pass will don't have sequence of letters (abc, cba, help)</summary>
        [Obsolete("Not implemented")]
        NoSequenceOfLetters = 1UL << 41,

        #endregion

        #region End-pass MUST be checked for

        /// <summary>Check end-pass for minimal brut-force shield</summary>
        [Obsolete("Not implemented")]
        EntropyCheck = 1UL << 32,
        /// <summary>Check end-pass for 100% of chars is unique</summary>
        [Obsolete("Not implemented")]
        Unique100PercentCheck = 1UL << 33,
        /// <summary>Check end-pass for 75% of chars is unique</summary>
        [Obsolete("Not implemented")]
        Unique75PercentCheck = 1UL << 34,
        /// <summary>Check end-pass for 50% of chars is unique</summary>
        [Obsolete("Not implemented")]
        Unique50PercentCheck = 1UL << 35,
        /// <summary>Check end-pass for 25% of chars is unique</summary>
        [Obsolete("Not implemented")]
        Unique25PercentCheck = 1UL << 36,
        /// <summary>Check end-pass for 10% of chars is unique</summary>
        [Obsolete("Not implemented")]
        Unique10PercentCheck = 1UL << 37,

        #endregion
    }
}