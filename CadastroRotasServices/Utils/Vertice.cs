public class Vertice
{
    public Vertice(string id)
    {
        Id = id;
    }
    public string Id { get; private set; }
    public Dictionary<Vertice, int> Adjacentes { get; private set; } = new Dictionary<Vertice, int>();
    public int Distancia { get; set; } = int.MaxValue;
    public bool Visitado { get; set; } = false;
    public Vertice VerticeAnterior { get; set; }

    public void AdicionarAdjacente(Vertice destino, int peso)
    {
        Adjacentes[destino] = peso;
    }
}