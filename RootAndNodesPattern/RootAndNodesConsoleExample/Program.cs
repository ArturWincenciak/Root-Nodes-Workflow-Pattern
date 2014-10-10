using System;
using TeoVincent.RootAndNodesConsoleExample.Nodes;
using TeoVincent.RootAndNodesPattern;

namespace TeoVincent.RootAndNodesConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OGNIA...");

            var root = new ExampleTree("teo");
            Node showMessage = new MessageNode(root, "Welcome", "This is start node...");
            Node asterisks = new AsteriskPrinterkNode(root, "Asterisks", 50);
            Node question = new YesOrNoMenuNode(root, "Question about asterisk", "Do you want to write asterisks?");
            Node notAsterisksMessage = new MessageNode(root, "Not asterisk", "You didn't want to asterisks.");
            Node wrongChoiceMessage = new MessageNode(root, "Bad choice.", "Bad choice. Try once again.");
            Node endMessage = new MessageNode(root, "End", "Fine.");

            showMessage.JoinChildNode(question);
            question.JoinChildNode(YesOrNoMenuNode.YES_OUTPUT, asterisks);
            question.JoinChildNode(YesOrNoMenuNode.NO_OUTPUT, notAsterisksMessage);
            question.JoinChildNode(wrongChoiceMessage);
            wrongChoiceMessage.JoinChildNode(question);
            asterisks.JoinChildNode(endMessage);
            notAsterisksMessage.JoinChildNode(endMessage);

            root.SetStartNode(showMessage);
            root.Run();

            while (true)
                root.OnKeyboard(Console.ReadKey().KeyChar);
        }
    }
}
