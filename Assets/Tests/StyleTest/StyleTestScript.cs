
using UnityEngine;

namespace Tests.StyleTest
{
    public sealed class StyleTestScript
    {
        int _incorrect_field;
        string _stringField;
        int _intField;

        public int CorrectProperty { get; set; }

        public void CheckRules()
        {
            // 条件ブロックにブレースがないのでルール違反 (SA1503)
            if (CorrectProperty > 0)
                Debug.Log("Correct Property is greater than zero");

            // 正しい例：必ずブレースを使用する
            if (CorrectProperty > 0)
            {
                Debug.Log("Correct Property is greater than zero");
            }
        }

        public void VariableDeclaration()
        {
            var number = 5;
            int specificNumber = 10;
        }

        public void methord()
        {
        }
    }

    public interface StyleTestInterface {}
}
