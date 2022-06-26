# Lab Manager
Aplicação para cadastro e leitura de computadores e laboratórios em um banco de dados.

---
# Funcionalidades

- Realizar cadastro de computadores
- Realizar cadastro de laboratórios
- Exibir computador por ID
- Exibir laboratório por ID
- Removeção de computador e laboratório
- Atualização de computador e laboratótio

---
# Tecnologias utilizadas

- .NET 6.0.6
- C#
- Dapper 2.0.123
- Sqlite

---
# 1. Utilização
Utilize o comando a seguir para baixar o repositório na sua máquina:
    
`git clone https://github.com/MariaEduardaBernardo/LabManager_Teste.git`

---
# 2. Utilização na aplicação - Computador

### Para trocar os valores para adicionar novas tuplas na tabelas:

    dotnet run -- Computer New id ram processor
    Exemplo: dotnet run -- Computer New 1 '16' 'Intel Dual Core' 

### Para exibir a lista

    dotnet run -- Computer List

### Para acessar um computador por ID

    dotnet run -- Computer Show id

### Para atualizar um computador

    dotnet run -- Computer Update id ram processor
    Exemplo: dotnet run -- Computer Update 1 '8' 'Intel Dual Core'

### Para excluir um computador

    dotnet run -- Computer Delete id

---
# 3. Utilização na aplicação - Laboratório

### Para trocar os valores para adicionar novas tuplas na tabela

    dotnet run -- Lab New id number name block
    Exemplo: dotnet run -- Lab New 1 '2' 'Lab Charles', '2' 

### Para exibir a lista 

    dotnet run -- Lab List

### Para acessar um laboratório por ID

    dotnet run -- Lab Show id

### Para excluir um computador

    dotnet run -- Lab Delete id
