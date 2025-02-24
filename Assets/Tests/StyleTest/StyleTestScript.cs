
using UnityEngine;

namespace Tests.StyleTest
{
    public sealed class StyleTestScript
    {
        int _incorrect_field;
        string stringField;

        public int CorrectProperty { get; set; }

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

        void _PrivateMethod()
        {

        }
    }

    public interface IStyleTestInterface { }
}
