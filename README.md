# Desafio Easynvest
Teste para desenvolvedor back-end na Easynvest

Esta solução consiste em uma API para retornar os investimentos para clientes, onde o mesmo pode possuir 3 tipos de investimentos (tesouro direto, renda fixa e fundos), retornando o valor total dos investimentos, e uma lista com todos eles, tendo o cálculo de imposto de renda, e do valor do resgate no momento atual em cada um dos investimentos listados.

## Decisões do projeto

Foi feito todos os requisitos que foram pedidos no desafio, desta maneira procurei organizer o projeto em algumas camadas, utilizei injeção de dependência, procurei seguir algumas regras do SOLID e de clear code, tais como boas práticas de desenvolvimento, para garantir uma alta coesão.
Para os teste utlizei a referencia Xunit, pois foram teste simplificados.
Para os logs, que posso acompanhar nas configurações de App Service no Azure Cloud ou mesmo AWS.
Foi usado o cache em memória com a interface IMemoryCache do .net,por se tratar de um projetinho bem simples.

.

