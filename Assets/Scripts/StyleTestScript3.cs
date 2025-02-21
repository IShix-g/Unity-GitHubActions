
using UnityEngine;
using System.Collections.Generic;

namespace Tests
{
    public sealed class StyleTestScript3
    {
        public const int ConstField = 10;
        public static readonly int StaticField = 10;
        public int NonStaticField;
        private static int _s_static_Field = 10;
        private int m_nonStaticField;
        public int property_value { get; set; }

        private List<int> testCollection =  new List<int>();

        public void test_Method() {
            int testVariable = 42 ;
            if(testVariable>   40)
                Debug.Log("Hello ");

            var result = "some result";
            this.runAdditionalLogic ();
        }

        private void runAdditionalLogic () {

        }
    }
}
