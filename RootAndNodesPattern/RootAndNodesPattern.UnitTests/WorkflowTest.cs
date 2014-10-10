using NUnit.Framework;
using Rhino.Mocks;
using TeoVincent.RootAndNodesConsoleExample;
using TeoVincent.RootAndNodesConsoleExample.Nodes;

namespace TeoVincent.RootAndNodesPattern.UnitTests
{
    public class WorkflowTest
    {
        private Root GetRootWithOneMessageNode(INode a_nextNode)
        {
            Root root = new ExampleTree("TEST ROOT NAME");
            INode node = new MessageNode(root, "MESSAGE NODE NAME", "SOME MESSAGE");

            node.JoinChildNode(a_nextNode);
            root.SetStartNode(node);

            return root;
        }

        private Root GetRootYesOrNoMenuNode(INode a_nextNode, string a_output)
        {
            Root root = new ExampleTree("TEST ROOT NAME");
            INode node = new YesOrNoMenuNode(root, "YESNO NODE NAME", "SOME MESSAGE");

            node.JoinChildNode(a_output, a_nextNode);
            root.SetStartNode(node);

            return root;
        }

        private Root GetRootAsteriskNode(INode a_nextNode)
        {
            Root root = new ExampleTree("TEST ROOT NAME");
            INode node = new AsteriskPrinterkNode(root, "ASTERISK NODE NAME", 50);

            node.JoinChildNode(a_nextNode);
            root.SetStartNode(node);

            return root;
        }

        [Test]
        public void Entry_To_Next_Node_After_Message_Node_Test()
        {
            // 1) arrange
            var node = MockRepository.GenerateMock<INode>();
            Root root = GetRootWithOneMessageNode(node);

            // 2) act
            root.Run();
            root.OnKeyboard('X');

            // 3) assert
            node.AssertWasCalled(n => n.Entry());
        }

        [Test]
        public void Entry_To_Next_Node_After_No_Node_Test()
        {
            // 1) arrange
            var node = MockRepository.GenerateMock<INode>();
            Root root = GetRootYesOrNoMenuNode(node, YesOrNoMenuNode.NO_OUTPUT);

            // 2) act
            root.Run();
            root.OnKeyboard('N');

            // 3) assert
            node.AssertWasCalled(n => n.Entry());
        }

        [Test]
        public void Entry_To_Next_Node_After_NoYes_Node_Test()
        {
            // 1) arrange
            var node = MockRepository.GenerateMock<INode>();
            Root root = GetRootYesOrNoMenuNode(node, YesOrNoMenuNode.NO_OUTPUT);

            // 2) act
            root.Run();
            root.OnKeyboard('Y');

            // 3) assert
            node.AssertWasNotCalled(n => n.Entry());
        }

        [Test]
        public void Entry_To_Next_Node_After_Yes_Node_Test()
        {
            // 1) arrange
            var node = MockRepository.GenerateMock<INode>();
            Root root = GetRootYesOrNoMenuNode(node, YesOrNoMenuNode.YES_OUTPUT);

            // 2) act
            root.Run();
            root.OnKeyboard('Y');

            // 3) assert
            node.AssertWasCalled(n => n.Entry());
        }

        [Test]
        public void Entry_To_Next_Node_After_YesNo_Node_Test()
        {
            // 1) arrange
            var node = MockRepository.GenerateMock<INode>();
            Root root = GetRootYesOrNoMenuNode(node, YesOrNoMenuNode.YES_OUTPUT);

            // 2) act
            root.Run();
            root.OnKeyboard('N');

            // 3) assert
            node.AssertWasNotCalled(n => n.Entry());
        }

        [Test]
        public void Entry_To_Asterisk_Node_Test()
        {
            // 1) arrange
            var node = MockRepository.GenerateMock<INode>();
            Root root = GetRootAsteriskNode(node);

            // 2) act
            root.Run();
            root.OnKeyboard('X');

            // 3) assert
            node.AssertWasCalled(n => n.Entry());
        }

        [Test]
        public void Entry_To_Asterisk_Node_End_Not_To_Nest_Test()
        {
            // 1) arrange
            var node = MockRepository.GenerateMock<INode>();
            Root root = GetRootAsteriskNode(node);

            // 2) act
            root.Run();

            // 3) assert
            node.AssertWasNotCalled(n => n.Entry());
        }
    }
}