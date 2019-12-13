using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_ValidParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine(solution.IsValid("{{}}"));
        }
    }
    public class Solution
    {
        readonly Hashtable _hash = new Hashtable()
        {
            {'}', '{'},
            {']', '['},
            {')', '('}
        };
        readonly Stack<char> _stack = new Stack<char>();

        public bool IsValid(string s)
        {
            foreach (char c in s)
            {
                if (_hash.ContainsValue(c))
                {
                    _stack.Push(c);
                }
                else
                {
                    if (_stack.Count == 0) return false;
                    var removed = _stack.Pop();
                    if ((char)_hash[c] != removed)
                    {
                        return false;
                    }
                }
            }

            return _stack.Count == 0;
        }
    }
}
