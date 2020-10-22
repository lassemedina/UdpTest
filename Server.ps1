docker build -f .\UdpServerWorkerService\Dockerfile --tag udpechoserver .
docker run --rm -it --name udpechoserver --network host udpechoserver