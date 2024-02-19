﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.PC.Contacts.Repository.Entities.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasData
            (
                new SubCategory
                {
                    Id = new Guid("5607a79f-455f-4330-9d02-4c3a44159db3"),
                    Name = "Boss",
                    CategoryId = new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7")
                },
                new SubCategory
                {
                    Id = new Guid("7dacda57-2fd7-4b49-9ed5-df81be7c675a"),
                    Name = "Customer",
                    CategoryId = new Guid("e385f467-b1ee-4df9-86ba-c91c5e3dccb7")
                }
            );
        }

    }
}
