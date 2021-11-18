#!/bin/bash
VERSION=$1
packFolder=$(pwd)
rootFolder="${packFolder}/"
projects=(
    "src/Taitans.Yarp.Provider.Abp"
    "src/Taitans.YarpManagement.Application"
    "src/Taitans.YarpManagement.Application.Contracts"
    "src/Taitans.YarpManagement.Domain"
    "src/Taitans.YarpManagement.Domain.Shared"
    "src/Taitans.YarpManagement.EntityFrameworkCore"
    "src/Taitans.YarpManagement.HttpApi"
    "src/Taitans.YarpManagement.HttpApi.Client" 
    "src/Taitans.YarpManagement.MongoDB"
) 
commonPropsXml="${packFolder}/common.props"
[ "$VERSION" == "latest" ] && VERSION=
[ ! -n "$VERSION" ] && VERSION=`grep -E -o -e '<Version>.+</Version>' $commonPropsXml | sed 's/<Version>//g'|sed 's/<\/Version>//g'|awk '{print $1}'`-preview`date +%Y%m%d%H%M%S`
for  project in ${projects[@]};do 
    projectFolder="${rootFolder}${project}"
    cd $projectFolder
    rm -rf "${projectFolder}/bin/Release" 

    dotnet msbuild -t:pack -p:Configuration=Release -p:SourceLinkCreate=false -p:Version=$VERSION

    if [ "$?" != 0 ] ; then
        echo "Packaging failed for the project: ${projectFolder}"
        exit $?
    fi

    # Copy nuget package
    projectName=${project##*"/"}
    projectPackPath="${projectFolder}/bin/Release/${projectName}.*.nupkg"
    echo $(ls $projectFolder/bin/Release/)
    mkdir -p $packFolder/nupkg/
    mv $projectPackPath $packFolder/nupkg/

done
