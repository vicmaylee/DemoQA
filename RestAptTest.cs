using DemoQA.API;
using DemoQA.APIPageObject;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace DemoQA
{
    public class RestAptTest
    {
        PageObject page;
        PageObjectChain pageObjectChain;
        public RestAptTest()
        {
            page = new PageObject();
            pageObjectChain = new PageObjectChain();
        }

        [Test]
        public void RestPostman()
        {
            var client = new RestClient();
            var request = new RestRequest("https://reqres.in/api/users?", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(response.StatusCode.ToString() == "OK");
                Assert.AreEqual("OK", response.StatusCode.ToString());
                Assert.IsTrue(response.Content.Contains("george.bluth@reqres.in"));
              
            });
           // response.StatusCode.ToString().Should().Be("OK");
        }


        [Test]
        public void RestPostmanUsers()
        {
            var client = new RestClient();
            var request = new RestRequest("https://reqres.in/api/users?", Method.Get);
            RestResponse response = client.Execute(request);
            UserList? myDeserializedClass = JsonConvert.DeserializeObject<UserList>(response.Content);

            if (response.IsSuccessful == true)
            {
                Assert.Multiple(() =>
                {
                    Assert.IsTrue(response.StatusCode.ToString() == "OK");
                    Assert.AreEqual("OK", response.StatusCode.ToString());

                    // Values at index of One
                    Assert.AreEqual("george.bluth@reqres.in", myDeserializedClass.data[0].email);
                    Assert.AreEqual("George", myDeserializedClass?.data[0].first_name);
                    Assert.AreEqual("Bluth", myDeserializedClass.data[0].last_name);

                    // Values at index of Two
                    Assert.AreEqual("janet.weaver@reqres.in", myDeserializedClass.data[1].email);
                    Assert.AreEqual("Janet", myDeserializedClass.data[1].first_name);
                    Assert.AreEqual("Weaver", myDeserializedClass.data[1].last_name);
                });
            }
            else
            {
                Assert.Fail(String.Format($" The {response} server seems to be down"));
            }            
        }

        [Test]

        public void GetSingleUser()
        {
            var client = new RestClient();           
            var request = new RestRequest("https://reqres.in/api/users/3", Method.Get);
            RestResponse response = client.Execute(request);
            SingleUser? myDeserializedClass = JsonConvert.DeserializeObject<SingleUser>(response.Content);
            if (response.IsSuccessful == true)

            {
                Assert.IsTrue(response.StatusCode.ToString() == "OK");
                Assert.AreEqual("OK", response.StatusCode.ToString());
                Assert.AreEqual("emma.wong@reqres.in", myDeserializedClass.data.email);
                Assert.AreEqual("Emma", myDeserializedClass?.data.first_name);
                Assert.AreEqual("Wong", myDeserializedClass.data.last_name);
            }   

        }

        [Test]

        public void BookStore()
        {
            var client = new RestClient();
            var request = new RestRequest("https://demoqa.com/BookStore/v1/Books", Method.Get);
            RestResponse response = client.Execute(request);
            AllBooks? myDeserializedClass = JsonConvert.DeserializeObject<AllBooks>(response.Content);
            Console.WriteLine(response.Content);

            Assert.IsTrue(response.StatusCode.ToString() == "OK");
            Assert.AreEqual("OK", response.StatusCode.ToString());
            Assert.AreEqual("9781449325862", myDeserializedClass.books[0].isbn);
            Assert.AreEqual("Git Pocket Guide", myDeserializedClass.books[0].title); 
            Assert.AreEqual("A Working Introduction", myDeserializedClass.books[0].subTitle);
            string descriptions = "This pocket guide is the perfect on-the-job companion to Git, the distributed version control system. It provides a compact, readable introduction to Git for new users, as well as a reference to common commands and procedures for those of you with Git exp";
            Assert.AreEqual(descriptions, myDeserializedClass.books[0].description);

        }

        [Test]
        public void GetListUsersPageObject()
        {
            var client = page.SetUrl();
            var request = page.GetRequest("/api/users", Method.Get);
            var response = page.GetResponse(client, request);
            var myDeserializedClass = page.GetDeserializedContent<UserList>(response);

            if (response.IsSuccessful == true)
            {
                Assert.Multiple(() =>
                {
                    Assert.IsTrue(response.StatusCode.ToString() == "OK");
                    Assert.AreEqual("OK", response.StatusCode.ToString());

                    // Values at index of One
                    Assert.AreEqual("george.bluth@reqres.in", myDeserializedClass.data[0].email);
                    Assert.AreEqual("George", myDeserializedClass?.data[0].first_name);
                    Assert.AreEqual("Bluth", myDeserializedClass.data[0].last_name);

                    // Values at index of Two
                    Assert.AreEqual("janet.weaver@reqres.in", myDeserializedClass.data[1].email);
                    Assert.AreEqual("Janet", myDeserializedClass.data[1].first_name);
                    Assert.AreEqual("Weaver", myDeserializedClass.data[1].last_name);
                });
            }
            else
            {
                Assert.Fail(String.Format($" The {response} server seems to be down"));
            }

        }

        [Test]

        public void GetSingleUserPageObject()
        {
            var client = page.SetUrl();
            var request = page.GetRequest("/api/users/3", Method.Get);
            var response = page.GetResponse(client, request);
            var myDeserializedClass = page.GetDeserializedContent<SingleUser>(response);

            if (response.IsSuccessful == true)

            {
                Assert.IsTrue(response.StatusCode.ToString() == "OK");
                Assert.AreEqual("OK", response.StatusCode.ToString());
                Assert.AreEqual("emma.wong@reqres.in", myDeserializedClass.data.email);
                Assert.AreEqual("Emma", myDeserializedClass?.data.first_name);
                Assert.AreEqual("Wong", myDeserializedClass.data.last_name);
            }
            else
            {
                Assert.Fail(String.Format($" The {response} server seems to be down"));
            }

        }

        [Test]

        public void GetSingleUsersWithChainsMetod()
        {
            var myDeserializedClass = pageObjectChain.SetUrl()
                .GetRequest("/api/users/3", Method.Get).Build<SingleUser>();
            var response = pageObjectChain.GetMyResponse();


            //if (response.IsSuccessful == true)

            //{
            //    Assert.IsTrue(response.StatusCode.ToString() == "OK");
            //    Assert.AreEqual("OK", response.StatusCode.ToString());
            //    Assert.AreEqual("emma.wong@reqres.in", myDeserializedClass.data.email);
            //    Assert.AreEqual("Emma", myDeserializedClass?.data.first_name);
            //    Assert.AreEqual("Wong", myDeserializedClass.data.last_name);
            //}
            //else
            //{
            //    Assert.Fail(String.Format($" The {response} server seems to be down"));
            //}

        }

        [Test]

        public void GetRequestUsingSingleMethod()
        {
            var response = pageObjectChain.SendRequest(pageObjectChain.baseUrl,"/api/users/3", Method.Get);
            var des = JsonConvert.DeserializeObject<SingleUser>(response.Content);
            if (response.IsSuccessful == true)
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

                Assert.AreEqual(3, des.data.id); 
                Assert.AreEqual("emma.wong@reqres.in", des.data.email);
                Assert.AreEqual("Emma", des.data.first_name);
                Assert.AreEqual("Wong", des.data.last_name);
                Assert.AreEqual("https://reqres.in/img/faces/3-image.jpg", des.data.avatar);

            }
        }


        [Test]

        public void PostRequestUsingSingleMethod()
        {
            var payload = new ReqresRequestPayload()
            {
                name = "Captain",
                job = "Teacher"
            };

           // string pl = JsonConvert.SerializeObject(payload);  
            var response = pageObjectChain.SendRequest(pageObjectChain.baseUrl, "/api/users", Method.Post, payload);
            var des = JsonConvert.DeserializeObject<ReqresResponseModule>(response.Content);
            if (response.IsSuccessful == true)
            {
                response.StatusCode.Should().Be(HttpStatusCode.Created);
                Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);

               
                Assert.AreEqual("Captain", des.name);
                Assert.AreEqual("Teacher", des.job);
              
            }
        }
    }
}
