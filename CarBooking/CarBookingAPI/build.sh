#!/bin/bash
docker build -t danipalli/car-booking-api .
docker run -d --name car-booking-api -p 5000:5000 danipalli/car-booking-api
