using AirlineTickets.BLL.Interfaces;
using AirlineTickets.DAL.Interfaces;
using AutoMapper;

namespace AirlineTickets.BLL.Services
{
    public class GenericService<TModel, TEntity> : IGenericService<TModel>
            where TModel : class
            where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public virtual async Task<TModel> Create(TModel model, CancellationToken cancellationToken)
        {
            return _mapper.Map<TModel>(await _genericRepository.Create(
                _mapper.Map<TEntity>(model), cancellationToken));
        }

        public virtual async Task<TModel> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _genericRepository.GetById(id, cancellationToken);

            if (entity is not null)
            {
                await _genericRepository.Delete(id, cancellationToken);
            }

            return _mapper.Map<TModel>(entity);
        }

        public async Task<TModel> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _genericRepository.GetById(id, cancellationToken);

            return _mapper.Map<TModel>(entity);
        }

        public async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<TModel>>(await _genericRepository.GetAll(cancellationToken));

        public async Task<TModel> Update(TModel model, CancellationToken cancellationToken) =>
            _mapper.Map<TModel>(await _genericRepository.Update(_mapper.Map<TEntity>(model), cancellationToken));
    }
}
