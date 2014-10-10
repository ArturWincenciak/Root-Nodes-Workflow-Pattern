using System.Collections.Generic;
using TeoVincent.RootAndNodesPattern.Exceptions;

namespace TeoVincent.RootAndNodesPattern
{
    public interface IEventHandler
    {
        void OnKeyboard(char a_c);
    }

    public class Root : IEventHandler
    {
        private readonly string m_name;
        protected INode m_activeNode;
        protected INode m_startNode;
        protected List<INode> m_ownNodes;

        protected Root(string a_name)
        {
            m_name = a_name;
            m_ownNodes = new List<INode>();
        }
        public void SetStartNode(INode a_node)
        {
            var n = m_ownNodes.Find(a_a => a_a == a_node);

            if (n == null)
                throw new InvalidNodeException(a_node);

            m_startNode = n;
        }

        public void Run()
        {
            m_activeNode = m_startNode;
            m_activeNode.Entry();
        }
        
        public override string ToString()
        {
            return GetType().Name + " <-> " + m_name;
        }

        public void OnKeyboard(char a_c)
        {
            m_activeNode.OnKeyboard(a_c);
        }

        internal void AddNode(INode a_node)
        {
            m_ownNodes.Add(a_node);
        }

        internal void OnFinishNode(string a_nodeOutputName)
        {
            var nextNode = m_activeNode.GetChildNode(a_nodeOutputName);

            if (nextNode == null)
            {
                OnFinish();
                return;
            }

            m_activeNode = nextNode;
            nextNode.Entry();
        }

        protected virtual void OnFinish() { }
    }
}