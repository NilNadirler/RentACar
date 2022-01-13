using Business.Abstract;
using Core.Abstract;
using Core.Entities.Concrete;
using Entities.Concentre;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public ITransactionService _transactionService;
        public IZiraatPaymentService _ziraatPaymentService;

        public TransactionController(ITransactionService transactionService, IZiraatPaymentService ziraatPaymentService)
        {
            _transactionService = transactionService;
            _ziraatPaymentService = ziraatPaymentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transactionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallactivelist")]
        public IActionResult GetAllActiveList()
        {
            var result = _transactionService.GetAllActiveList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(TransactionDto transaction)
        {
            var result = _transactionService.Add(transaction);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetbyId(int id)
        {
            var result = _transactionService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int id)
        {
            var result = _transactionService.GetByCustomerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result = _transactionService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("transaction")]
        public IActionResult AddPayment(PaymentDto dto)
        {
            var paymentResult = _ziraatPaymentService.Pay(dto);
            if (!paymentResult.Success)
            {
                return BadRequest(paymentResult);
            }
            var result = _transactionService.AddPaymentWithTransaction(paymentResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
