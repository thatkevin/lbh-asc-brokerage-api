.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose build brokerage-api

.PHONY: build-test
build-test: build
	docker-compose build brokerage-api-test

.PHONY: serve
serve: build
	docker-compose up -d brokerage-api

.PHONY: shell
shell: build
	docker-compose run --rm brokerage-api bash

.PHONY: test
test: test-db build-test migrate
	docker-compose run --rm brokerage-api-test

.PHONY: lint
lint:
	dotnet format

.PHONY: migrate
migrate: test-db
	CONNECTION_STRING="Host=127.0.0.1;Port=5435;Username=postgres;Password=mypassword;Database=testdb" \
	dotnet ef database update -p BrokerageApi -c BrokerageApi.V1.Infrastructure.BrokerageContext

.PHONY: stop
stop:
	docker-compose down

.PHONY: dev-db
dev-db:
	docker-compose up -d dev-database

.PHONY: test-db
test-db:
	docker-compose up -d test-database

.PHONY: restart-db
restart-db:
	docker stop $$(docker ps -q --filter ancestor=test-database -a)
	-docker rm $$(docker ps -q --filter ancestor=test-database -a)
	docker rmi test-database
	docker-compose up -d test-database
