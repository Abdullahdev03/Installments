using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class InstallmentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public InstallmentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<InfoDto>>> GetInfos()
    {
        try
        {
            var result = await _context.Infos.ToListAsync();
            var mapped = _mapper.Map<List<InfoDto>>(result);
            return new Response<List<InfoDto>>(mapped);
        }
        catch (Exception ex)
        {
            return  new Response<List<InfoDto>>(HttpStatusCode.InternalServerError,new List<string>(){ex.Message});
        }
    }
    public async Task<Response<InfoDto>> AddInfo(InfoDto customer)
    {
        try
        {
          
            var mapped = _mapper.Map<Info>(customer);
            await _context.Infos.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<InfoDto>(customer);
        }
        catch (Exception ex)
        {
            return new Response<InfoDto>(HttpStatusCode.InternalServerError,new List<string>(){ex.Message});
        }
    }
    public double CalculatePayment(string product, double amount, string phoneNumber, int installmentPeriod)
    {
        double totalAmount = amount;
        int minPeriod, maxPeriod, additionalPercentage;
    
        switch (product.ToLower())
        {
            case "smartphone":
                minPeriod = 3;
                maxPeriod = 24;
                if (installmentPeriod < 9)
                {
                    return totalAmount;
                }
                else if (installmentPeriod >9)
                {
                    for (int i = 9; i < installmentPeriod; i+=6)
                    {
                        totalAmount += (amount * 3 / 100);
                    }
                }
                break;
            case "computer":
                minPeriod = 3;
                maxPeriod = 24;
                if (installmentPeriod < 12)
                {
                    return totalAmount;
                }
                else if (installmentPeriod > 12)
                {
                    for (int i = 12; i < installmentPeriod; i+=6)
                    {
                        totalAmount += (amount * 4/ 100);
                    }
                }
                break;
            case "television":
                minPeriod = 3;
                maxPeriod = 24;
                if (installmentPeriod < 18)
                {
                    return totalAmount;
                }
                else if (installmentPeriod > 18)
                {
                    for (int i = 18; i < installmentPeriod; i+=6)
                    {
                        totalAmount += (amount * 5 / 100);
                    }
                }
                break;
            default:
                throw new ArgumentException("Неверный продукт");
        }
    
        if (installmentPeriod < minPeriod || installmentPeriod > maxPeriod)
        {
            throw new ArgumentException($"Рассрочка должна быть в диапазоне от {minPeriod} до {maxPeriod} месяцев");
        }
/*
        if(installmentPeriod >= min || installmentPeriod <= max)
        {
            for (int i = 12; i < installmentPeriod-1; i+=6)
            {
                double additionalAmount, additionalAmount2;
                int additionalMonths = installmentPeriod - min;
                if (additionalMonths > 0)
                {
                    for (int j = 6; j < additionalMonths; j+=6)
                    {
                        additionalAmount = amount * additionalPercentage *additionalMonths /100 ;
                        additionalAmount2 = additionalAmount/j;
                        totalAmount += additionalAmount2;
                        
                    }
                }
                if (additionalMonths == 0)
                {
                    for (int j = 1; j < 1; j++)
                    {
                        double additionalAmount4 = ((amount * additionalPercentage * 2)  / 100);
                        totalAmount += additionalAmount4;
                    }
                }
                
            }
        }
        // if (installmentPeriod >= minPeriod || installmentPeriod <= maxPeriod)
        // {
        //     for (int i = 12; i <= 24; i+=3)
        //     {
        //         int additionalMonths = installmentPeriod - minPeriod;
        //         if (additionalMonths > 0)
        //         {
        //             double additionalAmount = amount * additionalMonths * additionalPercentage / 100;
        //             totalAmount += additionalAmount;
        //         }
        //     }
        // }*/


        return totalAmount;
    }
    
    
    
    
    
    
    
    
    
}
