
using UnityEngine;

namespace Tests
{
    public sealed class CodingConventionsViolations : MonoBehaviour
    {
        // メンバー変数の命名規則違反（推奨: _camelCase または PascalCase）
        private int TestVariable = 10;

        // 正しい名前のフィールド
        private string _exampleField = "Valid";
        
        // スペースが1つ足りない違反
       public static readonly string StaticExample = "Static Value";

        // メソッド名の命名規則違反（PascalCaseが推奨される）
        public void printmessage() // 【違反】PascalCaseでない
        {
            Debug.Log("This should follow PascalCase.");
        }

        // 正しいメソッド
        public void DisplayMessage()
        {
            Debug.Log(_exampleField);
        }

        // if文に波括弧{}が無い（スタイル違反: IDE0011）
        public void CheckCondition(int value)
        {
            if (value > 0) // 【違反】波括弧が無い
                Debug.Log("Value is positive.");
            
            float x = 10;
            // 【違反】キャストと値の間に空白
            int y = (int)x;
            // 【違反】制御フロー ステートメントのキーワードの後に空白文字を配置
            for (var i=0;i<x;i++) { }
        }

        // 正しい条件分岐
        public void CorrectConditionCheck(int value)
        {
            if (value > 0)
            {
                Debug.Log("Value is positive.");
            }
        }

        // プロパティ定義ではPascalCaseが推奨
        public int myProperty { get; set; } = 42; // 【違反】PascalCaseでない名前

        // 正しいプロパティ定義
        public int MyProperty { get; set; } = 100;
    }
}