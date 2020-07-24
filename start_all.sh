#!/bin/bash
# Script to manage the containers execution

#Criar imagem do hproxy
echo -n "Criando imagem do hproxy..."
docker build --pull --rm -f "config/rabbitmq/Dockerfile" -t geekmania-haproxy:v1 .

 
## Variables for images build.
echo -n "Configurando variaveis para as images..."
JOIN_RABBIT2_RABBIT1="rabbitmqctl stop_app; rabbitmqctl join_cluster guedesdeveloper@gmail.com; rabbitmqctl start_app"
JOIN_RABBIT3_RABBIT1="rabbitmqctl stop_app; rabbitmqctl join_cluster guedesdeveloper@gmail.com; rabbitmqctl start_app"
JOIN_RABBIT4_RABBIT1="rabbitmqctl stop_app; rabbitmqctl join_cluster guedesdeveloper@gmail.com; rabbitmqctl start_app"
OPTIONAL_COMMAND="rabbitmqctl set_policy ha-all '' '{\"ha-mode\":\"all\", \"ha-sync-mode\":\"automatic\"}'"
 
 
#Subindo os container's do rabbitmq
echo -n "Starting container..."
docker-compose down
docker-compose up -d
sleep 15
docker exec -ti geekmania-rabbitmq2 bash -c "$JOIN_RABBIT2_RABBIT1"
docker exec -ti geekmania-rabbitmq3 bash -c "$JOIN_RABBIT3_RABBIT1"
docker exec -ti geekmania-rabbitmq4 bash -c "$JOIN_RABBIT4_RABBIT1"
docker exec -ti geekmania-rabbitmq1 bash -c "$OPTIONAL_COMMAND"