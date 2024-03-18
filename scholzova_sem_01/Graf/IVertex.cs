namespace scholzova_sem_01.Graf
{
    internal interface IVertex<T>
    {
        T Name { get; set; }
        List<Edge<T>> Edges { get; set; }
    }
}
