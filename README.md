## Sobre 📝

- Este projeto foi criado apenas para entender o conceito básico de criação de uma Web API com C# e DotNet 6.

- A API é um CRUD de usuários.

## Autenticação e autorização 🔏

- Foi utilizado método para autenticação e autorização. Onde as rotas só podem ser acessadas após autenticação do usuário onde é gerado um token.
E algums métodos como PUT e DELETE são protegidos por claims para serem somente acessadas por usuários com Role "manager".

## Rotas

- /api/Login
- /api/User

![alt text](./Assets/Images/print_swagger.png)