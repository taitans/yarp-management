#!/bin/bash
packFolder=$(pwd)
rootFolder="${packFolder}/"
nupkgFolder="${rootFolder}/nupkg"

cd $nupkgFolder 
echo $(ls|grep .nupkg)
for dir in `ls|grep .nupkg`;do 
    #echo $dir
    dotnet nuget push $dir -s https://api.nuget.org/v3/index.json --skip-duplicate --api-key $1

done