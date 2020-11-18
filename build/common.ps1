# COMMON PATHS

$rootFolder = (Get-Item -Path "./" -Verbose).FullName

# List of solutions

$solutionPaths = (
    "../service/auth/AuthServer.Host",
    "../service/gateways/BackendAdminGateway.Host",
    "../service/gateways/InternalGateway.Host",
    "../service/microservices/BackendAdminService.Host"
)

$efUpdatePaths = (
    "../service/auth/AuthServer.Host",
    "../service/microservices/BackendAdminService.Host"
)