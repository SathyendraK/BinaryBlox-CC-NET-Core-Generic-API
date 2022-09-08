# BinaryBlox {{cookiecutter.project_name}}

![version](https://img.shields.io/badge/version-v0.4.0-green)

This is a template project for boostrapping BinaryBlox Net Core Web Account API project.


## Docker
 
- [Tutorial: Creating Image](https://docs.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=linux)
- [Tutorial: Deploying Container to Azure](https://code.visualstudio.com/docs/containers/app-service)

1. [Cmd] + [Shift] + [P]: [Docker: Add Docker Files to Workspace](https://localhost) 
2. [Cmd] + [Shift] + [P]: [Docker Images: Build Image](https://code.visualstudio.com/docs/containers/app-service) 
3. Tag image: Specify the new name in LOWERCASE [(your registry or username)/(image name):(tag)](https://localhost) 
- Example: [{{cookiecutter.project_azure_registry_url}}/{{cookiecutter.project_api_name|replace(' ', '-')|lower}}:1.0.0](https://localhost)  
4. 'Push' Image to Azure Registry (BinaryBloxRegistry in this case...)


## Clean Git Repo 
```sh
rm -rf .git
````

