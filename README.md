# AtividadeCursoCsharp-APi

Projeto de API desenvolvida em C# usando ASP.NET Core para atividade do curso de C# da CodeRDIversity.

## Funcionalidades

- **GET /api/geladeira**: Retorna todos os itens armazenados na geladeira.
- **GET /api/geladeira/{andar}/{container}/{posicao}**: Retorna o item localizado na posição específica da geladeira.
- **POST /api/geladeira**: Adiciona um novo item na posição especificada da geladeira.
- **PUT /api/geladeira/{andar}/{container}/{posicao}**: Atualiza o item na posição especificada da geladeira.
- **DELETE /api/geladeira/{andar}/{container}/{posicao}**: Remove o item da posição especificada da geladeira.
