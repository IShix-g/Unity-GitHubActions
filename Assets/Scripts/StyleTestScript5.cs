
namespace Tests
{
    public sealed class StyleTestScript5
    {
        public static readonly string StaticProperty = "This is a static property";
        public int CorrectProperty { get; set; }

        private int _incorrectField;
        private string stringField;

        static readonly string staticField = "This is a static field";
        static string staticField2 = "This is a static field";

        public void CheckRules()
        {

        }

        public void VariableDeclaration()
        {

        }
    }
}
