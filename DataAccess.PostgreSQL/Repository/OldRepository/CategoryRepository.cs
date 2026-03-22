using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.PostgreSQL;
using DataAccess.PostgreSQL.ModelsPrimitive;

namespace DataAccess.PostgreSQL.Repository;

public class CategoryRepository(ApplicationDbContext dbContext)
    : Repository<CategoryEntity>(dbContext: dbContext)
{
    public override List<CategoryEntity> Get()
        => DbContext.Category.ToList();

    public override void Update(long id, CategoryEntity entity)
    {
        throw new NotImplementedException();
    }

    public override void Delete(long idEntity)
    {
        throw new NotImplementedException();
    }
}