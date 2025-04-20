// <copyright file="ProductService.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.Services.Implementations
{
    using CCL.Application.DTOs.Product;
    using CCL.Application.Mappers;
    using CCL.Application.Services.Interfaces;
    using CCL.Domain.Entities;
    using CCL.Domain.Exceptions;
    using CCL.Domain.Repositories;

    /// <summary>
    /// Implementación del servicio para la gestión de productos (<see cref="IProductService"/>).
    /// Proporciona métodos para realizar operaciones relacionadas con los productos,
    /// utilizando el repositorio <see cref="IProductRepository"/> y los mappers.
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// El repositorio para acceder a los datos de los productos.
        /// </summary>
        private readonly IProductRepository productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// Inicializa una nueva instancia de la clase <see cref="ProductService"/>.
        /// </summary>
        /// <param name="productRepository">El repositorio de productos a utilizar.
        /// Se espera una implementación de <see cref="IProductRepository"/>.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="productRepository"/> es nulo.</exception>
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        /// <inheritdoc />
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            try
            {
                List<Product> products = await this.productRepository.GetAllAsync();
                return products.ToDTOList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error inesperado al traer los productos.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ProductDTO> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            try
            {
                int id = updateProductDTO.Id;
                int quantity = updateProductDTO.Quantity;

                Product updatedProduct = await this.productRepository.UpdateAsync(id, quantity);

                return updatedProduct.ToDTO();
            }
            catch (ProductNotFoundException)
            {
                throw;
            }
            catch (ConcurrencyException)
            {
                throw;
            }
            catch (DatabaseOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error inesperado al actualizar el producto.", ex);
            }
        }
    }
}