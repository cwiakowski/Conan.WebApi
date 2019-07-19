using System.Collections.Generic;
using System.Threading.Tasks;
using Conan.Data.Models;
using Conan.Data.Repositories.Interfaces;

namespace Conan.Data.Repositories
{
    public class MessagesRepository : ICrudRepository<Message>
    {
        public async Task<IEnumerable<Message>> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Message> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Insert(Message item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(Message item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(Message item)
        {
            throw new System.NotImplementedException();
        }
    }
}