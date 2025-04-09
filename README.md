# SurtechChallenge

Este proyecto es una prueba técnica desarrollada con .NET 8 que implementa Clean Architecture, CQRS, DDD, validaciones con FluentValidation, MediatR y pruebas unitarias. Incluye integración con APIs externas y envío de datos a webhooks.
---
## 🧱 Arquitectura aplicada

Se siguió una estructura tipo Clean Architecture, desacoplando cada capa:

SurtechChallenge.API → Web API (Controllers, Swagger, Middlewares) 

SurtechChallenge.Application → Casos de uso, CQRS, Validaciones, Behaviors, Mapping 

SurtechChallenge.Domain → Entidades y contratos 

SurtechChallenge.Infrastructure → Servicios HTTP externos 

SurtechChallenge.Tests → Pruebas unitarias con xUnit, Moq y FluentAssertions
---

## 🛠 Tecnologías utilizadas

- ✅ .NET 8
- ✅ MediatR
- ✅ CQRS
- ✅ DDD (Domain-Driven Design)
- ✅ FluentValidation + ValidationBehavior
- ✅ AutoMapper
- ✅ Swagger/OpenAPI
- ✅ HttpClientFactory
- ✅ xUnit + Moq + FluentAssertions

---
## 📂 Estructura de carpetas

/SurtechChallenge

├── SurtechChallenge.API           → Web API

├── SurtechChallenge.Application   → Casos de uso, comands, queries

├── SurtechChallenge.Domain        → Entidades 

├── SurtechChallenge.Infrastructure → Servicios HTTP

└── SurtechChallenge.Tests         → Unit tests

## 🔁 Endpoints implementados
---
### 🧱 `/api/objects`

| Método | Ruta                         | Descripción                            |
|--------|------------------------------|----------------------------------------|
| GET    | `/api/objects`               | Obtener todos los objetos              |
| GET    | `/api/objects/{id}`          | Obtener objeto por ID                  |
| POST   | `/api/objects`               | Crear nuevo objeto                     |
| PUT    | `/api/objects/{id}`          | Actualizar objeto completo             |

### 🎲 `/api/randomuser`

| Método | Ruta                                     | Descripción                               |
|--------|------------------------------------------|-------------------------------------------|
| POST   | `/api/randomuser/{webhookId}`            | Envía un usuario aleatorio al webhook     |

---
