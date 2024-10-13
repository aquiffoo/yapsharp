using YapSharpClient;

void main() {
    Client client = new Client("127.0.0.1", 8000);
    client.start();
}

main();
