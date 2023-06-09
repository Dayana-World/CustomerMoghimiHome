﻿using AutoMapper;
using CustomerMoghimiHome.Server.EntityFramework.Common;
using CustomerMoghimiHome.Server.EntityFramework.Entities.Customer;
using CustomerMoghimiHome.Shared.Basic.Classes;
using CustomerMoghimiHome.Shared.EntityFramework.DTO.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerMoghimiHome.Server.Controllers.Customer;
[ApiController]
public class CustomerDetailController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;

    public CustomerDetailController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost(CustomerRoute.PersonDetail + CRUDRouts.Create)]
    public async Task CreateOrEdit([FromBody] string data)
    {
        var dto = await Task.Run(() => JsonSerializer.Deserialize<CustomerDetailDto>(data));
        if (dto != null)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName);
            var isAnoThereDetailExistForThisUser = await _unitOfWork.CustomerDetails.GetByUserIdAsync(user.Id);
            if (isAnoThereDetailExistForThisUser == null)
            {
                dto.CreateDate = DateTime.Now; dto.ModifiedDate = DateTime.Now; dto.UserId = user.Id;
                var entity = await Task.Run(() => _mapper.Map<CustomerDetailEntity>(dto));
                await _unitOfWork.CustomerDetails.AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                dto.ModifiedDate = DateTime.Now; dto.UserId = user.Id;
                
                var lastCustomerDetailData = await _unitOfWork.CustomerDetails.GetByUserIdAsync(user.Id);
                _unitOfWork.CustomerDetails.Remove(lastCustomerDetailData);
                var newData = await Task.Run(() => _mapper.Map<CustomerDetailEntity>(dto));
                await _unitOfWork.CustomerDetails.AddAsync(newData);
                await _unitOfWork.CommitAsync();
            }
        }
    }

    [HttpGet(CustomerRoute.PersonDetail + CRUDRouts.ReadOneById + "/{userName}")]
    public async Task<CustomerDetailDto> Get([FromRoute] string userName)
    {
      
            var user = await _userManager.FindByEmailAsync(userName);
            var entity = await Task.Run(async() => await _unitOfWork.CustomerDetails.GetByUserIdAsync(user.Id));
            if (entity == null)
            {
                return new CustomerDetailDto();
            }
            return await Task.Run(() => _mapper.Map<CustomerDetailDto>(entity));
        
    }
}
