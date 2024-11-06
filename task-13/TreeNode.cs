using System;
using System.Collections.Generic;

public class TreeNode<T> where T : IComparable<T>
{
    public TreeNode(T data)
    {
        Data = data;
    }

    //данные
    public T Data { get; set; }

    //левая ветка дерева
    public TreeNode<T> Left { get; set; }

    //правая ветка дерева
    public TreeNode<T> Right { get; set; }

    //рекурсивное добавление узла в дерево
    public void Insert(TreeNode<T> node)
    {
        if (Data.CompareTo(node.Data) > 0)
        {
            if (Left == null) Left = node;
            else Left.Insert(node);
        }
        else
        {
            if (Right == null) Right = node;
            else Right.Insert(node);
        }
    }

    //преобразование дерева в отсортированный массив
    public T[] Transform(List<T> elements = null)
    {
        if (elements == null) elements = new List<T>();

        Left?.Transform(elements);

        elements.Add(Data);

        Right?.Transform(elements);

        return elements.ToArray();
    }
}
