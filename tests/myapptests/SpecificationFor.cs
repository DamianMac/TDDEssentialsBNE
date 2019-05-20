namespace myapptests
{
    public abstract class SpecificationFor<T>
    {
        public T Subject { get; set; }
        public SpecificationFor()
        {
            Subject = Given();
            When();
        }

        public abstract T Given();
        public abstract void When();

        
    }
}