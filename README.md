# R6Stats.NET

![R6Stats.NET API CI/CD](https://github.com/LouisWhite15/R6Stats.NET/workflows/R6Stats.NET%20API%20CI/CD/badge.svg) ![R6Stats.NET client app CI/CD](https://github.com/LouisWhite15/R6Stats.NET/workflows/R6Stats.NET%20client%20app%20CI/CD/badge.svg)

Website for Rainbow Six Siege stats

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

- .NET Core 3.1 SDK
- Node.js v12.13.0 (or greater)

### Installing

- Clone the repository
- Navigate into the `R6Stats.NET` folder and open a new Terminal window
- Run `dotnet run` in the terminal window to start up the backend API
- Open a new Terminal window and navigate to the `client-app` folder
- Run `npm run serve` to start up the Vue.js front end app

Note: For full functionality you will need to specify the API key for the R6Tab API and enter it in the `appsettings.json` file with the key "R6Tab_ApiKey"

## Deployment

On merge to the `master` branch, the GitHub Actions that have been set up will run CI/CD for the API and the Vue.js website
