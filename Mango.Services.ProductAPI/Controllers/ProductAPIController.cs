﻿using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Mango.Services.ProductAPI.Controllers
{
	[Route("api/Product")]
	[ApiController]
	public class ProductAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;

		public ProductAPIController(AppDbContext db,IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
			_response = new ResponseDto();
		}
		[HttpGet]
		public ResponseDto Get()
		{
			try
			{
				IEnumerable<Product> objList = _db.Products.ToList();
				_response.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
		[HttpGet]
		[Route("{id:int}")]
		public ResponseDto Get(int id)
		{
			try
			{
				Product obj = _db.Products.First(u => u.ProductId == id);
			    _response.Result = _mapper.Map<ProductDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;	
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPost("Create")]
		[Authorize(Roles="ADMIN")]
		public ResponseDto Post([FromBody] ProductDto ProductDto)
		{
			try
			{
				Product obj = _mapper.Map<Product>(ProductDto);
				_db.Products.Add(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPut("Update")]
	   [Authorize(Roles = "ADMIN")]
		public ResponseDto Put([FromBody] ProductDto ProductDto)
		{
			try
			{
				Product obj = _mapper.Map<Product>(ProductDto);
				_db.Products.Update(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpDelete("Delete/{id:int}")]
	    [Authorize(Roles = "ADMIN")]
		public ResponseDto Delete(int id)
		{
			try
			{
				Product obj = _db.Products.First(u=>u.ProductId==id);
				_db.Products.Remove(obj);
				_db.SaveChanges();
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	}
}
