namespace TeoVincent.RootAndNodesPattern
{
    public interface INode : IEventHandler
    {
        string Name { get; }
        void OnEntry();
        void JoinChildNode(string a_parentOutput, INode a_nodeChild);
        void JoinChildNode(INode a_nodeChild);
        void Entry();
        INode GetChildNode(string a_outputName);
    }
}