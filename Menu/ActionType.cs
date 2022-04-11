using System;

namespace Bank
{
    internal class ActionType
    {
        public Action ActionToDo { get; private set; }
        public string Name { get; private set; }

        public ActionType(string name, Action action)
        {
            Name = name;
            ActionToDo = action;
        }
    }
}
