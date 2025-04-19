// <copyright file="ProductsController.cs" company="CCL">
// Copyright (c) CCL. All rights reserved.
// </copyright>

namespace CCL.API.Controllers
{
    using CCL.Application.DTOs.Product;
    using CCL.Application.Services.Interfaces;
    using CCL.Domain.Exceptions;
    using CCL.Shared.Response;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controlador API para la gestión de productos.
    /// Proporciona endpoints para obtener el inventario y actualizar la cantidad de productos.
    /// </summary>
    [Route("productos")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Servicio para la lógica de negocio de los productos.
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// Inicializa una nueva instancia del controlador <see cref="ProductsController"/>.
        /// </summary>
        /// <param name="productService">Servicio de productos a inyectar.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="productService"/> es nulo.</exception>
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Obtiene la lista completa del inventario de productos.
        /// </summary>
        /// <returns>Un <see cref="ActionResult"/> que contiene una respuesta <see cref="ApiResponse{List{ProductDTO}}"/>.
        /// Retorna Ok (200) con la lista de productos en caso de éxito.
        /// Retorna StatusCode(500) con un mensaje de error en caso de <see cref="DatabaseOperationException"/> u otra excepción inesperada.</returns>
        [HttpGet("inventario")]
        [ProducesResponseType(typeof(ApiResponse<List<ProductDTO>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<List<ProductDTO>>), 500)]
        [Authorize]
        public async Task<ActionResult<ApiResponse<List<ProductDTO>>>> GetAll()
        {
            try
            {
                List<ProductDTO> products = await this.productService.GetAllAsync();
                return this.Ok(new ApiResponse<List<ProductDTO>> { Success = true, Data = products });
            }
            catch (DatabaseOperationException ex)
            {
                return this.StatusCode(500, new ApiResponse<List<ProductDTO>> { Message = "Error al obtener los productos.", Errors = new List<string> { ex.Message } });
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, new ApiResponse<List<ProductDTO>> { Message = "Ocurrió un error inesperado.", Errors = new List<string> { "Intente nuevamente más tarde." } });
            }
        }

        /// <summary>
        /// Actualiza la cantidad de un producto específico.
        /// </summary>
        /// <param name="updateProductDTO">Un DTO <see cref="UpdateProductDTO"/> que contiene el ID del producto y la nueva cantidad.</param>
        /// <returns>Un <see cref="ActionResult"/> que contiene una respuesta <see cref="ApiResponse{ProductDTO}"/>.
        /// Retorna Ok (200) con el producto actualizado en caso de éxito.
        /// Retorna NotFound (404) si el producto no se encuentra (<see cref="ProductNotFoundException"/>).
        /// Retorna Conflict (409) si ocurre un error de concurrencia (<see cref="ConcurrencyException"/>).
        /// Retorna StatusCode(500) con un mensaje de error en caso de <see cref="DatabaseOperationException"/> u otra excepción inesperada.</returns>
        [HttpPost("movimiento")]
        [ProducesResponseType(typeof(ApiResponse<ProductDTO>), 200)]
        [ProducesResponseType(typeof(ApiResponse<ProductDTO>), 404)]
        [ProducesResponseType(typeof(ApiResponse<ProductDTO>), 409)]
        [ProducesResponseType(typeof(ApiResponse<ProductDTO>), 500)]
        [Consumes("application/json")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<ProductDTO>>> Update(UpdateProductDTO updateProductDTO)
        {
            try
            {
                var updatedProduct = await this.productService.UpdateAsync(updateProductDTO);
                return this.Ok(new ApiResponse<ProductDTO> { Success = true, Message = "Producto actualizado exitosamente.", Data = updatedProduct });
            }
            catch (ProductNotFoundException ex)
            {
                return this.NotFound(new ApiResponse<ProductDTO> { Message = ex.Message, Errors = new List<string> { ex.Message } });
            }
            catch (ConcurrencyException ex)
            {
                return this.Conflict(new ApiResponse<ProductDTO> { Message = ex.Message, Errors = new List<string> { ex.Message } });
            }
            catch (DatabaseOperationException ex)
            {
                return this.StatusCode(500, new ApiResponse<ProductDTO> { Message = "Error al actualizar el producto.", Errors = new List<string> { ex.Message } });
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, new ApiResponse<ProductDTO> { Message = "Ocurrió un error inesperado al actualizar el producto.", Errors = new List<string> { "Intente nuevamente más tarde." } });
            }
        }
    }
}