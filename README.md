# Car Rental System

## Overview
The Car Rental System is a software application designed to manage the rental process of vehicles. It provides functionalities for managing customers, vehicles, rentals, and returns.

## Features
- User management
- Vehicle management

## Technologies Used
- **C#** for backend development
- **Angular** for the frontend framework

## Architecture
- The backend uses Domain-Driven Design (DDD), Builder, Unit of Work, and Command Query Responsibility Segregation (CQRS) patterns.

## Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/yordanov03/CarRentalSystem.git
    ```
2. Navigate to the project directory:
    ```bash
    cd CarRentalSystem
    ```
3. Restore NuGet packages:
    ```bash
    dotnet restore
    ```
4. Navigate to the Angular frontend directory:
    ```bash
    cd ClientApp
    ```
5. Install Angular dependencies:
    ```bash
    npm install
    ```

## Usage
1. Start the backend application:
    ```bash
    dotnet run
    ```
2. Start the Angular frontend application:
    ```bash
    ng serve
    ```
3. Open your browser and navigate to `http://localhost:4200`.
