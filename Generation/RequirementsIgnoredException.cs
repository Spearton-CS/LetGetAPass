namespace LetGetAPass.Generation
{
    /// <summary>Created for cases, when PasswordRequirements was ignored</summary>
    /// <param name="msg"></param>
    /// <param name="inner"></param>
    public class RequirementsIgnoredException(string? msg = null, Exception? inner = null) : Exception(msg, inner);
}