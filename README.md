# Instructions

Open the following link :-

- [PaxFerdeenExcercise.Web](http://paxsossolution-dev-as.azurewebsites.net/)

Select the _API Documentation (Swagger)_ link [(or select it here)](http://paxsossolution-dev-as.azurewebsites.net/swagger/index.html).

This will allow you test the WebAPI endpoints using Swagger.

The endpoints of interest are :-

* POST /api/Messages
* GET /api/Messages

### POST /api/Messages

#### Swagger
Click the "POST /api/Messages panel", click the "Try it out" button.  Type a message, in the text box. For example :-

```
{
  "message": "Ferdeen"
}

```
Then click the "Execute" button.  The response will be :-

```
{
  "id": 1,
  "message": "Ferdeen",
  "digest": "94614313b6ab9fc78ff632295ebeb5a4ab993316f6ba0392ceb7811fc4da4435"
}
```

#### Curl

```
curl -X POST "http://paxsossolution-dev-as.azurewebsites.net/api/Messages" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{ \"message\": \"Ferdeen\"}"
```

### GET /api/Messages

#### Swagger
Click the "GET /api/Messages panel", click the "Try it out" button.  Copy and paste the generated hash from above into the text "Digest" text box.  Then click "Execute".  

The response will be :-

```
"Ferdeen"
```

#### Curl

```
curl -X GET "http://paxsossolution-dev-as.azurewebsites.net/api/Messages?digest=94614313b6ab9fc78ff632295ebeb5a4ab993316f6ba0392ceb7811fc4da4435" -H "accept: application/json"
```



### Extras

I've created extra WebAPI endpoints to populate and get message from the store. Also to flush out the messages from the store.

* GET /api/Messages/Populate
* GET /api/Messages/GetMessages
* GET /api/Messages/FlushMessages
* GET /api/Messages/{id}

Finally these endpoints are also available on the [PaxFerdeenExcercise.Web](http://paxsossolution-dev-as.azurewebsites.net/) via _Message Items (MVC)_ and _Message Items (Razor Pages)_.