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
using System.Xml.Linq;
using static DemoQA.API.LocalAPIResponse;

namespace DemoQA
{
    public class LocalAPITest
    {
        PageObject page;
        PageObjectChain pageObjectChain;
        public LocalAPITest()
        {
            page = new PageObject();
            pageObjectChain = new PageObjectChain();
        }

        [Test]
        public void Fixtures()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:3000/fixtures", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(response.StatusCode.ToString() == "OK");
                Assert.AreEqual("OK", response.StatusCode.ToString());
                //Assert.IsTrue(response.Content.Contains("george.bluth@reqres.in"));
              
            });
           // response.StatusCode.ToString().Should().Be("OK");
        }



        [Test]

        public void FixturesPost()
        {

            var payload = new Root()
            {
                fixtureId = "234",
                fixtureStatus = new FixtureStatus()
                {
                    displayed = true,
                    suspended = false,
                },
                footballFullState = new FootballFullState()
                {
                    homeTeam = "Abiola Babes",
                    awayTeam = "Eyinba",
                    finished = true,
                    gameTimeInSeconds = 95,
                    goals = new List<Goal>
                    {
                        new Goal()
                        {
                              clockTime = 56,
                              confirmed = true,
                              id = 5,
                              ownGoal = true,
                              penalty = false,
                              period = "first half",
                              playerId = 8,
                              teamId = "2",

                        },
                         new Goal()
                        {

                        },
                          
                    },
                    period = "Second Half",
                    possibles = new List<object>
                    {

                    },
                    corners = new List<object>
                    {

                    },
                    redCards = new List<object> { },
                    yellowCards = new List<object> { },
                    startDateTime = DateTime.Now,
                    started = true,
                    teams = new List<Team>
                    {
                        new Team()  
                        {
                             association = "Rauplrt",
                             name = "Zulu",
                             teamId = "33",

                        },

                    }
                }

            };

           // string pl = JsonConvert.SerializeObject(payload);  
            var response = pageObjectChain.SendRequest(pageObjectChain.FixtureUrl , "/fixtures", Method.Post, payload);
            var des = JsonConvert.DeserializeObject<Root>(response.Content);
            if (response.IsSuccessful == true)
            {
                response.StatusCode.Should().Be(HttpStatusCode.Created);
                Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);

               
                //Assert.AreEqual("Captain", des.name);
                //Assert.AreEqual("Teacher", des.job);
              
            }
        }
    }
}
