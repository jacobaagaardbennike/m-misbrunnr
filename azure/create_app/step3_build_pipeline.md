# Setup the Build Pipeline

- [ ] Go to the DevOps board, and create a task named "Azure pipeline for ..."
- [ ] Click new branch and add a branch named "dev/pipeline"
- [ ] Check-out branch, and add an azure-pipelines.yml file to it
- [ ] Create a Pull Request from your "dev/pipeline" branch into the "main" branch, where you link the work item.

# Templates for azure-pipelines.yml:

## Normal

```YML
trigger:
  - dev/*
  - main

variables:
  CONTAINERREGISTRY: 'CHANGEME'
  REPOSITORY: 'CHANGEME'

jobs:
  - job: BuildDockerImage
    displayName: 'Build Docker Image'
    pool:
      vmImage: 'ubuntu-latest'
    steps:
      - task: Docker@2
        inputs:
          containerRegistry: '$(CONTAINERREGISTRY)'
          repository: '$(REPOSITORY)'
          command: 'buildAndPush'
          Dockerfile: '**/Dockerfile'
```

## With Entity Framework Migration

If you need Entity Framework to Migrate during deployment. This will need a custom agent with SQL tools if you're deploying to an App on a VNET with Private Endpoints where the Standard Azure Pipeline Agents can't reach.

```YML
trigger:
  - dev/*
  - main

variables:
  CONTAINERREGISTRY: "CHANGEME"
  REPOSITORY: "CHANGEME"
  PROJECTNAME: "src/CHANGEME.csproj"
  CONTEXT1: "CHANGEME"
  SCRIPT1: "CHANGEME.sql"

jobs:
  - job: BuildDockerImage
    displayName: "Build Docker Image"
    pool:
      vmImage: "ubuntu-latest"
    steps:
      - task: Docker@2
        inputs:
          containerRegistry: "$(CONTAINERREGISTRY)"
          repository: "$(REPOSITORY)"
          command: "buildAndPush"
          Dockerfile: "**/Dockerfile"
      - task: DotNetCoreCLI@2
        displayName: "Install EF tool"
        inputs:
          command: "custom"
          custom: "tool"
          arguments: "install --global dotnet-ef"
      - task: DotNetCoreCLI@2
        displayName: "Generate SQL Script for $(CONTEXT1)"
        inputs:
          command: "custom"
          custom: "ef"
          arguments: "migrations script --idempotent --project $(Build.SourcesDirectory)/$(PROJECTNAME) --output $(System.ArtifactsDirectory)/$(SCRIPT1) --context $(CONTEXT1)"
      - task: PublishBuildArtifacts@1
        displayName: "Publish Artifacts for $(CONTEXT1)"
        inputs:
          PathtoPublish: "$(System.ArtifactsDirectory)/$(SCRIPT1)"
          ArtifactName: "SQL"
          publishLocation: "Container"
```

## With Entity Framework Migration with multiple contexts

If you need Entity Framework to Migrate during deployment. This will need a custom agent with SQL tools if you're deploying to an App on a VNET with Private Endpoints where the Standard Azure Pipeline Agents can't reach.

```YML
trigger:
  - dev/*
  - main

variables:
  CONTAINERREGISTRY: "CHANGEME"
  REPOSITORY: "CHANGEME"
  PROJECTNAME: "src/CHANGEME.csproj"
  CONTEXT1: "CHANGEME"
  SCRIPT1: "CHANGEME.sql"
  CONTEXT2: "CHANGEME"
  SCRIPT2: "CHANGEME.sql"

jobs:
  - job: BuildDockerImage
    displayName: "Build Docker Image"
    pool:
      vmImage: "ubuntu-latest"
    steps:
      - task: Docker@2
        inputs:
          containerRegistry: "$(CONTAINERREGISTRY)"
          repository: "$(REPOSITORY)"
          command: "buildAndPush"
          Dockerfile: "**/Dockerfile"
      - task: DotNetCoreCLI@2
        displayName: "Install EF tool"
        inputs:
          command: "custom"
          custom: "tool"
          arguments: "install --global dotnet-ef"
      - task: DotNetCoreCLI@2
        displayName: "Generate SQL Script for $(CONTEXT1)"
        inputs:
          command: "custom"
          custom: "ef"
          arguments: "migrations script --idempotent --project $(Build.SourcesDirectory)/$(PROJECTNAME) --output $(System.ArtifactsDirectory)/$(SCRIPT1) --context $(CONTEXT1)"
      - task: PublishBuildArtifacts@1
        displayName: "Publish Artifacts for $(CONTEXT1)"
        inputs:
          PathtoPublish: "$(System.ArtifactsDirectory)/$(SCRIPT1)"
          ArtifactName: "SQL"
          publishLocation: "Container"
      - task: DotNetCoreCLI@2
        displayName: "Generate SQL Script for $(CONTEXT2)"
        inputs:
          command: "custom"
          custom: "ef"
          arguments: "migrations script --idempotent --project $(Build.SourcesDirectory)/$(PROJECTNAME) --output $(System.ArtifactsDirectory)/$(SCRIPT2) --context $(CONTEXT2)"
      - task: PublishBuildArtifacts@1
        displayName: "Publish Artifacts for $(CONTEXT2)"
        inputs:
          PathtoPublish: "$(System.ArtifactsDirectory)/$(SCRIPT2)"
          ArtifactName: "SQL"
          publishLocation: "Container"
```
