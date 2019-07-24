using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conan.Data.Models;
using Conan.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Conan.Data.Repositories
{
    public class MessagesRepository : ICrudRepository<Message>
    {
        private readonly ApplicationDbContext _context;

        public MessagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> Get()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> Get(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task Insert(Message item)
        {
            _context.Messages.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Update(Message item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return false;
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}