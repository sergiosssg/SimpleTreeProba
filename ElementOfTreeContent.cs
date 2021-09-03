using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class ElementOfTreeContent : IElementOfTreeContent
    {

        bool _empty;


        public ElementOfTreeContent()
        {
            this._empty = true;
        }


        public bool IsEmpty() => _empty;

        public string GetStringValue()
        {
            throw new NotImplementedException();
        }
    }
}
