# How to create an Azure App

This guide describes how to create Azure Web and Function apps. This assumes you already have a resource group.

# Create The App

## If you're creating a Web App with GUI:

```powershell
# Create App and Deployment Slots
# Production
az webapp create --name jab-app-CHANGEME --resource-group rg-weu-CHANGEME --plan sp-jab-CHANGEME --deployment-container-image-name jab-app-CHANGEME

# Dev Slot
az webapp deployment slot create --name jab-app-CHANGEME --resource-group rg-weu-CHANGEME --slot dev

# Acceptance Test Slot
az webapp deployment slot create --name jab-app-CHANGEME --resource-group rg-weu-CHANGEME --slot test
```

## If you're creating a Web App as an API:

```powershell
# Create App and Deployment Slots
# Production
az webapp create --name jab-api-CHANGEME --resource-group rg-weu-CHANGEME --plan sp-jab-CHANGEME --deployment-container-image-name jab-api-CHANGEME

# Dev Slot
az webapp deployment slot create --name jab-api-CHANGEME--resource-group rg-weu-CHANGEME --slot dev

# Acceptance Test Slot
az webapp deployment slot create --name jab-api-CHANGEME--resource-group rg-weu-CHANGEME --slot test
```

## If you're creating a Function App:

```powershell
# Create storage account
az storage account create --name jab-func-CHANGEME --location westeurope --resource-group rg-weu-CHANGEME --sku Standard_LRS

# Create App and Deployment Slots
# Production
az functionapp create --name jab-func-CHANGEME --storage-account jab-func-CHANGEME --resource-group rg-weu-CHANGEME --plan sp-jab-CHANGEME --deployment-container-image-name jab-func-CHANGEME

# Dev Slot
az functionapp deployment slot create --name jab-func-CHANGEME --resource-group rg-weu-CHANGEME --slot dev

# Acceptance Test Slot
az functionapp deployment slot create --name jab-func-CHANGEME --resource-group rg-weu-CHANGEME --slot test
```

# Setup Container Registry Access for your App

- [ ] Requires an Azure AD group that is assigned the ArcPull role under Access Control (IAM) on your container registry.

## If you're creating a Web App:

```powershell
# Production slot
az webapp identity assign --resource-group rg-weu-CHANGEME --n jab-CHANGEME-CHANGEME
# Once created you get the PRINCIPALID you need for the next step
az ad group member add --group CHANGEME_TO_AZUREAD_GROUPID --member-id PRINCIPALID

# Dev Slot
az webapp identity assign --resource-group rg-weu-CHANGEME--n jab-CHANGEME-CHANGEME --slot dev
# Once created you get the PRINCIPALID you need for the next step
az ad group member add --group CHANGEME_TO_AZUREAD_GROUPID --member-id PRINCIPALID

# Acceptance Test Slot
az webapp identity assign --resource-group rg-weu-CHANGEME--n jab-CHANGEME-CHANGEME --slot test
# Once created you get the PRINCIPALID you need for the next step
az ad group member add --group CHANGEME_TO_AZUREAD_GROUPID --member-id PRINCIPALID
```

## If you're creating a Function App:

```powershell
# Production slot
az functionapp identity assign --resource-group rg-weu-CHANGEME --n jab-CHANGEME-CHANGEME
# Once created you get the PRINCIPALID you need for the next step
az ad group member add --group CHANGEME_TO_AZUREAD_GROUPID --member-id PRINCIPALID

# Dev Slot
az functionapp identity assign --resource-group rg-weu-CHANGEME--n jab-CHANGEME-CHANGEME --slot dev
# Once created you get the PRINCIPALID you need for the next step
az ad group member add --group CHANGEME_TO_AZUREAD_GROUPID --member-id PRINCIPALID

# Acceptance Test Slot
az functionapp identity assign --resource-group rg-weu-CHANGEME--n jab-CHANGEME-CHANGEME --slot test
# Once created you get the PRINCIPALID you need for the next step
az ad group member add --group CHANGEME_TO_AZUREAD_GROUPID --member-id PRINCIPALID
```
