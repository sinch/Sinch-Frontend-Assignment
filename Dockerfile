FROM alpine:3.14 AS base
RUN apk add --no-cache bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.14 AS api.build
WORKDIR /sinch
ADD sinch.config.mgmt /sinch
RUN dotnet publish "sinch.config.mgmt.csproj" --runtime alpine-x64 -c Release --self-contained true -o /sinch/publish

FROM base AS final
WORKDIR /app
COPY --from=api.build /sinch/publish /app
ENTRYPOINT ["/app/sinch.config.mgmt"]