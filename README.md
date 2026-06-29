# 🏆 Zsporting API

> Plataforma digital desenvolvida para funcionar como um ecossistema centralizado para esportistas amadores, removendo barreiras logísticas e conectando pessoas para a prática esportiva.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

## 📋 Sobre o Projeto

O Zsporting API é uma aplicação backend RESTful construída com os princípios da **Clean Architecture**. O sistema resolve as dores logísticas e de informação de esportistas amadores, permitindo a criação, gestão e busca de eventos esportivos, além do gerenciamento de usuários com autenticação segura.

## 🏗️ Arquitetura e Tecnologias

O projeto foi dividido em camadas lógicas para garantir baixo acoplamento e alta coesão:
- **API Layer (`Zsporting.Api`):** Controladores REST e configurações de entrada.
- **Application Layer (`Zsporting.Application`):** Casos de uso, interfaces e lógica de negócio.
- **Domain Layer (`Zsporting.Domain`):** Entidades puras do sistema.
- **Infrastructure Layer (`Zsporting.Infrastructure`):** Acesso a dados com repositórios e DbContext.
- **Test Layer (`Zsporting.Tests`):** Testes unitários com xUnit e Moq.

**Principais Tecnologias:**
- **C# & .NET 8**
- **Entity Framework Core** (ORM)
- **PostgreSQL** (Banco de dados relacional)
- **Docker & Docker Compose** (Containerização)
- **JWT (JSON Web Token)** (Autenticação Stateless)
- **xUnit & Moq** (Testes automatizados com padrão AAA)

## 🚀 Como Executar o Projeto

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/products/docker-desktop)
- *Ou execute diretamente via GitHub Codespaces.*

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/arthurfeliperl/Zsporting-API.git](https://github.com/arthurfeliperl/Zsporting-API.git)
   cd Zsporting-API
