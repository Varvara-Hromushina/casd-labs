﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace task_24
{
    public enum NodeColor
    {
        Red,
        Black
    }
     
    public class RedBlackTreeNode<T> 
    {
        public T Key { get; set; }
        public T Value { get; set; }
        public NodeColor Color { get; set; }
        public RedBlackTreeNode<T> Left { get; set; }
        public RedBlackTreeNode<T> Right { get; set; }
        public RedBlackTreeNode<T> Parent { get; set; }

        public RedBlackTreeNode(T key, T value)
        {
            Key = key;
            Value = value;
            Color = NodeColor.Red; // Новый узел всегда красный
            Left = null;
            Right = null;
            Parent = null;
        }
    }

    public class RedBlackTree<T>:IEnumerable<RedBlackTreeNode<T>> where T : IComparable<T>
    {
        private readonly Comparer<T> comparator;
        private int size;
        public RedBlackTreeNode<T> root;

        public RedBlackTree()
        {
            root = null;
            size = 0;
        }

        public RedBlackTree(Comparer<T> comparer) : this()
        {
            comparator = comparer;
        }
 
        public void Insert(T key, T value)
        {
            var newNode = new RedBlackTreeNode<T>(key, value);
            root = InsertNode(root, newNode);
            FixViolations(newNode); 
            size++;
        }

        private RedBlackTreeNode<T> InsertNode(RedBlackTreeNode<T> root, RedBlackTreeNode<T> newNode)
        {
            if (root == null) return newNode;

            if (newNode.Key.CompareTo(root.Key) < 0)
            {
                root.Left = InsertNode(root.Left, newNode);
                root.Left.Parent = root;
            }
            else
            {
                root.Right = InsertNode(root.Right, newNode);
                root.Right.Parent = root;
            }
            return root;
        }

        private void FixViolations(RedBlackTreeNode<T> node)
        {
            while (node != null && node != root && node.Parent.Color == NodeColor.Red)
            {
                var parent = node.Parent;
                var grandparent = parent.Parent;

                // Случай A: родитель - левый сын
                if (parent == grandparent.Left)
                {
                    var uncle = grandparent.Right;

                    // Случай 1: дядя красный
                    if (uncle != null && uncle.Color == NodeColor.Red)
                    {
                        grandparent.Color = NodeColor.Red;
                        parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node = grandparent; // поднимаемся вверх
                    }
                    else
                    {
                        // Случай 2: мы находимся в правом ребенке
                        if (node == parent.Right)
                        {
                            RotateLeft(parent);
                            node = parent;
                            parent = node.Parent;
                        }

                        // Случай 3: мы находимся в левом ребенке
                        RotateRight(grandparent);
                        SwapColor(parent, grandparent);
                        node = parent;
                    }
                }
                else // Случай B: родитель - правый сын
                {
                    var uncle = grandparent.Left;

                    // Случай 1: дядя красный
                    if (uncle != null && uncle.Color == NodeColor.Red)
                    {
                        grandparent.Color = NodeColor.Red;
                        parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node = grandparent; // поднимаемся вверх
                    }
                    else
                    {
                        // Случай 2: мы находимся в левом ребенке
                        if (node == parent.Left)
                        {
                            RotateRight(parent);
                            node = parent;
                            parent = node.Parent;
                        }

                        // Случай 3: мы находимся в правом ребенке
                        RotateLeft(grandparent);
                        SwapColor(parent, grandparent);
                        node = parent;
                    }
                }
            }

            root.Color = NodeColor.Black; // Корень всегда черный
        }

        private void RotateLeft(RedBlackTreeNode<T> node)
        {
            var temp = node.Right;
            node.Right = temp.Left;

            if (node.Right != null)
                node.Right.Parent = node;

            temp.Parent = node.Parent;

            if (node.Parent == null)
            {
                root = temp; // Если node был корнем, меняем корень
            }
            else if (node == node.Parent.Left)
            {
                node.Parent.Left = temp;
            }
            else
            {
                node.Parent.Right = temp;
            }

            temp.Left = node;
            node.Parent = temp;
        }

        private void RotateRight(RedBlackTreeNode<T> node)
        {
            var temp = node.Left;
            node.Left = temp.Right;

            if (node.Left != null)
                node.Left.Parent = node;

            temp.Parent = node.Parent;

            if (node.Parent == null)
            {
                root = temp; // Если node был корнем, меняем корень
            }
            else if (node == node.Parent.Right)
            {
                node.Parent.Right = temp;
            }
            else
            {
                node.Parent.Left = temp;
            }

            temp.Right = node;
            node.Parent = temp;
        }

        private void SwapColor(RedBlackTreeNode<T> node1, RedBlackTreeNode<T> node2)
        {
            var tempColor = node1.Color;
            node1.Color = node2.Color;
            node2.Color = tempColor;
        }

        public T Search(T key)
        {
            var resultNode = SearchNode(root, key);
            if (resultNode != null)
            {
                return resultNode.Value;
            }
            throw new Exception("Key not found");
        }

        private RedBlackTreeNode<T> SearchNode(RedBlackTreeNode<T> node, T key)
        {
            if (node == null || key.CompareTo(node.Key) == 0)
                return node;

            if (key.CompareTo(node.Key) < 0)
                return SearchNode(node.Left, key);

            return SearchNode(node.Right, key);
        }

        public void Remove(T key)
        {
            RedBlackTreeNode<T> nodeToRemove = SearchNode(root, key);
            if (nodeToRemove == null)
                throw new Exception("Key not found");

            RedBlackTreeNode<T> nodeToFix = RemoveNode(nodeToRemove);
            if (nodeToFix != null)
            {
                FixDeletion(nodeToFix);
            }
            size--;
        }

        private RedBlackTreeNode<T> RemoveNode(RedBlackTreeNode<T> node)
        {
            RedBlackTreeNode<T> nodeToFix = null;

            if (node.Left == null || node.Right == null)
            {
                nodeToFix = node; // Узел, который нужно удалить или заменить.
            }
            else
            {
                // Найдем следующий узел по порядку (ин-ордер).
                nodeToFix = GetSuccessor(node);
                node.Key = nodeToFix.Key; // Заменяем ключ текущего узла на ключ-успешник.
            }

            RedBlackTreeNode<T> child = nodeToFix.Left != null ? nodeToFix.Left : nodeToFix.Right;

            if (child != null)
            {
                // Установим родительский узел для дочернего узла.
                child.Parent = nodeToFix.Parent;
            }

            if (nodeToFix.Parent == null)
            {
                root = child; // Если удаляемый узел - корень.
            }
            else if (nodeToFix == nodeToFix.Parent.Left)
            {
                nodeToFix.Parent.Left = child;
            }
            else
            {
                nodeToFix.Parent.Right = child;
            }

            if (nodeToFix.Color == NodeColor.Black)
            {
                // Необходимо выполнить балансировку, если удаленный узел был черным.
                return child;
            }

            return null;
        }

        private void FixDeletion(RedBlackTreeNode<T> node)
        {
            while (node != root && (node == null || node.Color == NodeColor.Black))
            {
                if (node == node.Parent.Left)
                {
                    RedBlackTreeNode<T> sibling = node.Parent.Right;

                    // Случай 1: брат красный
                    if (sibling != null && sibling.Color == NodeColor.Red)
                    {
                        sibling.Color = NodeColor.Black;
                        node.Parent.Color = NodeColor.Red;
                        RotateLeft(node.Parent);
                        sibling = node.Parent.Right;
                    }

                    // Случай 2: оба брат и его дети черные
                    if ((sibling.Left == null || sibling.Left.Color == NodeColor.Black) &&
                        (sibling.Right == null || sibling.Right.Color == NodeColor.Black))
                    {
                        sibling.Color = NodeColor.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        // Случай 3: левый сын брата черный и правый красный
                        if (sibling.Right == null || sibling.Right.Color == NodeColor.Black)
                        {
                            if (sibling.Left != null)
                            {
                                sibling.Left.Color = NodeColor.Black;
                            }
                            sibling.Color = NodeColor.Red;
                            RotateRight(sibling);
                            sibling = node.Parent.Right;
                        }

                        // Случай 4: брат черный, его правый сын красный
                        sibling.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.Black;
                        if (sibling.Right != null)
                        {
                            sibling.Right.Color = NodeColor.Black;
                        }
                        RotateLeft(node.Parent);
                        node = root; // Завершение работы
                    }
                }
                else
                {
                    // Аналогичные действия, если узел - правый сын
                    RedBlackTreeNode<T> sibling = node.Parent.Left;

                    if (sibling != null && sibling.Color == NodeColor.Red)
                    {
                        sibling.Color = NodeColor.Black;
                        node.Parent.Color = NodeColor.Red;
                        RotateRight(node.Parent);
                        sibling = node.Parent.Left;
                    }

                    if ((sibling.Right == null || sibling.Right.Color == NodeColor.Black) &&
                        (sibling.Left == null || sibling.Left.Color == NodeColor.Black))
                    {
                        sibling.Color = NodeColor.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.Left == null || sibling.Left.Color == NodeColor.Black)
                        {
                            if (sibling.Right != null)
                            {
                                sibling.Right.Color = NodeColor.Black;
                            }
                            sibling.Color = NodeColor.Red;
                            RotateLeft(sibling);
                            sibling = node.Parent.Left;
                        }

                        sibling.Color = node.Parent.Color;
                        node.Parent.Color = NodeColor.Black;
                        if (sibling.Left != null)
                        {
                            sibling.Left.Color = NodeColor.Black;
                        }
                        RotateRight(node.Parent);
                        node = root; // Завершение работы
                    }
                }
            }

            if (node != null)
            {
                node.Color = NodeColor.Black; // Переключаем цвет на черный
            }
        }

        // Находим следующий узел
        private RedBlackTreeNode<T> GetSuccessor(RedBlackTreeNode<T> node)
        {
            if (node.Right != null)
            {
                // Если у узла есть правый дочерний узел, потомок по порядку - самый левый узел правого поддерева.
                RedBlackTreeNode<T> temp = node.Right;
                while (temp.Left != null)
                {
                    temp = temp.Left;
                }
                return temp;
            }
            else
            {
                // Если у узла нет правого потомка, поднимаемся по дереву, пока не найдем встревоженного предка.
                RedBlackTreeNode<T> parent = node.Parent;
                while (parent != null && node == parent.Right)
                {
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        public int Size()
        {
            return size;
        }

        public IEnumerable<RedBlackTreeNode<T>> TraverseInOrder(RedBlackTreeNode<T> node)
        {
            if (node != null)
            {
                foreach (var leftValue in TraverseInOrder(node.Left))
                    yield return leftValue;

                yield return node;

                foreach (var rightValue in TraverseInOrder(node.Right))
                    yield return rightValue;
            }
        }

        public IEnumerable<RedBlackTreeNode<T>> ReverseInOrder(RedBlackTreeNode<T> node)
        {
            if (node != null)
            {
                foreach (var leftValue in ReverseInOrder(node.Right))
                    yield return leftValue;

                yield return node;

                foreach (var rightValue in ReverseInOrder(node.Left))
                    yield return rightValue;
            }
        }

        public IEnumerator<RedBlackTreeNode<T>> GetEnumerator()
        {
            return TraverseInOrder(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool Contains(T value)
        {
            if (root == null) return false;
            else
            {
                var currentNode = root;
                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(value)) return true;

                    if (value.CompareTo(currentNode.Value) > 0 && currentNode.Right != null) currentNode = currentNode.Right;
                    else if (value.CompareTo(currentNode.Value) < 0 && currentNode.Left != null) currentNode = currentNode.Left;
                    else return false;
                }
                return false;
            }
        }

        public bool IsEmpty() { return size == 0; }


        // Метод для печати дерева в порядке возрастания 
        public void InOrderTraversal()
        {
            InOrder(root);
        }

        private void InOrder(RedBlackTreeNode<T> node)
        {
            if (node == null) return;

            InOrder(node.Left);
            Console.WriteLine($"Ключ: {node.Key}, Значение: {node.Value} (Цвет: {node.Color})");
            InOrder(node.Right);
        }
    }

    
}
