# UdpTest


## How to build 

  docker build -f .\UdpServerWorkerService\Dockerfile --tag  udpserver .
  
## How to run docker image in interative mode and network host mode
  sudo docker run -it --name test --network host  udpserver
