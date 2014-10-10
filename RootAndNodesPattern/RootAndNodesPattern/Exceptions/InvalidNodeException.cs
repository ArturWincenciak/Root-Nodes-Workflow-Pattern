using System;

namespace TeoVincent.RootAndNodesPattern.Exceptions
{
    public class InvalidNodeException : Exception
    {
        private readonly INode m_nodeChild;

        public InvalidNodeException(INode a_nodeChild)
        {
            m_nodeChild = a_nodeChild;
        }

        public INode NodeChild
        {
            get { return m_nodeChild; }
        }
    }
}