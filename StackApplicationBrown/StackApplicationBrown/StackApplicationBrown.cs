using System;
using System.Collections.Generic;

//Aleksander Brown CIS 152

namespace StackApplicationBrown
{
    static class StackApplicationBrown
    {
        static void Main(string[] args)
        {
            //arrays for infix
            string[] infix1 = new string[3] { "A", "&", "B" };
            string[] infix2 = new string[7] { "A", "&", "B", "|", "C", "&", "D" };
            string[] infix3 = new string[7] { "A", "|", "B", "&", "C", "|", "D" };
            string[] infix4 = new string[9] { "A", "|", "B", "&", "C", "|", "D", "&", "E" };
            PostFix pf = new PostFix();
            string postFix;
            //calls to class
            postFix = pf.Parse(infix1, infix1.Length);
            Console.WriteLine(postFix);

            postFix = pf.Parse(infix2, infix2.Length);
            Console.WriteLine(postFix);

            postFix = pf.Parse(infix3, infix3.Length);
            Console.WriteLine(postFix);

            postFix = pf.Parse(infix4, infix4.Length);
            Console.WriteLine(postFix);
        }
    }

    class PostFix
    {
        private string[] _infix;
        private string _postfix;
        private int _initInfixSize;
        private bool _freshState = true;
        private Stack<string> _postFixStack = new Stack<string>();

        public string[] Infix
        {
            get { return _infix; }
            set { _infix = value; }
        }
        public string Postfix
        {
            get { return _postfix; }
        }

        public PostFix()
        {
        }

        //input infix output postfix, recursion loops array so stack dump at end is in the right order
        public string Parse(string[] infix, int infixSize)
        {
            _infix = infix;
            if (_freshState)
            {
                _initInfixSize = infix.Length;
                _postfix = null;
            }
            _freshState = false;


            if (infixSize > 1)
            {
                Parse(_infix, infixSize - 1);
            }

            string temp = _infix[infixSize - 1];

            if (temp.Equals("&"))
            {
                _postFixStack.Push(temp);
            }
            else if (temp.Equals("|"))
            {
                if (_postFixStack.Count > 0)
                {
                    if (_postFixStack.Peek().Equals("&"))
                    {
                        _postfix += _postFixStack.Pop();
                    }
                }
                _postFixStack.Push(temp);
            }
            else
            {
                _postfix += temp;
            }

            if (infixSize == _initInfixSize)
            {
                while (_postFixStack.Count > 0)
                {
                    _postfix += _postFixStack.Pop();
                }
                _freshState = true;
            }

            return _postfix;
        }
    }
}

