namespace CodeOwls.PowerShell.Host.History
{
    public class NullHistoryStackWalker : IHistoryStackWalker
    {
        public string NextUp()
        {
            return null;
        }

        public string NextDown()
        {
            return null;
        }

        public string Oldest()
        {
            return null;
        }

        public string Newest()
        {
            return null;
        }

        public void Reset()
        {
        }
    }
}