#!/bin/bash
docker build -t danipalli/car-booking-api .
docker run -d --name car-booking-api -p 5000:5000 danipalli/car-booking-api

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest