using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxo.DataStructure
{
    class Node
    {
        #region Propriedades

        /// <summary>
        /// O nome do nó dentro do grafo.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A informação adicional armazenada no nó.
        /// </summary>
        public object Info { get; set; }
        /// <summary>
        /// A lista de arcos associada ao nó.
        /// </summary>
        public List<Edge> Edges { get; private set; }

        public int Nivel { get; set; }

        public int HeuristicValue { get; private set; }

        public Node Parent { get; set; }

        public bool Visited { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria um novo nó.
        /// </summary>
        public Node()
        {
            this.Edges = new List<Edge>();
            this.Visited = false;
        }

        /// <summary>
        /// Cria um novo nó.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <param name="info">A informação armazenada no nó.</param>
        public Node(string name, object info, int nivel) : this()
        {
            this.Name = name;
            this.Info = info;
            this.Nivel = nivel;
        }
        public Node(string name) : this(name, null, 0)
        {
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino e custo de acordo com os parâmetros.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        public void AddEdge(Node to)
        {
            AddEdge(to, 0);
        }

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino e custo de acordo com os parâmetros.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        /// <param name="cost">O custo associado ao arco.</param>
        public void AddEdge(Node to, double cost)
        {
            this.Edges.Add(new Edge(this, to, cost));
        }

        public void Heuristic()
        {
            this.HeuristicValue = HammingDistance((int[])this.Info) * ManhattanDistance((int[])this.Info) + this.Nivel;
        }

        private int ManhattanDistance(int[] v)
        {
            int distance = 0;
            int size = (int)Math.Sqrt(v.Length);
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] != 0)
                {
                    int currentY = i / size;
                    int currentX = i % size;
                    int targetY = v[i] / size;
                    int targetX = v[i] % size;
                    distance += Math.Abs(targetX - currentX) + Math.Abs(targetY - currentY);
                }
            }
            return distance;
        }

        private int HammingDistance(int[] v)
        {
            int distance = 0;
            for (int i = 0; i < v.Length; i++)
                if (v[i] != i)
                    distance++;
            return distance;
        }

        #endregion

        #region Métodos Sobrescritos

        /// <summary>
        /// Apresenta a visualização do objeto em formato texto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.Info != null)
            {
                return String.Format("{0}({1})", this.Name, this.Info);
            }
            return this.Name;
        }

        #endregion

    }
}

