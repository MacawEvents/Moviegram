using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviegramAPI.Controllers;
using MoviegramAPI.Models;
using System.Linq;

namespace MoviegramTests.Controllers
{
    [TestClass]
    public class MoviesControllerTest
    {
        [TestMethod]
        public void GetMovies_Returns_AllMovies()
        {
            MoviesController subject = new MoviesController(new MockedMovieRepository());
            Assert.AreEqual(2, subject.GetMovie().Count());
        }

        [TestMethod]
        public void GetMovies_Returns_SingleMovie_And_200()
        {
            MoviesController subject = new MoviesController(new MockedMovieRepository());
            OkObjectResult results = subject.GetMovie(2) as OkObjectResult;
            Assert.AreEqual(200, results.StatusCode.Value);
            Assert.AreEqual(2, ((Movie)results.Value).MovieId);
        }

        // Et cetera - more tests to prove the controller and various return codes
    }
}
