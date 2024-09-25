namespace Map
{
    public class NodePoint
    {
        public int x;
        public int y;

        public NodePoint(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public bool Equals(NodePoint np)
        {
            if (np == null) return false;
            if (this == np) return true;
            return x == np.x && y == np.y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this == obj) return true;
            if (obj.GetType() != typeof(NodePoint)) return false;
            return Equals((NodePoint)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}