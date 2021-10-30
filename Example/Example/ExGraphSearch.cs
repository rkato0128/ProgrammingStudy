using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    // 그래프 예제 - 넓이우선탐색 및 최단경로 탐색

    class Route
    {
        List<MetroVertex> routeList = new List<MetroVertex>();
        int routeWeight;
        MetroVertex station;

        public Route(MetroVertex vertex, List<MetroVertex> preRoute, int weight = 0)
        {
            station = vertex;
            routeWeight = weight;

            foreach (MetroVertex temp in preRoute)
            {
                routeList.Add(temp);
            }

            routeList.Add(vertex);

            //routeList = preRoute; // 데이터 값이 아닌 메모리 주소값을 가져옴
        }

        public void SearchRoute(MetroVertex endVertex)
        {
            if (this.station == endVertex) // 출발역과 도착역이 같을 경우 처리
            {
                Console.WriteLine("출발역과 도착역이 같습니다.");
                return;
            }

            int fastRouteWeight = 10000;
            List<MetroVertex> fastRoutes = new List<MetroVertex>();

            Queue<Route> routeQueue = new Queue<Route>();
            routeQueue.Enqueue(this);

            while(routeQueue.Count != 0)
            {
                Route route = routeQueue.Dequeue();

                for (int i = 0; i < route.station.GetNeighborList().Count; i++) //.GetNeighborList 같은 부분 그냥 get; set; 으로?
                {
                    bool isVisted = false;

                    foreach (MetroVertex vertex in route.routeList) // 왔던 경로인지 확인
                    {
                        if (route.station.GetNeighborList()[i] == vertex)
                        {
                            isVisted = true;
                            break;
                        }
                    }

                    if (!isVisted)
                    {
                        Route newRoute = new Route(route.station.GetNeighborList()[i], route.routeList, route.routeWeight + route.station.GetEdgeWeights()[i]);

                        // 경로 확인용
                        Console.Write("\n");
                        foreach (MetroVertex temp in newRoute.routeList)
                        {
                            Console.Write(" - " + temp.GetStationName());
                        }

                        if (newRoute.station == endVertex)
                        {
                            if (newRoute.routeWeight < fastRouteWeight)
                            {
                                fastRouteWeight = newRoute.routeWeight;
                                fastRoutes = newRoute.routeList;
                            }
                        }
                        else
                        {
                            routeQueue.Enqueue(newRoute);
                        }
                    }
                }
            }

            Console.WriteLine("\n탐색 완료");

            foreach (MetroVertex station in fastRoutes)
            {
                Console.Write(station.GetStationName() + " ");
            }

            Console.WriteLine("\n거리 : " + fastRouteWeight);
        }

    }

    class MetroGraph
    {
        public List<MetroVertex> VerticesList = new List<MetroVertex>();

        public MetroGraph(List<MetroVertex> vertices)
        {
            VerticesList = vertices;
        }

        public void SearchRoute(MetroVertex start, MetroVertex end)
        {
            List<MetroVertex> tempList = new List<MetroVertex>();

            Route way = new Route(start, tempList);
            way.SearchRoute(end);
        }

        // 이전 시도
        void SearchWayLegacy(MetroVertex start, MetroVertex end)
        {
            int stationCount = 0;

            Queue<MetroVertex> searchQueue = new Queue<MetroVertex>();
            List<List<MetroVertex>> routeList = new List<List<MetroVertex>>();
            List<MetroVertex> routeOrigin = new List<MetroVertex>();

            routeList.Add(routeOrigin);
            routeOrigin.Add(start);
            searchQueue.Enqueue(start);

            List<MetroVertex> stationVisited = new List<MetroVertex>();

            // 그래프 전체 넓이우선탐색
            while (searchQueue.Count != 0)
            {
                MetroVertex temp = searchQueue.Dequeue();
                stationVisited.Add(temp);

                if (temp == end)
                {
                    break;
                }

                // GetNeighborList() 같이 함수화한 반환값은 객체가 참조하고 있는 메모리에 접근해서 가져오는건가?
                for (int i = 0; i < temp.GetNeighborList().Count; i++)
                {
                    bool isVisted = false; // for문 안 선언보다 반복문 바깥에서 선언한 뒤 값 변경만 하는게 나을까

                    foreach (MetroVertex check in stationVisited)
                    {
                        if (check == temp.GetNeighborList()[i])
                        {
                            isVisted = true;
                            break;
                        }
                    }

                    if (isVisted == false)
                    {
                        searchQueue.Enqueue(temp.GetNeighborList()[i]);
                    }
                }
            }
        }
    }

    class MetroVertex
    {
        private List<MetroVertex> neighborVertices = new List<MetroVertex>();
        private List<int> edgeWeights = new List<int>();

        private string stationName;

        public MetroVertex(string name)
        {
            stationName = name;
        }

        public void AddNeighbor(MetroVertex neighbor, int weight, bool isOneWay = true)
        {
            neighborVertices.Add(neighbor);
            edgeWeights.Add(weight);

            if (!isOneWay)
            {
                neighbor.neighborVertices.Add(this);
                neighbor.edgeWeights.Add(weight);
            }
        }

        public string GetStationName() // 이런 부분 get; set; 프로퍼티로 처리?
        {
            return stationName;
        }

        public List<MetroVertex> GetNeighborList()
        {
            return neighborVertices;
        }

        public List<int> GetEdgeWeights()
        { 
            return edgeWeights;
        }
    }

    class ExGraphSearch
    {
        static void Main()
        {
            MetroVertex chungjeongno = new MetroVertex("충정로");
            MetroVertex cityHall = new MetroVertex("시청");
            MetroVertex seoulStation = new MetroVertex("서울역");
            MetroVertex chungmuro = new MetroVertex("충무로");
            MetroVertex gongdeok = new MetroVertex("공덕");
            MetroVertex yaksu = new MetroVertex("약수");
            MetroVertex noryangjin = new MetroVertex("노량진");
            MetroVertex yeouido = new MetroVertex("여의도");

            List<MetroVertex> stationList = new List<MetroVertex>()
            {
                chungjeongno, cityHall, seoulStation, chungmuro, gongdeok, yaksu, noryangjin, yeouido
            };

            MetroGraph metro = new MetroGraph(stationList);

            chungjeongno.AddNeighbor(cityHall, 1, false);
            chungjeongno.AddNeighbor(gongdeok, 2, false);

            cityHall.AddNeighbor(seoulStation, 1, false);

            seoulStation.AddNeighbor(gongdeok, 1, false);
            seoulStation.AddNeighbor(noryangjin, 3, false);
            seoulStation.AddNeighbor(chungmuro, 3, false);

            chungmuro.AddNeighbor(yaksu, 2, false);

            gongdeok.AddNeighbor(yeouido, 3, false);
            gongdeok.AddNeighbor(yaksu, 7, false);

            yeouido.AddNeighbor(noryangjin, 2, false);

            // 경로 탐색
            metro.SearchRoute(gongdeok, gongdeok);
        }
    }
}
