# Login and set Subscription

```powershell
az login
az account set -s "CHANGEME"
```

# Resource group

If you're making a new Azure DevOps project, you're probably going to precreate it, to allow a Service Connection on the Azure DevOps project to have rights to resource within the resource group.

```powershell
az group create --name rg-weu-jab-CHANGEME--location westeurope
```

If the app service plan is not in the same RG, find it this way:

```powershell
az appservice plan show -n SERVICEPLAN -g PLANRGGROUPNAME --query "id" --out tsv
```

# Service Plan

If you need a new service plan, you can create one like this:

```powershell
az appservice plan create --name sp-jab-CHANGEME --resource-group RESOURCEGROUPNAME --is-linux --location westeurope --sku P1V2
```
