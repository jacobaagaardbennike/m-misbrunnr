# Enable VNET

_You need to know the subnet name for this step_

```powershell
# Production slot
az webapp vnet-integration add -g RESOURCEGROUPNAME -n APPSERVICE --vnet VNETNAME --subnet SUBNETNAME

# Test slot (Optional)
az webapp vnet-integration add -g RESOURCEGROUPNAME -n APPSERVICE --vnet VNETNAME --subnet SUBNETNAME -s test

# Dev slot (Optional)
az webapp vnet-integration add -g RESOURCEGROUPNAME -n APPSERVICE --vnet VNETNAME --subnet SUBNETNAME -s dev
```

# Private Endpoints

This will tell you how to setup the Private Endpoints on your Web or Function app in the Azure Portal.

- [ ] Go to your App or Function and click "Networking" on your production deployment slot
- [ ] Click on "Private endpoints" under "Inbound Traffic"
- [ ] Click on "Add"
- [ ] Write "pe-jab-CHANGEME" or "pe-jab-CHANGEME-test" or "pe-jab-CHANGEME-dev" in "Name", depending on what deployment slot you are on
- [ ] Select "CHANGEME_TO_VNET_NAME" in "Virtual Network"
- [ ] Select "CHANGEME_TO_SUBNET_NAME"
- [ ] Select "Yes" in "Integrate with private DNS zone"
- [ ] Click on "OK"
