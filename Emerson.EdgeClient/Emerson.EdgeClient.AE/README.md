# Edge Client SDK

# Table of Contents
- [Edge Client SDK](#edge-client-sdk)
- [Table of Contents](#table-of-contents)
- [About](#about)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
- [Usage](#usage)
  - [Alarm and Events](#alarm-and-events)
- [Sample Clients](#sample-clients)
- [Authors](#authors)

# About

This repository contains a C# Edge REST API Client SDK implemented via HttpClient to simplify Edge REST API consumption. The currently available Edge endpoint covered in this SDK is Alarm and Events.

# Getting Started

## Prerequisites

Before working with this SDK, please ensure that you have setup the following with your Edge installation:


```
1. A working and reachable Edge REST API endpoint
2. Authorized Credentials for your Edge REST API endpoint
3. Authenticated endpoint to reach for Alarms and Events
```
For more information, please consult the Edge Environment User Guide.

# Usage

## Alarm and Events
Emerson.EdgeClient.AE

[![NuGet Version](https://img.shields.io/nuget/v/DeltaV.EdgeClient.AE)](https://www.nuget.org/packages/DeltaV.EdgeClient.AE) ![NuGet Downloads](https://img.shields.io/nuget/dt/DeltaV.EdgeClient.AE)

```
var client = GetAuthenticatedClient(); //see Authentication sample.

var history = await client.GetAeAsync(pageSize, pageNumber);
```

# Sample Clients
Check out our sample code here to learn more.
  * [ConsoleApp](./samples/ConsoleApp/readme.md)

# Authors

- Lawrence Benitez
- Peter Balanag
- Gershon Young
- Carlo Tamayo

