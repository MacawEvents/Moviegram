using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviegramAPI.Controllers;
using MoviegramAPI.Models;
using MoviegramAPI.ViewModels;
using System.Linq;

namespace MoviegramTests.Controllers
{
    [TestClass]
    public class MoveListItemTests
    {
        [TestMethod]
        public void Properties_Correctly_Mapped()
        {
            Movie source = new Movie { MovieId = 1, Details = "Some details", Thumbnail = new byte[] { } };
            MovieListItem subject = new MovieListItem(source);

            Assert.AreEqual(1, subject.MovieId);
            Assert.AreEqual(0, subject.Thumbnail.Length);
            
            //etc etc
        }

    }
}
