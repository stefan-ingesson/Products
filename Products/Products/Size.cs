namespace Products
{
    public abstract class Size
    {
        public virtual string GetAsText() {
            return "";
        }

        public virtual int GetAsInt() { return 1; }
    }
}