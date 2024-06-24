# Uzbek Cuisines
<!-- TOC -->
- [Overview](#overview)
    - [Features](#features)
    - [Getting Started](#getting-started)
    - [Running the Solution](#running-the-solution)
<!-- TOC -->

## Overview
Uzbek Cuisines was designed to solve the most important business challenges from the world of digital shopping. The goal is to provide the platform with:
* The high performance application to handle temporary and permanent traffic overloads,
* Highly advanced e-commerce platform with unlimited possibilities of integration with existing third-party softwares
* Fast development with modern codebase
* Scalable e-commerce platform to grow with the business

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

## Getting Started

### Installation

1. Install the SSW CA template

```bash
dotnet new install FreshMarket.Template
```

> NOTE: The template only needs to be installed once. Running this command again will update your version of the template.

2. Create a new directory

```bash
mkdir Northwind365
cd Northwind365
```

3. Create a new solution

```bash
dotnet new ssw-ca
```

> NOTE: `name` is optional; if you don't specify it, the directory name will be used as the solution name and project namespaces.

Alternatively, you can specify the `name` and `output` directory as follows:

```bash
dotnet new ssw-ca --name {{SolutionName}} --output .\
```

### Adding a Feature

1. Create a query

```bash
cd src/Application/Features
mkdir {{FeatureName}}
cd {{FeatureName}}
dotnet new ssw-ca-query --name {{QueryName}} --entityName {{Entity}} --slnName {{SolutionName}}
```

2. Create a command

```bash
cd src/Application/Features
mkdir {{FeatureName}}
cd {{FeatureName}}
dotnet new ssw-ca-command --name {{CommandName}} --entityName {{Entity}} --slnName {{SolutionName}}
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


You should be able to make requests to localhost:5001 for the Public API project once these commands complete. If you have any problems, especially with login, try from a new guest or incognito browser instance.

You can also run the applications by using the instructions located in their `Dockerfile` file in the root of each project. Again, run these commands from the root of the solution (where the .sln file is located).


