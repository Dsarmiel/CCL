// <copyright file="ProductRepository.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>
    
namespace CCL.Infrastructure.Repositories
{
    using CCL.Domain.Entities;
    using CCL.Domain.Exceptions;
    using CCL.Domain.Repositories;
    using CCL.Infrastructure.DB;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Implementación del repositorio para la entidad <see cref="Product"/>.
    /// Proporciona métodos para interactuar con la base de datos para operaciones relacionadas con los productos.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// El contexto de la base de datos de la aplicación.
        /// </summary>
        private readonly ApplicationDBContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ProductRepository"/>.
        /// </summary>
        /// <param name="dbContext">El contexto de la base de datos de la aplicación.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="dbContext"/> es nulo.</exception>
        public ProductRepository(ApplicationDBContext dbContext)
        {
            this.context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Obtiene asíncronamente todos los productos de la base de datos.
        /// </summary>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea
        /// contiene una lista de <see cref="Product"/>.</returns>
        public async Task<List<Product>> GetAllAsync()
        {
            return await this.context.Product.OrderBy(x => x.Id).ToListAsync();
        }

        /// <summary>
        /// Actualiza asíncronamente un producto existente en la base de datos.
        /// </summary>
        /// <param name="id">El ID del producto que se va a actualizar.</param>
        /// <param name="quantity">La nueva cantidad para el producto.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado de la tarea
        /// contiene la entidad <see cref="Product"/> actualizada.</returns>
        /// <exception cref="ProductNotFoundException">Se lanza si no se encuentra un producto con el ID especificado.</exception>
        /// <exception cref="ConcurrencyException">Se lanza si el producto ha sido modificado por otro usuario durante la operación.</exception>
        /// <exception cref="DatabaseOperationException">Se lanza si ocurre un error al guardar los cambios en la base de datos.</exception>
        public async Task<Product> UpdateAsync(int id, int quantity)
        {
            Product? productToUpdate = await this.context.Product.FirstOrDefaultAsync(x => x.Id == id);
            if (productToUpdate == null)
            {
                throw new ProductNotFoundException($"No se encontró el producto con ID: {id} para actualizar.", id);
            }

            productToUpdate.Quantity = quantity;
            try
            {
                await this.context.SaveChangesAsync();
                return productToUpdate;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("El producto ha sido modificado por otro usuario.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseOperationException("Error al guardar los cambios del producto.", ex);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"Error inesperado al actualizar el producto con ID: {id}.", ex);
            }
        }
    }
}