using MovieSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSample.Persistency.Mappings
{
    public class GenreMap : EntityMap<Genre>
    {
        public GenreMap()
        {
            ToTable("genre");

            HasKey(_ => _.Id);
            Property(_ => _.Name).IsRequired().HasMaxLength(128).IsUnicode(false).HasColumnType("varchar");
            Property(_ => _.Description).IsRequired().HasMaxLength(128).IsUnicode(false).HasColumnType("varchar");
        }
    }
}