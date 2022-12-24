using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MyCompany.Service
{
    public static class Extencions
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }
    }
}
