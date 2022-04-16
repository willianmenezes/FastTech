# FastTech

## Empresa de vendas FastTech

A empresa FastTech precisa de uma consultoria que desenvolva um sistema de gestao de vendas, para controlar melhor todo o fluxo da sua empresa.

### 01 - Acoes comuns

- Todas as entidades devem ter um CRUD.
- As entidades nao podem ser excluidas, apenas desabilitadas.

### 02 - Controle de vendas

#### Vendedor

- O vendedor pode obter relatorios por data das suas vendas.
- O vendedor pode adicionar/cadastrar uma venda.
- O vendedor pode editar uma venda.
- O vendedor pode cancelar uma venda.

#### Gerente

- O gerente pode obter relatorios por data das vendas de um ou mais vendedores do setor.
- O gerente pode adicionar/cadastrar uma venda para um determinado vendedor.
- O gerente pode editar uma venda de um vendedor.
- O gerente pode cancelar uma venda de um vendedor.

#### Administrador

- O administrador do sistema, nao pode manipular recursos de vendas.

### 03 - Gerenciamento do setor

#### Vendedor

- Nao pode realizar alteracoes no setor.

#### Gerente

- Somente gerentes podem cadastrar vendedores no setor.
- Somente gerentes podem trasnferir vendedores de setor.
- Um vendedor nao pode ser excluido de um setor.
- Um vendedor pode ser transferido de setor, mas as suas vendas ainda farao parte do setor em que foram cadastradas.

#### Administrador

- Somente administradores podem manipular os dados de um setor.

### 04 - Catalogo de produtos

#### Vendedor

- Um vendedor pode consultar produtos.

#### Gerente

- Um gerente pode consultar produtos.

#### Administrador

- Um administrador pode cadastrar produtos.
- Um administrador pode editar produtos.
- Um administrador pode desabilitar um produto.

### 05 - Controle de acesso

- Um usuario so podera acessar a aplicacao se estiver devidamente cadastrado e autenticado.
- O sistema deve ter 03 niveis de acesso, sendo eles: Administrador, Gerente e Vendedor.
- Um usuario so podera acessar recurso que o seu nivel de acesso permita.
- Um usuario nao pode alterar o seu email.

As regras aqui descritas podem ser alteradas de acordo com o contexto em que essa aplicacao vai ser utilizada. Sinta-se a vontade para dar dicas de melhorias. 

### Ferramentas

Esse projeto sera criado utilizando a o SDK do dotnet na versao 6, voce pode fazer o download [aqui](https://dotnet.microsoft.com/en-us/download)

Vamos aprender a implementar diversas funcionalidades e a utilizar diversas ferramentas, sendo elas: 

- ASP.NET 6 WEB API
- Entity Framework Core
- Fluent Validations
- Documentação com Swagger
- Autenticação
- Autorização
- JWT
- Permissões de acesso de acordo com regras
- E varias funcionalidades que conseguirmos colocar em prática.

Valeu pessoas! 

Crie ISSUES e FORKS.
