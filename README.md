# FastTech

## Empresa de vendas FastTech

A empresa FASTTECH precisa de uma consultoria que desenvolva um sistema de gestao de vendas, para controlar melhor todo o fluxo da sua empresa.

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

- O administrador so sistema, nao pode manipular recursos de vendas.

### 03 - Gerenciamento do setor

#### Gerente

- Somente gerentes podem cadastrar vendedores no setor.
- Somente gerentes podem trasnferir vendedores de setor.
- Um vendedor nao pode ser excluido de um setor.
- Um vendedor pode ser transferido de setor, mas as suas vendas ainda farao parte do setor em que foram cadastradas.

#### Administrador

- Somente administradores podem manipular os dados de um setor.

## 04 - Controle de acesso

- Um usuario so podera acessar a aplicacao se estiver devidamente cadastrado e autenticado.
- O sistema deve ter 03 niveis de acesso, sendo eles: Administrador, Gerente e Vendedor.
- Um usuario so podera acessar recurso que o seu nivel de acesso permita.
- Um usuario nao pode alterar o seu email.
