# Java API Counter

## Learning Objectives
- Use Spring Boot Web to build a simple API
- Use RestController classes to map HTTP requests to class methods

## Instructions

1. Fork this repository
2. Clone your fork to your machine
3. Open the project in Visual Studio
4. In the `CounterController` class, implement the requirements below

## Core Requirements

You're going to build a simple counter API that stores a number in memory, then provide routes to increment, decrement and retrieve the value of the number.

Use this documentation as a reference guide for the controllers: https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0
- You can ignore the @EXTENSIONS tags for now
1. Annotate the `CounterController` class appropriately to set it up as a REST controller, and map all requests of `http://localhost:4000/counter` to it
   1. Route decorators look like this `[HttpGet("/url/path", Name = "Appropriate endpoint name")]`, `[HttpPost("/url/path", Name = "Appropriate endpoint name")]`
2. Create a GET method that responds with the current value of the counter. Its initial value should always be 0
3. Create a GET method that maps to the route `http://localhost:4000/counter/increment` that increases the counter by 1 and responds with the updated value. The method you created in step 2 should also now respond with the updated value
4. Create a GET method that maps to the route `http://localhost:4000/counter/decrement` that decreases the counter by 1 and responds with the updated value
5. After you are done, you will need to update the CoreTests.cs file
   1. Open CoreTests.cs
   2. Find the lines that have a @TODO
   3. On the line after the @TODO you will need to replace the PlaceholderFunction with the name of you function in your controller

## Extension Requirements

1. Create a GET method that maps to the route `http://localhost:4000/counter/custom/{name}`
    - `{name}` is a path variable, the client can provide any string they want
    - If a counter with the provided name does not already exist, a new counter should be created with the name provided in the path variable, initialised to a value of 0
    - If a counter with the provided name does exist, the route should respond with the current value of the named counter
2. Create a GET method that maps to the route `http://localhost:4000/counter/custom/{name}/increment`
   - If a counter with the provided name exists, increase the value of that counter by 1 and then respond with the new value
   - If a counter with the provided name does not exist, it should be created and initialised with a value of 1
   - The route you created in step 1 should respond appropriately
3. Create a GET method that maps to the route `http://localhost:4000/counter/custom/{name}/decrement`
    - If a counter with the provided name exists, decrease the value of that counter by 1 and then respond with the new value
    - If a counter with the provided name does not exist, it should be created and initialised with a value of -1
    - The previous routes you created should respond appropriately

Tips for extensions:
- Check the comments that have the @EXTENSIONS tag

## Further work

Explore the documentation of the ASP.NET framework as much as you are able, you'll be using it for almost everything going forward. We'll be introducing new components of the framework in future exercises.

Try building your own simple API using what you've learned so far.