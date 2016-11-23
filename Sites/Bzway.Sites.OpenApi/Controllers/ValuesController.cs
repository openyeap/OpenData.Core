﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bzway.Sites.OpenApi.Controllers
{
    public class Model
    {
        public string media_id { get; set; }
    }
    [Route("api/[controller]")]
    public class MaterialController : Controller
    {
        // GET api/values
        [HttpPost]
        public IEnumerable<string> GetMaterial(string access_token, Model model)
        {
            return new string[] { model.media_id, access_token };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
