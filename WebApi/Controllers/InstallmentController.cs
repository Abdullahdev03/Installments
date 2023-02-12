using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class InstallmentController: ControllerBase
{
    private readonly InstallmentService _service;
    
    public InstallmentController(InstallmentService service)
    {
        _service = service;
    }
    
    [HttpGet("GetInfos")]
    public async Task<Response<List<InfoDto>>> Get()
    {
        return await _service.GetInfos();
    }
    
    [HttpPost("AddInfo")]
    public async  Task<Response<InfoDto>> Add(InfoDto customer)
    {
        if (ModelState.IsValid)
        {
            return await _service.AddInfo(customer);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<InfoDto>(HttpStatusCode.BadRequest, errors);
        }
       
    }
    
    
    [HttpGet("GetCalculator")]
    public async Task<decimal> Calculate2(string product, double amount, string phoneNumber, int installmentPeriod)
    {
        return  (decimal)_service.CalculatePayment(product, amount, phoneNumber, installmentPeriod);
    }
}
