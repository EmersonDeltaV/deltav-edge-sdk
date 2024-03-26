<h3 align="center">Edge Client SDK</h3>

---

## Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Usage](#usage)
- [Authors](#authors)

## About <a name = "about"></a>

This repository contains a C# Edge REST API Client SDK implemented via HttpClient to simplify Edge REST API consumption. The currently available Edge endpoints covered in this SDK are Authentication, Graph, History, and Alarm and Events.

## Getting Started <a name = "getting_started"></a>

### Prerequisites

Before working with this SDK, please ensure that you have setup the following with your Edge installation:

```
1. A working and reachable Edge REST API endpoint
2. Authorized Credentials for your Edge REST API endpoint
```
For more information, please consult the Edge Environment User Guide.

## Usage <a name="usage"></a>

### Authentication
Emerson.EdgeClient.Authentication

```
var handler = new HttpClientHandler();
var client = new HttpClient(handler);

var edgeUrl = "https://localhost/"; //add your Edge REST API IP here
var user = "user"; //add your REST API username here
var pass = "pass"; //add your REST API password here

client.BaseAddress = new Uri(edgeUrl);
var token = await edgeClient.RequestClientTokenAsync(new Emerson.EdgeClient.Authentication.Models.Credentials()
        {
            Username = user,
            Password = pass
        });

edgeClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

```

### Graph

Emerson.EdgeClient.Graph

```
var client = GetAuthenticatedClient(); //see Authentication sample.

var entity = await client.GetGraphByEntityIdAsync(entityId, propertyList, relationshipList);
```

### History
Emerson.EdgeClient.History
```
var client = GetAuthenticatedClient(); //see Authentication sample.

var history = await client.GetHistoryByIdAsync(entityId, field);
```

### Alarm and Events
Emerson.EdgeClient.AE
```
var client = GetAuthenticatedClient(); //see Authentication sample.

var history = await client.GetAeAsync(pageSize, pageNumber);
```

## Authors <a name = "authors"></a>

- Lawrence Benitez
- Peter Balanag
- Gershon Young
- Carlo Tamayo

