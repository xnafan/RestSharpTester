# RestSharpTester
Sample code to communicate with a REST service using a custom REST client.

## Data Access Layer "CustomerDataAccessLayer"
Is a stub which stores a list of customers in a static List<Customer>, to emulate CRUD on a database.

## Web Api "RestService"
Implements a CustomerController with CRUD and an extra Search method which takes arguments from the querystring.
Also has a CustomerDTO model object without the attribute ``public bool IsReliable { get; set; }`` from the Data Access Layer's Customer model, because we don't want this information sent over the web.

##Console app "RestSharpTesterConsole"
Application which holds uses the RestClient to perform CRUD on the data via the Web API.

<img width="854" alt="image" src="https://user-images.githubusercontent.com/3811290/202298792-64c9fc8c-6955-423e-af02-5674428e8ff8.png">

