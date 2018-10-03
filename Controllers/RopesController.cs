using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using practiceClimbingShop.Models;
using practiceClimbingShop.Repositories;

namespace practiceClimbingShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RopesController : Controller
    {
        RopesRepository _repo;
        public RopesController(RopesRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Rope> Get()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        public Rope Post([FromBody] Rope rope)
        {
            if (ModelState.IsValid)
            {
                return _repo.Create(rope);
            }
            throw new System.Exception("Creation failed: Invalid rope.");
        }

        [HttpPut]
        public Rope Put([FromBody] Rope rope)
        {
            if (ModelState.IsValid)
            {
                return _repo.Update(rope);
            }
            throw new System.Exception("Update failed: Invalid rope.");   
        }

        [HttpDelete]
        public Rope Delete([FromBody] Rope rope)
        {
            return _repo.Delete(rope);
        }
    }
}