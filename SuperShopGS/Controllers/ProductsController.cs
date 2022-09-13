﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperShopGS.Data;
using SuperShopGS.Data.Entities;
using SuperShopGS.Helperes;
using SuperShopGS.Models;

namespace SuperShopGS.Controllers
{
    //[Authorize]




    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;//////////////////////////////////////////////////////////////////////////
        private readonly IConverterHelper _converterHelper;

        

        public ProductsController(
            IProductRepository productRepository,
            IUserHelper userHelper,
            IBlobHelper blobHelper,
            IConverterHelper converterHelper)///////////////////////////////////////////////////////////////
        {
            _productRepository = productRepository;
            _userHelper = userHelper;
            _blobHelper = blobHelper;///////////////////////////////////////////////////////////////
            _converterHelper = converterHelper;
        }




        // GET: Products
        public IActionResult Index()
        {
            return View(_productRepository.GetAll().OrderBy(p => p.Name));
        }





        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model) 
        {

            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty; ////////////////////////////////////////////////
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {

                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "products");////////////////////////////////////////////////
                }

                var product = _converterHelper.ToProduct(model, imageId, true);////////////////////////////////////////////////



              
                product.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);


                await _productRepository.CreateAsync(product);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }






        // GET: Products/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToProductViewModel(product);
            return View(model);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model) 
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    Guid imageId = model.ImageId;//////////////////////////////////////////////////////////////
                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "products");//////////////////////////////////////////////////////////
                    }
                    var product = _converterHelper.ToProduct(model, imageId, false);//////////////////////////////////////////////////////////


                    //TODO: Modificar para o user que esta logado
                    product.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await _productRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productRepository.ExistAsync(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }










        // GET: Products/Delete/5
        [Authorize] 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeletAsync(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
