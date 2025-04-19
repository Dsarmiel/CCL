// <copyright file="ProductMapper.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.Application.Mappers
{
    using CCL.Application.DTOs.Product;
    using CCL.Domain.Entities;

    /// <summary>
    /// Clase estática que proporciona métodos de mapeo para la entidad <see cref="Product"/>
    /// y el Data Transfer Object <see cref="ProductDTO"/>.
    /// </summary>
    public static class ProductMapper
    {
        /// <summary>
        /// Mapea un objeto <see cref="ProductDTO"/> a una nueva instancia de <see cref="Product"/>.
        /// </summary>
        /// <param name="productDTO">El objeto <see cref="ProductDTO"/> a mapear.</param>
        /// <returns>Una nueva instancia de <see cref="Product"/> con los valores mapeados.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="productDTO"/> es nulo.</exception>
        public static Product ToEntity(this ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                throw new ArgumentNullException(nameof(productDTO));
            }

            return new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Quantity = productDTO.Quantity,
            };
        }

        /// <summary>
        /// Mapea un objeto <see cref="Product"/> a una nueva instancia de <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="product">El objeto <see cref="Product"/> a mapear.</param>
        /// <returns>Una nueva instancia de <see cref="ProductDTO"/> con los valores mapeados.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="product"/> es nulo.</exception>
        public static ProductDTO ToDTO(this Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
            };
        }

        /// <summary>
        /// Mapea una colección de entidades <see cref="Product"/> a una lista de objetos <see cref="ProductDTO"/>.
        /// </summary>
        /// <param name="products">La colección de entidades <see cref="Product"/> a mapear.</param>
        /// <returns>Una lista de objetos <see cref="ProductDTO"/> con los valores mapeados.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="products"/> es nulo.</exception>
        public static List<ProductDTO> ToDTOList(this IEnumerable<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            return products.Select(ToDTO).ToList();
        }
    }
}