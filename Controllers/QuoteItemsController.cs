using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteApi.Models;

namespace QuoteApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuoteItemsController : ControllerBase
    {
        private static QuoteItemDTO QuoteToDTO(QuoteItem quotetoItem) =>
            new QuoteItemDTO
            {
                Id = quotetoItem.Id,
                Quote = quotetoItem.Quote,
                Author = quotetoItem.Author
            };

        private readonly QuoteContext _context;

        public QuoteItemsController(QuoteContext context)
        {
            _context = context;
        }

        // GET: api/QuoteItems
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<QuoteItemDTO>>> GetQuoteItems()
        {
            return await _context.QuoteItems
                .Select(x => QuoteToDTO(x))
                .ToListAsync();

        }

        // GET: api/QuoteItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteItemDTO>> GetQuoteItem(long id)
        {
            var quoteItem = await _context.QuoteItems.FindAsync(id);

            if (quoteItem == null)
            {
                return NotFound();
            }

            return QuoteToDTO(quoteItem);
        }

        // PUT: api/QuoteItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuoteItem(long id, QuoteItemDTO quoteItemDTO)
        {
            if (id != quoteItemDTO.Id)
            {
                return BadRequest();
            }

            var quoteItem = await _context.QuoteItems.FindAsync(id);
            if (quoteItem == null)
            {
                return NotFound();
            }

            quoteItem.Quote = quoteItemDTO.Quote;
            quoteItem.Author = quoteItemDTO.Author;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!QuoteItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/QuoteItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuoteItemDTO>> CreateQuoteItem(QuoteItemDTO quoteItemDTO)
        {
            var quoteItem = new QuoteItem
            {
                Author = quoteItemDTO.Author,
                Quote = quoteItemDTO.Quote
            };

            _context.QuoteItems.Add(quoteItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetQuoteItem),
                new { id = quoteItem.Id },
                QuoteToDTO(quoteItem));
        }

        //Delete all
        //TODO:Create a HTTP Delete ALL 
        
                

        // DELETE: api/QuoteItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuoteItem(long id)
        {
            var quoteItem = await _context.QuoteItems.FindAsync(id);

            if (quoteItem == null)
            {
                return NotFound();
            }

            _context.QuoteItems.Remove(quoteItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuoteItemExists(long id)
        {
            return _context.QuoteItems.Any(e => e.Id == id);
        }
        

    }
}
