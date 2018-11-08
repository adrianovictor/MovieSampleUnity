using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MovieSample.Persistency.Mappings
{
    public class EntityMap<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public EntityMap()
        {

        }
    }
}