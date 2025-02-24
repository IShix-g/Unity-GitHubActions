namespace Tests.StyleTest
{
    public sealed class StyleTestScript2
    {
        public static readonly string StaticProperty = "This is a static property";
        static readonly string staticField = "This is a static field";
        static string staticField2 = "This is a static field";
        public int CorrectProperty { get; set; }

        private int _incorrectField;
        string _stringField;

        public void CheckRules()
        {

        }

        internal void methord()
        {

        }
    }
}
