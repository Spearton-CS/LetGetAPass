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

                MinCharBounds = bounds;
            } //MIN CHAR BOUNDS

            {

            } //DEFAULT CHAR BOUNDS

            {

            } //MAX CHAR BOUNDS

            List<char> specials;

            {
                MinSpecialsBounds = specials = ['-', '_'];
            } //MIN SPECIALS BOUNDS

            {
                specials.AddRange(['!', '=', '+', '(', ')', '[', ']', '{', '}']);

                DefaultSpecialsBounds = specials;
            } //DEFAULT SPECIALS BOUNDS

            {
                specials.AddRange();

                MaxSpecialsBounds = specials;
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

        public const byte MinLen = 3;

        public const byte DefaultMinLen = 8;
        public const byte DefaultMaxLen = 40;

        public const byte ProtectiveMinLen = 12;
        public const byte ProtectiveMaxLen = 120;
    }
}