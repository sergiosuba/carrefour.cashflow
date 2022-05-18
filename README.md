# Pre-condition
    1. "Docker Desktop Installer.exe" install
        https://docs.docker.com/desktop/windows/install/

    2. Install Report Generator
    dotnet tool install -g dotnet-reportgenerator-globaltool

# Run Appllication (vs code)
    1. Navegue até o diretório da aplicação (localPath\Carrefour)

    2. Abra o terminal e digite o comando
        docker-compose -f "docker-compose.yml" up -d --build

    3. Abra o Navegador em "http://localhost:8080/index.php"
        3.1 Login
            user: root
            password: Sistemas!23
        3.2 Clique na aba Importar
        3.3 Selecione o arquivo localizado em <localPath\Carrefour\Resource\cashflow.sql>
        3.4 Clique em importar

# Swagger
    1. Para abrir o Swagger acessse o link "http://localhost:3001/index.html"
# Integraded Test 
## Postam
    1. Install Postman
        https://www.postman.com/downloads/

    2. Importe a Collection <localPath>\test\IntegratedTest\Cashflow 1.0.postman_collection.json

    Nota
        Foi criado um serviço de autênticação (User) Mock apenas para gerar um token.
    
        1. No postman execute o serviço /api/User/Authenticate que este carregará em uma variavel de ambiente o token para uso nos demais serviços.

## Automation with Cypress

    1. Navegue até a pasta
        test\IntegratedTest\automation-cypress
    
    2. Execute o comando npm install

    3. Execute o comando npx cypress run
# Unit Test
    - Run Unit Test
        dotnet test --collect:"XPlat Code Coverage"

        Navegue até a pasta \test e use o comando abaixo
        - Generate command
            reportgenerator -reports:"TestResults\{guid}\coverage.cobertura.xml" -targetdir:"TestResultsCoverageReport" -reporttypes:Html
        
        Nota
            Para visualizar o relatório de cobertura de código, troque no caminho acima a tag {guid} pelo nome do arquivo gerado em test\TestResultss

        - View
            Chrome - <solutionPath>test/TestResultsCoverageReport/index.html

