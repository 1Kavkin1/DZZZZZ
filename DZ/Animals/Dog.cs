namespace DZ.Animals
{
    // Клас собаки
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        // порівняння за типом та ім'ям
        public static bool operator ==(Dog a, Dog b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Name == b.Name;
        }

        public static bool operator !=(Dog a, Dog b) => !(a == b);

        public override bool Equals(object obj) => obj is Dog other && this == other;
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;
    }
}
