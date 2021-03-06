using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class ElementOfTreeContent : IElementOfTreeContent
    {

        private bool _empty;

        private string _stringValue;


        public ElementOfTreeContent()
        {
            this._empty = true;
            this._stringValue = string.Empty;
        }

        public ElementOfTreeContent(string newStringValue)
        {
            this._empty = false;
            this._stringValue = newStringValue;
        }

        public override bool Equals(object obj)
        {

            return false;
        }

        public override int GetHashCode()
        {

            return 0;
        }


        public bool IsEmpty() => _empty;

        public string GetStringValue() => _stringValue;
    }
}
