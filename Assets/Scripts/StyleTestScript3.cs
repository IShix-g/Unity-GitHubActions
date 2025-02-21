
using UnityEngine;
using System.Collections.Generic;

namespace Tests
{
    public sealed class StyleTestScript3
    {
        private static int _s_static_Field = 10; // 静的メンバーへのアンダースコアは許可されない (SA1311)
        private int m_nonStaticField; // フィールド名が "m_" で始まっている (SA1307)

        private List<int> testCollection =  new List<int>();  // フィールド名が小文字始まり (SA1300)

        // プロパティ名が PascalCase に一致しない
        public int property_value { get; set; }  // プロパティ名が小文字始まり (SA1300)

        public void test_Method() {  // メソッド名が PascalCase に一致していない (SA1300)
            int    testVariable    = 42 ; // 余分なスペースで整列が崩れている (スペースルール反則)
            if(testVariable>   40)       // 演算子周辺のスペースが不適切
                Debug.Log("Hello ");     // スペースの不足や、不要なトレイリングスペース(SA1028)

            var result = "some result"; // 型が明確でない場所で var を使用 (dotnet_style_var_elsewhere)
            this.runAdditionalLogic (); // メソッド名が PascalCase に沿っていない
        }

        // 長く複雑なメソッド構造
        private void runAdditionalLogic () {  // PascalCase に一致していない (SA1300)
            for (int i=0; i <50;i++)  // 行の適切なスペースを欠く (スペース関連違反)
                testCollection.Add(i);  // ループで波括弧が欠如 (SA1503)

            if(m_nonStaticField < 10) Debug.Log("Direct Action") ; // 単一行の制御構文で波括弧が欠如 (SA1503)

            foreach ( var x  in   testCollection)    // インデント、スペースが正しく装飾されていない
                Debug.Log  ( string.Format  ( "Item : {0}",x) );  // スペースが不足、メソッド呼び出しの形式違反
        }

        private void Very_Long_Method_With_No_Clear_Structure ()
        {
            int a=0; // インデント、スペースの欠如
            while (a<5) a++; // 見づらいコード、波括弧省略

            if(a>=5)
            { // 不要な開業
                Debug.Log(a); // 不適切なインデント (タブ vs スペース違反)

            }

            // コレクションと演算で波括弧を使用せず、冗長
            var myList= new List<int>{1,2,3};

            foreach(int item in  myList) {
                if ( item%2 == 0) Debug.Log("偶数 アイテム") ; else Debug.Log ("奇数 アイテム") ; }
        }

    }
}
