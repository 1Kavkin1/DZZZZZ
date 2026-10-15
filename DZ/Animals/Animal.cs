namespace DZ.Animals
{
    // Базовий клас тварини
    public abstract class Animal
    {
        public string Name { get; }
        protected Animal(string name)
        {
            Name = name;
        }

        public override string ToString() => $"{GetType().Name} '{Name}'";
    }
}
