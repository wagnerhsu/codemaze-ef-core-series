using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ApplicationContext context, ILogger<ValuesController> logger)
        {
            this._logger = logger;
            _context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _context.Model
                .FindEntityType(typeof(Student).FullName);

            var tableName = entity.GetTableName();
            var schemaName = entity.GetSchema();
            var key = entity.FindPrimaryKey();
            var properties = entity.GetProperties();
            _logger.LogInformation($"Table Name: {tableName} schema: {schemaName} key: {key} properties: {properties}");
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}