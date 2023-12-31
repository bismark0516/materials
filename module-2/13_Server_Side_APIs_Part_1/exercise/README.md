# Server-Side APIs: Part 1 Exercise

Previously, you created a command-line application that made requests to an API server. In this exercise, you'll recreate the API server in C# to handle `GET` and `POST` requests.

## Step One: Open solution and explore starting code

Open `ServersideAPIsPart1Exercise.sln` and expand the folders in the `AuctionApp` project.

### Models

In the `Models` folder, there's an `Auction` model that has the same properties as the `Auction` class you've been working with.

### DAO

In the `DAO` folder, there's an `AuctionMemoryDao` class, that provides data access code. To reduce complexity, the applications uses a static `List` instead of a SQL database. Look at the interface `IAuctionDao.cs` for the methods you'll call from the controller.

### Controllers

In the `Controllers` folder, there's an `AuctionsController` class that you'll work in today. You'll create the action methods for the API. The controller class is already decorated with the `[Route]` and `[ApiController]` attributes.

Note the value `[Route]` attribute. The name of the controller is `AuctionsController`—this means the route for the controller is `/auctions`.

### Unit tests

In the `AuctionApp.Tests` project, you'll find the unit tests for the methods you'll write today. After you complete each step, more tests pass.

If you also want to run the server and test with Postman or the browser, feel free to do so. However, your goal is to make sure all the unit tests pass.

## Step Two: Implement `GET` `/auctions`

This method's purpose is to return a list of all auctions.

Create a method that responds to `GET` requests for `/auctions`. Look in `IAuctionDao.cs` for a method that returns all auctions.

If completed properly, the `GetAuctions_ExpectList` test passes.

## Step Three: Implement `GET` `/auctions/id`

This method's purpose is to return a specific auction based on the value passed to it.

Create a method that responds to `GET` requests for `/auctions` with a number following it—for example, `/auctions/7`. Look in `IAuctionDao.cs` for a method that returns a specific auction.

If completed properly, the `GetAuction_SpecificAuction_ExpectAuction` and `GetAuction_NonExistentAuction_ExpectEmpty` tests pass.

## Step Four: Implement `POST` `/auctions`

This method's purpose is to add the auction that's passed to it.

Create a method that responds to `POST` requests for `/auctions`. Look in `IAuctionDao.cs` for a method that creates an auction. The controller method must pass the newly created auction back to the client.

If completed properly, the `CreateAuction_ExpectAuction` test passes.

## Step Five: Add searching by title

The purpose of this step is to enable searching by title. You'll modify the `list()` method to accept an optional query string parameter that returns all auctions with the search term in the title. The URL to use this would look like `/auctions?title_like=` with a search term following it.

Return to the method you created that responds to `GET` requests for `/auctions`. Add a `string` parameter to the method with the name `title_like`—this allows the method to respond to requests for `/auctions?title_like=`.

You'll need to make this parameter optional, which means you set a default value for it in the parameter declaration. In this case, you want to set the default value to an empty string `""`. Your parameter declaration must look like `string title_like = ""`.

Look in `IAuctionDao.cs` for a method that returns auctions that have titles containing a search term. Return that result in the controller method if `title_like` contains a value, otherwise return the full list like before.

If completed properly, the `SearchByTitle_ExpectList` and `SearchByTitle_ExpectNone` tests pass.

## Step Six: Add searching by price

The purpose of this step is to enable searching by price. You'll modify the `list()` method to accept an optional query string parameter that returns all auctions with the current bid less than or equal to the value passed to it. The URL to use this would look like `/auctions?currentBid_lte=` with a numeric value following it.

Return to the method you created that responds to `GET` requests for `/auctions`. Add another optional parameter after `title_like`—this time a `double` with the name `currentBid_lte`.

This responds to requests for `/auctions?currentBid_lte=`. Set the default value to `0`. If you already declared `title_like`, you can figure out how to declare `currentBid_lte`.

Look in `IAuctionDao.cs` for a method that returns auctions based on prices being less than or equal to a certain amount. Return that result in the controller method if `currentBid_lte` is greater than zero.

You might be thinking, "Wait, what if the client searches with both parameters?" There's another method in `IAuctionDao.cs` that returns search results for both parameters. Add a call to this method if a request has both parameters. In the controller method, determine when to call the search methods and when to call the method that returns the full list.

If completed properly, the `SearchByPrice_ExpectList`, `SearchByPrice_ExpectNone`, `SearchByTitleAndPrice_ExpectList`, and `SearchByTitleAndPrice_ExpectNone` tests pass.

---

If you completed all of the steps correctly, all of your tests pass.
