# Moviegram
Hi Tigerspike

One could spend an awful lot of time doing these tests.  This one took me a fair bit longer as I ran into some sql server installation issues.  Then it turned out the problem was me - I hadn't realised with EF Core that firing up the app and using it would not create the database like older EF would.

I've implemented the basic API functionality for Movies and MovieViewTime, but decided that since MovieViewListItem was a subset of Movie, there is no post, put or delete functionality for it.  I've placed MovieViewListItem in a viewmodels 
folder to help differentiate it from other models that are mapped to the db via EF.

I have implemented a repository pattern for the MoviesController to allow for unit testing, however, I have not repeated the same for the MoviesViewTime controller as hopefully my one example is enough to illustrate.  There are basic unit tests to illustrate controller testing and the simplistic behaviour of the MovieViewListItem.  Whilst I have put Thumbnail and FullImage fields of the Movie class, I decided against burning hours testing that upload functionality as uploading immages is not my strong point.

Would love to talk to you all
Regards
Jase
