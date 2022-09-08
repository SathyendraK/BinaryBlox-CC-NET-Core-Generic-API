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

    # -*- Adding {{cookiecutter.project_api_pkg_account}} Project -*-
    os.system('dotnet sln {{cookiecutter.project_dir}}.sln add {{cookiecutter.project_api_pkg_account}}/{{cookiecutter.project_api_pkg_account}}.csproj')  
    print ("Project {{cookiecutter.project_api_pkg_account}} added to solution...")  

    # -*- Adding {{cookiecutter.project_api_pkg_configuration}} Project -*-
    os.system('dotnet sln {{cookiecutter.project_dir}}.sln add {{cookiecutter.project_api_pkg_configuration}}/{{cookiecutter.project_api_pkg_configuration}}.csproj')  
    print ("Project {{cookiecutter.project_api_pkg_configuration}} added to solution...")  

    # -*- Adding {{cookiecutter.project_api_pkg}} Project -*-
    os.system('dotnet sln {{cookiecutter.project_dir}}.sln add {{cookiecutter.project_api_pkg}}/{{cookiecutter.project_api_pkg}}.csproj')
    print ("Project {{cookiecutter.project_api_pkg}} added to solution...") 

     # -*- Adding {{cookiecutter.project_spa_pkg}} Project -*-
    os.system('dotnet sln {{cookiecutter.project_dir}}.sln add {{cookiecutter.project_spa_pkg}}/{{cookiecutter.project_spa_pkg}}.csproj')
    print ("Project {{cookiecutter.project_spa_pkg}} added to solution...") 
 
    # -*- Creating .net Solution file -*-
    os.system('dotnet restore')
    print ("Restoring solution dependencies...") 

    # -*- Adding Migrations to Configuration API (Account API Migration not needed as dependencies migrated in Identity package.) -*- 
    configuration_dir = os.path.join(cur_dir,'{{cookiecutter.project_api_pkg_configuration}}') 
    os.chdir(configuration_dir)

    print ("Adding Configuration API migrations..") 

    os.system('dotnet ef migrations add InitialConfigurationApiMigration -c BxApplicationDbContext -o Migrations')
    print ("Adding Configuration BxApplicationDbContext migration added...") 

    # -*- os.system('dotnet ef database update -c BxApplicationDbContext')
    # -*- print ("Applying Configuration BxApplicationDbContext migration...") 
 
    # -*- Adding Migrations to Identity Server -*- 
    identity_dir = os.path.join(cur_dir,'{{cookiecutter.project_api_pkg_account}}') 
    os.chdir(identity_dir)
  
    # -*- Building applicaton and seeding Identity Data -*- 
    # -*- print ("Starting Account API...") 
    # -*- os.system('dotnet run --environment=development')
    
     
except OSError:
    print (bcolors.WARNING + "<<< Creation of project: {{cookiecutter.project_api_pkg|upper}} failed" % cur_dir)
else:
    print (bcolors.OKGREEN + "<<< Successfully created the project: {{cookiecutter.project_dir|upper}} [🍺 <BEER TIME> 🍺] >>>" + bcolors.ENDC)
