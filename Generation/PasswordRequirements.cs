namespace LetGetAPass.Generation
{
    [Flags]
    public enum PasswordRequirements : ulong
    {
        None = 0,
        /// <summary>Will check Generator, but be sure bounds have Uppercase chars</summary>
        HaveUppercase = 1,
        /// <summary>Will check Generator, but be sure bounds have Lowercase chars</summary>
        HaveLowercase = 2,
        /// <summary>Will check Generator, but be sure bounds have Special chars</summary>
        HaveSpecial = 4,
        /// <summary>Will check Generator, but be sure bounds have Digit chars</summary>
        HaveDigit = 8,
        /// <summary>Will check Generator, but be sure bounds have Letter chars</summary>
        HaveLetter = 16,
        /// <summary>Check before Generator</summary>
        NoUppercase = 32,
        /// <summary>Check before Generator</summary>
        NoLowercase = 64,
        /// <summary>Check before Generator</summary>
        NoSpecial = 128,
        /// <summary>Check before Generator</summary>
        NoDigits = 256,
        /// <summary>Check before Generator</summary>
        NoLetters = 512
    }
}