﻿using Microsoft.AspNetCore.Mvc;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;
using webapi.health.clinic.Repositories;

namespace webapi.health.clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicController()
        {
            _clinicRepository = new ClinicRepository();
        }

        [HttpPost]
        public IActionResult Create(Clinic clinic)
        {
            try
            {
                _clinicRepository.Create(clinic);

                return StatusCode(201, clinic);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}