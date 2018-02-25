using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HomeKookd.Services.DTOs;
using Newtonsoft.Json;
using TokenAuthWebApiCore.Server.IntegrationTest.Setup;
using Xunit;

namespace HomeKookd.AuthTests
{
	public class AuthControllerRegisterUserTest : IClassFixture<TestFixture<TestStartup>>
	{
		public HttpClient Client { get; }

		public AuthControllerRegisterUserTest(TestFixture<TestStartup> fixture)
		{
			Client = fixture.httpClient;
		}

		[Theory]
		[InlineData("", "", "")]
		[InlineData("", "WebApiCore1#", "WebApiCore1#")]
		[InlineData("", "", "WebApiCore1#")]
		[InlineData("", "WebApiCore1#", "")]
		[InlineData("simpleuser@yopmail.com", "WebApiChggore1#", "WebApiCore1#")]
		[InlineData("simpleuser", "WebApiCore1#", "WebApiCore1#")]
		public async Task WhenNoRegisteredUser_SignUp_WithModelError_Return_BadRequest(string email, string passWord, string ConfirmPassword)
		{
			// Arrange
			
			var obj = new RegisterDto
			{
				Email= email,
				Password = passWord,
			    BirthDate = new DateTime(1988, 7, 26, 11, 15, 45),
			    PhoneNumber = TestHelper.GenerateRandomPhoneNumber(),
			    UserName = email,
			    ImageUrl = "https://kids.nationalgeographic.com/content/dam/kids/photos/animals/Mammals/A-G/chimpanzee-with-baby.ngsversion.1412621761167.adapt.1900.1.jpg"
            };


            string stringData = JsonConvert.SerializeObject(obj);
			var contentData = new StringContent(stringData, Encoding.UTF8,"application/json");

			// Act
			var response = await Client.PostAsync($"/api/auth/register", contentData);

			// Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
		[Fact]
		public async Task WhenNoRegisteredUser_SignUp_WithValidModelState_Return_OK()
		{
			// Arrange
			var obj = new RegisterDto
            {
				Email = "simpleuser@yopmail.com",
				Password = "WebApiCore1#",
                BirthDate = new DateTime(1988, 7, 26, 11, 15, 45),
                PhoneNumber = TestHelper.GenerateRandomPhoneNumber(),
                UserName = "simpleuser@yopmail.com",
                ImageUrl = "https://kids.nationalgeographic.com/content/dam/kids/photos/animals/Mammals/A-G/chimpanzee-with-baby.ngsversion.1412621761167.adapt.1900.1.jpg"
            };


			string stringData = JsonConvert.SerializeObject(obj);
			var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
			// Act
			var response = await Client.PostAsync($"/api/auth/register", contentData);

			// Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}

