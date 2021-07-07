<p align="center"><img src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/512px-.NET_Core_Logo.svg.png" width="150"></p>

# Api criada usando .NET Core criada usando vscode

## Cadastro de cliente.

Um cliente deve possuir nome, data de nascimento e sexo(masculino,
feminino).
Cada cliente pode possuir endereços comerciais e/ou residenciais.
Um endereço possui cep obrigatoriamente, logradouro obrigatoriamente,
número
obrigatoriamente, complemento opcional, bairro opcional e UF
obrigatoriamente.

## Objetivo:
### Desenvolver sistema para cadastro de clientes e endereços com as
funcionalidades:
Exibição, inclusão, edição e exclusão de clientes.
Exibição, inclusão, edição e exclusão de endereços de clientes.

## Observação:
A remoção de clientes é independente da existência de endereços, caso um
cliente
seja excluído seus endereços devem ser apagados também.

## Funcionalidades:
Cadastrar um cliente somente quando o nome, data de nascimento e sexo
estiverem preenchidos.

Visualizar os clientes e seus dados.

Editar um cliente seguindo as regras dos seus atributos.

Excluir um cliente.

Cadastrar endereços no cliente seguindo as obrigatoriedades dos atributos
de
endereço.

Visualizar os endereços de um cliente.
Editar o endereço de um cliente seguindo as regras de seus atributos.

Excluir endereços de um cliente.

---

## Rodar o projeto

### Clone o repositório:
```
git clone https://github.com/mvfernandes/client_crud_asp_net client_crud_asp_net
```

### Acesse o projeto:
```
cd client_crud_asp_net
```

### Rode o projeto:
```
dotnet run
```

## [Respositório do front](https://github.com/mvfernandes/cliente_crud_reactjs).
