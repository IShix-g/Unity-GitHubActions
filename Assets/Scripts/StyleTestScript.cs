
using UnityEngine;

namespace Tests
{
    public sealed class StyleTestScript
    {
        public const string ConstProperty = "This is a const property";
        public static readonly string StaticProperty = "This is a static property";
        public string ProperlyStyledProperty { get; } = "This is a properly styled property";
        public int IntProperty => _intField;

        static readonly string s_staticField = "This is a static field";

        string stringField;
        int _intField;
        double doubleField;
        float floatField;

        public void improperlyStyledMethod(){
        int x=10;
            if(x>5){
                Debug.Log("Improper styling with inconsistent spaces and format");
    }
        }

        public string GetString() => "This is a string";

        public int GetInt() => 10;

        public long GetLong() => 10;

        public float GetFloat() => 10;

        public double GetDouble() => 10;

    public void ExampleMethod()
    {
        // 未使用の変数で警告
        int unusedVariable;

        // 意図的にコンパイルエラー
        not_defined_variable = 10;
    }
    }
}
