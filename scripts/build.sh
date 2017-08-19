set -e

projs=("JF.Domain")
for arg in $projs
do
    dotnet build -c Release ./src/$arg
done
