using 'func_app_node.bicep'

//Change this
var name = 'CHANGEME'
param node_version = '~18'
param linux_fx_version = 'DOCKER|mcr.microsoft.com/azure-functions/node:4-node18'

// standard keyvault
param keyvault_resource_group_name = 'rg-CHANGEME'
param keyvault_name = 'kv-CHANGEME'

@description('The name of the function app that you wish to create.')
param app_name = name

@description('resource group name')
param resource_group_name = 'rg-${name}'

@description('Azure Location')
@allowed([
  'West Europe'
])
param location = 'West Europe'


// Service plan
@description('The App service plan resource group')
@allowed([
  'CHANGEME'
])
param service_plan_resource_group_name = 'CHANGEME'

@description('The App service plan')
@allowed([
  'CHANGEME'
])
param service_plan_name = 'CHANGEME'

// networking
@description('VNET Resource Group')
@allowed([
  'CHANGEME'
])
param vnet_resource_group_name = 'CHANGEME'

@description('VNET name')
@allowed([
  'CHANGEME'
])
param vnet_name = 'CHANGEME'


@description('SUBNET name')
param vnet_subnets_name = ['CHANGEME']


@description('Storage Account type')
@allowed([
  'Standard_LRS'
  'Standard_GRS'
  'Standard_RAGRS'
])
param storage_account_type = 'Standard_LRS'
