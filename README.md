# Voting App Documentation

Welcome to the Voting App documentation. This application provides an API for managing user accounts and conducting voting sessions. It also includes Swagger for easy API exploration.

## Table of Contents

- [Installation](#installation)
  - [Prerequisites](#prerequisites)
  - [Setting up with Docker Compose](#setting-up-with-docker-compose)
- [API Endpoints](#api-endpoints)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Installation

### Prerequisites

Make sure you have the following software installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (for building and running the application)
- [Docker](https://www.docker.com/get-started) (for running Docker Compose)

### Setting up with Docker Compose

1. Clone this repository and navigate to the project directory.

2. Run the docker app

3. Open a terminal and navigate to the project directory.

4. Run the following command to start the containers using Docker Compose: \n
```docker compose up```

### Starting the project
#### To start the backend
1. In the folder of the app run: \n
```dotnet watch run --urls=http://localhost:5600/```
We specify the 5600 port, as the client web app will listen to this port.
After raning the backend app, an Swagger api page will be automatiaclly opened, you can interact with the backened from it.
#### To start frontend
1. Run `index.html` file from `VotesApp/Pages` folder.

## API Endpoints
- [POST] `/Login`: Authenticate a user and receive an authentication token.
- [GET] `/Users`: Retrieve a list of all users.
- [POST] `/Users`: Create a new user.
- [GET] `/Votes`: Retrieve a list of all votes.
- [POST] `/addChoice`: Add a new choice to a voting session.
- [POST] `/removeChoice`: Remove a choice from a voting session.
- [POST] `/updateChoice`: Update the details of a choice.
- [POST] `/incrementChoice`: Increment the vote count for a choice.

## Usage

 1. In the folder of the app run: \n
```dotnet watch run --urls=http://localhost:5600/```
We specify the 5600 port, as the client web app will listen to this port.
After raning the backend app, an Swagger api page will be automatiaclly opened, you can interact with the backened from it.
2. Run `index.html` file from `VotesApp/Pages` folder.


## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please feel free to submit a pull request.


## License

This project is licensed under the MIT License.
