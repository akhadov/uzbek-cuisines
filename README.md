# Uzbek Cuisines
<!-- TOC -->
- [Overview](#overview)
    - [Features](#features)
    - [Prerequisites](#prerequisites)
    - [Getting Started](#getting-started)
    - [Running the Solution](#running-the-solution)
<!-- TOC -->

## Overview
National foods in Uzbek kitchens attracts everyone, it is always tasty and interesting 😋

## Features

- Minimal Endpoints
- Global Exception Handling
- OpenAPI/Swagger
- Entity Framework Core
- Result Pattern
- CQRS
- MediatR
- FluentValidation
- Dapper

## Prerequisites

- [Install & start Docker Desktop](https://docs.docker.com/engine/install/)

### Windows with Visual Studio
- Install [Visual Studio 2022 version 17.10 or newer](https://visualstudio.microsoft.com/vs/).
  - Select the following workload:
    - `ASP.NET and web development` workload.
      
## Getting Started

### Setup

Follow these steps to get your development environment set up:

1. Clone the repository
2. At the root directory, restore required packages by running:

```bash
 dotnet restore
```

3. Next, build the solution by running:

```bash
dotnet build
```

### Running the Solution

1. Start dockerized PostgreSQL Server

```bash
docker compose up
```

2. Run the solution

```bash
dotnet run
```

> **NOTE:** The first time you run the solution, it may take a while to download the docker images, create the DB, and seed the data.

Launch [https://localhost:5001/api](http://localhost:5000/api) in your browser to view the API
   
You should be able to make requests to localhost:5001 for the Public API project once these commands complete. If you have any problems, especially with login, try from a new guest or incognito browser instance.

You can also run the applications by using the instructions located in their `Dockerfile` file in the root of each project. Again, run these commands from the root of the solution (where the .sln file is located).


