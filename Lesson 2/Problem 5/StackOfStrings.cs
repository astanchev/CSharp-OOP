using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;

        public Stack<string> AddRange(Stack<string> stack)
        {
            foreach (var element in stack)
            {
                this.Push(element);
            }

            return this;
        }
    }
}