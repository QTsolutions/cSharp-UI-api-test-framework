using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UiandApiTest.Pages.Api.DTO;

namespace UiandApiTest.Pages.Api
{
    public class Demo
    {
        public static ApiHelper user;
        public static RestClient url;
        public static RestResponse response;
        public void getResponse(RestClient url, RestRequest request)
        {
            response = user.GetResponse(url, request);

        }

        public void setUp(string endpoint)
        {
            user = new ApiHelper();
            url = user.SetUrl(endpoint);
        }
        public void GetStatusCode(int code)
        {
            HttpStatusCode statusCode = response.StatusCode;
            int numericCode = (int)statusCode;
            Assert.IsTrue(numericCode.Equals(code));
        }

        public ListOfUserDTO GetUsers(string endpoint)
        {
            Demo d = new Demo();
            d.setUp(endpoint);
            RestRequest request = user.CreateGetRequest();
            d.getResponse(url, request);
            d.GetStatusCode(200);
            ListOfUserDTO content = user.GetContent<ListOfUserDTO>(response);
            return content;
        }

        public CreateUserRequestDTO CreateUser(string endpoint, dynamic payload)
        {
            Demo d = new Demo();
            d.setUp(endpoint);
            var jsonReq = user.Serialize(payload);
            var request = user.CreatePostRequest(jsonReq);
            d.getResponse(url, request);
            d.GetStatusCode(201);
            CreateUserRequestDTO content = user.GetContent<CreateUserRequestDTO>(response);
            return content;
        }

        public UpdateUserDTO UpdateUser(string endpoint, dynamic payload)
        {
            Demo d = new Demo();
            d.setUp(endpoint);
            var request = user.CreatePutRequest(payload);
            d.getResponse(url, request);
            d.GetStatusCode(200);
            UpdateUserDTO content = user.GetContent<UpdateUserDTO>(response);
            return content;
        }

        public ListOfUserDTO DeleteUser(string endpoint)
        {
            Demo d = new Demo();
            d.setUp(endpoint);
            var request = user.CreateDeleteRequest();
            d.getResponse(url, request);
            ListOfUserDTO content = user.GetContent<ListOfUserDTO>(response);
            return content;
        }
    }
}
