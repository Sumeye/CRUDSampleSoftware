using AutoMapper;
using CrudSample.API.Controllers;
using CrudSample.Core.DTOs;
using CrudSample.Core.Models;
using CrudSample.Core.Services;
using CrudSample.Service.Mapping;
using CrudSample.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;

namespace CrudSampleUnitTest.Test
{
    public class UserApiControllerTest
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly UserController _usercontroller;
        private readonly IMapper _mapper;
        private List<Users> users;
        public UserApiControllerTest()
        {
            _mockUserService = new Mock<IUserService>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _usercontroller = new UserController(_mapper, _mockUserService.Object);

            users = new List<Users>() {
             new Users { Id = 7, Name = "Sümeyye", SurName = "Yerli", Email = "sumeyye@sumeyye.com", Password = "Aa145679", UserName = "syerli", CreatedDate = DateTime.Now },
             new Users { Id = 8, Name = "Sümeyye1", SurName = "Yerli1", Email = "sumeyye1@sumeyye.com", Password = "Aa145679", UserName = "syerlii", CreatedDate = DateTime.Now }
            };
        }


        [Fact]
        public async void GetAllUser_ActionExecutes_ReturnObjectResultUserList()
        {
            _mockUserService.Setup(x => x.GetAllAsync()).ReturnsAsync(users);
            var result = await _usercontroller.GetAll();
            var okResult = Assert.IsType<ObjectResult>(result);
            var returnUsers = Assert.IsAssignableFrom<CustomResponseDto<List<UserDto>>>(okResult.Value);
            Assert.Equal<int>(2, returnUsers.Data.ToList().Count);
        }

        [Theory]
        [InlineData(3)]
        public async void UpdateUser_ActionExecutes_ReturnNoContentDto(int userId)
        {
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                var userName = "SumeyyeYerli";
                user.UserName = userName;
                _mockUserService.Setup(x => x.UpdateAsync(_mapper.Map<UserUpdateDto>(user)));
                var result = await _usercontroller.Update(_mapper.Map<UserUpdateDto>(user));
                _mockUserService.Verify(x => x.UpdateAsync(It.IsAny<UserUpdateDto>()), Times.Once);
                Assert.IsType<ObjectResult>(result);
            }
        }

        [Fact]
        public async void SaveUser_ActionExecutes_ReturnObjectResultUser()
        {
            var user = users.FirstOrDefault();
            if (user != null)
            {
                _mockUserService.Setup(x => x.AddAsync(user)).ReturnsAsync(user);
                var result = await _usercontroller.Save(_mapper.Map<UserDto>(user));
                var createActionResult = Assert.IsType<ObjectResult>(result);
            }
        }

        [Theory]
        [InlineData(1)]
        public async void RemoveUser_ActionExecutes_ReturnNoContentDto(int userId)
        {
            var user = users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                _mockUserService.Setup(x => x.GetByIdAsync(userId)).ReturnsAsync(user);
                _mockUserService.Setup(x => x.RemoveAsync(user)).Returns(Task.CompletedTask);
                var noContentResult = await _usercontroller.Remove(user.Id);
                _mockUserService.Verify(x => x.RemoveAsync(user), Times.Once);
                Assert.IsType<ObjectResult>(noContentResult);
            }
        }
    }
}
