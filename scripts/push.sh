
# 0: scripts path 1: versuffix 2: source 3: apikey
set -e
projs=("JF.Domain")
for arg in $projs
do
    dotnet pack --version-suffix $1 -c Release -o ./src/$arg
done

dotnet nuget push **/*.nupkg -k $3 -s $2