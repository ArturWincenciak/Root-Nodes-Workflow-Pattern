using System;
using System.Threading;
using System.Threading.Tasks;
using TeoVincent.RootAndNodesPattern;

namespace TeoVincent.RootAndNodesConsoleExample.Nodes
{
    public class AsteriskPrinterkNode : Node
    {
        private readonly int m_count;
        private bool m_stop;

        public AsteriskPrinterkNode(Root a_root, string a_name, int a_count) 
            : base(a_root, a_name)
        {
            m_count = a_count;
        }

        public override void OnEntry()
        {
            m_stop = false;
            Console.WriteLine("Press any key to stop writing asterisk...");

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < m_count; i++)
                {
                    Thread.Sleep(1000);

                    if (m_stop)
                        break;

                    Console.Write("*");
                }
            });
        }

        public override void OnKeyboard(char a_c)
        {
            m_stop = true;
            Finish();
        }
    }
}