namespace scholzova_sem_01.Graf
{
    internal interface IEdge<T>
    {
        T Name { get; set; }
        Vertex<T> StartVertex { get; set; }
        Vertex<T> EndVertex { get; set; }
    }
}
