using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.ViewModels;
using PaymentService.Intefaces;
using PaymentService.Models;
using System;
using System.Threading.Tasks;

namespace Payment.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        public PaymentController(ISaleService saleService,
                                 IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [HttpGet("sale/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaleGetByIdViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSaleById(Guid id)
        {
            var sale = _mapper.Map<SaleGetByIdViewModel>(await _saleService.GetById(id));

            if (sale == null)
                return NotFound();

            return Ok(sale);
        }

        [Route("sale/add")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(SaleViewModel saleViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var response = await _saleService.Add(_mapper.Map<Sale>(saleViewModel));
                return  Created("", response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("sale/update")]
        [HttpPut]
        public async Task<IActionResult> Update(SaleUpdateViewModel saleViewModel)
        {
            try
            {
                await _saleService.Update(_mapper.Map<Sale>(saleViewModel));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
