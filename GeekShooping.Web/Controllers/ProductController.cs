﻿using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;
using GeekShooping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }

    [Authorize]
    public async Task<IActionResult> ProductIndex()
    {
        var products = await _productService.FindAllProducts();
        return View(products);
    }

    [Authorize]
    public async Task<IActionResult> ProductCreate()
    { 
        return View();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductModel productModel)
    {
        if(ModelState.IsValid)
        {
            var response = await _productService.CreateProduct(productModel);
            if(response != null)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        } 
        return View(productModel);
    }

    public async Task<IActionResult> ProductUpdate(int id)
    {
        var product = await _productService.FindProductById(id);
        if(product != null)
        {
            return View(product);
        }
        return NotFound();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductModel productModel)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.UpdateProduct(productModel);
            if (response != null)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }
        return View(productModel);
    }

    [Authorize]
    public async Task<IActionResult> ProductDelete(int id)
    {
        var product = await _productService.FindProductById(id);
        if (product != null)
        {
            return View(product);
        }
        return NotFound();
    }
     
    [HttpPost]
    [Authorize(Roles = Role.Admin)]
    public async Task<IActionResult> ProductDelete(ProductModel productModel)
    {
        var response = await _productService.DeleteProductById(productModel.Id);
        if (response)
        {
            return RedirectToAction(nameof(ProductIndex));
        } 
        return View(productModel);
    }
}
