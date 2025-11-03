# Sistema de Gestão de Estoque
>Essa rotina tem como objetivo gerenciar os produtos no estoque, suas funcionalidades:
 - Cadastrar um novo Produto;
 - Editar um produto;
 - Deletar um produto;
>Informações disponiveis:
  - Todos os produtos;
  - Produtos em baixa de estoque;
  - Total de produtos, todos os produtos juntos pela quantidade;
  - Preço total de todos os produtos por Qtd * Preço;

## Arquitetura
  - Padrão de Arquitetura **MVVM**.
  - Banco de dados utilizado: **SQL SERVER - MIGRATIONS**
  - Tecnologias utilizadas: **C#, WPF, ENTITY FRAMEWORK, MVVMLightLibs, Bogus**

## Como executar esse projeto:
> [!IMPORTANT]
>  1. Crie um fork!
>  2. Utilize o comando para clonar no seu PC: `git clone LINK_SSH/HTTPS`
>     
>  <img src="https://i.imgur.com/RgYeWeg.jpeg" height="25" margin="0" align="center"/> **Após ter baixado na sua máquina**
>  1. Na solution GestaoProdutos.Data, abra o Console.
>  2. Execute o comando  `dotnet ef migrations add inicial` (Para criar as migrations com seeds)
>  3. E depois, execute o comando `dotnet ef database update` (Pois irá subir para o banco de dados)
>  4. Após isso, Seleciona o Assembly **GestaoProdutos.UI** Como principal 
>  5. E agora clique em buildar.

> [!NOTE] 
> ### Documentação do Projeto: 
> Na [PROJ-DOCS](./Projeto-DOCS.md) você encontrará toda a documentação referente a arquitetura disponivel.


#### Agradecimentos:
*Agradeço pela oportunidade de poder participar dessa etapa, pude aprender bastante coisa sobre MVVM e WPF.*

