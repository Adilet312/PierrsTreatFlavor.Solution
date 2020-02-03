# Pierr's Bakery : The C# Web App
### By Adilet Momunaliev
-----

## Description
* Pierr's Bakery C# Web App that has "many to many" database relationship 
## DataBase

## Technologies Used
* C#
* .NET
* ASP.NET Core MVC
* HTML
* MSTest

## Installation
* Clone project repo
* From the project's root directory, open console and type dotnet run

```sh
$ git clone 
$ cd  
$ dotnet run
```

## Specs

| Behaviors       | Input          | Output      |
| ---------------- |:------------:| :--------------:|


## Project Directory
1. Model Directory
    * contains project's class files 
    * this is where your classes go
2. Project.csproj
    * things needed to install 
    * dotnet restore -- will install dependencies
3. Views
4. Controllers

## Project.Tests Directory
1. ModelTests Directory
    * your tests will be here
2. Project.Tests.csproj
    * make sure update the ProjectReference !
    * run dotnet restore to install the dependencies
---

# Notes on this project
## forms
* Action Attribute- indicates where the given form will route to in the project
* Method Attribute- need a post method if form is being used to create a new object
* required eliments
* submit button
* remember to add route to HomeController!
* Name Attribute- matches the route decorator in controller

# HomeController
* the link from Index.cshtml invokes this route
* returns View()
* the name of the ActionResult is the same name as the .cshtml file, so knows which one to choose to render
* The CreateForm() route method will automatically render this view.

# View()
* can have varying number of arguments
* first- specify the vire that should be returned
* second- specify what the Model property on the view should be

# Action Result
* class that Routes return

# Route Decorator
* kind of like the argument that goes inside route
* matches the name attribute of the form action

# Generating a Request
* Three ways to access a page- 
  * type url
  * click a link
  * submit a form
* client makes server request
* Method, Path, Headers, Body 
* Verbs are another word for http methods

* post requests aim to change something on the website's server
  * examples: add, update, delete

* Path - itendifies the web resources that should be retrieved/acted on (GET/POST)
* Headers- provide server more info about the client, server and request
  * host-- domain of ther server
  * user-agent-- software acting on behalf of the suer to make the request
  * Accept-language-- human language accepted for response

* Body-- any data that must be sent to server
  * ex: the info in a form that a user entered

* Viewing Requests
  * use chrome developer tools to view
  
* Routing in MVC Controllers
  * controller is responsible for bringing view data and class methods together
  * route decorators indicate the corresponding path
  * Does our application make a server?
  * our server can identify what resource should be retrieved and sent back
  * executes the route's code

# better annotaton for defining the routes
* [HttpGet("route-name")] for GET
* [HttpPost("route-name)] for POST

* the browser receives the response from the server, it then renders the HTML into a viewable format for the user.
