using TeoVincent.RootAndNodesPattern.Exceptions;

namespace TeoVincent.RootAndNodesPattern
{
    public sealed class OutputNode
    {
        private readonly string m_name;
        private INode m_childNode;

        public string Name
        {
            get { return m_name; }
        }

        public INode Child
        {
            get
            {
                return m_childNode;
            }

            set
            {
                if (m_childNode != null)
                    throw new DuplicateChildNodeException(m_childNode);

                m_childNode = value;
            }
        }

        public OutputNode(string a_name)
        {
            m_name = a_name;
        }
    }
}
