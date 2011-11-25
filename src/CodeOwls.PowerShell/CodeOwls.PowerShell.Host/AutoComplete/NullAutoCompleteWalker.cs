namespace CodeOwls.PowerShell.Host.AutoComplete
{
    public class NullAutoCompleteWalker : IAutoCompleteWalker
    {
        public string NextUp(string guess)
        {
            return null;
        }

        public string NextDown(string guess)
        {
            return null;
        }
    }
}