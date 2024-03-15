using CadastroRotasDomain.Entities;
public class Grafo 
{
    public SortedDictionary<string, Vertice> Vertices { get; private set; } = new SortedDictionary<string, Vertice>();
    private bool Direcionado;

    public Grafo(bool direcionado)
    {
        Direcionado = direcionado;
    }

    public void InicializarFonteUnica(Vertice fonte)
    {
        foreach (var vertice in Vertices.Values)
        {
            vertice.Distancia = int.MaxValue;
            vertice.VerticeAnterior = null;
        }        
        if (Vertices.ContainsKey(fonte.Id))
        {
            Vertices[fonte.Id].Distancia = 0;
        }
    }  

    public void InserirAresta(List<Rota> rotas)
    {
        foreach (var rota in rotas)
        {
            if (!Vertices.ContainsKey(rota.Origem))
            {
                Vertices[rota.Origem] = new Vertice(rota.Origem);
            }

            if (!Vertices.ContainsKey(rota.Destino))
            {
                Vertices[rota.Destino] = new Vertice(rota.Destino);
            }

            Vertices[rota.Origem].AdicionarAdjacente(Vertices[rota.Destino], (int)rota.Custo);

            if (!Direcionado)
            {
                Vertices[rota.Destino].AdicionarAdjacente(Vertices[rota.Origem], (int)rota.Custo);
            }
        }
    }

    public Vertice ExtrairVerticeComMenorDistancia(SortedDictionary<string, Vertice> verticesNaoVisitados)
    {
        var verticeComMenorDistancia = verticesNaoVisitados.Values.Where(v => !v.Visitado).MinBy(v => v.Distancia);
        verticesNaoVisitados.Remove(verticeComMenorDistancia.Id);
        return verticeComMenorDistancia;
    }

    public void Relaxar(Vertice verticeAtual, Vertice verticeAdjacente, int pesoAresta)
    {
        if (verticeAdjacente.Distancia > verticeAtual.Distancia + pesoAresta)
        {
            verticeAdjacente.Distancia = verticeAtual.Distancia + pesoAresta;
            verticeAdjacente.VerticeAnterior = verticeAtual;
        }
    }

    public void Dijkstra(Vertice fonte)
    {
        InicializarFonteUnica(fonte);
        var verticesNaoVisitados = new SortedDictionary<string, Vertice>(Vertices);
        while (verticesNaoVisitados.Any())
        {
            var verticeAtual = ExtrairVerticeComMenorDistancia(verticesNaoVisitados);
            verticeAtual.Visitado = true;
            foreach (var adjacente in verticeAtual.Adjacentes)
            {
                var verticeAdjacente = adjacente.Key;
                if (!verticeAdjacente.Visitado)
                {
                    Relaxar(verticeAtual, verticeAdjacente, adjacente.Value);
                }
            }
        }
    }    

    public List<string> EncontrarTodosCaminhos(string origem, string destino)
    {
        List<string> caminhos = new List<string>();
        EncontrarCaminhos(origem, destino, new List<string> { origem }, 0, caminhos);
        return caminhos;
    }

    private void EncontrarCaminhos(string atual, string destino, List<string> visitados, int custoAtual, List<string> caminhos)
    {
        if (atual == destino)
        {
            caminhos.Add($"{string.Join(" - ", visitados)} ao custo de ${custoAtual}");
            return;
        }

        if (!Vertices.ContainsKey(atual)) return;

        foreach (var adjacente in Vertices[atual].Adjacentes)
        {
            if (!visitados.Contains(adjacente.Key.Id))
            {
                visitados.Add(adjacente.Key.Id);
                EncontrarCaminhos(adjacente.Key.Id, destino, visitados, custoAtual + adjacente.Value, caminhos);
                visitados.RemoveAt(visitados.Count - 1); // Backtrack
            }
        }
    }
}