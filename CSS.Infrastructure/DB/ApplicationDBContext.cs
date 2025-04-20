// <copyright file="ApplicationDBContext.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Infrastructure.DB
{
    using CCL.Domain.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents the application's database context used for Entity Framework Core.
    /// Inherits from <see cref="IdentityDbContext"/> to support ASP.NET Core Identity.
    /// </summary>
    public class ApplicationDBContext : IdentityDbContext
    {

        /// <summary>
        /// Gets or sets obtiene o establece el conjunto de entidades de Productos en la base de datos.
        /// </summary>
        public DbSet<Product> Product { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDBContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">The options to be used by a <see cref="DbContext"/>.</param>
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}
