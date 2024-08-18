# Praxos

## Intention
This is a starter template for building a web API with AspNetCore and SQLite.

## Architecture

Contracts and implementation agnostic models are defined in `Praxos.Application`.  
These contracts are then implemented in an implementation specific project.
`Praxos.Persistence`, for example, provides an SQLite implementation for repos in `Praxos.Application.Contracts.Persistence`.  
Implementation specific models and their Automapper Profiles are declared internal to the implementation projects.
Each project has its own Mapper instance and Dependency Injection Extension.
`Praxos.Api` starts the application and registers all the DI methods.

## Todos

- [ ] Email
- [ ] Document Create Service
- [ ] Auth Server
- [ ] Expand Repo
- [ ] Auditable Repo
- [ ] Web Client with generated services