# UdpTest


## How to build 

  (sudo) docker build -f .\UdpServerWorkerService\Dockerfile --tag  udpserver .
  
## How to run docker image in interative mode and network host mode
  (sudo) docker run -it --name test --network host  udpserver
