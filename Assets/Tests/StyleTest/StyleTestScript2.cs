namespace Tests.StyleTest
{
    public sealed class StyleTestScript2
    {
        private int _incorrectField;
         private string stringField;

        public int CorrectProperty { get; set; }

        public static readonly string StaticProperty = "This is a static property";
        static readonly string staticField = "This is a static field";
        static string staticField2 = "This is a static field";

        public void CheckRules()
        {

        }

        public void variableDeclaration()
        {

        }
    }
}
