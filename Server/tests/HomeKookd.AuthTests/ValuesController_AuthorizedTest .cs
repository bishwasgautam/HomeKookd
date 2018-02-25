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
	public class ValuesControllerAuthorizedTest  : IClassFixture<TestFixture<TestStartup>>
	{
		public ValuesControllerAuthorizedTest(TestFixture<TestStartup> fixture)
		{
			Client = fixture.httpClient;
		}

		public HttpClient Client { get; }

		[Fact, TestPriority(1)]
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

		[Theory, TestPriority(2)]
		[InlineData("POST","myRequestBody")]
		[InlineData("GET", "myRequestBody")]
		[InlineData(new object[] { "PUT", "myRequestBody", 1 })]
		[InlineData(new object[] { "DELETE", "myRequestBody", 1 })]
		public async Task WhenAuthenticatedUser_MakeRequestRequest_Return_Ok(string method,string obj =null, int? id =null)
		{
			// Arrange
			var jwToken = await getJwToken();
			string token =$"bearer {jwToken.token}";
						
			string stringData = JsonConvert.SerializeObject(obj);
			var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

			var request = new HttpRequestMessage(new HttpMethod(method), $"/api/values/{id}");
			request.Content = contentData;
			request.Headers.Add("Authorization", token);

			// Act
			var response = await Client.SendAsync(request);

			// Assert
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}

		private async Task<JwToken> getJwToken()
		{
			var loginViewModel = new LoginDto()
			{
				UserName = "simpleuser@yopmail.com",
				Password = "WebApiCore1#"
			};
			string loginViewModelData = JsonConvert.SerializeObject(loginViewModel);
			var contentData = new StringContent(loginViewModelData, Encoding.UTF8, "application/json");

			var response = await Client.PostAsync($"/api/auth/token", contentData);
			response.EnsureSuccessStatusCode();
			var jwToken = JsonConvert.DeserializeObject<JwToken>(
				await response.Content.ReadAsStringAsync());
			return jwToken;
		}
	}
}

