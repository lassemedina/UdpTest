docker build -f .\UdpClient\Dockerfile --tag udpechoclient .
docker run --rm -it --name udpechoclient --network host udpechoclient