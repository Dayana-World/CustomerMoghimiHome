﻿using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Shop;
using Microsoft.EntityFrameworkCore;

namespace CustomerMoghimiHome.Server.EntityFramework.Repositories.Shop;

public interface IBasketRepository : IRepository<UserBasketEntity>
{
    Task<UserBasketEntity> GetByIdAsync(long id);
    Task<UserBasketEntity> GetByUserIdAsync(string id);
}

public class BasketRepository : Repository<UserBasketEntity>, IBasketRepository
{
    private readonly IQueryable<UserBasketEntity> _queryable;

    public BasketRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<UserBasketEntity>();
    }

    public async Task<UserBasketEntity> GetByIdAsync(long id) =>
         await _queryable.Include(x => x.ProductEntities)
        .FirstOrDefaultAsync(x => x.Id == id && x.IsOrdered == false);

    public async Task<UserBasketEntity> GetByUserIdAsync(string id) =>
       await _queryable.Include(x => x.ProductEntities)
      .FirstOrDefaultAsync(x => x.UserId == id && x.IsOrdered == false);
}
