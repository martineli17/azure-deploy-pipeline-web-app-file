# Deploy de um Azure Web App Service via arquivos e pipeline

A seguir, contém instruções para que seja feito deploy de um Web App Service, utilizando o .ZIP dos arquivos gerados e a pipeline do Azure DevOps.

## 1 - Adicionando permissões para o Azure DevOps acessar o portal Azure
#### Criando o registro de aplicativo
Aplicações terceiras que precisam realizar operações dentro do portal da Azure precisam de ter o seu acesso reconhecido e com as devidas permissões configuradas.
Para isso, é necessário registrar a aplicação terceira através do `Registro de Aplicativos (App registrations)`.
![new_app_registration](https://github.com/martineli17/azure-deploy-pipeline-web-app-file/assets/50757499/9686990e-4487-4e28-85fc-6539cc8bd327)

#### Criando o client secret
Ao salvar esse novo registro, será necessário adicionar a credencial para o Azure DevOps ter acesso ao mesmo.
Observação importante: ao salvar a nova credencial, é importante salvar o valor da chave da secret, pois ele é exibido somente no momento de criação.
![app_registration_credentials](https://github.com/martineli17/azure-deploy-pipeline-web-app-file/assets/50757499/63e7cd4e-3463-4c53-9b43-e747ead69bc7)

#### Adicionando permissões para o Azure Devops acessar a subscription
Após os passaos anteriores, é necessário adicionar as permissões necessárias para que o Azure DevOps consiga ler os dados da subscription e também realizar as operações nos recursos pertencentes a essa subscription (fazer deploy de um WebApp por exemplo).
Para isso, vamos associar, através do `Access control (IAM)`, as permissões para o `Registro de aplicativo` criando anteriormente: `azure-devops-1`
No contexto de realizar o deploy de um Web App utilizando o Azure DevOps Pipeline, será necessário duas permissões específicas:
- Microsoft.Resources/subscriptions/read
- Microsoft.Web/sites/config/list/action

![subscription_access](https://github.com/martineli17/azure-deploy-pipeline-web-app-file/assets/50757499/f7b7a824-8104-4f6d-be17-581b24282657)

## 2 - Adicionando as Conexões de Serviços no Azure

O Azure Devops contém uma sessão que é específica para definir as conexões de serviços que serão utilizadas durante o processo de execução das pipelines para permitir acesso a alguns recursos do portal e também acesso a modificação do Web App selecionado. Em alguns casos, as conexões relacionadas a Azure podem ser identificadas automaticamente através do e-mail utilizado no Azure DevOps. No entanto, para este exemplo, foi configurado manualmente uma conexão com o objetivo de simular o acesso a uma conta Azure que não esteja vinculada diretamente ao e-mail do DevOps.
![new_service_connections](https://github.com/martineli17/azure-deploy-pipeline-web-app-file/assets/50757499/53b18060-539f-4137-b244-5b8dee00419c)

- Para o campo `Service Principal Id`, será o ID do `Registro de Aplicativo`.
![image](https://github.com/martineli17/azure-deploy-pipeline-web-app-file/assets/50757499/87851b34-1651-41f3-a47a-cbc31b2ab164)

- Para o campo `Service principal key`, será o valor da chave da secret criada para o `Registro de Aplicativo` (lembrando que esse valor fica disponível somente após finalizar a criação da secret)
![image](https://github.com/martineli17/azure-deploy-pipeline-web-app-file/assets/50757499/32a85020-44e9-48d9-a76f-e4c3b12d6947)

 - Para o campo `Tenant ID`, será o ID do seu diretório. Esse ID pode ser obtido pesquisando por `Tenant properties` na barra de pesquisa.

## 3 - Usando a conexão de serviço criada no Azure DevOps Pipeline
Finalizando todos os processos acima, a conexão de serviço ficará disponível para ser utilizada nas pipelines do Azure DevOps.
No exemplo deste repositório, a conexão foi utilizada para realizar o deploy de um WebApp via código e um WebApp via container.
Para o WebApp via container, foi adicionada uma nova conexão de serviço referente ao Docker Hub.

