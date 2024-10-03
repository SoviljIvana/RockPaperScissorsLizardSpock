# Rock Paper Scissors Lizard Spock

## Overview

Rock Paper Scissors Lizard Spock is an engaging twist on the classic game, allowing users to compete against a computer opponent. This application tracks scores and displays game results for an enhanced gaming experience.

## Game Rules

The game follows these rules:

- **Rock** crushes **Scissors**.
- **Scissors** cuts **Paper**.
- **Paper** covers **Rock**.
- **Rock** crushes **Lizard**.
- **Lizard** poisons **Spock**.
- **Spock** smashes **Scissors**.
- **Scissors** decapitates **Lizard**.
- **Lizard** eats **Paper**.
- **Paper** disproves **Spock**.
- **Spock** vaporizes **Rock**.

## Tools and Technologies Used

- **ASP.NET Core**: The web framework used to build the application.
- **PostgreSQL**: The database used to store user scores and game history.
- **Visual Studio**: The integrated development environment (IDE) used for development.
- **Docker**: The application is containerized to ensure consistency across different environments.

## Getting Started

### Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- **Visual Studio**: Ensure you have Visual Studio installed for development.
- **PostgreSQL**: Make sure you have PostgreSQL installed and running.

### Running the Application

1. **Clone the repository**:
   ```bash
   git clone https://github.com/SoviljIvana/RockPaperScissorsLizardSpock
   
2.  **Set docker-compose Set As Startup Project**

3.  **Run docker compose**

4.  **Open swagger http://localhost:8082/swagger/index.html**

5.  **Postgres db setup: http://localhost:999/login?next=%2F (for credentials follow docker-compose.override.yml file)**

6.  **Use POST /choice endpoint to add all choices in database in the following order:**
{id: 1, name: 'rock'},
{id: 2, name: 'paper'},
{id: 3, name: 'scissors'},
{id: 4, name: 'spock'},
{id: 5, name: 'lizard'}

### Author: 
Sovilj Ivana 
