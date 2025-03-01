using System;

namespace CodeStyleExample
{
    // クラス名はPascalCaseが推奨されているが、lowercase名を使った例（スタイル違反）
    public class FileNameIssueStyleViolationTest
    {
        // メンバー変数の命名規則違反（推奨: _camelCase または PascalCase）
        private int TestVariable = 10;

        // 正しい名前のフィールド
        private string _exampleField = "Valid";

        // Staticメンバー配置順序の違反（推奨: 静的要素 → インスタンスメンバーの順序）
        public static readonly string StaticExample = "Static Value";

        // メソッド名の命名規則違反（PascalCaseが推奨される）
        public void printmessage() // 【違反】PascalCaseでない
        {
            Console.WriteLine("This should follow PascalCase.");
        }

        // 正しいメソッド
        public void DisplayMessage()
        {
            Console.WriteLine(_exampleField);
        }

        // if文に波括弧{}が無い（スタイル違反: IDE0011）
        public void CheckCondition(int value)
        {
            if (value > 0) // 【違反】波括弧が無い
                Console.WriteLine("Value is positive.");
        }

        // 正しい条件分岐
        public void CorrectConditionCheck(int value)
        {
            if (value > 0)
            {
                Console.WriteLine("Value is positive.");
            }
        }

        // プロパティ定義ではPascalCaseが推奨
        public int myProperty { get; set; } = 42; // 【違反】PascalCaseでない名前

        // 正しいプロパティ定義
        public int MyProperty { get; set; } = 100;

        // 最後に改行がない（スタイル違反: `insert_final_newline=true`）
    }
}
