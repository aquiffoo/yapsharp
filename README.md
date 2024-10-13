# yapsharp

YapSharp is a simple started project. It's basically a TCP chat app that allows multiple clients on your machine send messages with each other in real time. It is divided into the **server** and the **client**.

## Server

The server component is responsible for listening to incoming TCP connections, handling multiple clients, and broadcasting messages to all connected clients except the sender.

### Features

- TCP Listener for incoming client connections
- Multi-threaded client handling
- Real-time message broadcasting to connected clients

### Usage

To start the server, navigate to the server's executable directory and run the following command:
```shell
dotnet run
```


The server will start and listen on the specified IP address and port.

## Client

The client component connects to the server and allows users to send and receive messages.

### Features

- TCP Client for server connection
- Multi-threaded message receiving
- Console-based user interface for message input and display

### Usage

To start a client, navigate to the client's executable directory and run the following command:
```shell
dotnet run
```

After starting, the client will prompt the user to enter messages which will then be sent to the server and broadcasted to other clients.

## Getting Started

To get started with YapSharp, clone the repository to your local machine using the following command:
```shell
git clone https://www.github.com/aquiffoo/yapsharp.git
```

Open multiple instances of the terminal (1 for server and at least 2 for clients) and run them on their directories.

## Requirements

- .NET 5.0 or higher

## Contributing

Contributions are welcome! Feel free to open a pull request or an issue if you have suggestions or find a bug.