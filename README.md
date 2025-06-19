# MyCRUDApp
# ASP.NET Core MVC + Web API CRUD Projects

This repository contains two related projects:

## 📁 Projects

- **CrudApp** — ASP.NET Core MVC front-end
- **CrudApi** — ASP.NET Core Web API backend

## ✅ Features

- Full CRUD functionality
- AJAX integration for Create
- API returns JSON data
- Client-side + server-side validation

## 🔧 How to Run Locally

1. Clone the repo:

2. Open `CrudSolution.sln` in Visual Studio.

3. Set **CrudApi** as the first startup project.

4. Set **CrudApp** as the second startup project.

5. Run the solution. The API will listen on one port (e.g., `https://localhost:7071`), and the MVC app will run on another (e.g., `https://localhost:7277`).

6. The MVC app will POST to the API for Create and read data from it.


Prepared by Sunhena as part of a coding evaluation.
