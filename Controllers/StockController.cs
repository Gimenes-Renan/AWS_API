﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_AWS.Model;

namespace WebAPI_AWS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly DatabaseContext context;

        public StockController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Stock> Get()
        {
            return context.Stocks.ToArray();
        }


        [HttpPost]
        public Stock Post([FromBody] Stock body)
        {
            var data = context.Add(body);
            context.SaveChanges();
            return data.Entity;
        }

        [HttpPut]
        public Stock Put([FromBody] Stock body)
        {
            var data = context.Update(body);
            context.SaveChanges();
            return data.Entity;
        }

        [HttpDelete]
        public bool Delete([FromBody] Stock body)
        {
            context.Remove(body);
            context.SaveChanges();
            return true;
        }
    }
}
