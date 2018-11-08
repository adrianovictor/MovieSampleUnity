using MovieSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSample.Persistency.Mappings
{
    public class MovieMap : EntityMap<Movie>
    {
        public MovieMap()
        {
            ToTable("movie");

            HasKey(_ => _.Id);
            Property(_ => _.Title).IsRequired().HasMaxLength(128).IsUnicode(false).HasColumnType("varchar");
            Property(_ => _.Description).IsRequired().HasMaxLength(128).IsUnicode(false).HasColumnType("varchar");
            Property(_ => _.Year).IsRequired().HasColumnType("datetime");
        }
    }
}