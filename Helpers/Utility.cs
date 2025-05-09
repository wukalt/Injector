namespace Injector.Helpers;

public static class Utility
{
    public static bool ContainsReqArgs(this string[] args)
    {
        return 
            args.Contains("-path") &&
            args.Contains("-add") &&
            args.Length == 4;
    }
}
