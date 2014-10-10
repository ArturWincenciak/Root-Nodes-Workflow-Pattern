using System;
using System.Collections.Generic;
using TeoVincent.RootAndNodesPattern.Exceptions;

namespace TeoVincent.RootAndNodesPattern
{
    public abstract class Node : INode
    {
        public const string DEFAULT_OUTPUT_NAME = "DEFAULT_OUTPUT";

        protected readonly Root m_rootOnwer;
        
        private readonly string m_name;
        private readonly List<OutputNode> m_outputs = new List<OutputNode>();

        public string Name
        {
            get
            {
                return m_name;
            }
        }

        public abstract void OnEntry();

        protected Node(Root a_root, string a_name)
        {
            if (a_root == null)
                throw new ArgumentNullException("a_ivr");

            if (string.IsNullOrEmpty(a_name))
                throw new ArgumentNullException("a_name");

            m_name = a_name;
            m_rootOnwer = a_root;
            m_rootOnwer.AddNode(this);

            AddNodeOutput(new OutputNode(DEFAULT_OUTPUT_NAME));
        }

        public void JoinChildNode(string a_parentOutput, INode a_nodeChild)
        {
            var nodeOutput = m_outputs.Find(a_n => a_n.Name == a_parentOutput);

            if (nodeOutput == null)
                throw new InvalidNodeException(a_nodeChild);

            nodeOutput.Child = a_nodeChild;
        }

        public void JoinChildNode(INode a_nodeChild)
        {
            JoinChildNode(DEFAULT_OUTPUT_NAME, a_nodeChild);
        }

        public void Entry()
        {
            OnEntry();
        }

        public INode GetChildNode(string a_outputName)
        {
            var n = m_outputs.Find(a_a => a_a.Name == a_outputName);
            return n == null ? null : n.Child;
        }

        public override string ToString()
        {
            return GetType().Name + " <-> " + m_name;
        }

        public abstract void OnKeyboard(char a_c);

        protected void AddNodeOutput(OutputNode a_outputNode)
        {
            if (m_outputs.Exists(a_n => a_n == a_outputNode))
                throw new DuplicateOutputNodeException(a_outputNode);

            m_outputs.Add(a_outputNode);
        }

        protected void Finish(string a_strNodeOutputName = DEFAULT_OUTPUT_NAME)
        {
            m_rootOnwer.OnFinishNode(a_strNodeOutputName);
        }
    }
}
