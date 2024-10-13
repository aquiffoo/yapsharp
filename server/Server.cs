using System.Net;
using System.Net.Sockets;

namespace YapSharpServer {
    class Server {
        private TcpListener listener;
        private List<TcpClient> clients = new List<TcpClient>();

        public Server(string ip, int port) {
            listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        private void broadcastMessage(string message, TcpClient sender) {
            foreach (var client in clients) {
                if (client != sender) {
                    try {
                        StreamWriter writer = new StreamWriter(client.GetStream());
                        writer.WriteLine(message);
                        writer.Flush();
                    } catch (Exception) {
                        Console.WriteLine("error sending the message...");
                    }
                }
            }
        }

        private void handleClient(TcpClient client) {
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);

            while (true) {
                try {
                    string? message = reader.ReadLine();
                    if (message != null) {
                        Console.WriteLine($"received message: {message}");
                        broadcastMessage(message, client);
                    }
                } catch (Exception) {
                    Console.WriteLine("error while sending message...");
                }
            }
        }

        public void start() {
            listener?.Start();
            Console.WriteLine("server up and running...");
            if (listener == null) throw new InvalidOperationException("listener not initialized.");

            while (true) {
                TcpClient client = listener.AcceptTcpClient();
                clients.Add(client);
                Console.WriteLine("new client connected...");

                Thread clientThread = new Thread(() => handleClient(client));
                clientThread.Start();
            }
        }
    }
}
