<h1 align="center">TaskManager - Projeto Full Stack</h1>

<p align="center">
  Aplicativo Web Full Stack com <strong>ASP.NET Core (.NET 8.0)</strong> no backend e <strong>SAPUI5</strong> no frontend.<br>
  Permite busca, visualização, atualização de tarefas e aplica regras de negócio como <em>limite de 5 tarefas incompletas por usuário</em>.<br>
  O backend inclui <strong>testes de integração com xUnit</strong>.
</p>

---

## Como Utilizar o Projeto

<details>
  <summary><strong>Frontend (SAPUI5)</strong></summary>
  <br>

  <strong>Requisitos:</strong><br>
  - <a href="https://nodejs.org">Node.js</a> instalado<br>
  - npm (vem junto com o Node.js)<br>
  - UI5 CLI instalado globalmente:<br>
  <code>npm install --global @ui5/cli</code><br>

  <strong>Passo a passo:</strong><br>
  1. Clone o repositório ou baixe o .zip<br>
  2. Abra o terminal na pasta: <code>TaskManager - Frontend/sapui5-app</code><br>
  3. Instale as dependências:<br>
  <code>npm install</code><br>
  4. Execute o projeto:<br>
  <code>ui5 serve</code><br>
  5. Acesse no navegador:<br>
  <code>http://localhost:8080/index.html</code><br>

</details>

<details>
  <summary><strong>Backend (.NET 8.0)</strong></summary>
  <br>

  <strong>Requisitos:</strong><br>
  - SDK do .NET 8.0 instalado<br>
  - Banco de dados SQL Server (ou configure outro manualmente)<br>

  <strong>Passo a passo:</strong><br>
  1. Clone o repositório ou baixe o .zip<br>
  2. Navegue até: <code>TaskManager - Backend/TaskManager.API</code><br>
  3. Restaure os pacotes NuGet:<br>
  <code>dotnet restore</code><br>
  4. Configure a connection string no arquivo:<br>
  <code>appsettings.Development.json</code><br>
  5. Execute o projeto:<br>
  <code>dotnet run</code><br>
  ou abra no Visual Studio e pressione <strong>F5</strong><br>

</details>

<details>
  <summary><strong>Integração Frontend + Backend</strong></summary>
  <br>

  - Execute o frontend com <code>ui5 serve</code><br>
  - Execute o backend com <code>dotnet run</code> ou via Visual Studio<br>
  - Configure o <code>baseURL</code> no arquivo:<br>
  <code>TaskManager - Frontend/sapui5-app/webapp/config/baseURL.js</code><br>
  - Edite a propriedade <code>baseURL</code> para o endereço onde o backend está rodando (ex: <code>https://localhost:5001</code>)<br>
  - Acesse no navegador:<br>
  <code>http://localhost:8080/index.html</code><br>

</details>

<details>
  <summary><strong>Observações Importantes</strong></summary>
  <br>

  - As funções de <strong>pesquisa</strong> e <strong>modificação de status</strong> dependem dos dados no banco local<br>
  - Antes de usar essas funções, clique no botão <strong>“Sincronizar Banco”</strong> no canto superior direito da página<br>
  - Isso importa os dados da API externa e insere no banco local<br>
  - Após esse passo, a API estará pronta para receber requisições<br>

</details>
