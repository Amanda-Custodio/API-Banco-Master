# API-Banco-Master
API de teste - Banco Master

## Sobre o Projeto:
<p> Trata-se de uma API para criar e consultar clientes, além de possibilitar uma transação bancária entre dois clientes cadastrados válidos.
  
## Tecnologias Utilizadas:
<li> Visual Studio 2022;
<li> ASP.NET 5;
<li> Entity Framework;
<li> Swagger;
<li> SQLServer.
           
## Endpoints:
### Para Clientes:
<li> /api/Clientes/ConsultarClientes -> permite a consulta de todos os clientes cadastrados;
<li> /api/Clientes/{id} -> possibilita a consulta de clientes pelo número de id desejado;
<li> /api/Clientes/CadastrarCliente -> insere novo cliente nos registros.
       
### Para Transferências:
<li> /api/transferência/Transferências -> permite a consulta a todas as transferências realizadas;
<li> /api/transferência/TransferirPix -> gera nova transferência.
  
  
## Como utilizar:
-> Para criar novo usuário, é necessário inserir os dados solicitados (Id - começando pelo número 10 -, Nome, Documento, ChaveOrigem, e Saldo).
-> Para realizar nova transação, basta inserir o id_de_Cliente(refere-se ao cliente que fará a transferência), a chaveDestino(chave cadastratada pelo cliente para o qual deseja enviar a transferência), e o valor.
 
--> Caso o cliente não esteja cadastrado, o programa retorna uma mensagem ("Cliente não existente"); e caso o valor inserido na transferência seja maior do que o saldo existente para o determinado cliente, o programa retorna uma mensagem de erro também ("Saldo insuficiente").
