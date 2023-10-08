using Blazor_Store.Data;
using Dapper;
using System.Data;

namespace Blazor_Store.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IDapperService _dapperDal;
        public ProdutoService(IDapperService dapperDal)
        {
            this._dapperDal = dapperDal;
        }

        public Task<int> Create(Produto produto)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Nome", produto.Nome, DbType.String);
            dbPara.Add("Descricao", produto.Descricao, DbType.String);
            dbPara.Add("Imagem", produto.Imagem, DbType.String);
            dbPara.Add("Preco", produto.Preco, DbType.Decimal);
            dbPara.Add("Estoque", produto.Estoque, DbType.Int32);

            var produtoId = Task.FromResult(_dapperDal.Insert<int>("[dbo].[SP_Novo_Produto]",
                            dbPara, commandType: CommandType.StoredProcedure));

            return produtoId;
        }
        public Task<Produto> GetById(int id)
        {
            var produto = Task.FromResult(_dapperDal.Get<Produto>($"select * from [Produtos] " +
                          $"where ProdutoId = {id}", null, commandType: CommandType.Text));

            return produto;
        }
        public Task<int> Delete(int id)
        {
            var deleteProduto = Task.FromResult(_dapperDal.Execute($"Delete [Produtos] " +
                                $"where ProdutoId = {id}", null, commandType: CommandType.Text));

            return deleteProduto;
        }
        public Task<List<Produto>> ListAll()
        {
            var produtos = Task.FromResult(_dapperDal.GetAll<Produto>("select * from [Produtos]",
                           null, commandType: CommandType.Text));

            return produtos;
        }
        public Task<int> Update(Produto produto)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ProdutoId", produto.ProdutoId);
            dbPara.Add("Nome", produto.Nome, DbType.String);
            dbPara.Add("Descricao", produto.Descricao, DbType.String);
            dbPara.Add("Imagem", produto.Imagem, DbType.String);
            dbPara.Add("Preco", produto.Preco, DbType.Decimal);
            dbPara.Add("Estoque", produto.Estoque, DbType.Int32);

            var updateProduto = Task.FromResult(_dapperDal.Update<int>("[dbo].[SP_Atualiza_Produto]",
                                 dbPara, commandType: CommandType.StoredProcedure));

            return updateProduto;
        }
    }
}

