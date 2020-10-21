# UdpTest


## How to build 

  <code>(sudo) docker build -f .\UdpServerWorkerService\Dockerfile --tag  udpserver .</code>
  
## How to run docker image in interative mode and network host mode
  <code>(sudo) docker run -it --name test --network host  udpserver</code>
