using YapSharpServer;

void main() {
    Server server = new Server("127.0.0.1", 8000);
    server.start();
}

main();
