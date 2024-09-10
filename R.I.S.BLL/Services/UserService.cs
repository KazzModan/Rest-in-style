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
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
            _mapper = mapper;
        }

        public async Task AddUser(UserDTO User)
        {
            await _userRepository.Create(_mapper.Map<User>(User)).ConfigureAwait(false);
        }
        public async Task DeleteUser(Guid id)
        {
            await _userRepository.Delete(id).ConfigureAwait(false);
        }
        public async Task<ICollection<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.Get().ConfigureAwait(false);
            var userDTOs = _mapper.Map<ICollection<UserDTO>>(users);

            return userDTOs;
        }
        public async Task<UserDTO> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id).ConfigureAwait(false);
            var dto = _mapper.Map<UserDTO>(user);
            return dto;
        }
        public async Task UpdateUser(UserDTO user)
        {
            await _userRepository.Update(_mapper.Map<User>(user)).ConfigureAwait(false);
        }
    }
}