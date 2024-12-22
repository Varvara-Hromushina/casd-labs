using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace task_29
{
    public class Tarjan
    {
        private int index; // Текущий индекс для индексации вершин
        private int[] indices; // Массив для хранения индексов вершин
        private int[] lowLink; // Массив для хранения низких связей
        private Stack<int> stack; // Стек для хранения вершин
        private HashSet<int> onStack; // Множество для проверки, находятся ли вершины в стеке
        private List<List<int>> stronglyConnectedComponents; // Список для хранения SCC

        public List<List<int>> FindStronglyConnectedComponents(List<List<int>> graph)
        {
            int vertexCount = graph.Count;
            indices = new int[vertexCount];
            lowLink = new int[vertexCount];
            stack = new Stack<int>();
            onStack = new HashSet<int>();
            stronglyConnectedComponents = new List<List<int>>();
            index = 0;

            // Проходим через все вершины графа
            for (int i = 0; i < vertexCount; i++)
            {
                if (indices[i] == 0) // Если не посетили
                {
                    StrongConnect(i, graph);
                }
            }

            return stronglyConnectedComponents; // Возвращаем список сильно связных компонентов
        }

        private void StrongConnect(int v, List<List<int>> graph)
        {
            // Присваиваем индекс и низкую связь
            indices[v] = lowLink[v] = ++index;
            stack.Push(v);
            onStack.Add(v);

            // Проходим по всем соседям
            foreach (var neighbor in graph[v])
            {
                if (indices[neighbor] == 0) // Если соседа не посетили
                {
                    StrongConnect(neighbor, graph);
                    lowLink[v] = Math.Min(lowLink[v], lowLink[neighbor]); // Обновляем lowLink
                }
                else if (onStack.Contains(neighbor)) // Если сосед в стеке
                {
                    lowLink[v] = Math.Min(lowLink[v], indices[neighbor]); // Обновляем lowLink
                }
            }

            // Если v является корневым узлом, извлекаем стек и создаем SCC
            if (lowLink[v] == indices[v])
            {
                var component = new List<int>();
                int w;
                do
                {
                    w = stack.Pop();
                    onStack.Remove(w);
                    component.Add(w);
                } while (w != v);

                stronglyConnectedComponents.Add(component); // Добавляем компонент в список SCC
            }
        }
    }



    // 11) Построение максимального потока в транспортной сети. Алгоритм Диница. 
    class DinicsAlgorithm
    {
        private int[] level; // уровне вершины в графе
        private int[] pointer; // указатель на следующее необработанное ребро
        private List<int>[] adjList; // список смежности
        private int[,] network; // матрица пропускных способностей
        private int INF = int.MaxValue;
        private int[,] flow; // матрица фактических потоков
        private List<List<int>> paths; // Список для хранения найденных путей

        public DinicsAlgorithm(int n)
        {
            adjList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
            }
            level = new int[n];
            pointer = new int[n];
            network = new int[n, n]; // Инициализация матрицы пропускных способностей
            flow = new int[n, n]; // Инициализация матрицы фактических потоков
            paths = new List<List<int>>(); // Инициализация списка путей
        }


        // Добавление ребра с заданной пропускной способностью для ориентированного графа
        public void AddEdge(int u, int v, int capacity)
        {
            adjList[u].Add(v); // добавляем ориентированное ребро u -> v
            network[u, v] += capacity; // добавляем пропускную способность
        }

        // Поиск увеличивающего пути с помощью обхода в ширину
        private bool BFS(int source, int sink)
        {
            // Устанавливаем уровень -1 для всех вершин
            for (int i = 0; i < level.Length; i++)
            {
                level[i] = -1;
            }
            level[source] = 0; // Устанавливаем уровень источника равным 0
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in adjList[u])
                {
                    // Если v еще не был посещен и есть доступный поток
                    if (level[v] < 0 && network[u, v] > 0)
                    {
                        level[v] = level[u] + 1;
                        queue.Enqueue(v);
                    }
                }
            }
            return level[sink] >= 0; // Если уровень стока >= 0, значит путь найден
        }


        //  DFS (в глубину)
        private int DFS(int u, int sink, int flowLimit, List<int> currentPath)
        {
            if (u == sink)
            {
                paths.Add(new List<int>(currentPath)); // Сохранить текущий путь
                return flowLimit; // Если достигли стока, возвращаем поток
            }

            for (; pointer[u] < adjList[u].Count; pointer[u]++)
            {
                int v = adjList[u][pointer[u]];
                // Если v находится на следующем уровне и есть доступный поток
                if (level[v] == level[u] + 1 && network[u, v] > 0)
                {
                    currentPath.Add(v); // Добавляем вершину к пути
                    int pushedFlow = DFS(v, sink, Math.Min(flowLimit, network[u, v]), currentPath);
                    if (pushedFlow > 0)
                    {
                        network[u, v] -= pushedFlow; // Уменьшаем доступный поток
                        flow[u, v] += pushedFlow; // Обновляем фактический поток
                        currentPath.RemoveAt(currentPath.Count - 1); // Удаляем текущую вершину из пути
                        return pushedFlow; // Возвращаем текущий поток
                    }
                    currentPath.RemoveAt(currentPath.Count - 1); // Удаляем текущую вершину из пути, если не удалось
                }
            }

            return 0; // Возвращаем 0, если нет блокирующего потока
        }

        // Метод вычисления максимального потока
        public int MaxFlow(int source, int sink)
        {
            int maxFlow = 0;
            while (BFS(source, sink)) // Пока существует путь
            {
                // Устанавливаем указатель на следующее ребро в 0
                for (int i = 0; i < pointer.Length; i++)
                {
                    pointer[i] = 0;
                }
                int flow;

                // Определение потоков и вывод путей
                List<int> currentPath = new List<int> { source };
                while ((flow = DFS(source, sink, INF, currentPath)) > 0) // Пытаемся найти поток
                {
                    maxFlow += flow; // Увеличиваем максимальный поток
                                     // Здесь вы можете вывести пути, если нужно:
                    Console.WriteLine("Найдены пути:");
                    foreach (var path in paths)
                    {
                        Console.WriteLine(string.Join(" -> ", path));
                    }
                }
            }

            return maxFlow; // Возвращаем максимальный поток
        }
    }


    // 14) Построение максимальной клики. Эвристический алгоритм «слияния» клик. 
    class MaxClique
    {
        private List<List<int>> adjList;

        public MaxClique(int vertices)
        {
            adjList = new List<List<int>>(vertices);
            for (int i = 0; i < vertices; i++)
            {
                adjList.Add(new List<int>());
            }
        }

        // Добавляем ребро между вершинами u и v (недиректная связь)
        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
            adjList[v].Add(u); // Добавляем обратное ребро, так как мы рассматриваем неориентированный граф
        }

        public List<int> FindMaxClique()
        {
            int n = adjList.Count;
            List<int> maxClique = new List<int>();
            List<int> currentClique = new List<int>();

            // Начнем с каждой вершины, и будем пытаться строить клик
            for (int i = 0; i < n; i++)
            {
                currentClique.Clear();
                currentClique.Add(i);
                for (int j = i + 1; j < n; j++)
                {
                    if (CanAddToClique(currentClique, j))
                    {
                        currentClique.Add(j);
                    }
                }
                if (currentClique.Count > maxClique.Count)
                {
                    maxClique = new List<int>(currentClique);
                }
            }

            return maxClique;
        }

        private bool CanAddToClique(List<int> clique, int vertex)
        {
            // Проверяем, соединена ли вершина с каждой из вершин в текущей клике (должны быть рёбра в обе стороны)
            foreach (var v in clique)
            {
                if (!adjList[v].Contains(vertex))
                {
                    return false; // Если нет соединения, не можем добавить вершину
                }
            }
            return true; // Вершина может быть добавлена
        }
    }
}

