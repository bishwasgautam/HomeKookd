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
	[TestCaseOrderer("TokenAuthWebApiCore.Server.IntegrationTest.Setup.PriorityOrderer", "TokenAuthWebApiCore.Server.IntegrationTest")]
	public class AuthControllerTokenTest : IClassFixture<TestFixture<TestStartup>>
	{
		public HttpClient Client { get; }
		public AuthControllerTokenTest(TestFixture<TestStartup> fixture)
		{
			Client = fixture.httpClient;
		}
		
		[Fact(DisplayName = "WhenNoRegisteredUser_SignUpForToken_WithValidModelState_Return_OK"), TestPriority(1)]
		public async Task WhenNoRegisteredUser_SignUpForToken_WithValidModelState_Return_OK()
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

		[Fact(DisplayName = "WhenRegisteredUser_SignIn_WithValidModelState_Return_ValidToken"), TestPriority(2)]
		public async Task WhenRegisteredUser_SignIn_WithValidModelState_Return_ValidToken()
		{
			// Arrange
			var obj = new LoginDto
			{
				UserName = "simpleuser@yopmail.com",
				Password = "WebApiCore1#"
			};
			string stringData = JsonConvert.SerializeObject(obj);
			var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
			// Act
			var response = await Client.PostAsync($"/api/auth/token", contentData);
			response.EnsureSuccessStatusCode();
			// Assert
			
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
			
			var jwToken = JsonConvert.DeserializeObject<JwToken>(
				await response.Content.ReadAsStringAsync());
			Assert.True(jwToken.expiration > DateTime.UtcNow);
			Assert.True(jwToken.token.Split('.').Length == 3);
		}
	}
}

