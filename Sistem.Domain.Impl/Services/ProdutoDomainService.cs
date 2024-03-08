using Sistem.Domain.Impl.Etities;
using Sistem.Domain.Impl.Interfaces;

namespace Sistem.Domain.Impl.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoDomainService(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(RegisterProduto entity)
        {
            if (_unitOfWork.ProdutoRepository.GetByNome(entity.Nome) != null)
                throw new Exception("Nome do Produto ja existente no sistema");

            if (_unitOfWork.ProdutoRepository.GetByTipo(entity.Tipo) != null)
                throw new Exception("Ja existe um produto desse tipo no sistema");

            await _unitOfWork.ProdutoRepository.CreateAsync(entity);
              
        }

        public async Task UpdateAsync(RegisterProduto entity)
        {
            if ( await _unitOfWork.ProdutoRepository.GetByIdAsync(entity.Id) == null)
                throw new Exception("Produto não encontrado");

            var nomeProduto = _unitOfWork.ProdutoRepository.GetByNome(entity.Nome);
            if (nomeProduto != null && nomeProduto.Id.Equals(entity.Id))
                throw new Exception("Nome do Produto ja existente no sistema");

            /*var nomeTipoProduto = _unitOfWork.ProdutoRepository.GetByTipo(entity.Tipo);

            if (nomeTipoProduto != null && nomeTipoProduto.Id.Equals(entity.Id))
                throw new Exception("Tipo de produto nao encontrado");*/

            await _unitOfWork.ProdutoRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(RegisterProduto entity)
        {
            if (await _unitOfWork.ProdutoRepository.GetByIdAsync(entity.Id) == null)
                throw new Exception("Produto nao encontrado");

            await _unitOfWork.ProdutoRepository.DeleteAsync(entity);
        }

        public async Task<List<RegisterProduto>> GetAllAsync(int page, int limit)
        {
            if (limit > 250)
                throw new ArgumentException("Limite maximo 250");

            return await _unitOfWork.ProdutoRepository.GetAllAsync(page, limit);
        }

        public async Task<RegisterProduto> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.ProdutoRepository.GetByIdAsync(id);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
