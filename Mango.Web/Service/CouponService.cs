﻿using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using System;

namespace Mango.Web.Service
{
	public class CouponService : ICouponService
	{
		private readonly IBaseService _baseService;
		public CouponService( IBaseService baseService) 
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/coupon/Create/"

			});
		}

		public async Task<ResponseDto?> DeleteCouponsAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.CouponAPIBase + "/api/coupon/Delete/" + id
			});
		}

		public async Task<ResponseDto?> GetAllCouponAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon/"
			});

		}

		public async Task<ResponseDto?> GetCouponAsync(string CouponCode)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon/GetByCode/" + CouponCode
			});
		}

		public async Task<ResponseDto?> GetCouponByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon/"+id
			});
		}

		public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = couponDto,
				Url = SD.CouponAPIBase +"/api/coupon/Update/"
			}) ;
		}
	}
}
