namespace scholzova_sem_01.Graf
{
    internal interface IGraf<T>
    {

        List<Vertex<T>> Vertices { get; }
        List<List<Vertex<T>>> Cross { get; }
        int size { get; }

        void AddVertex(Vertex<T> vertex);
        void RemoveVertex(Vertex<T> vertex);
        Vertex<T> findVertexByName(T name);

    }
}
