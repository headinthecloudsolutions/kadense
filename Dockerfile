ARG DOTNET_SDK_VERSION=8.0
ARG KADENSE_VERSION="0.1.0"
ARG KADENSE_VERSION_SUFFIX="-local"

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_SDK_VERSION} AS builder
ARG KADENSE_VERSION
ARG KADENSE_VERSION_SUFFIX
ARG DOTNET_SDK_VERSION
COPY ./c-sharp /src
WORKDIR /src
RUN dotnet build
RUN dotnet publish -c Release /p:Version=${KADENSE_VERSION}${KADENSE_VERSION_SUFFIX} /p:AssemblyVersion=${KADENSE_VERSION}
RUN mkdir -p /outputs/crds && \
    dotnet /src/cli/CustomResourceDefinition.Generator/src/bin/Release/net${DOTNET_SDK_VERSION}/publish/Kadense.CustomResourceDefinition.Generator.dll /outputs/crds


FROM mcr.microsoft.com/dotnet/runtime:${DOTNET_SDK_VERSION} AS jupyternetes-pods-operator
ARG DOTNET_SDK_VERSION
COPY --from=builder "/src/operators/Jupyternetes.Pods.Operator/src/bin/Release/net${DOTNET_SDK_VERSION}/publish/" "/app"
WORKDIR /app
ENTRYPOINT ["dotnet", "Kadense.Jupyternetes.Pods.Operator.dll"]
USER 999

FROM mcr.microsoft.com/dotnet/runtime:${DOTNET_SDK_VERSION} AS jupyternetes-pvcs-operator
ARG DOTNET_SDK_VERSION
COPY --from=builder "/src/operators/Jupyternetes.Pvcs.Operator/src/bin/Release/net${DOTNET_SDK_VERSION}/publish/" "/app"
WORKDIR /app
ENTRYPOINT ["dotnet", "Kadense.Jupyternetes.Pvcs.Operator.dll"]
USER 999