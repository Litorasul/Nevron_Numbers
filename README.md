# Numbers List App

This ASP.NET Core Razor Pages application displays a list of numbers fetched from a `NumbersService` and allows users to interact with the list by adding, summing, and clearing numbers. The application uses distributed cache to store and retrieve the list of numbers, ensuring consistency across multiple browser tabs.

## Features

- **Display Numbers**: Fetches and displays a list of numbers from a `NumbersService`.
- **Add Number**: Adds a new random number to the list.
- **Sum Numbers**: Calculates and displays the sum of the numbers in the list.
- **Clear Numbers**: Clears the list of numbers.
- **Count Numbers**: Displays the count of numbers in the list.
- **Distributed Cache**: Uses distributed cache to store and retrieve the list of numbers for consistency across browser tabs.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Installation

1. Clone the repository:

    ```bash
    git clone <repository-url>
    cd numbers-list-app
    ```

2. Restore the dependencies:

    ```bash
    dotnet restore
    ```

3. Run the application:

    ```bash
    dotnet run
    ```

### Usage

1. Open the application in your web browser by navigating to `http://localhost:7247`.
2. Use the "Add Number" button to add a new random number to the list.
3. Use the "Sum Numbers" button to calculate and display the sum of the numbers in the list.
4. Use the "Clear Numbers" button to clear the list of numbers.
5. The count of numbers and the sum will be displayed below the 
