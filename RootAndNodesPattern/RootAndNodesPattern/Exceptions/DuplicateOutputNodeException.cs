using System;

namespace TeoVincent.RootAndNodesPattern.Exceptions
{
    public class DuplicateOutputNodeException : Exception
    {
        private readonly OutputNode m_outputNode;

        public DuplicateOutputNodeException(OutputNode a_outputNode)
        {
            m_outputNode = a_outputNode;
        }

        public OutputNode OutputNode
        {
            get { return m_outputNode; }
        }
    }
}