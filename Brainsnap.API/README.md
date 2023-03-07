docker build -t brainsnap-api-image -f Brainsnap.API/Dockerfile .
docker run --name brainsnap-api -p 5292:80 -e ASPNETCORE_ENVIRONMENT=Development --network postgres_default  brainsnap-api-image
