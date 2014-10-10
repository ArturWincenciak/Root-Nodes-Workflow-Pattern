using System;
using TeoVincent.RootAndNodesPattern;

namespace TeoVincent.RootAndNodesConsoleExample.Nodes
{
    public class YesOrNoMenuNode : Node
    {
        public const string YES_OUTPUT = "YES";
        public const string NO_OUTPUT = "NO";
        
        private readonly string m_question;

        public YesOrNoMenuNode(Root a_root, string a_name, string a_question) 
            : base(a_root, a_name)
        {
            m_question = a_question;
            
            AddNodeOutput(new OutputNode(YES_OUTPUT));
            AddNodeOutput(new OutputNode(NO_OUTPUT));
        }

        public override void OnEntry()
        {
            Console.WriteLine(m_question);
            Console.WriteLine("YES = Y, NO = N");
        }

        public override void OnKeyboard(char a_c)
        {
            switch (a_c)
            {
                case 'Y':
                    Finish(YES_OUTPUT);
                    break;
                case 'N':
                    Finish(NO_OUTPUT);
                    break;
                default:
                    Console.WriteLine("Niepoprawna odpowiedź...");
                    Finish();
                    break;
            }
        }
    }
}
