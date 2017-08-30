set -e

projs=("JF.Domain" "JF.Common")
for arg in $projs
do
    dotnet build -c Release ./src/$arg
done
