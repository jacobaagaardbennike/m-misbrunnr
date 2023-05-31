- [ ] Log on [Route50](https://signin.aws.amazon.com/)
- [ ] Click on "Create Record"
- [ ] Write "asuid.jab-CHANGEME" in "Record name"
- [ ] Change "Record type" to "TXT"
- [ ] Write "CHANGEME" in "Value"
- [ ] Click on "Add another record"
- [ ] Write "asuid.jab-CHANGEME-test" in "Record name"
- [ ] Change "Record type" to "TXT"
- [ ] Write "CHANGEME" in "Value"
- [ ] Click on "Add another record"
- [ ] Write "asuid.jab-CHANGEME-dev" in "Record name"
- [ ] Change "Record type" to "TXT"
- [ ] Write "CHANGEME" in "Value"

### Custom domain certificate for Production Slot

_(This is currently required, but it can be optional if we use a wildcard certificate)_

- [ ] Click on "Add another record"
- [ ] Write "jab-CHANGEME" in "Record name"
- [ ] Change "Record type" to "CNAME"
- [ ] Write "jab-CHANGEME.azurewebsites.net" in "Value". _(This is the regular url to your App, and can be found in azure)_
      _(Currently required optional end)_
- [ ] Click on "Create records"
- [ ] Log off Route50
