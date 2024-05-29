# Deploy de um Azure Web App Service via arquivos e pipeline

A seguir, contém instruções para que seja feito deploy de um Web App Service, utilizando o .ZIP dos arquivos gerados e a pipeline do Azure DevOps.

## 1 - Adicionando as Conexões de Serviços no Azure

O Azure Devops contém uma sessão que é específica para definir as conexões de serviços que serão utilizadas durante o processo de execução das pipelines para permitir acesso a alguns recursos do portal e também acesso a modificação do Web App selecionado. Em alguns casos, as conexões relacionadas a Azure podem ser identificadas automaticamente através do e-mail utilizado no Azure DevOps. No entanto, para este exemplo, foi configurado manualmente uma conexão com o objetivo de simular o acesso a uma conta Azure que não esteja vinculada diretamente ao e-mail do DevOps.
![new_service_connections](https://github.com/martineli17/azure-deploy-pipeline-web-app-file/assets/50757499/53b18060-539f-4137-b244-5b8dee00419c)
