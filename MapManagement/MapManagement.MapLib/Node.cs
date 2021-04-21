namespace MapManagement.MapLib
{
    public abstract class Node
    {
        public virtual string GetNodeType()
        {
            return "Unknown type";
        }
    }
}