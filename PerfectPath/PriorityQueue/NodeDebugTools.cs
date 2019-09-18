using System.Text;
using System.Collections.Generic;

namespace PerfectPath.PriorityQueue
{
    public class NodeDebugTools<T>
    {
        public static string Stringify(Node<T> node)
        {
            var stringbuilder = new StringBuilder();

            stringbuilder.AppendLine(); // nunit starts indented in VSCode console

            if (node == null)
            {
                stringbuilder.AppendLine("[ empty ]");
                return stringbuilder.ToString();
            }
            Visualize(node, string.Empty, stringbuilder);

            stringbuilder.AppendLine();
            stringbuilder.AppendLine();

            return stringbuilder.ToString();
        }

        public static IEnumerable<Node<T>> IterateSiblings(Node<T> node)
        {
            var start = node;
            var next = node;
            do
            {
                yield return next;
                next = next.Next;
            }
            while (next != start);

            yield break;
        }

        public static IEnumerable<(Node<T> parent, Node<T> child)> IterateUpParents(Node<T> parent, Node<T> child = null)
        {
            var p = parent;
            var c = child ?? parent.Child;
            do
            {
                yield return (p, c);
                c = parent;
                p = parent.Parent;
            }
            while (p != null);
            yield break;
        }

        // https://rosettacode.org/wiki/Fibonacci_heap#Kotlin
        private static void Visualize(Node<T> node, string prepend, StringBuilder builder)
        {
            var linePrefix = "│ ";
            var currentNode = node;
            while (true)
            {
                if (currentNode.Next != node)
                {
                    builder.Append($"{prepend}├─");
                }
                else
                {
                    builder.Append($"{prepend}└─");
                    linePrefix = "  ";
                }
                if (currentNode.Child == null)
                {
                    builder.AppendLine($"╴ {currentNode.Value}");
                }
                else
                {
                    builder.AppendLine($"┐ {currentNode.Value}");
                    Visualize(currentNode.Child, prepend + linePrefix, builder);
                }
                if (currentNode.Next == node)
                {
                    break;
                }
                currentNode = currentNode.Next;
            }
        }
    }
}