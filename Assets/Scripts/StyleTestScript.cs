
using UnityEngine;

namespace Tests
{
    public sealed class StyleTestScript
    {
        public static readonly string StaticProperty = "This is a static property";

        public string ProperlyStyledProperty { get; } = "This is a properly styled property";

        public void improperlyStyledMethod(){
        int x=10;
            if(x>5){
                Debug.Log("Improper styling with inconsistent spaces and format");
    }
        }
    }
}
