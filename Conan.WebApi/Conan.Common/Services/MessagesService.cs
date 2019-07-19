using System.Collections.Generic;
using System.Threading.Tasks;
using Conan.Common.DTO;
using Conan.Common.Services.Interfaces;

namespace Conan.Common.Services
{
    public class MessagesService : ICrudService<MessageDTO>
    {
        public async Task<IEnumerable<MessageDTO>> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<MessageDTO> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Insert(MessageDTO item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(MessageDTO item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(MessageDTO item)
        {
            throw new System.NotImplementedException();
        }
    }
}