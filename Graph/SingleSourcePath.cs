using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.Graph
{
    public class SingleSourcePath
    {
        // Adjectancy Matrix for Graph Connectivity
        public List<Vertex>[] adjMatix = new List<Vertex>[10];

        public void PopulateGraph()
        {
            for (var i = 0; i < 10; i++)
            {
                var vertexList = new List<Vertex>();
                vertexList.Add(new Vertex(i));
                vertexList.Add(new Vertex(i + 1));

                adjMatix[i] = vertexList;
            }
        }

        public void ShowMatrix()
        {
            for (var i = 0; i < 10; i++)
            {
                foreach (var instance in adjMatix[i])
                {
                    Console.Write(instance.VertexId + ",");
                }
                Console.Write("\n");
            }
        }
    }
    // Vertex node for Graph
    public class Vertex
    {
        // Vertex Identifier
        public int VertexId { get; set; }

        // Flag to Track Vertex is Visited
        public bool IsVisited { get; set; }

        /// <summary>
        /// Ctor for Vertex
        /// </summary>
        /// <param name="value"></param>
        public Vertex(int value)
        {
            this.VertexId = value;
            this.IsVisited = false;
        }
    }
}
