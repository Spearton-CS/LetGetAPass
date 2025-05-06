namespace LetGetAPass.Generation
{
    public static class KnownPassBounds
    {
        static KnownPassBounds()
        {
            List<char> bounds = [];

            {
                bounds.FillBounds((char)48, (char)57); //0-9
                bounds.FillBounds((char)97, (char)122); //a-z
                bounds.FillBounds((char)65, (char)90); //A-Z

                MinCharBounds = bounds.AsReadOnly();
            } //MIN CHAR BOUNDS

            {
                bounds = [.. bounds];

                bounds.FillBounds((char)1040, (char)1071); //А-Я
                bounds.FillBounds((char)1072, (char)1103); //а-я
                //bounds.FillBounds((char)1024, (char)1039); //Ѐ-Џ, usually don't allowed
                //bounds.FillBounds((char)1104, (char)1119); //ѐ-џ, usually don't allowed
                //bounds.FillBounds((char)1168, (char)1169); //"Ґ" "ґ", usually don't allowed

                DefaultCharBounds = bounds.AsReadOnly();
            } //DEFAULT CHAR BOUNDS

            {
                bounds = [.. bounds];

                for (char c = char.MinValue; c < char.MaxValue; c++)
                    if (char.IsLetter(c) && !bounds.Contains(c))
                        bounds.Add(c);

                MaxCharBounds = bounds.AsReadOnly();
            } //MAX CHAR BOUNDS

            List<char> specials;

            {
                MinSpecialsBounds = (specials = ['-', '_']).AsReadOnly();
            } //MIN SPECIALS BOUNDS

            {
                specials = [.. specials];
                specials.AddRange(['!', '=', '+',
                    //'(', ')', '[', ']', '{', '}' usually don't allowed
                    ]);

                DefaultSpecialsBounds = specials.AsReadOnly();
            } //DEFAULT SPECIALS BOUNDS

            {
                specials = [.. specials];
                specials.AddRange(['@', '#', '$', ';', ':', '.', '\\', '/', '|', '*', '&', '?', '^', '~', '%', '<', '>']);

                MaxSpecialsBounds = specials.AsReadOnly();
            } //MAX SPECIALS BOUNDS
        }

        /// <summary>Fills bounds-list with 'Left' and 'Right' bounds. Including</summary>
        /// <param name="b">Bounds-list</param>
        /// <param name="lb">'Left' bound. Including</param>
        /// <param name="hb">'Right' bound. Including</param>
        public static void FillBounds(this List<char> b, char lb, char hb)
        {
            for (; lb <= hb; lb++)
                b.Add(lb);
        }

        public static readonly IReadOnlyList<char> MinCharBounds;
        public static readonly IReadOnlyList<char> MinSpecialsBounds;

        public static readonly IReadOnlyList<char> DefaultCharBounds;
        public static readonly IReadOnlyList<char> DefaultSpecialsBounds;

        public static readonly IReadOnlyList<char> MaxCharBounds;
        public static readonly IReadOnlyList<char> MaxSpecialsBounds;

        public static readonly List<char> UserDefinedSpecials = [];

        public const byte MinLen = 3;

        public const byte DefaultMinLen = 8;
        public const byte DefaultMaxLen = 40;

        public const byte ProtectiveMinLen = 12;
        public const byte ProtectiveMaxLen = 120;
    }
}