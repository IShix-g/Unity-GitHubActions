
using UnityEngine;
using System.Collections.Generic;

namespace Tests
{
    public sealed class StyleTestScript3
    {
        private static int _s_static_Field = 10;
        private int m_nonStaticField;

        private List<int> testCollection =  new List<int>();
        public int property_value { get; set; }

        public void test_Method() {
            int testVariable = 42 ;
            if(testVariable>   40)
                Debug.Log("Hello ");

            var result = "some result";
            this.runAdditionalLogic ();
        }

        private void runAdditionalLogic () {

        }

        private void Very_Long_Method_With_No_Clear_Structure ()
        {
            int a=0;
            while (a<5) a++;

            if(a>=5)
            {
                Debug.Log(a);

            }

            var myList= new List<int>{1,2,3};

            foreach(int item in  myList) {
                if ( item%2 == 0) Debug.Log("偶数 アイテム") ; else Debug.Log ("奇数 アイテム") ; }
        }

    }
}
