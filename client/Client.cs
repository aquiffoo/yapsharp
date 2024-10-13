using System.Net.Sockets;

namespace YapSharpClient {
    class Client {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public Client(string ip, int port) {
            client = new TcpClient(ip, port);
            NetworkStream stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            Thread receiveThread = new Thread(receiveMessages);
            receiveThread.Start();
        }

        private void sendMessage(string message) {
            writer.WriteLine(message);
            writer.Flush();
        }

        public void start() {
            Console.WriteLine("welcome to yapsharp. send messages below: ");
            while (true) {
                string? message = Console.ReadLine();
                if (message != null) sendMessage(message);
            }
        }

        private void receiveMessages() {
            while (true) {
                try {
                    string? message = reader.ReadLine();
                    Console.WriteLine($"server: {message}");
                } catch (Exception) {
                    Console.WriteLine("connection closed.");
                    break;
                }
            }
        }
    }
}
