namespace FootballLeagueApi.Data.Repository
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Data.Entities.Interfaces;

    public class Repository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateEntityAsync(T entity)
        {
            await AddEntityAsync(entity);
            await SaveModificationAsync(entity);
        }

        public async Task DeleteEntityAsync(T entity)
        {
            entity.IsDeleted = true;

            await SaveModificationAsync(entity);
        }

        public async Task AddEntityAsync(T entity)
        {
            entity.CreationDate = DateTime.UtcNow;

            await _dbContext.AddAsync(entity);
        }

        public async Task SaveModificationAsync(T entity)
        {
            entity.LastModifiedOn = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        protected async Task<T> GetByIdAsync(int id)
        {
            var entity = await this.FindByIdOrDefaultAsync(id);

            if (entity != null)
                return entity;


            return null;
        }

        private async Task<T> FindByIdOrDefaultAsync(int id)
        {
            var entity = await _dbContext.Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            return entity;
        }
    }
}
