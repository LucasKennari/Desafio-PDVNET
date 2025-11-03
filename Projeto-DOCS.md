# Arquitetura
 - Foi Utilizado o padrão **MVVMM**
## Estrutura do projeto
 <img src="https://image.prntscr.com/image/9jFIlo2dQNKmcZN5-t5byg.png">
 
> - **Business:** Camada de regra de negocio, onde fica a services e suas validações.
   
> - **Data:** Se encontra a conexão do banco de dados, a entitidade/model, e o repositorio que faz o CRUD.
 
> - **Tests:** Camada de testes simples (Model e Service)

> - **UI**: Onde fica as Views, views models, lógicas de manipulação de dados e componentes relacionado a views.


<details>
    <summary> GestaoProdutos.UI</summary>
 <img src="https://i.imgur.com/CnoMjPg.png">
 
  - Principais pontos:
  - - Views: Camada de design
  - - Views Models: Camada de manipulação do design
  - - Services: Gestão de navegação entre as telas
  - - Converters: Lógica de conversões relacionado a valores e realizar determinada situação
  - - Command: Seria todas as ações realizadas. (Por exemplo um Adicionar Produto estaria dentro da pasta command).
</details>

<details>
    <summary> GestaoProdutos.Data</summary>
 <img src="https://i.imgur.com/w1bzVA1.png">
 
  - Principais pontos:
  - - Model: Camada da estrutura da tabela do banco.
  - - Repository: Camada de gerenciamento do banco de dados, como consulta, editar, adicionar, excluir
  - - Context: Conexão com banco, criação da tabela e de seeds.
</details>


<details>
    <summary> GestaoProdutos.Business</summary>
 <img src="https://i.imgur.com/UPgGoax.png">
 
  - Principais pontos:
  - - Service: Camada de regra de negocio, validações e gerenciamento de dados para o banco.
</details>
