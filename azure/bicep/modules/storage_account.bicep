param location string
param storage_account_type string

var storage_account_name = '${uniqueString(resourceGroup().id)}azfunctions'

resource storage_account 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: storage_account_name
  location: location
  sku: {
    name: storage_account_type
  }
  kind: 'Storage'
  properties: {
    supportsHttpsTrafficOnly: true
    defaultToOAuthAuthentication: true
  }
}

var test = storage_account.listKeys().keys[0].value

output name string = storage_account.name

output keyvalue string = test
