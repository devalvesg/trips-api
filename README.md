# Trips API

## Visão Geral

Bem-vindo ao repositório da **Trips API**! Este projeto foi desenvolvido utilizando C# com .NET 8 e SQL Server. A ideia principal deste projeto é criar uma API que permita realizar operações CRUD (Create, Read, Update, Delete) para registrar viagens, bem como trabalhar com relacionamentos, onde cada viagem pode ter uma ou mais atividades específicas associadas.

## Funcionalidades

- **CRUD de Viagens**: Registre, consulte, atualize e delete viagens.
- **Gerenciamento de Atividades**: Associe atividades específicas a cada viagem.
- **Relacionamentos**: Implemente relacionamentos entre viagens e atividades.
- **Segurança**: Autenticação e autorização para acesso seguro à API.
- **Validação de Dados**: Valide entradas do usuário para garantir a integridade dos dados.

## Tecnologias Utilizadas

- **C#**
- **.NET 8**
- **SQL Server**
- **Entity Framework Core**: Para gerenciamento de dados e mapeamento objeto-relacional (ORM).
- **Swagger**: Para documentação e testes da API.

## Configuração do Ambiente

### Pré-requisitos

- **.NET 8 SDK**: [Download .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server**: Pode ser local ou em nuvem (Azure SQL Database, por exemplo).

### Passos para Configuração

1. **Clone o repositório**
    ```bash
    git clone https://github.com/seu-usuario/travel-management-api.git
    ```

2. **Navegue até o diretório do projeto**
    ```bash
    cd travel-management-api
    ```

3. **Configure a string de conexão do SQL Server no `appsettings.json`**
    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server=seu-servidor;Database=sua-base-de-dados;User Id=seu-usuario;Password=sua-senha;"
        }
    }
    ```

4. **Execute as migrações para criar o banco de dados**
    ```bash
    dotnet ef database update
    ```

5. **Execute o projeto**
    ```bash
    dotnet run
    ```

## Endpoints da API

### Viagens

- **GET /api/trips**: Obtém todas as viagens.
- **GET /api/trips/{id}**: Obtém uma viagem específica pelo ID.
- **POST /api/trips**: Cria uma nova viagem.
- **DELETE /api/trips/{id}**: Deleta uma viagem pelo ID.

### Atividades

- **POST /api/trips/{tripId}/activity**: Cria uma nova atividade.
- **PUT /api/trips/{tripId}/activitiy/{activityId}**: Atualiza o status de uma atividade para concluida.
- **DELETE /api/trips/{tripId}/activitiy/{activityId}**: Deleta uma atividade pelo ID.

## Documentação da API

A documentação completa da API pode ser acessada via Swagger após iniciar o projeto. Navegue para `http://localhost:7098/swagger` para visualizar e testar os endpoints.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

### Passos para Contribuir

1. **Fork o repositório**
2. **Crie uma branch para sua feature** (`git checkout -b feature/nome-da-feature`)
3. **Commit suas mudanças** (`git commit -m 'Adiciona nova feature'`)
4. **Push para a branch** (`git push origin feature/nome-da-feature`)
5. **Abra um Pull Request**
