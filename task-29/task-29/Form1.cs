using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace task_29
{
    public class Edge
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Weight { get; set; }

        public Edge(int start, int end, int weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }
    }
    public partial class Form1 : Form
    {
        private List<Point> vertices = new List<Point>();
        private List<Edge> edges = new List<Edge>();

        private System.Windows.Forms.Button btnTarjan;
        private System.Windows.Forms.Button btnDinic;
        private System.Windows.Forms.Button btnClique;

        public Form1()
        {
            InitializeComponent();
            CreateGraph(); // Создаем граф
        }

        private void CreateGraph()
        {
            vertices.Add(new Point(50, 50));       // Вершина 0
            vertices.Add(new Point(300, 50));      // Вершина 1
            vertices.Add(new Point(450, 50));      // Вершина 2
            vertices.Add(new Point(50, 250));      // Вершина 3
            vertices.Add(new Point(300, 300));     // Вершина 4
            vertices.Add(new Point(450, 300));     // Вершина 5
            vertices.Add(new Point(250, 450));     // Вершина 6


            // Задаем рёбра и их веса
            edges.Add(new Edge(0, 1, 2));
            edges.Add(new Edge(1, 0, 2));
            edges.Add(new Edge(1, 2, 4));
            edges.Add(new Edge(0, 3, 7));
            edges.Add(new Edge(1, 3, 5));
            edges.Add(new Edge(1, 4, 1));
            edges.Add(new Edge(2, 5, 3));
            edges.Add(new Edge(3, 4, 6));
            edges.Add(new Edge(4, 5, 8));
            edges.Add(new Edge(4, 6, 9));
            edges.Add(new Edge(5, 6, 2));
            edges.Add(new Edge(0, 4, 10));
        }

        
        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Font vertexFont = new Font("Arial", 12); 

            // Отрисовка рёбер с весами
            foreach (var edge in edges)
            {
                g.DrawLine(Pens.Black, vertices[edge.Start], vertices[edge.End]);
                var weightPosition = new Point(
                    (vertices[edge.Start].X + vertices[edge.End].X) / 2,
                    (vertices[edge.Start].Y + vertices[edge.End].Y) / 2);
                g.DrawString(edge.Weight.ToString(), vertexFont, Brushes.Red, weightPosition);
            }

            // Отрисовка вершин
            for (int i = 0; i < vertices.Count; i++)
            {
                g.FillEllipse(Brushes.DarkSeaGreen, vertices[i].X - 10, vertices[i].Y - 10, 25, 25);
                g.DrawString(i.ToString(), vertexFont, Brushes.White, vertices[i].X - 5, vertices[i].Y - 5);
            }

            // Освобождаем ресурсы созданного шрифта
            vertexFont.Dispose();
        }

        private void btnTarjan_Click(object sender, EventArgs e)
        {
            var tarjan = new Tarjan();
            var graph = CreateAdjacencyList();
            var components = tarjan.FindStronglyConnectedComponents(graph);

            string results = string.Join(" ", components.Select(c => "{" + string.Join(", ", c) + "}"));
            resultLabel.Text = "Сильно связные компоненты:\n" + results;
        }

        private List<List<int>> CreateAdjacencyList()
        {
           
            int vertexCount = 7; 

            var adjacencyList = new List<List<int>>(vertexCount);
            for (int i = 0; i < vertexCount; i++)
            {
                adjacencyList.Add(new List<int>());
            }

            List<Edge> edges = new List<Edge>() {
                new Edge(0, 1, 2),
                new Edge(1, 0, 2),
                new Edge(1, 0, 2),
                new Edge(1, 2, 4),
                new Edge(0, 3, 7),
                new Edge(1, 3, 5),
                new Edge(1, 4, 1),
                new Edge(2, 5, 3),
                new Edge(3, 4, 6),
                new Edge(4, 5, 8),
                new Edge(4, 6, 9),
                new Edge(5, 6, 2),
                new Edge(0, 4, 10),
            };

            foreach (var edge in edges)
            {
                adjacencyList[edge.Start].Add(edge.End);
            }

            return adjacencyList;
        }

        private void btnDinic_Click(object sender, EventArgs e)
        {
            DinicsAlgorithm dinic = new DinicsAlgorithm(8);

            dinic.AddEdge(0, 1, 2);
            dinic.AddEdge(1, 0, 2);
            dinic.AddEdge(1, 2, 4);
            dinic.AddEdge(0, 3, 7);
            dinic.AddEdge(1, 3, 5);
            dinic.AddEdge(1, 4, 1);
            dinic.AddEdge(2, 5, 3);
            dinic.AddEdge(3, 4, 6);
            dinic.AddEdge(4, 5, 8);
            dinic.AddEdge(4, 6, 9);
            dinic.AddEdge(5, 6, 2);
            dinic.AddEdge(0, 4, 10);

            int maxFlow = dinic.MaxFlow(0, 6);
            resultLabel.Text = "Максимальный поток: " + maxFlow;
        }

     

        private void btnClique_Click(object sender, EventArgs e)
        {
            MaxClique clique = new MaxClique(8);

            clique.AddEdge(0, 1);
            clique.AddEdge(1, 0);
            clique.AddEdge(1, 2);
            clique.AddEdge(0, 3);
            clique.AddEdge(1, 3);
            clique.AddEdge(1, 4);
            clique.AddEdge(2, 5);
            clique.AddEdge(3, 4);
            clique.AddEdge(4, 5);
            clique.AddEdge(4, 6);
            clique.AddEdge(5, 6);
            clique.AddEdge(0, 4);

            var maxClique = clique.FindMaxClique();
            resultLabel.Text = "Максимальная клика: [" + string.Join(", ", maxClique) + "]";
        }


    }
}
