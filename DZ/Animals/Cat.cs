namespace DZ.Animals
{
    // Клас кота
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public static bool operator ==(Cat a, Cat b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Name == b.Name;
        }

        public static bool operator !=(Cat a, Cat b) => !(a == b);

        public override bool Equals(object obj) => obj is Cat other && this == other;
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;
    }
}
