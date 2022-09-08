import re
import sys
import os
import shutil

# -*- import pyodbc # Maybe use later for running DML
 

class bcolors:
    HEADER = '\033[95m'
    OKBLUE = '\033[94m'
    OKGREEN = '\033[92m'
    WARNING = '\033[93m'
    FAIL = '\033[91m'
    ENDC = '\033[0m'
    BOLD = '\033[1m'
    UNDERLINE = '\033[4m'

# -*- coding: utf-8 -*-

 
cur_dir = os.getcwd()
print ("The current working directory is %s" % cur_dir)
 

try:
    # -*- Creating .net Solution file -*-
    os.system('dotnet new sln')
    print ("Solution file created for {{cookiecutter.project_dir}} solution...") 
  
    # -*- Adding SDK Project -*-
    # -*- os.system('dotnet sln {{cookiecutter.project_dir}}.sln add BinaryBlox.SDK/BinaryBlox.SDK.csproj')
    # -*- print ("Project BinaryBlox.SDK added to solution...") 

     # -*- Adding {{cookiecutter.project_identity_pkg}} Project -*-
    # -*- os.system('dotnet sln {{cookiecutter.project_dir}}.sln add {{cookiecutter.project_identity_pkg}}/{{cookiecutter.project_identity_pkg}}.csproj')
    # -*- print ("Project {{cookiecutter.project_identity_pkg}} added to solution...") 
 
    # -*- Adding {{cookiecutter.project_api_pkg}} Project -*-
    os.system('dotnet sln {{cookiecutter.project_dir}}.sln add {{cookiecutter.project_api_pkg}}/{{cookiecutter.project_api_pkg}}.csproj')
    print ("Project {{cookiecutter.project_api_pkg}} added to solution...") 
 
 
    # -*- Creating .net Solution file -*-
    os.system('dotnet restore')
    print ("Restoring solution dependencies...") 

    generic_api_dir = os.path.join(cur_dir,'{{cookiecutter.project_api_pkg}}') 

    generate_schema = "{{cookiecutter.project_generate_schema|lower}}"
    if generate_schema == "true":  
        print ("Schema Migration Generation: Creating Microservice(s) Schema migration(s)..." )
        
        # -*- Generic API Migrations
        os.chdir(generic_api_dir) 
        os.system('dotnet ef migrations add Initial{{cookiecutter.project_api_pfx}}ApiMigration -c BxApplicationDbContext -o Migrations')
        print (bcolors.OKBLUE + "Created: {{cookiecutter.project_api_name}} Microservice migration from DbContext...") 
    else: 
        print(bcolors.WARNING + "Schema Migration Generation: Skipped....")

    deploy_schema = "{{cookiecutter.project_deploy_schema|lower}}"
    if deploy_schema == "true":  
        print ("Schema Migration Deployment: Deploying Microservice(s) Schema migration(s)..." )
        
        # -*- Generic API Migrations 
        os.chdir(generic_api_dir) 
        os.system('dotnet ef database update -c BxApplicationDbContext')
        print ("Deploying: {{cookiecutter.project_api_name}} Microservice migration from DbContext...") 
    else: 
        print(bcolors.WARNING + "Schema Migration Generation: Skipped....")
 
    launch_api = "{{cookiecutter.project_launch_api|lower}}"
    if launch_api == "true":  
  
        print (bcolors.OKBLUE + "Launch: Starting {{cookiecutter.project_api_name}} Microservice...") 
        os.system('dotnet run --environment=development')
    else: 
        print(bcolors.WARNING + "Launch: Skipped....")
    
     
except OSError:
    print (bcolors.FAIL + "<<< Creation of project: {{cookiecutter.project_api_pkg|upper}} failed" % cur_dir)
else:
    print (bcolors.OKGREEN + "<<< Successfully created the project: {{cookiecutter.project_dir|upper}} [🍺 <BEER TIME> 🍺] >>>" + bcolors.ENDC)
