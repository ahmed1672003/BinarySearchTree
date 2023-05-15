using System.Security;

namespace ConsoleApp1.BinarySeerchTreeImplementation
{
    public class BinarySearchTree
    {
        public Node Root { get; set; }
        public BinarySearchTree() => Root = null;

        #region Insert
        public void Insert(int data) => Root = InsertNode(Root, data);
        private Node InsertNode(Node current, int data)
        {
            if (current is null)
            {
                current = new Node(data);
            }
            else if (data < current.Data)
            {
                current.Left = InsertNode(current.Left, data);
            }
            else if (data > current.Data)
            {
                current.Right = InsertNode(current.Right, data);
            }
            return current;
        }
        #endregion 

        #region Search
        public bool Search(int data) => SearchNode(Root, data);
        private bool SearchNode(Node current, int data)
        {
            if (current is null)
            {
                return false;
            }
            else if (current.Data == data)
            {
                return true;
            }
            else if (data < current.Data)
            {
                return SearchNode(current.Left, data);
            }
            else
            {
                return SearchNode(current.Right, data);
            }
        }
        public bool IsEmpty() => Root is null;
        #endregion

        #region PreOrderTraversal
        public void PreOrder() => PreOrderTraversal(Root);
        private void PreOrderTraversal(Node current)
        {
            if (current is not null)
            {
                Console.Write(current.Data + " ");
                if (current.Left is not null)
                    PreOrderTraversal(current.Left);
                if (current.Right is not null)
                    PreOrderTraversal(current.Right);
            }
        }

        #endregion

        #region InOrderTraversal
        public void InOrder() => InOrderTraversal(Root);
        private void InOrderTraversal(Node current)
        {
            if (current is not null)
            {
                if (current.Left is not null)
                    InOrderTraversal(current.Left);
                Console.Write(current.Data + " ");
                if (current.Right is not null)
                    InOrderTraversal(current.Right);
            }
        }
        #endregion

        #region PostOrderTraversal 
        public void PostOrder() => PostOrderTraversal(Root);
        private void PostOrderTraversal(Node current)
        {
            if (current is not null)
            {
                if (current.Left is not null)
                    PostOrderTraversal(current.Left);
                if (current.Right is not null)
                    PostOrderTraversal(current.Right);
                Console.Write(current.Data + " ");
            }
        }
        #endregion

        #region Delete Node By Find Maximum
        private Node GetMaxNode(Node node)
        {
            Node current = node;
            while (current.Right is not null) current = current.Right;
            return current;
        }
        public void Remove(int data) => Root = RemoveNode(Root, data);
        private Node RemoveNode(Node current, int data)
        {
            if (current is null) return null;
            else if (data < current.Data) current.Left = RemoveNode(current.Left, data);
            else if (data > current.Data) current.Right = RemoveNode(current.Right, data);
            else
            {
                if (current.Left is null && current.Right is null) current = null;
                else if (current.Left is null) current = current.Left;
                else if (current.Right is null) current = current.Right;
                else
                {
                    Node temp = GetMaxNode(current.Left);
                    current.Data = temp.Data;
                    current.Left = RemoveNode(current.Left, temp.Data);
                }
            }
            return current;
        }
        #endregion

        #region Delete Node By Find Minemum 
        public void Delete(int data) => Root = DeleteNode(Root, data);
        private Node DeleteNode(Node current, int data)
        {
            if (current is null)
            {
                return null;
            }
            else if (data < current.Data)
            {
                current.Left = DeleteNode(current.Left, data);
            }
            else if (data > current.Data)
            {
                current.Right = DeleteNode(current.Right, data);
            }
            else
            {
                // found the node to delete
                if (current.Left is null && current.Right is null)
                {
                    current = null;
                }
                else if (current.Left == null)
                {
                    current = current.Right;
                }
                else if (current.Right == null)
                {
                    current = current.Left;
                }
                else
                {
                    Node temp = GetMinNode(current.Right);
                    current.Data = temp.Data;
                    current.Right = DeleteNode(current.Right, temp.Data);
                }
            }
            return current;
        }
        private Node GetMinNode(Node node)
        {
            Node current = node;
            while (current.Left is not null) current = current.Left;
            return current;
        }
        #endregion
    }
}






