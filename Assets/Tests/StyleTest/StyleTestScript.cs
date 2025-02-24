
using UnityEngine;

namespace Tests.StyleTest
{
    public sealed class StyleTestScript
    {
        public int CorrectProperty { get; set; }

        int _incorrect_field;
        string stringField;

        public void CheckRules()
        {
            if (CorrectProperty > 0)
            {
                Debug.Log("Correct Property is greater than zero");
            }

            if (CorrectProperty > 0)
                Debug.Log("Correct Property is greater than zero");
        }

        public void VariableDeclaration()
        {
            var number = 5;
            int specificNumber = 10;
        }

        public void Methord()
        {

        }

        void PrivateMethod()
        {

        }
    }

    public interface IStyleTestInterface { }
}
