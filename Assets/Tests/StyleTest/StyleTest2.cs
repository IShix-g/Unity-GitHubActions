namespace Tests.StyleTest
{
    public sealed class StyleTest2
    {
        static string staticField = string.Empty;
        string _test;
        string _test2;

        void test()
        {
            var a = this._test2;
        }
    }
}
