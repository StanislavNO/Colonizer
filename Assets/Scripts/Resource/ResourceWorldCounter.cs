namespace Assets.Scripts
{
    public static class ResourceWorldCounter
    {
        public static int Count { get; private set; }

        public static void AddResource() => Count++;

        public static void RemoveResource() => Count--;
    }
}