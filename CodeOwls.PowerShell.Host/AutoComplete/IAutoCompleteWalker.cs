namespace CodeOwls.PowerShell.Host.AutoComplete
{
    public interface IAutoCompleteWalker
    {
        string NextUp(string guess);
        string NextDown(string guess);
    }
}