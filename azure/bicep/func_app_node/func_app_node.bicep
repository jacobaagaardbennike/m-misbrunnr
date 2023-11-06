param location string
param node_version string
param linux_fx_version string
param service_plan_resource_group_name string
param service_plan_name string
param app_name string
param vnet_resource_group_name string
param vnet_name string
param vnet_subnets_name string[]
param keyvault_resource_group_name string
param keyvault_name string
param storage_account_type string
param resource_group_name string

resource keyvault 'Microsoft.KeyVault/vaults@2023-07-01' existing = {
  name: keyvault_name
  scope: resourceGroup(keyvault_resource_group_name )
}

targetScope='subscription'

resource newRG 'Microsoft.Resources/resourceGroups@2022-09-01' = {
  name: resource_group_name
  location: location
}

module storage_account '../modules/storage_account.bicep' = {
  name: 'create_storage_account'
  scope: newRG
  params: {
    location: location
    storage_account_type: storage_account_type
  }
}

resource hosting_plan 'Microsoft.Web/serverfarms@2022-09-01' existing = {
  name: service_plan_name
  scope: resourceGroup(service_plan_resource_group_name)
}


resource vnet 'Microsoft.Network/virtualNetworks@2023-05-01' existing ={
  name: vnet_name
  scope: resourceGroup(vnet_resource_group_name)
}

resource vnet_subnets 'Microsoft.Network/virtualNetworks/subnets@2023-05-01' existing =  [for name in vnet_subnets_name: {
  name : name
  parent: vnet
}]

module function_app '../modules/function_app_node.bicep' = {
  name: 'deploy_function_app'
  scope: newRG
  params: {
    app_name: app_name
    node_version: node_version
    linux_fx_version: linux_fx_version
    location: location
    hosting_plan_id: hosting_plan.id
    vnet_subnet_id: vnet_subnets[0].id
    storage_account_name: storage_account.outputs.name
    storage_account_key_value: storage_account.outputs.keyvalue
    container_registry_url: keyvault.getSecret('container-registry-url')
    container_registry_username: keyvault.getSecret('container-registry-username')
    container_registry_password: keyvault.getSecret('container-registry-password')
  }
}
