param app_name string
param location string
param hosting_plan_id string
param vnet_subnet_id string
param storage_account_name string
param storage_account_key_value string
param node_version string
param linux_fx_version string
@secure()
param container_registry_url string
@secure()
param container_registry_username string
@secure()
param container_registry_password string


resource functionApp 'Microsoft.Web/sites@2022-09-01' = {
  name: app_name
  location: location
  kind: 'functionapp'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: hosting_plan_id
    virtualNetworkSubnetId: vnet_subnet_id
    httpsOnly: true
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storage_account_name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${storage_account_key_value}'
        }
        {
          name: 'FUNCTIONS_EXTENSION_VERSION'
          value: '~4'
        }
        {
          name: 'WEBSITE_NODE_DEFAULT_VERSION'
          value: node_version
        }
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: 'node'
        }
        {
          name: 'DOCKER_REGISTRY_SERVER_URL'
          value: container_registry_url
        }
        {
          name: 'DOCKER_REGISTRY_SERVER_USERNAME'
          value: container_registry_username
        }
        {
          name: 'DOCKER_REGISTRY_SERVER_PASSWORD'
          value: container_registry_password
        }
        {
          name: 'WEBSITES_ENABLE_APP_SERVICE_STORAGE'
          value: 'false'
        }
      ]
      linuxFxVersion: linux_fx_version
      ftpsState: 'FtpsOnly'
      minTlsVersion: '1.2'
    }
  }
}
