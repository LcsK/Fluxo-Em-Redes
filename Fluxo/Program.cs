using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxo.DataStructure;

namespace Fluxo
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.AddNode("1");
            g.AddNode("2");
            g.AddNode("3");
            g.AddNode("4");
            g.AddNode("5");
            g.AddNode("6");
            g.AddEdgeB("1", "2", 5);
            g.AddEdgeB("1", "4", 13);
            g.AddEdgeB("2", "4", 3);
            g.AddEdgeB("2", "3", 12);
            g.AddEdgeB("3", "4", 2);
            g.AddEdgeB("3", "5", 3);
            g.AddEdgeB("3", "6", 20);
            g.AddEdgeB("4", "5", 14);
            g.AddEdgeB("5", "6", 1);
            double cost = g.FordFulkerson("1", "6");
            Console.WriteLine(cost);
            List<Edge> minimumCut = g.MinimumCut("1", "6");
            foreach(Edge e in minimumCut)
            {
                Console.Write(e + "\n");
            }
            Console.ReadKey();
        }
    }
}
