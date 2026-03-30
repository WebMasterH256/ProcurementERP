# ProcurementERP

> 🇧🇷 Português | 🇺🇸 [English below](#english-version)

---

## 🇧🇷 Versão em Português

### Sobre o Projeto

**ProcurementERP** é uma API REST de nível corporativo para gestão de compras e suprimentos, desenvolvida em **.NET 8** com **SQL Server**. O projeto simula o backend de um sistema ERP real, cobrindo o fluxo completo de pedidos de compra — desde a criação por um funcionário até a aprovação por um gerente — com controle de orçamento por departamento, trilha de auditoria e relatórios de alta performance.

O objetivo é demonstrar domínio de arquitetura em camadas, boas práticas de desenvolvimento backend e tecnologias amplamente utilizadas em ambientes corporativos.

### Tecnologias

- **.NET 8** — plataforma principal
- **ASP.NET Core** — framework web para a API REST
- **Entity Framework Core** — ORM para operações do dia a dia
- **Dapper** — consultas otimizadas para relatórios complexos
- **SQL Server** — banco de dados relacional
- **JWT** — autenticação e autorização
- **Swagger / OpenAPI** — documentação dos endpoints

### Estrutura do Projeto

```
ProcurementERP/
├── ProcurementERP.API/             # Endpoints, controllers, Program.cs
├── ProcurementERP.Domain/          # Entidades e enums
├── ProcurementERP.Infrastructure/  # DbContext, migrations, repositórios
│   └── Configurations/             # Mapeamento EF Core por entidade
└── ProcurementERP.Application/     # Services e regras de negócio (em breve)
```

### Roadmap

- [x] Modelagem das entidades de domínio
- [x] Mapeamento com Entity Framework Core
- [x] Migration inicial — banco de dados criado
- [ ] Repositórios (camada de acesso a dados)
- [ ] Services com transações ACID
- [ ] Controllers e endpoints REST
- [ ] Autenticação JWT com RBAC (controle de acesso por cargo)
- [ ] Trilha de auditoria (audit log)
- [ ] Relatórios com Dapper
- [ ] Documentação completa

---

## 🇺🇸 English Version

### About the Project

**ProcurementERP** is a corporate-grade REST API for procurement and supply management, built with **.NET 8** and **SQL Server**. The project simulates the backend of a real ERP system, covering the full purchase order workflow — from creation by an employee to approval by a manager — with department budget control, audit logging, and high-performance reporting.

The goal is to demonstrate proficiency in layered architecture, backend development best practices, and technologies widely used in corporate environments.

### Tech Stack

- **.NET 8** — core platform
- **ASP.NET Core** — web framework for the REST API
- **Entity Framework Core** — ORM for day-to-day operations
- **Dapper** — optimized queries for complex reports
- **SQL Server** — relational database
- **JWT** — authentication and authorization
- **Swagger / OpenAPI** — endpoint documentation

### Project Structure

```
ProcurementERP/
├── ProcurementERP.API/             # Endpoints, controllers, Program.cs
├── ProcurementERP.Domain/          # Entities and enums
├── ProcurementERP.Infrastructure/  # DbContext, migrations, repositories
│   └── Configurations/             # EF Core mapping per entity
└── ProcurementERP.Application/     # Services and business logic (coming soon)
```

### Roadmap

- [x] Domain entity modeling
- [x] Entity Framework Core mapping
- [x] Initial migration — database created
- [ ] Repositories (data access layer)
- [ ] Services with ACID transactions
- [ ] Controllers and REST endpoints
- [ ] JWT authentication with RBAC
- [ ] Audit logging
- [ ] Dapper reporting queries
- [ ] Full documentation
