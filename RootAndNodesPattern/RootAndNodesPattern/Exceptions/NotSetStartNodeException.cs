using System;

namespace TeoVincent.RootAndNodesPattern.Exceptions
{
    public class NotSetStartNodeException : Exception
    {
        public NotSetStartNodeException()
            : base("Did not set a start node. The root requires the start node.")
        {
        }
    }
}