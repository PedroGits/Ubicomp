# Ubicomp

#Codigo ainda em construção, algumas apis não estão corretas. 

Esta é uma aplicação que consiste na criação de um backend simples para o controlo de luzes mediante entradas de sensores. Para a comunicação são utilizadas API's Rest e o protocolo mqtt através de um broker(eclipse mosquitto). Para o deploy é utilizado o docker compose para orquestração dos containers(App + sql server + mqtt broker) e multiplos ficheiros de ambiente com configurações diferentes, debug e deploy.
A abordagem consiste num codigo pouco acopulado para permitir a sua testagem na integra.
O swagger está habilitado em ambiente deploy para facilitar a interação com a aplicação.

#Para correr a aplicacao deve ser usado o docker compose com o comando docker compose up (linux docker-compose up)

#Unit testing
Para correr os testes, deve ser feito o build do container Dockerfile_Test com o comando docker build -f Dockerfile_Test (Sem produção de artefactos).