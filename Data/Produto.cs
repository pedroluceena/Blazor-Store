namespace Blazor_Store.Data
{
    public class Produto
    {
        public int ProddutId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public object ProdutoId { get; internal set; }
    }
}
