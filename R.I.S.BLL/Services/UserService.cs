using AutoMapper;
using R.I.S.BLL.Services.Abstraction;
using R.I.S.DAL.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using R.I.S.DAL.Models;
using R.I.S.BLL.DTO;
namespace R.I.S.BLL.Services
{
    public class UserService : IUserService

    {
        private readonly IRepository<User> _UserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool disposed = false;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _UserRepository = _unitOfWork.GetRepository<User>();
            _mapper = mapper;
        }

        public async Task AddUser(UserDTO User)
        {
            await _UserRepository.Create(_mapper.Map<User>(User)).ConfigureAwait(false);
        }
        public async Task DeleteUser(Guid id)
        {
            await _UserRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            var Users = await _UserRepository.Get().ConfigureAwait(false);
            var UserDTOs = _mapper.Map<ICollection<UserDTO>>(Users);

            return UserDTOs;
        }
        public async Task<UserDTO> GetUserById(Guid id)
        {
            var User = await _UserRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<UserDTO>(User);
            return dto;
        }
        public async Task UpdateUser(UserDTO User)
        {
            await _UserRepository.Update(_mapper.Map<User>(User)).ConfigureAwait(false);
        }
    }
}