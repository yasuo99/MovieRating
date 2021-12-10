using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.API.Abstractions
{
    public interface ICrudApiController<TKey, TData>
    {
        [HttpGet]
        Task<IActionResult> GetAll();
        [HttpGet("{id}")]
        Task<IActionResult> GetDetail(TKey id);
        [HttpPost]
        Task<IActionResult> Create(TData data);
        [HttpPut("{id}")]
        Task<IActionResult> Update(TKey id, TData data);
        [HttpDelete("{id}")]
        Task<IActionResult> Delete(TKey id);
    }
}
