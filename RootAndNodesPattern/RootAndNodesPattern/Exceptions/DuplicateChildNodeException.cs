using System;

namespace TeoVincent.RootAndNodesPattern.Exceptions
{
    public class DuplicateChildNodeException : Exception
    {
        private readonly INode m_nodeChild;

        public DuplicateChildNodeException(INode a_nodeChild)
        {
            m_nodeChild = a_nodeChild;
        }

        public INode NodeChild
        {
            get { return m_nodeChild; }
        }
    }
}