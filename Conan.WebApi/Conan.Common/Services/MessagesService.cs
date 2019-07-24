using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Conan.Common.DTO;
using Conan.Common.Services.Interfaces;
using Conan.Data;
using Conan.Data.Models;
using Conan.Data.Repositories;

namespace Conan.Common.Services
{
    public class MessagesService : ICrudService<MessageDTO>
    {
        private readonly IMapper _mapper;
        private readonly MessagesRepository _repository;
        public MessagesService(ApplicationDbContext context)
        {
            _repository = new MessagesRepository(context);
            _mapper = MapperService.GetMapperInstance();
        }

        public async Task<IEnumerable<MessageDTO>> Get()
        {
            var messages = await _repository.Get();
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public async Task<MessageDTO> Get(int id)
        {
            var messages = await _repository.Get(id);
            return _mapper.Map<MessageDTO>(messages);
        }

        public async Task Insert(MessageDTO item)
        {
            await _repository.Insert(_mapper.Map<Message>(item));
        }

        public async Task<bool> Update(MessageDTO item)
        {
            return await _repository.Update(_mapper.Map<Message>(item));
        }

        public async Task<bool> Delete(int item)
        {
            return await _repository.Delete(item);
        }
    }
}