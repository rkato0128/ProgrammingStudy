using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    // 그래프 학습

    public class Graph<T>
    {
        private List<GraphVertex<T>> vertexList = new List<GraphVertex<T>>();

        public void AddVetices (List<GraphVertex<T>> inputList)
        {
            vertexList = inputList;
        }

        public void PrintAllVerticesInfo()
        {
            foreach (GraphVertex<T> vertex in vertexList)
            {
                vertex.PrintNeighborInfo();
            }
        }

        public void BFS(GraphVertex<T> root)
        {
            Queue<GraphVertex<T>> queue = new Queue<GraphVertex<T>>();

            queue.Enqueue(root);
            root.isVisted = true;

            while (queue.Count != 0)
            {
                GraphVertex<T> node;
                List<GraphVertex<T>> neighborList;

                node = queue.Dequeue();
                node.PrintData();
                neighborList = node.getNeighborList();

                foreach (GraphVertex<T> neighbor in neighborList)
                {
                    if (!neighbor.isVisted) 
                    {
                        neighbor.isVisted = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }

    public class GraphVertex<T>
    {
        public List<GraphVertex<T>> neighborList = new List<GraphVertex<T>>();
        List<int> weightList = new List<int>();

        public bool isVisted = false;
        T data;

        public GraphVertex(T input)
        {
            data = input;
        }

        public void PrintData()
        {
            Console.WriteLine(data.ToString());
        }

        public List<GraphVertex<T>> getNeighborList()
        {
            return neighborList;
        }

        public void AddVertex(GraphVertex<T> neighbor, int weight, bool isOneWay = true)
        {
            neighborList.Add(neighbor);
            weightList.Add(weight);

            if (!isOneWay)
            {
                neighbor.AddVertex(this, weight);
            }
        }

        public void PrintNeighborInfo()
        {
            Console.WriteLine(data.ToString() + "의 이웃나라들");

            for (int i = 0; i < neighborList.Count(); i++)
            {
                Console.WriteLine(neighborList[i].data.ToString() + ", 거리 : " + weightList[i].ToString());
            }
        }
    }

    class GraphExample
    {
        static void Main()
        {
            Graph<string> countries = new Graph<string>();

            GraphVertex<string> korea = new GraphVertex<string>("Korea");
            GraphVertex<string> japan = new GraphVertex<string>("Japan");
            GraphVertex<string> china = new GraphVertex<string>("China");
            GraphVertex<string> usa = new GraphVertex<string>("USA");
            GraphVertex<string> france = new GraphVertex<string>("France");

            korea.AddVertex(japan, 1, false);
            korea.AddVertex(china, 1, false);

            japan.AddVertex(china, 2, false);
            japan.AddVertex(usa, 6, false);

            china.AddVertex(france, 4, false);

            france.AddVertex(usa, 4, false);

            List<GraphVertex<string>> vertexList = new List<GraphVertex<string>>() { korea, japan, china, france, usa };

            countries.AddVetices(vertexList);
            //countries.PrintAllVerticesInfo();
            countries.BFS(korea);
        }
    }
}
