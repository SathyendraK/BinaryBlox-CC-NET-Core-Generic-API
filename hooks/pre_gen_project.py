
import re
import sys
import os
import shutil

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

 # -*- Installing Entity framework tools -*- 
os.system('dotnet tool uninstall -g dotnet-ef')
os.system('dotnet tool install -g dotnet-ef --version {{cookiecutter.project_target_version}}')
print ("Adding .NET Entity Framework tools version [{{cookiecutter.project_target_version}}]...") 

 
# -*- Installing InentityServer4 Templates - back to defaults->(dotnet new --debug:reinit)-*-
# -*- Ios.system('dotnet new -i identityserver4.templates')-*-
# -*- Iprint ("Adding Identity Server 4 Templates...") -*-
